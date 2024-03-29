// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.VisualSearch.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines a shopping sources action.
    /// </summary>
    public partial class ImageShoppingSourcesAction : ImageAction
    {
        /// <summary>
        /// Initializes a new instance of the ImageShoppingSourcesAction class.
        /// </summary>
        public ImageShoppingSourcesAction()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ImageShoppingSourcesAction class.
        /// </summary>
        /// <param name="id">A String identifier.</param>
        /// <param name="readLink">The URL that returns this resource. To use
        /// the URL, append query parameters as appropriate and include the
        /// Ocp-Apim-Subscription-Key header.</param>
        /// <param name="webSearchUrl">The URL to Bing's search result for this
        /// item.</param>
        /// <param name="name">The name of the thing represented by this
        /// object.</param>
        /// <param name="url">The URL to get more information about the thing
        /// represented by this object.</param>
        /// <param name="image">An image of the item.</param>
        /// <param name="description">A short description of the item.</param>
        /// <param name="alternateName">An alias for the item.</param>
        /// <param name="bingId">An ID that uniquely identifies this
        /// item.</param>
        /// <param name="thumbnailUrl">The URL to a thumbnail of the
        /// item.</param>
        /// <param name="provider">The source of the creative work.</param>
        /// <param name="datePublished">The date on which the CreativeWork was
        /// published.</param>
        /// <param name="text">Text content of this creative work.</param>
        /// <param name="result">The result produced in the action.</param>
        /// <param name="displayName">A display name for the action.</param>
        /// <param name="isTopAction">A Boolean representing whether this
        /// result is the top action.</param>
        /// <param name="serviceUrl">Use this URL to get additional data to
        /// determine how to take the appropriate action. For example, the
        /// serviceUrl might return JSON along with an image URL.</param>
        /// <param name="actionType">A string representing the type of
        /// action.</param>
        /// <param name="data">A list of merchants that offer items related to
        /// the image.</param>
        public ImageShoppingSourcesAction(string _type = default(string), string id = default(string), string readLink = default(string), string webSearchUrl = default(string), string name = default(string), string url = default(string), ImageObject image = default(ImageObject), string description = default(string), string alternateName = default(string), string bingId = default(string), string thumbnailUrl = default(string), IList<Thing> provider = default(IList<Thing>), string datePublished = default(string), string text = default(string), IList<Thing> result = default(IList<Thing>), string displayName = default(string), bool? isTopAction = default(bool?), string serviceUrl = default(string), string actionType = default(string), AggregateOffer data = default(AggregateOffer))
            : base(_type, id, readLink, webSearchUrl, name, url, image, description, alternateName, bingId, thumbnailUrl, provider, datePublished, text, result, displayName, isTopAction, serviceUrl, actionType)
        {
            Data = data;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets a list of merchants that offer items related to the image.
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public AggregateOffer Data { get; private set; }

    }
}
