using Microsoft.Bing.CustomSearch;
using Microsoft.Bing.CustomSearch.Models;
using System.Linq;
using Xunit;
using Credentials;
using System.Net.Http;

namespace SearchSDK.Tests
{
    public class CustomSearchTests
    {
        private static string SubscriptionKey = "Enter subscription here";

        [Fact]
        public void CustomSearch()
        {

            var client = new CustomSearchClient(new ClientCredentials(SubscriptionKey));
            var resp = client.CustomInstance.SearchWithHttpMessagesAsync(query: "tom cruise", customConfig: "0").Result;

            Assert.NotNull(resp);
            Assert.NotNull(resp.Body.WebPages);
            Assert.NotNull(resp.Body.WebPages.WebSearchUrl);

            Assert.NotNull(resp.Body.WebPages.Value);
            Assert.NotNull(resp.Body.WebPages.Value[0].DisplayUrl);
            
        }
    }
}
