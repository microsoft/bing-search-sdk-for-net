// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EntitiesQuickstart
{
    static class Program
    {
        // In production, make sure you're pulling the subscription key from secured storage.

        private static string _subscriptionKey = "<YOUR SUBSCRIPTION KEY GOES HERE>";
        private static string _baseUri = "https://api.bing.microsoft.com/v7.0/entities";

        // Each of the query parameters you may specify.

        private const string QUERY_PARAMETER = "?q=";  // Required
        private const string MKT_PARAMETER = "&mkt=";  // Strongly suggested
        private const string RESPONSE_FILTER_PARAMETER = "&responseFilter=";
        private const string SAFE_SEARCH_PARAMETER = "&safeSearch=";

        // The user's search string.

        private static string searchString = "bill gates";

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
                // Remember to encode the query parameter.

                var queryString = QUERY_PARAMETER + Uri.EscapeDataString(searchString);
                queryString += MKT_PARAMETER + "en-us";
                //queryString += RESPONSE_FILTER_PARAMETER + Uri.EscapeDataString("places");

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

                if ("Entities" == answerType)
                {
                    if ((index = item["resultIndex"]) == null)
                    {
                        DisplayAllEntities(((Newtonsoft.Json.Linq.JToken)response["entities"])["value"]);
                    }
                    else
                    {
                        DisplayEntity(((Newtonsoft.Json.Linq.JToken)response["entities"])["value"].ElementAt((int)index));
                    }
                }
                else if ("Places" == answerType)
                {
                    if ((index = item["resultIndex"]) == null)
                    {
                        DisplayAllPlaces(((Newtonsoft.Json.Linq.JToken)response["places"])["value"]);
                    }
                    else
                    {
                        DisplayPlace(((Newtonsoft.Json.Linq.JToken)response["places"])["value"].ElementAt((int)index));
                    }
                }
                else
                {
                    Console.WriteLine("\nUnknown answer type: {0}\n", answerType);
                }
            }
        }


        // Displays all entities in the Entities answer.

        static void DisplayAllEntities(Newtonsoft.Json.Linq.JToken entities)
        {
            foreach (Newtonsoft.Json.Linq.JToken entity in entities)
            {
                DisplayEntity(entity);
            }
        }

        // Displays a single entity.

        static void DisplayEntity(Newtonsoft.Json.Linq.JToken entity)
        {
            string rule = null;

            // Entities require attribution. Gets the list of attributions to apply.

            Dictionary<string, string> rulesByField = null;
            rulesByField = GetRulesByField(entity["contractualRules"]);

            Console.WriteLine("\tEntity\n");
            Console.WriteLine("\t\tName: " + entity["name"]);

            if (entity["image"] != null)
            {
                Console.WriteLine("\t\tImage: " + entity["image"]["thumbnailUrl"]);

                if (rulesByField.TryGetValue("image", out rule))
                {
                    Console.WriteLine("\t\t\tImage from: " + rule);
                }
            }

            if (entity["description"] != null)
            {
                Console.WriteLine("\t\tDescription: " + entity["description"]);

                if (rulesByField.TryGetValue("description", out rule))
                {
                    Console.WriteLine("\t\t\tData from: " + rulesByField["description"]);
                }
            }
            else
            {
                // See if presentation info can shed light on what this entity is.

                var hintCount = entity["entityPresentationInfo"]["entityTypeHints"].Count();
                Console.WriteLine("\t\tEntity hint: " + entity["entityPresentationInfo"]["entityTypeHints"][hintCount - 1]);
            }

            Console.WriteLine();
        }

        // Displays all places in the Places answer.

        static void DisplayAllPlaces(Newtonsoft.Json.Linq.JToken places)
        {
            foreach (Newtonsoft.Json.Linq.JToken place in places)
            {
                DisplayPlace(place);
            }
        }

        // Displays a single place.

        static void DisplayPlace(Newtonsoft.Json.Linq.JToken place)
        {
            Console.WriteLine("\tPlace\n");
            Console.WriteLine("\t\tName: " + place["name"]);
            Console.WriteLine("\t\tPhone: " + place["telephone"]);
            Console.WriteLine("\t\tWebsite: " + place["url"]);
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


