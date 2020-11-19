// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebSearchQuickstart2
{
    static class Program
    {
        // In production, make sure you're pulling the subscription key from secured storage.

        private static string _subscriptionKey = "<YOUR SUBSCRIPTION KEY GOES HERE>";
        private static string _baseUri = "https://api.bing.microsoft.com/v7.0/suggestions";

        // Each of the query parameters you may specify.

        private const string QUERY_PARAMETER = "?q=";  // Required
        private const string MKT_PARAMETER = "&mkt=";  // Strongly suggested

        // The user's search string.

        private static string searchString = "coro";

        // Bing uses the X-MSEdge-ClientID header to provide users with consistent
        // behavior across Bing API calls. See the the reference documentation
        // for usage.

        private static string _clientIdHeader = null;


        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            try
            {
                // Remember to encode the q query parameter.

                var queryString = QUERY_PARAMETER + Uri.EscapeDataString(searchString);
                queryString += MKT_PARAMETER + "en-us";

                HttpResponseMessage response = await MakeRequestAsync(queryString);

                _clientIdHeader = response.Headers.GetValues("X-MSEdge-ClientID").FirstOrDefault();

                // This example uses dictionaries instead of objects to access the response data.

                var contentString = await response.Content.ReadAsStringAsync();
                Dictionary<string, object> searchResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(contentString);

                if (response.IsSuccessStatusCode)
                {
                    PrintSuggestions(searchResponse);
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

        // Makes the request to the Autosuggest endpoint.

        static async Task<HttpResponseMessage> MakeRequestAsync(string queryString)
        {
            var client = new HttpClient();

            // Request headers. The subscription key is the only required header but you should
            // include User-Agent (especially for mobile), X-MSEdge-ClientID, X-Search-Location
            // and X-MSEdge-ClientIP (especially for local aware queries).

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return (await client.GetAsync(_baseUri + queryString));
        }

        // Prints the list of search string suggestions from the JSON response.

        static void PrintSuggestions(Dictionary<string, object> response)
        {
            Console.WriteLine("The response contains the following search string suggestions:\n");

            var groups = response["suggestionGroups"] as Newtonsoft.Json.Linq.JToken;

            foreach (Newtonsoft.Json.Linq.JToken group in groups)
            {
                if ((string)group["name"] == "Web")
                {
                    foreach (Newtonsoft.Json.Linq.JToken suggestion in group["searchSuggestions"])
                    {
                        Console.WriteLine("Suggestion: {0} ({1})", suggestion["displayText"], suggestion["url"]);

                        // Use the suggestion in the query field if you want to call Web Search API and
                        // display the results yourself.
                    }
                }
            }
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


