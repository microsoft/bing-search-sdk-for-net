// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.CustomImageSearch.Models
{
    using System.Linq;

    /// <summary>
    /// Defines an answer.
    /// </summary>
    public partial class Answer : Response
    {
        /// <summary>
        /// Initializes a new instance of the Answer class.
        /// </summary>
        public Answer()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Answer class.
        /// </summary>
        /// <param name="id">A String identifier.</param>
        /// <param name="readLink">The URL that returns this resource.</param>
        /// <param name="webSearchUrl">The URL To Bing's search result for this
        /// item.</param>
        public Answer(string _type = default(string), string id = default(string), string readLink = default(string), string webSearchUrl = default(string))
            : base(_type, id, readLink, webSearchUrl)
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

    }
}
