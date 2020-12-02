namespace bing_search_dotnet.Samples
{
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.Bing.CustomSearch;
    using Microsoft.Bing.CustomSearch.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using System.Collections;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Credentials;

    [SampleCollection("CustomSearch")]
    public class CustomSearchSamples
    {
        [Example("This will look up a single query (Xbox) and print out name and url for first web result")]
        public static void CustomSearchWebPageResultLookup(string subscriptionKey, string customConfig)
        {
            var client = new CustomSearchClient(new ClientCredentials(subscriptionKey));
            
            try
            {
                var webData = client.CustomInstance.SearchWithHttpMessagesAsync(query: "Xbox", customConfig: customConfig).Result;
                Console.WriteLine("Searched for Query# \" Xbox \"");

                //WebPages
                if (webData?.Body.WebPages?.Value?.Count > 0)
                {
                    // find the first web page
                    var firstWebPagesResult = webData.Body.WebPages.Value.FirstOrDefault();

                    if (firstWebPagesResult != null)
                    {
                        Console.WriteLine("Webpage Results#{0}", webData.Body.WebPages.Value.Count);
                        Console.WriteLine("First web page name: {0} ", firstWebPagesResult.Name);
                        Console.WriteLine("First web page URL: {0} ", firstWebPagesResult.Url);
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find web results!");
                    }
                }
                else
                {
                    Console.WriteLine("Didn't see any Web data..");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encountered exception. " + ex.Message);
            }
            
        }
    }
}