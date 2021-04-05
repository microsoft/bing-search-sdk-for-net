# The Bing Visual Search SDK sample

This sample shows you how to get up and running using the Bing Visual Search Nuget package. It covers a few use cases and expresses best practices for interacting with the data from this API. For more information on the Bing Visual Search API v7, go to: https://docs.microsoft.com/en-us/bing/search-apis/bing-visual-search/overview. Complete reference documentation including descriptions of parameters, their values, and supported markets is available [here](https://docs.microsoft.com/en-us/bing/search-apis/bing-visual-search/overview).

If you want to amend samples to suit your needs, the most important file is VisualSearchSamples.cs. See how you can access this file in the [Quickstart](#quickstart) section below.

## Features

This sample references the Bing Visual Search SDK, which is a stand-alone package for the v7 version of this API. An all-in-one package including all the Bing Search APIs will be available in the future.

This example provides sample use cases of the [Bing Visual Search v7](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples/BingVisualSearch) using the Bing Visual Search Nuget Package at https://www.nuget.org/packages/Microsoft.Bing.Search.VisualSearch/.

## Getting started

### Prerequisites

- Visual Studio 2017. If required, you can download the [free community version](https://www.visualstudio.com/vs/community/).
- A Bing API key is required to authenticate SDK calls. You can [sign up here](https://portal.azure.com/#create/microsoft.bingsearch) for the free trial key. This trial key is good for 30 days with 3 calls per second. Or, for production scenarios, you can [buy an access key](https://portal.azure.com/#create/microsoft.bingsearch). When buying an access key, consider which tier is appropriate for you.
- .NET Core SDK (with the ability to run .netcore 1.1 apps). You can get .NET Core, Framework, and Runtime from here: https://www.microsoft.com/net/download/. 

### Quickstart

To get the Bing Visual Search sample running locally, follow these steps:

1. Run `git clone https://github.com/microsoft/bing-search-sdk-for-net.git`.
2. From Visual Studio 2017, open bing-search-sdk-for-net\samples\BingSearchSamples\BingVisualSearch\Microsoft.Bing.VisualSearch.Samples.sln. 
3. From **Tools > Nuget Package Manager > Package Manager Console**, run `npm install https://www.nuget.org/packages/Microsoft.Bing.Search.VisualSearch/`. Or, go to **Project > Manage Nuget Packages** and search for Microsoft.Bing.VisualSearch under the **Browse** tab, and then click **Install**. 
4. From the top menu of Visual Studio, click **Microsoft.Bing.VisualSearch.Samples** for the debug/release version. This runs examples from the BingVisualSearch\VisualSearchSamples.cs file. 

### Note: 
Change TargetFramework in Microsoft.Bing.VisualSearch.Samples.csproj to netcoreapp1.1 if you have .NET Framework version as 2.1.2. 

If you have an older version, change it as follows:

**Current**
````  
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>
````

## Resources
- [Bing Visual Search Reference Document](https://docs.microsoft.com/en-us/bing/search-apis/bing-visual-search/overview)
- [Bing Visual Search Dotnet SDK (source code)](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/sdk/VisualSearch)
- [Bing Visual Search Nuget Package](https://www.nuget.org/packages/Microsoft.Bing.Search.VisualSearch/) 
- Support channel: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search)
