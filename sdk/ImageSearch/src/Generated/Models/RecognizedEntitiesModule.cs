// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ImageSearch.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines a list of previously recognized entities.
    /// </summary>
    public partial class RecognizedEntitiesModule
    {
        /// <summary>
        /// Initializes a new instance of the RecognizedEntitiesModule class.
        /// </summary>
        public RecognizedEntitiesModule()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RecognizedEntitiesModule class.
        /// </summary>
        /// <param name="value">A list of recognized entities.</param>
        public RecognizedEntitiesModule(IList<RecognizedEntityGroup> value = default(IList<RecognizedEntityGroup>))
        {
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets a list of recognized entities.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<RecognizedEntityGroup> Value { get; private set; }

    }
}
