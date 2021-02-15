namespace Microsoft.Bing.VisualSearch.Samples
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    class ExampleAttribute : Attribute
    {
        public string ExampleDescription { get; private set; }

        public ExampleAttribute(string description)
        {
            this.ExampleDescription = description;
        }
    }
}
