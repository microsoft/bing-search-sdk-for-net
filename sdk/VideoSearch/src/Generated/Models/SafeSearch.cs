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
    /// Defines values for SafeSearch.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SafeSearch
    {
        [EnumMember(Value = "Off")]
        Off,
        [EnumMember(Value = "Moderate")]
        Moderate,
        [EnumMember(Value = "Strict")]
        Strict
    }
    internal static class SafeSearchEnumExtension
    {
        internal static string ToSerializedValue(this SafeSearch? value)
        {
            return value == null ? null : ((SafeSearch)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this SafeSearch value)
        {
            switch( value )
            {
                case SafeSearch.Off:
                    return "Off";
                case SafeSearch.Moderate:
                    return "Moderate";
                case SafeSearch.Strict:
                    return "Strict";
            }
            return null;
        }

        internal static SafeSearch? ParseSafeSearch(this string value)
        {
            switch( value )
            {
                case "Off":
                    return SafeSearch.Off;
                case "Moderate":
                    return SafeSearch.Moderate;
                case "Strict":
                    return SafeSearch.Strict;
            }
            return null;
        }
    }
}
