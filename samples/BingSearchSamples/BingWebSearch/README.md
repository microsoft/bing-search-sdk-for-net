# The Bing Web Search SDK sample

This sample shows you how to get up and running using the Bing Web Search SDK. It covers a few use cases and expresses best practices for interacting with the data from this API. For more information on the Bing Web Search API v7, go to: https://docs.microsoft.com/en-us/bing/search-apis/bing-web-search/overview. Complete reference documentation including descriptions of parameters, their values, and supported markets is available [here](https://docs.microsoft.com/en-us/bing/search-apis/bing-web-search/overview).

If you want to amend samples to suit your needs, the most important file is WebSearchSamples.cs. See how you can access this file in the [Quickstart](#quickstart) section below.

## Features

This sample references the Bing Web Search SDK, which is a stand-alone package for the v7 version of this API. An all-in-one package including all the Bing Search APIs will be available in future.

This example provides use cases of the [Bing Web Search v7](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples/BingWebSearch) using the Bing Web Search Nuget Package at https://www.nuget.org/packages/Microsoft.Bing.Search.WebSearch/.

## Getting started

### Prerequisites

- Visual Studio 2017. If required, you can download the [free community version](https://www.visualstudio.com/vs/community/).
- A Bing API key is required to authenticate SDK calls. You can [sign up here](https://portal.azure.com/#create/microsoft.bingsearch) for the free trial key. This trial key is good for 30 days with 3 calls per second. Or, for production scenarios, you can [buy an access key](https://portal.azure.com/#create/microsoft.bingsearch). When buying an access key, consider which tier is appropriate for you.
- .NET Core SDK (with the ability to run .netcore 1.1 apps). You can get .NET Core, Framework, and Runtime from here: https://www.microsoft.com/net/download/. 

### Quickstart

To get the Bing Web Search sample running locally, follow these steps:

1. Run `git clone https://github.com/microsoft/bing-search-sdk-for-net.git`.
2. From Visual Studio 2017, open bing-search-sdk-for-net\samples\BingSearchSamples\BingWebSearch\Microsoft.Bing.WebSearch.Samples.sln.
3. From **Tools > Nuget Package Manager > Package Manager Console**, run `npm install https://www.nuget.org/packages/Microsoft.Bing.Search.WebSearch/`. Or, you can go to **Project > Manage Nuget Packages** and search for Microsoft.Bing.WebSearch under the **Browse** tab, and click **Install**. 
4. From the top menu of Visual Studio, click **Microsoft.Bing.WebSearch.Samples** for the debug/release version. This runs examples from the BingWebSearch\WebSearchSamples.cs file. 

### Note: 
Change TargetFramework in Microsoft.Bing.WebSearch.Samples.csproj to netcoreapp1.1 if you have .NET Framework version as 2.1.2.

If you have an older version: 

**Current**
````  
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>
````

## Resources
- [Bing Web Search Reference Document](https://docs.microsoft.com/en-us/bing/search-apis/bing-web-search/overview)
- [Bing Web Search Dotnet SDK (source code)](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/sdk/WebSearch)
- [Bing Web Search Nuget Package](https://www.nuget.org/packages/Microsoft.Bing.Search.WebSearch/) 
- Support channel: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search)
