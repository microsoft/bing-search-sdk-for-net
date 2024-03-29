// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.WebSearch.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines a webpage's metadata.
    /// </summary>
    public partial class WebMetaTag
    {
        /// <summary>
        /// Initializes a new instance of the WebMetaTag class.
        /// </summary>
        public WebMetaTag()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WebMetaTag class.
        /// </summary>
        /// <param name="name">The metadata.</param>
        /// <param name="content">The name of the metadata.</param>
        public WebMetaTag(string name = default(string), string content = default(string))
        {
            Name = name;
            Content = content;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of the metadata.
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public string Content { get; private set; }

    }
}
