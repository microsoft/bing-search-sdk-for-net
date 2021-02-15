namespace Microsoft.Bing.Autosuggest.Samples
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    class SampleCollectionAttribute : Attribute
    {
        public string SampleName { get; private set; }

        public SampleCollectionAttribute(string name)
        {
            this.SampleName = name;
        }
    }
}
