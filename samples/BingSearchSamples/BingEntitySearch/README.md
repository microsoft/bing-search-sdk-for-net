

# The Bing Entity Search SDK sample

This sample shows you how to get up and running using the Bing Entity Search Nuget package. It covers a few use cases and expresses best practices for interacting with the data from this API. For more information on the Bing Entity Search API v7, go to: https://docs.microsoft.com/en-us/bing/search-apis/bing-entity-search/overview. Complete reference documentation including descriptions of parameters, their values, and supported markets is [here](https://docs.microsoft.com/en-us/bing/search-apis/bing-entity-search/overview).

If you want to amend samples to suit your needs, the most important file is EntitySearchSamples.cs. See how you can access this file in the [Quickstart](#quickstart) section below.

## Features

This sample references the Bing Entity Search SDK, which is a stand-alone package for the v7 version of this API. An all-in-one package including all the Bing Search APIs will be available in future.

This example provides use cases of the [Bing Entity Search v7](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples/BingEntitySearch) using the Bing Entity Search Nuget Package at https://www.nuget.org/packages/Microsoft.Bing.Search.EntitySearch/.

## Getting started

### Prerequisites

- Visual Studio 2017. If required, you can download the [free community version](https://www.visualstudio.com/vs/community/).
- A Bing API key is required to authenticate SDK calls. You can [sign up here](https://portal.azure.com/#create/microsoft.bingsearch) for the free trial key. This trial key is good for 30 days with 3 calls per second. Or, for production scenarios, [buy an access key](https://portal.azure.com/#create/microsoft.bingsearch) or https://aka.ms/bingapisignup. When buying an access key, consider which tier is appropriate for you.
- .NET Core SDK (with the ability to run .netcore 1.1 apps). You can get Core, Framework, and Runtime from here: https://www.microsoft.com/net/download/. 

### Quickstart

To get the Bing Entity Search sample running locally, follow these steps

1. Run `git clone https://github.com/microsoft/bing-search-sdk-for-net.git`.
2. From Visual Studio 2017, open `bing-search-sdk-for-net\samples\BingSearchSamples\BingEntitySearch\Microsoft.Bing.EntitySearch.Samples.sln`.
3. From **Tools > Nuget Package Manager > Package Manager Console**, run `npm install https://www.nuget.org/packages/Microsoft.Bing.Search.EntitySearch/`. Or, you can go to **Project > Manage Nuget Package**s and search for Microsoft.Bing.EntitySearch under the **Browse** tab, and then click on **Install**.
4. From the top of Visual Studio, click **Microsoft.Bing.EntitySearch.Samples** for the debug/release version. This will run examples from the BingEntitySearch\EntitySearchSamples.cs file. 

### Note: 
Change TargetFramework in Microsoft.Bing.EntitySearch.Samples.csproj to netcoreapp1.1 if you have .NET Framework version as 2.1.2. 

If you have an older version:

**Current**
````  
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>
````

## Resources
- [Bing Entity Search Reference Document](https://docs.microsoft.com/en-us/bing/search-apis/bing-entity-search/overview)
- [Bing Entity Search Nuget Package](https://www.nuget.org/packages/Microsoft.Bing.Search.EntitySearch/)
- [Bing Entity Search Dotnet SDK (source code)](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/sdk/EntitySearch) 
- Support channel: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search) 
