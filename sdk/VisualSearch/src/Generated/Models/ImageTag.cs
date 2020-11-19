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
    /// A visual search tag.
    /// </summary>
    public partial class ImageTag : Thing
    {
        /// <summary>
        /// Initializes a new instance of the ImageTag class.
        /// </summary>
        public ImageTag()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ImageTag class.
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
        /// <param name="displayName">Display name for this tag. For the
        /// default tag, the display name is empty.</param>
        /// <param name="boundingBox">The bounding box for this tag. For the
        /// default tag, there is no bounding box.</param>
        /// <param name="actions">Actions within this tag. The order of the
        /// items denotes the default ranking order of these actions, with the
        /// first action being the most likely user intent.</param>
        public ImageTag(string _type = default(string), string id = default(string), string readLink = default(string), string webSearchUrl = default(string), string name = default(string), string url = default(string), ImageObject image = default(ImageObject), string description = default(string), string alternateName = default(string), string bingId = default(string), string displayName = default(string), ImageTagRegion boundingBox = default(ImageTagRegion), IList<ImageAction> actions = default(IList<ImageAction>))
            : base(_type, id, readLink, webSearchUrl, name, url, image, description, alternateName, bingId)
        {
            DisplayName = displayName;
            BoundingBox = boundingBox;
            Actions = actions;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets display name for this tag. For the default tag, the display
        /// name is empty.
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets the bounding box for this tag. For the default tag, there is
        /// no bounding box.
        /// </summary>
        [JsonProperty(PropertyName = "boundingBox")]
        public ImageTagRegion BoundingBox { get; private set; }

        /// <summary>
        /// Gets actions within this tag. The order of the items denotes the
        /// default ranking order of these actions, with the first action being
        /// the most likely user intent.
        /// </summary>
        [JsonProperty(PropertyName = "actions")]
        public IList<ImageAction> Actions { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (BoundingBox != null)
            {
                BoundingBox.Validate();
            }
        }
    }
}