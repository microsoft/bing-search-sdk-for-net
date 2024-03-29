// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.AutoSuggest.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class SearchAction : Action
    {
        /// <summary>
        /// Initializes a new instance of the SearchAction class.
        /// </summary>
        public SearchAction()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SearchAction class.
        /// </summary>
        /// <param name="id">A String identifier.</param>
        /// <param name="readLink">The URL that returns this resource.</param>
        /// <param name="webSearchUrl">The URL To Bing's search result for this
        /// item.</param>
        /// <param name="url">The URL to get more information about the thing
        /// represented by this object.</param>
        /// <param name="thumbnailUrl">The URL to a thumbnail of the
        /// item.</param>
        /// <param name="about">For internal use only.</param>
        /// <param name="mentions">For internal use only.</param>
        /// <param name="provider">The source of the creative work.</param>
        /// <param name="text">Text content of this creative work</param>
        /// <param name="searchKind">Possible values include: 'WebSearch',
        /// 'HistorySearch', 'DocumentSearch', 'TagSearch', 'LocationSearch',
        /// 'CustomSearch'</param>
        public SearchAction(string _type = default(string), string id = default(string), string readLink = default(string), string webSearchUrl = default(string), IList<Action> potentialAction = default(IList<Action>), IList<Action> immediateAction = default(IList<Action>), string preferredClickthroughUrl = default(string), string adaptiveCard = default(string), string url = default(string), string thumbnailUrl = default(string), IList<Thing> about = default(IList<Thing>), IList<Thing> mentions = default(IList<Thing>), IList<Thing> provider = default(IList<Thing>), Thing creator = default(Thing), string text = default(string), string discussionUrl = default(string), int? commentCount = default(int?), Thing mainEntity = default(Thing), string headLine = default(string), Thing copyrightHolder = default(Thing), int? copyrightYear = default(int?), string disclaimer = default(string), bool? isAccessibleForFree = default(bool?), IList<string> genre = default(IList<string>), bool? isFamilyFriendly = default(bool?), IList<Thing> result = default(IList<Thing>), string displayName = default(string), bool? isTopAction = default(bool?), string serviceUrl = default(string), string displayText = default(string), string query = default(string), string searchKind = default(string))
            : base(_type, id, readLink, webSearchUrl, potentialAction, immediateAction, preferredClickthroughUrl, adaptiveCard, url, thumbnailUrl, about, mentions, provider, creator, text, discussionUrl, commentCount, mainEntity, headLine, copyrightHolder, copyrightYear, disclaimer, isAccessibleForFree, genre, isFamilyFriendly, result, displayName, isTopAction, serviceUrl)
        {
            DisplayText = displayText;
            Query = query;
            SearchKind = searchKind;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "displayText")]
        public string DisplayText { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "query")]
        public string Query { get; private set; }

        /// <summary>
        /// Gets possible values include: 'WebSearch', 'HistorySearch',
        /// 'DocumentSearch', 'TagSearch', 'LocationSearch', 'CustomSearch'
        /// </summary>
        [JsonProperty(PropertyName = "searchKind")]
        public string SearchKind { get; private set; }

    }
}
