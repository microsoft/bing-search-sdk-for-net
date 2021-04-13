# The Bing Custom Search SDK sample

This sample shows you how to get up and running using the Bing Custom Search Nuget package. This example covers a few use cases and expresses best practices for interacting with the data from this API. For more information on the Bing Custom Search API v7, go to: https://www.customsearch.ai/. Complete reference documentation including descriptions of parameters, their values, and supported markets is available [here](https://www.customsearch.ai/).

If you want to amend samples to suit your needs, the most important file is CustomSearchSamples.cs. See how you can access this file in the [Quickstart](#quickstart) section below.

## Features

This sample references the Bing Custom Search SDK, which is a stand-alone package for the v7 version of this API. An all-in-one package including all the Bing Search APIs will be available in the future.

This example provides sample use cases of the [Bing Custom Search v7](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples/BingCustomWebSearch) using the Bing Custom Search Nuget Package at https://www.nuget.org/packages/Microsoft.Bing.Search.CustomWebSearch/.

## Getting started

### Prerequisites

- Visual Studio 2017. If required, you can download the [free community version](https://www.visualstudio.com/vs/community/).
- A Bing API key is required to authenticate SDK calls. You can [sign up here](https://portal.azure.com/#create/microsoft.bingsearch) for the free trial key. This trial key is good for 30 days with 3 calls per second. Or, for production scenarios, you can [buy an access key](https://portal.azure.com/#create/microsoft.bingsearch). When buying access key, consider which tier is appropriate for you.
- .NET Core SDK (with the ability to run .netcore 1.1 apps). You can get Core, Framework, and Runtime from here: https://www.microsoft.com/net/download/. 

### Quickstart

To get the Bing Custom Web Search Search sample running locally, follow these steps:

1. Run `git clone https://github.com/microsoft/bing-search-sdk-for-net.git`.
2. From Visual Studio 2017, open bing-search-sdk-for-net\samples\BingSearchSamples\BingCustomWebSearch\Microsoft.Bing.CustomWebSearch.Samples.sln.
3. From **Tools > Nuget Package Manager > Package Manager Console**, run `npm install https://www.nuget.org/packages/Microsoft.Bing.Search.CustomWebSearch/`. Or, go to **Project > Manage Nuget Packages** and search for Microsoft.Bing.CustomWebSearch under the **Browse** tab, and click **Install**
4. From the top menu of Visual Studio, click Microsoft.Bing.CustomWebSearch.Samples. This runs examples from the BingCustomSearch\CustomSearchSamples.cs file.

### Note: 
Change TargetFramework in Microsoft.Bing.CustomWebSearch.Samples.csproj to netcoreapp1.1 if you have .NET Framework version as 2.1.2.

For older versions:

**Current**
````  
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>
````
**Revision**
````
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.1</TargetFramework>
  </PropertyGroup>
````

## Resources
- [Bing Custom Search Reference Document](https://www.customsearch.ai/)
- [Bing Custom Search Nuget Package](https://www.nuget.org/packages/Microsoft.Bing.Search.CustomWebSearch/)
- [Bing Custom Search Search Dotnet SDK (source code)](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/sdk/CustomWebSearchSearch) 
- Support channel: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search) 
