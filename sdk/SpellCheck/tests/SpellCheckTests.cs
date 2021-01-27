using Microsoft.Bing.SpellCheck;
using Microsoft.Bing.SpellCheck.Models;
using System.Linq;
using Xunit;
using Credentials;

namespace SpellCheckSDK.Tests
{
    public class SpellCheckTests
    {
        private static string SubscriptionKey = "Enter subscription here";

        [Fact]
        public void SpellCheck()
        {

            var client = new SpellCheckClient(new ClientCredentials(SubscriptionKey));

            var resp = client.SpellCheckerWithHttpMessagesAsync(text: "Bill Gatas", mode: "proof").Result; ;
            Assert.NotNull(resp);
            Assert.NotNull(resp.Body.FlaggedTokens);
            Assert.Equal(1, resp.Body.FlaggedTokens.Count);

            // verify token
            var flaggedToken = resp.Body.FlaggedTokens.First();
            Assert.NotNull(flaggedToken);
            Assert.NotNull(flaggedToken.Token);
            Assert.Equal("Gatas", flaggedToken.Token);
            Assert.Equal("UnknownToken", flaggedToken.Type);

            // verify suggestions
            Assert.Equal(1, flaggedToken.Suggestions.Count);

            var suggestion = flaggedToken.Suggestions.First();
            Assert.NotNull(suggestion);
            Assert.Equal(0.887992481895458, suggestion.Score);
            Assert.Equal("Gates", suggestion.Suggestion);
            
        }
    }
}
