# The Bing Custom Search SDK sample

This sample shows you how to get up and running using the Bing Custom Search Nuget package. It covers a few use cases and expresses best practices for interacting with the data from this API. For more information on the Bing Custom Search API v7, go to https://docs.microsoft.com/en-us/bing/search-apis/bing-custom-search/overview. Complete reference documentation including description of parameters, their values, and supported markets is available [here](https://docs.microsoft.com/en-us/bing/search-apis/bing-custom-search/overview).

If you are looking for amending samples to suit your needs, the most important file is CustomImageSearchSamples.cs. See how you can access this file in the [Quickstart(#quickstart) section.

## Features

This sample references the Bing Custom Image Search SDK, which is a stand-alone package for the v7 version of this API. An all-in-one package including all the Bing Search APIs will be available in the future.

This example provides use cases of the [Bing Custom Search v7](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples/BingCustomImageSearch) using the [Bing Custom Image Search Nuget Package](https://www.nuget.org/packages/Microsoft.Bing.Search.CustomImageSearch/).

## Getting started

### Prerequisites

- Visual Studio 2017. If required, you can download the [free community version](https://www.visualstudio.com/vs/community/).
- A Bing API key is required to authenticate SDK calls. You can [sign up here](https://portal.azure.com/#create/microsoft.bingsearch) for the free trial key. This trial key is good for 30 days with 3 calls per second. Or, for production scenarios, [buy an access key](https://portal.azure.com/#create/microsoft.bingsearch). When buying the access key consider which tier is appropriate for you.
- .NET Core SDK (with the bility to run .netcore 1.1 apps). You can get Core, Framework, and Runtime here: https://www.microsoft.com/net/download/. 

### Quickstart

To get the Bing Custom Image Search Search sample running locally, follow these steps:

1. Run `git clone https://github.com/microsoft/bing-search-sdk-for-net.git`.
2. From Visual Studio 2017, open bing-search-sdk-for-net\samples\BingSearchSamples\BingCustomImageSearch\Microsoft.Bing.CustomImageSearch.Samples.sln.
3. From **Tools > Nuget Package Manager > Package Manager Console**, run `npm install https://www.nuget.org/packages/Microsoft.Bing.Search.CustomImageSearch/`. Or, you can go to **Project > Manage Nuget Packages** and search for Microsoft.Bing.CustomImageSearch under the **Browse** tab, and then click **Install**.
4. From the top menu of Visual Studio, click **Microsoft.Bing.CustomImageSearch.Samples** for the debug/release version. This runs examples from the BingCustomImageSearch\CustomImageSearchSamples.cs file.

### Note: 
Change TargetFramework in Microsoft.Bing.CustomImageSearch.Samples.csproj to netcoreapp1.1 if you have .NET Framework version as 2.1.2. 

If you have an older version:

**Current**
````  
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>
````

## Resources
- [Bing Custom Search Reference Document](https://docs.microsoft.com/en-us/bing/search-apis/bing-custom-search/overview)
- [Bing Custom Image Search Nuget Package](https://www.nuget.org/packages/Microsoft.Bing.Search.CustomImageSearch/)
- [Bing Custom Search Search Dotnet SDK (source code)](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/sdk/CustomImageSearchSearch) 
- Support channel: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search)
