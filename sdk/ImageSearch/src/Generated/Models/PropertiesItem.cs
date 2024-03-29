// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ImageSearch.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines an item.
    /// </summary>
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
        public PropertiesItem(string text = default(string), string _type = default(string))
        {
            Text = text;
            this._type = _type;
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

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_type")]
        public string _type { get; set; }

    }
}
