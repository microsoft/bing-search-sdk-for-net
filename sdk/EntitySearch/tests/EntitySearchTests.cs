using Microsoft.Bing.EntitySearch;
using Microsoft.Bing.EntitySearch.Models;
using System.Linq;
using Xunit;
namespace SearchSDK.Tests
{
    public class EntitySearchTests
    {
        private static string SubscriptionKey = "Enter subscription here";

        [Fact]
        public void EntitySearch()
        {

            IEntitySearchClient client = new EntitySearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey));

            var resp = client.Entities.Search(query: "tom cruise");


            Assert.NotNull(resp);
            Assert.NotNull(resp.Entities);
            Assert.NotNull(resp.Entities.Value);
            Assert.Equal(1, resp.Entities.Value.Count);

            Assert.NotNull(resp.Entities.Value[0].ContractualRules);

            var licenseAttribution = resp.Entities.Value[0].ContractualRules.Where(rule => rule is ContractualRulesLicenseAttribution).FirstOrDefault();

            Assert.NotNull(licenseAttribution);
            Assert.Equal("description", licenseAttribution.TargetPropertyName);

            var image = resp.Entities.Value[0].Image;

            Assert.NotNull(image);
            Assert.NotNull(image.Provider);

            var provider = image.Provider.FirstOrDefault();

            Assert.NotNull(provider);
            Assert.IsType<Organization>(provider);
           
        }
    }
}
