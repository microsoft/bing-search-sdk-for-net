# The Bing All Search SDK samples

This sample shows you how to get up and running using the Bing Search SDKs. It covers some usecases and also express best practices for interacting with the data from the Bing Search APIs. It includes  mples for these offerings: Bing Web Search, Bing Image Search, Bing Video Search, Bing News Search, Bing Custom Search, Bing Entity Search, and Bing Spell Check. This sample is used for checking multiple samples at the same time and it references packages for all the APIs. For more information on the Bing Search APIs, go to https://aka.ms/bingapisignup. 

If you are interested in a specific Bing Search API, check out the corresponding subfolder. 

## Features

This sample references the all Bing Search SDKs, which is the complete list of packages for the v7 version of Bing APIs. An all-in-one package--including all the Bing Search APIs--will be available in the future.

This example provides sample use cases of the [Bing Search APIs v7](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples) using the following packages:

* **Bing Web Search Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.WebSearch/
* **Bing Image Search Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.ImageSearch/
* **Bing News Search Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.NewsSearch/
* **Bing Video Search Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.VideoSearch/
* **Bing Visual Search Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.VisualSearch/
* **Bing Custom Search Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.CustomWebSearch/
* **Bing Entity Search Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.EntitySearch/
* **Bing Spell Check Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.Spellcheck/
* **Bing Autosuggest Nuget Package** at https://www.nuget.org/packages/Microsoft.Bing.Search.AutoSuggest/

These packages are contained in the TempPackage folder. 

## Getting started

### Prerequisites

- Visual Studio 2017. If required, you can [download the free community version](https://www.visualstudio.com/vs/community/).
- A Bing API key is required to authenticate SDK calls. You can [sign up here](hhttps://aka.ms/bingapisignup) for the free trial key. This trial key is good for 30 days with 3 calls per second. Alternately, for production scenarios, you can [buy the access key](https://aka.ms/bingapisignup). When buying an access key, consider which tier is appropriate for you. More information is available [here](https://aka.ms/bingapisignup). 
- .NET core SDK (with the ability to run .netcore 1.1 apps). You can [get .NET Core, Framework, and Runtime](https://www.microsoft.com/net/download/). 
- You will need Custom Config ID if you are running the Bing Custom Search sample. Get it from customsearch.ai by creating your own custom search instance. Here is [a step-by-step guide to creating a custom search instance](https://blogs.bing.com/search-quality-insights/2017-12/build-your-ads-free-search-engine-with-bing-custom-search).

### Quickstart

To get the Bing Search sample running locally, follow these steps:

1. On the command line of a git repo, run `git clone https://github.com/microsoft/bing-search-sdk-for-net.git`.
2. Open the project from Visual Studio 2017.
3. You do not need to install individual packages as they are contained in the tempPackage folder. If these don't work, go to **Tools > Nuget Package Manager > Package Manager Console** and run `npm install <packages as mentioned above in Features section>`. Or, go to **Project > Manage Nuget Packages** and search for individual packages under the **Browse** tab, and then click **Install**. 
4. From the top menu of Visual Studio, click **bing-search-dotnet**.

### Note: 
Change TargetFramework in bing-search-dotnet.csproj to `netcoreapp1.1` if you have .NET Framework version as 2.1.2. 

If you have an older version, enter the following:

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
- [Bing Search APIs Demo & capabilities](https://github.com/microsoft/bing-search-sdk-for-net)
- Bing Search Reference Documents: See documentation of the corresponding API
- Nuget Packages: See the [Features](#features) section.
- Bing Search Dotnet SDKs (source code): See the corresponding entry in https://github.com/microsoft/bing-search-sdk-for-net
- Support channels: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search) or [Azure Support](https://azure.microsoft.com/en-us/support/options/)
