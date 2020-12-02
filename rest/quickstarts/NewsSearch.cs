// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewsSearchQuickstart
{
    class Program
    {
        // In production, make sure you're pulling the subscription key from secured storage.

        private static string _subscriptionKey = "<YOUR SUBSCRIPTION KEY GOES HERE>";
        private static string _baseUri = "https://api.bing.microsoft.com/v7.0/news/search";

        // Each of the query parameters you may specify.

        private const string QUERY_PARAMETER = "?q=";  // Required
        private const string MKT_PARAMETER = "&mkt=";  // Strongly suggested
        private const string COUNT_PARAMETER = "&count=";
        private const string OFFSET_PARAMETER = "&offset=";
        private const string ORIGINAL_IMG_PARAMETER = "&originalImg=";
        private const string SAFE_SEARCH_PARAMETER = "&safeSearch=";
        private const string SORT_BY_PARAMETER = "&sortBy=";
        private const string TEXT_DECORATIONS_PARAMETER = "&textDecorations=";
        private const string TEXT_FORMAT_PARAMETER = "&textFormat=";

        // Each of the filter query parameters you may specify.

        private const string FRESHNESS_PARAMETER = "&freshness=";

        // The user's search string.

        private static string _searchString = "california wildfires";

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
                // Remember to encode the q query parameter.

                var queryString = QUERY_PARAMETER + Uri.EscapeDataString(_searchString);
                queryString += MKT_PARAMETER + "en-us";

                HttpResponseMessage response = await MakeRequestAsync(queryString);

                _clientIdHeader = response.Headers.GetValues("X-MSEdge-ClientID").FirstOrDefault();

                // This example uses dictionaries instead of objects to access the response data.

                var contentString = await response.Content.ReadAsStringAsync();
                Dictionary<string, object> searchResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(contentString);

                if (response.IsSuccessStatusCode)
                {
                    PrintNews(searchResponse);
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

        // Makes the request to the Video Search endpoint.

        static async Task<HttpResponseMessage> MakeRequestAsync(string queryString)
        {
            var client = new HttpClient();

            // Request headers. The subscription key is the only required header but you should
            // include User-Agent (especially for mobile), X-MSEdge-ClientID, X-Search-Location
            // and X-MSEdge-ClientIP (especially for local aware queries).

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return (await client.GetAsync(_baseUri + queryString));
        }

        // Prints the list of news articles in the JSON response. This example prints
        // the first page of articles.

        static void PrintNews(Dictionary<string, object> response)
        {
            Newtonsoft.Json.Linq.JToken value = null;

            Console.WriteLine("The response contains the following news articles:\n");

            var articles = response["value"] as Newtonsoft.Json.Linq.JToken;

            foreach (Newtonsoft.Json.Linq.JToken article in articles)
            {
                Console.WriteLine("Title: " + article["name"]);
                Console.WriteLine("URL to article: " + article["url"]);
                Console.WriteLine("Description: " + article["description"]);
                Console.WriteLine("Publisher: " + GetPublisherString(article["provider"]));

                if ((value = article["image"]) != null)
                {
                    Console.WriteLine("Thumbnail: " + value["thumbnail"]["contentUrl"]);
                    Console.WriteLine("Thumbnail size: {0} (w) x {1} (h) ", value["thumbnail"]["width"], value["thumbnail"]["height"]);
                }

                if ((value = article["video"]) != null)
                {
                    if (value["motionThumbnailUrl"] != null)
                    {
                        Console.WriteLine("Title: " + value["name"]);
                        Console.WriteLine("Motion thumbnail: " + value["motionThumbnailUrl"]);
                        Console.WriteLine("Motion thumbnail size: {0} (w) x {1} (h) ", value["thumbnail"]["width"], value["thumbnail"]["height"]);
                    }
                }

                Console.WriteLine();
            }
        }

        // Get a printable publisher string. The article's publisher field is an array
        // of publishers. In practice, there's a single publisher, but...

        static string GetPublisherString(Newtonsoft.Json.Linq.JToken publishers)
        {
            string publisherString = "";
            Boolean isFirst = true;

            foreach (Newtonsoft.Json.Linq.JToken publisher in publishers)
            {
                if (!isFirst)
                {
                    publisherString += " | ";
                }

                publisherString += publisher["name"];
            }

            return publisherString;
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
