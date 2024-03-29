// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.VisualSearch.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines an item.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Properties/Item")]
    public partial class PropertiesItem
    {
        /// <summary>
        /// Initializes a new instance of the PropertiesItem class.
        /// </summary>
        public PropertiesItem()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PropertiesItem class.
        /// </summary>
        /// <param name="text">Text representation of an item.</param>
        public PropertiesItem(string text = default(string))
        {
            Text = text;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets text representation of an item.
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; private set; }

    }
}
