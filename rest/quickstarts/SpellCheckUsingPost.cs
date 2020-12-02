// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpellCheckQuickstart
{
    class Program
    {
        // In production, make sure you're pulling the subscription key from secured storage.

        private static string _subscriptionKey = "<YOUR SUBSCRIPTION KEY GOES HERE>";
        private static string _baseUri = "https://api.bing.microsoft.com/v7.0/spellcheck";

        // The query parameters you're most likely to use.

        private const string TEXT_PARAMETER = "text=";  // Required
        private const string MKT_PARAMETER = "&mkt=";    // Strongly suggested
        private const string MODE_PARAMETER = "&mode=";  // proof (default), spell

        // The text to spell check.

        private static string _spellCheckString = "when its your turn turn, john, come runing";


        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            try
            {
                // Remember to encode the q query parameter.

                var queryString = TEXT_PARAMETER + Uri.EscapeDataString(_spellCheckString);
                queryString += MODE_PARAMETER + "proof"; // "spell";
                queryString += MKT_PARAMETER + "en-us";

                HttpResponseMessage response = await MakeRequestAsync(queryString);

                // This example uses dictionaries instead of objects to access the response data.

                var contentString = await response.Content.ReadAsStringAsync();
                Dictionary<string, object> searchResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(contentString);

                if (response.IsSuccessStatusCode)
                {
                    PrintSpellCheckResults(searchResponse);
                }
                else
                {
                    PrintErrors(response.Headers, searchResponse);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();
        }

        // Makes the request to the Spell Check endpoint.

        static async Task<HttpResponseMessage> MakeRequestAsync(string queryString)
        {
            var client = new HttpClient();

            // Request headers. The subscription key is the only required header but you should
            // include User-Agent (especially for mobile), X-MSEdge-ClientID, X-Search-Location
            // and X-MSEdge-ClientIP (especially for local aware queries).

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            var postContent = new StringContent(queryString, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");

            return (await client.PostAsync(_baseUri, postContent));
        }

        // Prints the list of spelling issues and the corrected string.

        static void PrintSpellCheckResults(Dictionary<string, object> response)
        {
            string updatedTextString = _spellCheckString;
            int adjustOffset = 0;
            int tokenLength = 0;
            bool isRemoveTokenCase = false;

            Console.WriteLine("The response contains the following spelling issues:\n");

            var tokens = response["flaggedTokens"] as Newtonsoft.Json.Linq.JToken;

            foreach (Newtonsoft.Json.Linq.JToken token in tokens)
            {
                Console.WriteLine("Word: " + token["token"]);
                Console.WriteLine("Suggestion: " + token["suggestions"][0]["suggestion"]);
                Console.WriteLine("Offset: " + token["offset"]);
                Console.WriteLine();

                tokenLength = ((string)token["token"]).Length;

                // Repeat token case

                if ((string)(token["suggestions"][0]["suggestion"]) == string.Empty)
                {
                    isRemoveTokenCase = true;
                    adjustOffset--;
                    tokenLength++;
                }

                updatedTextString = updatedTextString.Remove((int)token["offset"] + adjustOffset, tokenLength);

                if (!isRemoveTokenCase)
                {
                    updatedTextString = updatedTextString.Insert((int)token["offset"] + adjustOffset, (string)token["suggestions"][0]["suggestion"]);
                }
                else
                {
                    isRemoveTokenCase = false;
                    adjustOffset++;
                }

                // The token offset value is the offset into the original string but
                // we need the offset into the updated text string after applying the
                // changes.

                adjustOffset += ((string)token["suggestions"][0]["suggestion"]).Length - tokenLength;
            }

            Console.WriteLine("Original text: " + _spellCheckString);
            Console.WriteLine("Updated text: " + updatedTextString);
        }


        // Print any errors that occur. Depending on which part of the service is
        // throwing the error, the response may contain different formats.

        static void PrintErrors(HttpResponseHeaders headers, Dictionary<String, object> response)
        {
            Console.WriteLine("The response contains the following errors:\n");

            object value;

            if (response.TryGetValue("error", out value))  // typically 401, 403
            {
                PrintError(response["error"] as Newtonsoft.Json.Linq.JToken);
            }
            else if (response.TryGetValue("errors", out value))
            {
                // Bing API error

                foreach (Newtonsoft.Json.Linq.JToken error in response["errors"] as Newtonsoft.Json.Linq.JToken)
                {
                    PrintError(error);
                }

                // Included only when HTTP status code is 400; not included with 401 or 403.

                IEnumerable<string> headerValues;
                if (headers.TryGetValues("BingAPIs-TraceId", out headerValues))
                {
                    Console.WriteLine("\nTrace ID: " + headerValues.FirstOrDefault());
                }
            }

        }

        static void PrintError(Newtonsoft.Json.Linq.JToken error)
        {
            string value = null;

            Console.WriteLine("Code: " + error["code"]);
            Console.WriteLine("Message: " + error["message"]);

            if ((value = (string)error["parameter"]) != null)
            {
                Console.WriteLine("Parameter: " + value);
            }

            if ((value = (string)error["value"]) != null)
            {
                Console.WriteLine("Value: " + value);
            }
        }
    }
}
