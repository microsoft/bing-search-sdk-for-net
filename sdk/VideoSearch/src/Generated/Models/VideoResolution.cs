// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.VideoSearch.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for VideoResolution.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VideoResolution
    {
        [EnumMember(Value = "All")]
        All,
        [EnumMember(Value = "SD480p")]
        SD480p,
        [EnumMember(Value = "HD720p")]
        HD720p,
        [EnumMember(Value = "HD1080p")]
        HD1080p
    }
    internal static class VideoResolutionEnumExtension
    {
        internal static string ToSerializedValue(this VideoResolution? value)
        {
            return value == null ? null : ((VideoResolution)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this VideoResolution value)
        {
            switch( value )
            {
                case VideoResolution.All:
                    return "All";
                case VideoResolution.SD480p:
                    return "SD480p";
                case VideoResolution.HD720p:
                    return "HD720p";
                case VideoResolution.HD1080p:
                    return "HD1080p";
            }
            return null;
        }

        internal static VideoResolution? ParseVideoResolution(this string value)
        {
            switch( value )
            {
                case "All":
                    return VideoResolution.All;
                case "SD480p":
                    return VideoResolution.SD480p;
                case "HD720p":
                    return VideoResolution.HD720p;
                case "HD1080p":
                    return VideoResolution.HD1080p;
            }
            return null;
        }
    }
}
