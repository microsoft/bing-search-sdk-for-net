// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.AutoSuggest.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Suggestions : SearchResultsAnswer
    {
        /// <summary>
        /// Initializes a new instance of the Suggestions class.
        /// </summary>
        public Suggestions()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Suggestions class.
        /// </summary>
        /// <param name="id">A String identifier.</param>
        /// <param name="readLink">The URL that returns this resource.</param>
        /// <param name="webSearchUrl">The URL To Bing's search result for this
        /// item.</param>
        public Suggestions(IList<SuggestionsSuggestionGroup> suggestionGroups, string _type = default(string), string id = default(string), string readLink = default(string), string webSearchUrl = default(string), IList<Action> potentialAction = default(IList<Action>), IList<Action> immediateAction = default(IList<Action>), string preferredClickthroughUrl = default(string), string adaptiveCard = default(string), QueryContext queryContext = default(QueryContext))
            : base(_type, id, readLink, webSearchUrl, potentialAction, immediateAction, preferredClickthroughUrl, adaptiveCard, queryContext)
        {
            SuggestionGroups = suggestionGroups;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "suggestionGroups")]
        public IList<SuggestionsSuggestionGroup> SuggestionGroups { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (SuggestionGroups == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SuggestionGroups");
            }
            if (SuggestionGroups != null)
            {
                foreach (var element in SuggestionGroups)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
