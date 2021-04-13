# The Bing News Search SDK sample

This sample shows you how to get up and running using the Bing Video Search Nuget package. It covers a few use cases and expresses best practices for interacting with the data from this API. For more information on the Bing Video Search API v7, go to: https://docs.microsoft.com/en-us/bing/search-apis/bing-news-search/overview. Complete reference documentation including descriptions of parameters, their values, and supported markets is available [here](https://docs.microsoft.com/en-us/bing/search-apis/bing-news-search/overview).

If you want to amend samples to suit your needs, the most important file is NewsSearchSamples.cs. See how you can access this file in the [Quickstart](#quickstart) section below.

## Features

This sample references the Bing News Search SDK, which is a stand-alone package for the v7 version of this API. An all-in-one package including all the Bing Search APIs will be available in the future.

This example provides sample use cases of the [Bing News Search v7](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples/BingNewsSearch) using the Bing News Search Nuget Package at https://www.nuget.org/packages/Microsoft.Bing.Search.NewsSearch/.

## Getting started

### Prerequisites

- Visual Studio 2017. If required, you can download the [free community version](https://www.visualstudio.com/vs/community/).
- A Bing API key is required to authenticate SDK calls. You can [sign up here](https://portal.azure.com/#create/microsoft.bingsearch) for the free trial key. This trial key is good for 30 days with 3 calls per second. Or, for production scenarios, you can [buy an access key](https://portal.azure.com/#create/microsoft.bingsearch). When buying an access key, consider which tier is appropriate for you.
- .NET Core SDK (with the ability to run .netcore 1.1 apps). You can get .NET Core, Framework, and Runtime from here: https://www.microsoft.com/net/download/. 

### Quickstart

To get the Bing News Search sample running locally, follow these steps:

1. Run `git clone https://github.com/microsoft/bing-search-sdk-for-net.git`.
2. From Visual Studio 2017, open bing-search-sdk-for-net\samples\BingSearchSamples\BingNewsSearch\Microsoft.Bing.NewsSearch.Samples.sln.
3. From **Tools > Nuget Package Manager > Package Manager Console**, run `npm install https://www.nuget.org/packages/Microsoft.Bing.Search.NewsSearch/`. Or, go to **Project > Manage Nuget Packages** and search for Microsoft.Bing.NewsSearch under the **Browse** tab, and then click **Install**.
4. From the top menu of Visual Studio, click **Microsoft.Bing.NewsSearch.Samples** for the debug/release version. This runs examples from the BingNewsSearch\NewsSearchSamples.cs file. 

### Note: 
Change TargetFramework in Microsoft.Bing.NewsSearch.Samples.csproj to “netcoreapp1.1” if you have .NET Framework version as 2.1.2. 

If you have an older version, change it as follows:

**Current**
````  
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>
````

## Resources
- [Bing News Search Reference Document](https://docs.microsoft.com/en-us/bing/search-apis/bing-news-search/overview)
- [Bing News Search Nuget Package](https://www.nuget.org/packages/Microsoft.Bing.Search.NewsSearch/)
- [Bing News Search Dotnet SDK (source code)](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/sdk/NewsSearch)  
- Support channel: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search)
