// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Globalization;

namespace VisualSearchQuickstart
{
    class Program
    {
        // In production, make sure you're pulling the subscription key from secured storage.

        private static string _subscriptionKey = "<YOUR SUBSCRIPTION KEY GOES HERE>";
        private static string _baseUri = "https://api.bing.microsoft.com/v7.0/images/visualsearch";

        // Each of the query parameters you may specify.

        private const string MKT_PARAMETER = "?mkt=";  // Strongly suggested
        private const string SAFE_SEARCH_PARAMETER = "&safeSearch=";

        // To page through visually similar images, you'll need the next offset that Bing returns.

        private static long _nextOffset = 0;

        // To get additional insights about the image, you'll need the image's
        // insights token (see Image Search API), URL, or binary.

        private static string _insightsToken = null;
        private static string _imageUrl = null;

        // Bing uses the X-MSEdge-ClientID header to provide users with consistent
        // behavior across Bing API calls. See the reference documentation
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
                var queryString = MKT_PARAMETER + "en-us";

                // Build the form data. This example passes an insights token from
                // an Image Search API result. It also includes the enable entity
                // flag to include entity data in the response if applicable.

                using (var postContent = new MultipartFormDataContent("boundary_" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    var visualSearchParams = new Dictionary<string, object>()
                    {
                        {"ImageInfo", new Dictionary<string, object>()
                            {
                                {"ImageInsightsToken", _insightsToken}
                            }
                        },
                        {"KnowledgeRequest", new Dictionary<string, object>()
                            {
                                {"InvokedSkillsRequestData",  new Dictionary<string, object>()
                                    {
                                        {"EnableEntityData", true}
                                    }
                                }
                            }
                        }
                    };

                    using (var jsonContent = new StringContent(JsonConvert.SerializeObject(visualSearchParams,
                        new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore })))
                    {

                        var dispositionHeader = new ContentDispositionHeaderValue("form-data");
                        dispositionHeader.Name = "knowledgeRequest";
                        jsonContent.Headers.ContentDisposition = dispositionHeader;
                        jsonContent.Headers.ContentType = null;

                        postContent.Add(jsonContent);

                        HttpResponseMessage response = await MakeRequestAsync(queryString, postContent);

                        // Get the client ID to use in the next request. See documentation for usage.

                        IEnumerable<string> values;
                        if (response.Headers.TryGetValues("X-MSEdge-ClientID", out values))
                        {
                            _clientIdHeader = values.FirstOrDefault();
                        }

                        // This example uses dictionaries instead of objects to access the response data.

                        var contentString = await response.Content.ReadAsStringAsync();
                        Dictionary<string, object> searchResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(contentString);

                        if (response.IsSuccessStatusCode)
                        {
                            PrintInsights(searchResponse);
                        }
                        else
                        {
                            PrintErrors(response.Headers, searchResponse);
                        }
                    }
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

        static async Task<HttpResponseMessage> MakeRequestAsync(string queryString, MultipartFormDataContent postContent)
        {
            var client = new HttpClient();

            // Request headers. The subscription key is the only required header but you should
            // include User-Agent (especially for mobile), X-MSEdge-ClientID, X-Search-Location
            // and X-MSEdge-ClientIP (especially for local aware queries).

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return (await client.PostAsync(_baseUri + queryString, postContent));
        }


        // Prints insights about the image.

        static void PrintInsights(Dictionary<string, object> response)
        {
            Console.WriteLine("The response contains the following insights:\n");

            var tags = response["tags"] as Newtonsoft.Json.Linq.JToken;

            foreach (Newtonsoft.Json.Linq.JToken tag in tags)
            {
                var displayName = (string)tag["displayName"];

                if (string.IsNullOrEmpty(displayName))
                {
                    // Handle default insights.

                    PrintDefaultInsights(tag);

                }
                else
                {
                    // Contains other tags related to the original search request that the 
                    // user might want to discover. Most will contain URLs to images or
                    // web search results but there are a couple that you might want to
                    // pursue: text recognition and entity.

                    Console.WriteLine("\nTag: {0}\n", (string)tag["displayName"]);
                    PrintOtherInsights(tag);
                }
            }
        }


        // Prints the image's default insights.

        static void PrintDefaultInsights(Newtonsoft.Json.Linq.JToken tag)
        {
            var actions = tag["actions"];

            foreach (Newtonsoft.Json.Linq.JToken action in actions)
            {
                if ((string)action["actionType"] == "PagesIncluding")
                {
                    Console.WriteLine("Webpages that include this image:\n");
                    DisplayPagesIncluding(action["data"]["value"]);
                }
                else if ((string)action["actionType"] == "VisualSearch")
                {
                    Console.WriteLine("Images that are visually similar to this image:\n");
                    DisplaySimilarImages(action["data"]["value"]);

                    // Capture offset if you're going to page by visually
                    // similar images.

                    //_nextOffset = (long)action["data"]["nextOffset"];
                }
                else if ((string)action["actionType"] == "ProductVisualSearch")
                {
                    Console.WriteLine("Images that have products that are visually similar to the products in this image:\n");
                    DisplaySimilarImages(action["data"]["value"]);

                    // Capture offset if you're going to page by images that have products that
                    // are visually similar to the products in this image.

                    //_nextOffset = (long)action["data"]["nextOffset"];
                }
                else if ((string)action["actionType"] == "ShoppingSources")
                {
                    Console.WriteLine("Sites where you can buy the product seen in this image:\n");
                    DisplayShoppingSources(action["data"]["offers"]);
                }
                else if ((string)action["actionType"] == "RelatedSearches")
                {
                    Console.WriteLine("Related search strings:\n");
                    DisplayRelatedSearches(action["data"]["value"]);
                }
                else
                {
                    Console.WriteLine("{0} - Not parsing\n", (string)action["actionType"]);
                }
            }
        }


        // Displays all webpages that include the image.

        static void DisplayPagesIncluding(Newtonsoft.Json.Linq.JToken pages)
        {
            foreach (Newtonsoft.Json.Linq.JToken page in pages)
            {
                Console.WriteLine("\tWebpage: " + (string)page["hostPageUrl"]);
            }

            Console.WriteLine();
        }


        // Displays images that are visually similar to the source image.

        static void DisplaySimilarImages(Newtonsoft.Json.Linq.JToken images)
        {
            foreach (Newtonsoft.Json.Linq.JToken image in images)
            {
                DisplayImage(image);
            }

            Console.WriteLine();
        }


        // Displays websites where you can buy the product seen in the image.

        static void DisplayShoppingSources(Newtonsoft.Json.Linq.JToken offers)
        {
            foreach (Newtonsoft.Json.Linq.JToken offer in offers)
            {
                Console.WriteLine("\tSeller: {0} ({1})", offer["seller"]["name"], offer["url"]);
                Console.WriteLine("\tName: " + offer["name"]);
                Console.WriteLine("\tDescription: " + offer["description"]);
                Console.WriteLine("\tPrice: {0} {1}", offer["price"], offer["priceCurrency"]);
                Console.WriteLine("\tAvailability: " + offer["availability"]);
            }

            Console.WriteLine();
        }


        // Displays a single image.

        static void DisplayImage(Newtonsoft.Json.Linq.JToken image)
        {
            Console.WriteLine("\tThumbnail: " + image["thumbnailUrl"]);
            Console.WriteLine("\tThumbnail size: {0} (w) x {1} (h) ", image["thumbnail"]["width"], image["thumbnail"]["height"]);
            Console.WriteLine("\tOriginal image: " + image["contentUrl"]);
            Console.WriteLine("\tOriginal image size: {0} (w) x {1} (h) ", image["width"], image["height"]);
            Console.WriteLine("\tHost: {0} ({1})", image["hostPageDomainFriendlyName"], image["hostPageDisplayUrl"]);
            Console.WriteLine();
        }


        // Displays all related searches.

        static void DisplayRelatedSearches(Newtonsoft.Json.Linq.JToken relatedSearches)
        {
            foreach (Newtonsoft.Json.Linq.JToken relatedSearch in relatedSearches)
            {
                Console.WriteLine("\tSearch string: {0} ({1})", (string)relatedSearch["displayText"], (string)relatedSearch["webSearchUrl"]);
            }

            Console.WriteLine();
        }

        static void PrintOtherInsights(Newtonsoft.Json.Linq.JToken tag)
        {
            var actions = tag["actions"];

            foreach (Newtonsoft.Json.Linq.JToken action in actions)
            {
                if ((string)action["actionType"] == "ImageResults")
                {
                    Console.WriteLine("\tImage search URLs:");
                    Console.WriteLine("\t\tDisplay name: " + action["displayName"]);
                    Console.WriteLine("\t\tImage API URL: " + action["serviceUrl"]);
                    Console.WriteLine("\t\tBing search URL: " + action["webSearchUrl"]);
                }
                else if ((string)action["actionType"] == "TextResults")
                {
                    Console.WriteLine("\tWeb search URLs:");
                    Console.WriteLine("\t\tDisplay name: " + action["displayName"]);
                    Console.WriteLine("\t\tWeb API URL: " + action["serviceUrl"]);
                    Console.WriteLine("\t\tBing search URL: " + action["webSearchUrl"]);
                }
                else if ((string)action["actionType"] == "Entity")
                {
                    DisplayEntity(action["data"]);
                }
                else if ((string)action["actionType"] == "TextRecognition")
                {
                    Console.WriteLine("\tRecognized text strings:\n");
                    DisplayRecognizedText(action["data"]["regions"]);
                }
                else
                {
                    Console.WriteLine("\tUnknown action type: {0}\n", (string)action["actionType"]);
                }
            }
        }

        // Displays an entity.

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

            Console.WriteLine();
        }

        // Displays an entity.

        static void DisplayRecognizedText(Newtonsoft.Json.Linq.JToken regions)
        {
            foreach (Newtonsoft.Json.Linq.JToken region in regions)
            {
                foreach (Newtonsoft.Json.Linq.JToken line in region["lines"])
                {
                    Console.WriteLine("\t\tLine: " + line["text"]);
                }
            }
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
