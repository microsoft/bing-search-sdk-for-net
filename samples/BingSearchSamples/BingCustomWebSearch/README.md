# The Bing Custom Search SDK Sample

This sample will show you how to get up and running using the Bing Custom Search Nuget package. This example will cover a few usecases and hopefully express best practices for interacting with the data from this API. For more information on the Bing Custom Search API v7, you can navigate to: https://www.customsearch.ai/. Exhaustive reference documentation including description of parameters, their values, and supported markets is [here](https://www.customsearch.ai/).

If you are looking for amending samples to suit your needs, the single, most important file is CustomSearchSamples.cs. See how you can access this file in the "Quickstart" section below.

## Features

This sample references the Bing Custom Search SDK, which is a stand-alone package for the v7 version of this API. All-in-one package including all the Bing Search APIs will be available in future.

This example provides sample usecases of the the [Bing Custom Search v7](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples/BingCustomWebSearch)

* Using the **Bing Custom Search Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.CustomWebSearch/

## Getting Started

### Prerequisites

- Visual Studio 2017. If required, you can download free community version from here: https://www.visualstudio.com/vs/community/.
- A Bing API key is required to authenticate SDK calls. You can [sign up here](https://portal.azure.com/#create/microsoft.bingsearch) for the **free** trial key. This trial key is good for 30 days with 3 calls per second. **Alternately**, for production scenario, you can buy access key from here: https://portal.azure.com/#create/microsoft.bingsearch or https://aka.ms/bingapisignup. While buying access key you may want to consider which tier is appropriate for you.
- .NET core SDK (ability to run .netcore 1.1 apps). You can get CORE, Framework, and Runtime from here: https://www.microsoft.com/net/download/. 

### Quickstart

To get the Bing Custom Web Search Search sample running locally, follow these steps:

1. git clone https://github.com/microsoft/bing-search-sdk-for-net.git
2. Open bing-search-sdk-for-net\samples\BingSearchSamples\BingCustomWebSearch\Microsoft.Bing.CustomWebSearch.Samples.sln from Visual Studio 2017
3. npm install https://www.nuget.org/packages/Microsoft.Bing.Search.CustomWebSearch/ from Tools > Nuget Package Manager > Package Manager Console. **Alternately**, you can go to Project > Manage Nuget Packages and search for "Microsoft.Bing.CustomWebSearch" in the "Browse" tab, and click on "Install".
4. Click on "Microsoft.Bing.CustomWebSearch.Samples" for debug/release version from the top of Visual Studio. This will run examples from the **BingCustomSearch\CustomSearchSamples.cs** file. **Alternately** you can build and run solution in separate steps.

### Note: 
Change TargetFramework in Microsoft.Bing.CustomWebSearch.Samples.csproj to “netcoreapp1.1” if you have .NET Framework version as 2.1.2. [ Older ] as follows:

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
- Support channels: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search) 
