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
    /// A JSON object that contains information about the image to get insights
    /// of. Specify this object only in a knowledgeRequest form data.
    /// </summary>
    public partial class VisualSearchRequest
    {
        /// <summary>
        /// Initializes a new instance of the VisualSearchRequest class.
        /// </summary>
        public VisualSearchRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VisualSearchRequest class.
        /// </summary>
        /// <param name="imageInfo">A JSON object that identities the image to
        /// get insights of.</param>
        /// <param name="knowledgeRequest">A JSON object containing information
        /// about the request, such as filters, or a description.</param>
        public VisualSearchRequest(ImageInfo imageInfo = default(ImageInfo), KnowledgeRequest knowledgeRequest = default(KnowledgeRequest))
        {
            ImageInfo = imageInfo;
            KnowledgeRequest = knowledgeRequest;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a JSON object that identities the image to get
        /// insights of.
        /// </summary>
        [JsonProperty(PropertyName = "imageInfo")]
        public ImageInfo ImageInfo { get; set; }

        /// <summary>
        /// Gets or sets a JSON object containing information about the
        /// request, such as filters, or a description.
        /// </summary>
        [JsonProperty(PropertyName = "knowledgeRequest")]
        public KnowledgeRequest KnowledgeRequest { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ImageInfo != null)
            {
                ImageInfo.Validate();
            }
        }
    }
}
