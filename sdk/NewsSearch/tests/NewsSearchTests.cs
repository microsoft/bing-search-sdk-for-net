using Microsoft.Bing.NewsSearch;
using Microsoft.Bing.NewsSearch.Models;
using System.Linq;
using Xunit;

namespace SearchSDK.Tests
{
    public class NewsSearchTests
    {
        private static string SubscriptionKey = "Enter subscription here";

        [Fact]
        public void NewsSearch()
        {

            var client = new NewsSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey));

            var resp = client.News.SearchAsync(query: "tom cruise").Result;

            Assert.NotNull(resp);
            Assert.NotNull(resp.Value);
            Assert.True(resp.Value.Count > 0);

            var news = resp.Value[0];
            Assert.NotNull(news.Name);
            Assert.NotNull(news.Url);
            Assert.NotNull(news.Description);
            Assert.NotNull(news.DatePublished);
            Assert.NotNull(news.Provider);
            Assert.NotNull(news.Provider[0].Name);
            
        }

        [Fact]
        public void NewsCategory()
        {


            var client = new NewsSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey));

            var resp = client.News.CategoryAsync(category: "sports").Result;

            Assert.NotNull(resp);
            Assert.NotNull(resp.Value);
            Assert.True(resp.Value.Count > 0);

            var news = resp.Value[0];
            Assert.NotNull(news.Name);
            Assert.NotNull(news.Url);
            Assert.NotNull(news.Description);
            Assert.NotNull(news.DatePublished);
            Assert.NotNull(news.Provider);
            Assert.NotNull(news.Category);
            Assert.NotNull(news.Provider[0].Name);
            
        }

        [Fact]
        public void NewsTrending()
        {

            var client = new NewsSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey));
            var resp = client.News.TrendingAsync().Result;

            Assert.NotNull(resp);
            Assert.NotNull(resp.Value);
            Assert.True(resp.Value.Count > 0);

            var trendingTopic = resp.Value[0];
            Assert.NotNull(trendingTopic.Name);
            Assert.NotNull(trendingTopic.WebSearchUrl);
            Assert.NotNull(trendingTopic.NewsSearchUrl);
            Assert.NotNull(trendingTopic.Image);
            Assert.NotNull(trendingTopic.Image.Url);
            Assert.NotNull(trendingTopic.Query);
            Assert.NotNull(trendingTopic.Query.Text);
        }
   
    }
}
