using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Bing.AutoSuggest;
using Microsoft.Bing.AutoSuggest.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Reflection;
using Credentials;
using Xunit;


namespace SearchSDK.Tests
{
    
    public class AutoSuggestTests
    {
        private static string SubscriptionKey = "Enter subscription here";

        [Fact]
        public void AutoSuggest()
        {
            var client = new AutoSuggestClient(new ClientCredentials(SubscriptionKey));
            var resp = client.AutoSuggestMethod(query: "Satya Nadella");
            Assert.NotNull(resp);
            Assert.NotNull(resp.QueryContext);
            Assert.NotNull(resp.SuggestionGroups);
            Assert.NotNull(resp.SuggestionGroups[0]);
            var suggestions = resp.SuggestionGroups[0].SearchSuggestions;
            Assert.NotNull(suggestions);
            Assert.True(suggestions.Count == 8);
            foreach (var suggestion in suggestions)
            {
                Assert.NotNull(suggestion);
                Assert.NotEmpty(suggestion.Url);
                Assert.NotEmpty(suggestion.DisplayText);
                Assert.NotEmpty(suggestion.SearchKind);
                Assert.NotEmpty(suggestion.Query);
            }
        }
    }
}
