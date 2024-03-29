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
    /// A key-value object consisting of filters that may be specified to limit
    /// the results returned by the API. Current available filters: site.
    /// </summary>
    public partial class Filters
    {
        /// <summary>
        /// Initializes a new instance of the Filters class.
        /// </summary>
        public Filters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Filters class.
        /// </summary>
        /// <param name="site">The URL of the site to return similar images and
        /// similar products from. (e.g., "www.bing.com", "bing.com").</param>
        public Filters(string site = default(string))
        {
            Site = site;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the URL of the site to return similar images and
        /// similar products from. (e.g., "www.bing.com", "bing.com").
        /// </summary>
        [JsonProperty(PropertyName = "site")]
        public string Site { get; set; }

    }
}
