// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.EntitySearch.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the top-level object that the response includes when the
    /// request succeeds.
    /// </summary>
    public partial class SearchResponse : Response
    {
        /// <summary>
        /// Initializes a new instance of the SearchResponse class.
        /// </summary>
        public SearchResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SearchResponse class.
        /// </summary>
        /// <param name="id">A String identifier.</param>
        /// <param name="contractualRules">A list of rules that you must adhere
        /// to if you display the item.</param>
        /// <param name="webSearchUrl">The URL To Bing's search result for this
        /// item.</param>
        /// <param name="queryContext">An object that contains the query string
        /// that Bing used for the request. This object contains the query
        /// string as entered by the user. It may also contain an altered query
        /// string that Bing used for the query if the query string contained a
        /// spelling mistake.</param>
        /// <param name="entities">A list of entities that are relevant to the
        /// search query.</param>
        /// <param name="places">A list of local entities such as restaurants
        /// or hotels that are relevant to the query.</param>
        public SearchResponse(string _type = default(string), string id = default(string), IList<ContractualRulesContractualRule> contractualRules = default(IList<ContractualRulesContractualRule>), string webSearchUrl = default(string), QueryContext queryContext = default(QueryContext), Entities entities = default(Entities), Places places = default(Places))
            : base(_type, id, contractualRules, webSearchUrl)
        {
            QueryContext = queryContext;
            Entities = entities;
            Places = places;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets an object that contains the query string that Bing used for
        /// the request. This object contains the query string as entered by
        /// the user. It may also contain an altered query string that Bing
        /// used for the query if the query string contained a spelling
        /// mistake.
        /// </summary>
        [JsonProperty(PropertyName = "queryContext")]
        public QueryContext QueryContext { get; private set; }

        /// <summary>
        /// Gets a list of entities that are relevant to the search query.
        /// </summary>
        [JsonProperty(PropertyName = "entities")]
        public Entities Entities { get; private set; }

        /// <summary>
        /// Gets a list of local entities such as restaurants or hotels that
        /// are relevant to the query.
        /// </summary>
        [JsonProperty(PropertyName = "places")]
        public Places Places { get; private set; }

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
            if (Entities != null)
            {
                Entities.Validate();
            }
            if (Places != null)
            {
                Places.Validate();
            }
        }
    }
}
