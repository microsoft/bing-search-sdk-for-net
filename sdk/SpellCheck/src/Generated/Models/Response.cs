// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.SpellCheck.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines a response. All schemas that could be returned at the root of a
    /// response should inherit from this
    /// </summary>
    [Newtonsoft.Json.JsonObject("Response")]
    public partial class Response : Identifiable
    {
        /// <summary>
        /// Initializes a new instance of the Response class.
        /// </summary>
        public Response()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Response class.
        /// </summary>
        /// <param name="id">A String identifier.</param>
        public Response(string id = default(string))
            : base(id)
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

    }
}
