// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebCustomSearchQuickstart
{
    static class Program
    {
        // In production, make sure you're pulling the subscription key from secured storage.

        private static string _subscriptionKey = "<YOUR SUBSCRIPTION KEY GOES HERE>";
        private static string _baseUri = "https://api.bing.microsoft.com/v7.0/custom/search";
        private static string _customConfigId = "<YOUR INSTANCE CONFIGURATION ID GOES HERE>";

        // Each of the query parameters you may specify.

        private const string QUERY_PARAMETER = "?q=";  // Required
        private const string CUSTOM_CONFIG_PARAMETER = "&customConfig=";  // Required
        private const string MKT_PARAMETER = "&mkt=";  // Strongly suggested
        private const string COUNT_PARAMETER = "&count=";
        private const string OFFSET_PARAMETER = "&offset=";
        private const string SAFE_SEARCH_PARAMETER = "&safeSearch=";
        private const string TEXT_DECORATIONS_PARAMETER = "&textDecorations=";
        private const string TEXT_FORMAT_PARAMETER = "&textFormat=";

        // The user's search string.

        private static string searchString = "surface book 3";

        // Bing uses the X-MSEdge-ClientID header to provide users with consistent
        // behavior across Bing API calls. See the the reference documentation
        // fo usage.

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
                queryString += CUSTOM_CONFIG_PARAMETER + _customConfigId;
                queryString += MKT_PARAMETER + "en-us";
                queryString += TEXT_DECORATIONS_PARAMETER + Boolean.TrueString;

                HttpResponseMessage response = await MakeRequestAsync(queryString);

                _clientIdHeader = response.Headers.GetValues("X-MSEdge-ClientID").FirstOrDefault();

                // This example uses dictionaries instead of objects to access the response data.

                var contentString = await response.Content.ReadAsStringAsync();
                Dictionary<string, object> searchResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(contentString);

                if (response.IsSuccessStatusCode)
                {
                    PrintResponse(searchResponse);
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

        // Makes the request to the Web Search endpoint.
        static async Task<HttpResponseMessage> MakeRequestAsync(string queryString)
        {
            var client = new HttpClient();

            // Request headers. The subscription key is the only required header but you should
            // include User-Agent (especially for mobile), X-MSEdge-ClientID, X-Search-Location
            // and X-MSEdge-ClientIP (especially for local aware queries).

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return (await client.GetAsync(_baseUri + queryString));
        }

        // Prints the JSON response data for pole, mainline, and sidebar.
        static void PrintResponse(Dictionary<string, object> response)
        {
            Console.WriteLine("The response contains the following answers:\n");

            var ranking = response["rankingResponse"] as Newtonsoft.Json.Linq.JToken;

            Newtonsoft.Json.Linq.JToken position;

            if ((position = ranking["pole"]) != null)
            {
                Console.WriteLine("Pole Position:\n");
                DisplayAnswersByRank(position["items"], response);
            }

            if ((position = ranking["mainline"]) != null)
            {
                Console.WriteLine("Mainline Position:\n");
                DisplayAnswersByRank(position["items"], response);
            }

            if ((position = ranking["sidebar"]) != null)
            {
                Console.WriteLine("Sidebar Position:\n");
                DisplayAnswersByRank(position["items"], response);
            }
        }


        // Displays each result based on ranking. Ranking contains the results for
        // the pole, mainline, or sidebar section of the search results.

        static void DisplayAnswersByRank(Newtonsoft.Json.Linq.JToken items, Dictionary<string, object> response)
        {
            foreach (Newtonsoft.Json.Linq.JToken item in items)
            {
                var answerType = (string)item["answerType"];
                Newtonsoft.Json.Linq.JToken index = -1;

                // If the ranking item doesn't include an index of the result to  
                // display, then display all the results for that answer.

                if ("WebPages" == answerType)
                {
                    if ((index = item["resultIndex"]) == null)
                    {
                        DisplayAllWebPages(((Newtonsoft.Json.Linq.JToken)response["webPages"])["value"]);
                    }
                    else
                    {
                        DisplayWegPage(((Newtonsoft.Json.Linq.JToken)response["webPages"])["value"].ElementAt((int)index));
                    }
                }
                else
                {
                    Console.WriteLine("\nUnknown answer type: {0}\n", answerType);
                }
            }
        }

        // Displays all webpages in the Webpages answer.
        static void DisplayAllWebPages(Newtonsoft.Json.Linq.JToken webpages)
        {
            foreach (Newtonsoft.Json.Linq.JToken webpage in webpages)
            {
                DisplayWegPage(webpage);
            }
        }

        // Displays a single webpage.
        static void DisplayWegPage(Newtonsoft.Json.Linq.JToken webpage)
        {
            // Some webpages require attribution. Checks if this page requires
            // attribution and gets the list of attributions to apply.

            Dictionary<string, string> rulesByField = null;
            rulesByField = GetRulesByField(webpage["contractualRules"]);

            Console.WriteLine("\tWebpage\n");
            Console.WriteLine("\t\tName: " + webpage["name"]);
            Console.WriteLine("\t\tUrl: " + webpage["url"]);
            Console.WriteLine("\t\tDisplayUrl: " + webpage["displayUrl"]);
            Console.WriteLine("\t\tSnippet: " + webpage["snippet"]);

            // Apply attributions if they exist.

            if (null != rulesByField && null != rulesByField["snippet"])
            {
                Console.WriteLine("\t\t\tData from: " + rulesByField["snippet"]);
            }

            Console.WriteLine();

        }

        // Checks if the result includes contractual rules and builds a dictionary of 
        // the rules. 
        static Dictionary<string, string> GetRulesByField(Newtonsoft.Json.Linq.JToken contractualRules)
        {
            if (null == contractualRules)
            {
                return null;
            }

            var rules = new Dictionary<string, string>();

            foreach (Newtonsoft.Json.Linq.JToken rule in contractualRules as Newtonsoft.Json.Linq.JToken)
            {
                // Use the rule's type as the key.

                string key = null;
                string value = null;
                var index = ((string)rule["_type"]).LastIndexOf('/');
                var ruleType = ((string)rule["_type"]).Substring(index + 1);
                string attribution = null;

                if (ruleType == "LicenseAttribution")
                {
                    attribution = (string)rule["licenseNotice"];
                }
                else if (ruleType == "LinkAttribution")
                {
                    attribution = string.Format("{0}({1})", (string)rule["text"], (string)rule["url"]);
                }
                else if (ruleType == "MediaAttribution")
                {
                    attribution = (string)rule["url"];
                }
                else if (ruleType == "TextAttribution")
                {
                    attribution = (string)rule["text"];
                }

                // If the rule targets specific data in the result; for example, the
                // snippet field, use the target's name as the key. Multiple rules
                // can apply to the same field. 

                if ((key = (string)rule["targetPropertyName"]) != null)
                {
                    if (rules.TryGetValue(key, out value))
                    {
                        rules[key] = value + " | " + attribution;
                    }
                    else
                    {
                        rules.Add(key, attribution);
                    }
                }
                else
                {
                    // Otherwise, the rule applies to the result. Uses 'global' as the key
                    // value for this case.

                    key = "global";

                    if (rules.TryGetValue(key, out value))
                    {
                        rules[key] = value + " | " + attribution;
                    }
                    else
                    {
                        rules.Add(key, attribution);
                    }
                }
            }

            return rules;
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


