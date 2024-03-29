// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.CustomSearch.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("SearchResultsAnswer")]
    public partial class SearchResultsAnswer : Answer
    {
        /// <summary>
        /// Initializes a new instance of the SearchResultsAnswer class.
        /// </summary>
        public SearchResultsAnswer()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SearchResultsAnswer class.
        /// </summary>
        /// <param name="id">A String identifier.</param>
        /// <param name="webSearchUrl">The URL To Bing's search result for this
        /// item.</param>
        /// <param name="totalEstimatedMatches">The estimated number of
        /// webpages that are relevant to the query. Use this number along with
        /// the count and offset query parameters to page the results.</param>
        public SearchResultsAnswer(string id = default(string), string webSearchUrl = default(string), IList<Query> followUpQueries = default(IList<Query>), QueryContext queryContext = default(QueryContext), long? totalEstimatedMatches = default(long?), bool? isFamilyFriendly = default(bool?))
            : base(id, webSearchUrl, followUpQueries)
        {
            QueryContext = queryContext;
            TotalEstimatedMatches = totalEstimatedMatches;
            IsFamilyFriendly = isFamilyFriendly;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "queryContext")]
        public QueryContext QueryContext { get; private set; }

        /// <summary>
        /// Gets the estimated number of webpages that are relevant to the
        /// query. Use this number along with the count and offset query
        /// parameters to page the results.
        /// </summary>
        [JsonProperty(PropertyName = "totalEstimatedMatches")]
        public long? TotalEstimatedMatches { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isFamilyFriendly")]
        public bool? IsFamilyFriendly { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (QueryContext != null)
            {
                QueryContext.Validate();
            }
        }
    }
}
