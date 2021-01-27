using Microsoft.Bing.CustomImageSearch;
using Microsoft.Bing.CustomImageSearch.Models;
using System.Linq;
using Xunit;
using Credentials;
using System.Net.Http;

namespace SearchSDK.Tests
{
    public class CustomImageSearchTests
    {
        private static string SubscriptionKey = "Enter subscription here";

        [Fact]
        public void CustomImageSearch()
        {
                
            var client = new CustomImageSearchClient(new ClientCredentials(SubscriptionKey));
            var resp = client.CustomInstance.ImageSearchAsync(query: "Xbox", customConfig: "0").Result;

            Assert.NotNull(resp);
            Assert.NotNull(resp.Value);
            Assert.NotNull(resp.ReadLink);
            Assert.NotNull(resp.Value[0]);

            Assert.NotNull(resp.Value[0].Thumbnail);
            Assert.NotNull(resp.Value[0].ThumbnailUrl);
            Assert.NotNull(resp.Value[0].ContentUrl);
        }
    }
}
