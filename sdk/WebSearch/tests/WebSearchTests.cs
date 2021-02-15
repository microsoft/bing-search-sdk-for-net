using Microsoft.Bing.WebSearch;
using Microsoft.Bing.WebSearch.Models;
using System.Linq;
using Xunit;

namespace SearchSDK.Tests
{
    public class WebSearchTests
    {
        private static string SubscriptionKey = "Enter subscription here";

        [Fact]
        public void WebSearch()
        {

            var client = new WebSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey));

            var resp = client.Web.SearchAsync(query: "tom cruise").Result;

            Assert.NotNull(resp);
            Assert.NotNull(resp.WebPages);
            Assert.NotNull(resp.WebPages.WebSearchUrl);

            Assert.NotNull(resp.WebPages.Value);
            Assert.NotNull(resp.WebPages.Value[0].DisplayUrl);

            Assert.NotNull(resp.Images);
            Assert.NotNull(resp.Images.Value);
            Assert.NotNull(resp.Images.Value[0].HostPageUrl);
            Assert.NotNull(resp.Images.Value[0].WebSearchUrl);
            Assert.NotNull(resp.Videos);
            Assert.NotNull(resp.News);
            
        }
    }
}
