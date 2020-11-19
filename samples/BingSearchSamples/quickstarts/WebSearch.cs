// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebSearchQuickstart
{
    static class Program
    {
        // In production, make sure you're pulling the subscription key from secured storage.

        private static string _subscriptionKey = "<YOUR SUBSCRIPTION KEY GOES HERE>";
        private static string _baseUri = "https://api.bing.microsoft.com/v7.0/search";

        // Each of the query parameters you may specify.

        private const string QUERY_PARAMETER = "?q=";  // Required
        private const string MKT_PARAMETER = "&mkt=";  // Strongly suggested
        private const string RESPONSE_FILTER_PARAMETER = "&responseFilter=";
        private const string COUNT_PARAMETER = "&count=";
        private const string OFFSET_PARAMETER = "&offset=";
        private const string FRESHNESS_PARAMETER = "&freshness=";
        private const string SAFE_SEARCH_PARAMETER = "&safeSearch=";
        private const string TEXT_DECORATIONS_PARAMETER = "&textDecorations=";
        private const string TEXT_FORMAT_PARAMETER = "&textFormat=";
        private const string ANSWER_COUNT = "&answerCount=";
        private const string PROMOTE = "&promote=";

        // The user's search string.

        private static string searchString = "coronavirus vaccine";

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
                // Remember to encode query parameters like q, responseFilters, promote, etc.

                var queryString = QUERY_PARAMETER + Uri.EscapeDataString(searchString);
                queryString += MKT_PARAMETER + "en-us";
                //queryString += RESPONSE_FILTER_PARAMETER + Uri.EscapeDataString("webpages,news");
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
                else if ("Images" == answerType)
                {
                    if ((index = item["resultIndex"]) == null)
                    {
                        DisplayAllImages(((Newtonsoft.Json.Linq.JToken)response["images"])["value"]);
                    }
                    else
                    {
                        DisplayImage(((Newtonsoft.Json.Linq.JToken)response["images"])["value"].ElementAt((int)index));
                    }
                }
                else if ("Videos" == answerType)
                {
                    if ((index = item["resultIndex"]) == null)
                    {
                        DisplayAllVideos(((Newtonsoft.Json.Linq.JToken)response["videos"])["value"]);
                    }
                    else
                    {
                        DisplayVideo(((Newtonsoft.Json.Linq.JToken)response["videos"])["value"].ElementAt((int)index));
                    }
                }
                else if ("News" == answerType)
                {
                    if ((index = item["resultIndex"]) == null)
                    {
                        DisplayAllNews(((Newtonsoft.Json.Linq.JToken)response["news"])["value"]);
                    }
                    else
                    {
                        DisplayArticle(((Newtonsoft.Json.Linq.JToken)response["news"])["value"].ElementAt((int)index));
                    }
                }
                else if ("RelatedSearches" == answerType)
                {
                    if ((index = item["resultIndex"]) == null)
                    {
                        DisplayAllRelatedSearches(((Newtonsoft.Json.Linq.JToken)response["relatedSearches"])["value"]);
                    }
                    else
                    {
                        DisplayRelatedSearch(((Newtonsoft.Json.Linq.JToken)response["relatedSearches"])["value"].ElementAt((int)index));
                    }
                }
                else if ("Entities" == answerType)
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
                else if ("Computation" == answerType)
                {
                    DisplayComputation((Newtonsoft.Json.Linq.JToken)response["computation"]);
                }
                else if ("Translations" == answerType)
                {
                    DisplayTranslations((Newtonsoft.Json.Linq.JToken)response["translations"]);
                }
                else if ("TimeZone" == answerType)
                {
                    DisplayTimeZone((Newtonsoft.Json.Linq.JToken)response["timeZone"]);
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
            string rule = null;

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

            if (null != rulesByField)
            {
                if (rulesByField.TryGetValue("snippet", out rule))
                {
                    Console.WriteLine("\t\t\tData from: " + rulesByField["snippet"]);
                }
            }

            Console.WriteLine();

        }

        // Displays all images in the Images answer.

        static void DisplayAllImages(Newtonsoft.Json.Linq.JToken images)
        {
            foreach (Newtonsoft.Json.Linq.JToken image in images)
            {
                DisplayImage(image);
            }
        }

        // Displays a single image.

        static void DisplayImage(Newtonsoft.Json.Linq.JToken image)
        {
            Console.WriteLine("\tImage\n");
            Console.WriteLine("\t\tThumbnail: " + image["thumbnailUrl"]);
            Console.WriteLine();
        }

        // Displays all videos in the Videos answer.

        static void DisplayAllVideos(Newtonsoft.Json.Linq.JToken videos)
        {
            foreach (Newtonsoft.Json.Linq.JToken video in videos)
            {
                DisplayVideo(video);
            }
        }

        // Displays a single video.

        static void DisplayVideo(Newtonsoft.Json.Linq.JToken video)
        {
            Console.WriteLine("\tVideo\n");
            Console.WriteLine("\t\tEmbed HTML: " + video["embedHtml"]);
            Console.WriteLine();
        }

        // Displays all news articles in the News answer.

        static void DisplayAllNews(Newtonsoft.Json.Linq.JToken news)
        {
            foreach (Newtonsoft.Json.Linq.JToken article in news)
            {
                DisplayArticle(article);
            }
        }

        // Displays a single news article.

        static void DisplayArticle(Newtonsoft.Json.Linq.JToken article)
        {
            // News articles require attribution. Gets the list of attributions to apply.

            Dictionary<string, string> rulesByField = null;
            rulesByField = GetRulesByField(article["contractualRules"]);

            Console.WriteLine("\tArticle\n");
            Console.WriteLine("\t\tName: " + article["name"]);
            Console.WriteLine("\t\tURL: " + article["url"]);
            Console.WriteLine("\t\tDescription: " + article["description"]);
            Console.WriteLine("\t\tArticle from: " + rulesByField["global"]);
            Console.WriteLine();
        }

        // Displays all related search in the RelatedSearches answer.

        static void DisplayAllRelatedSearches(Newtonsoft.Json.Linq.JToken searches)
        {
            foreach (Newtonsoft.Json.Linq.JToken search in searches)
            {
                DisplayRelatedSearch(search);
            }
        }

        // Displays a single related search query.

        static void DisplayRelatedSearch(Newtonsoft.Json.Linq.JToken search)
        {
            Console.WriteLine("\tRelatedSearch\n");
            Console.WriteLine("\t\tName: " + search["displayText"]);
            Console.WriteLine("\t\tURL: " + search["webSearchUrl"]);
            Console.WriteLine();
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

        // Displays the Computation answer.

        static void DisplayComputation(Newtonsoft.Json.Linq.JToken expression)
        {
            Console.WriteLine("\tComputation\n");
            Console.WriteLine("\t\t{0} is {1}", expression["expression"], expression["value"]);
            Console.WriteLine();
        }

        // Displays the Translation answer.

        static void DisplayTranslations(Newtonsoft.Json.Linq.JToken translation)
        {
            // Some webpages require attribution. Checks if this page requires
            // attribution and gets the list of attributions to apply.

            Dictionary<string, string> rulesByField = null;
            rulesByField = GetRulesByField(translation["contractualRules"]);

            // The translatedLanguageName field contains a 2-character language code,
            // so you might want to provide the means to print Spanish instead of es.

            Console.WriteLine("\tTranslation\n");
            Console.WriteLine("\t\t\"{0}\" translates to \"{1}\" in {2}", translation["originalText"], translation["translatedText"], translation["translatedLanguageName"]);
            Console.WriteLine("\t\tTranslation by " + rulesByField["global"]);
            Console.WriteLine();
        }

        // Displays the TimeZone answer. This answer has multiple formats, so you need to figure
        // out which fields exist in order to format the answer.

        static void DisplayTimeZone(Newtonsoft.Json.Linq.JToken timeZone)
        {
            Console.WriteLine("\tTime zone\n");

            if (timeZone["primaryCityTime"] != null)
            {
                var time = DateTime.Parse((string)timeZone["primaryCityTime"]["time"]);
                Console.WriteLine("\t\tThe time in {0} is {1}:", timeZone["primaryCityTime"]["location"], time);

                if (timeZone["otherCityTimes"] != null)
                {
                    Console.WriteLine("\t\tThere are {0} other time zones", timeZone["otherCityTimes"].Count());
                }
            }

            if (timeZone["date"] != null)
            {
                Console.WriteLine("\t\t" + timeZone["date"]);
            }

            if (timeZone["primaryResponse"] != null)
            {
                Console.WriteLine("\t\t" + timeZone["primaryResponse"]);
            }

            if (timeZone["timeZoneDifference"] != null)
            {
                Console.WriteLine("\t\t{0} {1}", timeZone["description"], timeZone["timeZoneDifference"]["text"]);
            }

            if (timeZone["primaryTimeZone"] != null)
            {
                Console.WriteLine("\t\t" + timeZone["primaryTimeZone"]["timeZoneName"]);
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

                if ((key = (string) rule["targetPropertyName"]) != null)
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


