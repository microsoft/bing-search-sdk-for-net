# The Bing AutoSuggest Search SDK sample

This sample shows you how to get up and running using the Bing AutoSuggest Search Nuget package. It covers a few use cases and expresses best practices for interacting with the data from this API. More information is available for the [Bing AutoSuggest Search API v7](https://docs.microsoft.com/en-us/bing/search-apis/bing-autosuggest/overview). Complete reference documentation including descriptions of parameters, their values, and supported markets is available [here](https://docs.microsoft.com/en-us/bing/search-apis/bing-autosuggest/overview).

If you are looking for amending samples to suit your needs, the most important file is AutoSuggestSearchSamples.cs. Learn how you can access this file in the [Quickstart](#quickstart) section.

## Features

This sample references the Bing AutoSuggest Search SDK, which is a stand-alone package for the v7 version of this API. An all-in-one package including all the Bing AutoSuggest APIs on Bing will be available in future.

This example illustrates use cases for the the Bing AutoSuggest Search v7. It uses the Bing AutoSuggest Search Nuget Package at https://www.nuget.org/packages/Microsoft.Bing.Search.AutoSuggest/.

## Getting started

### Prerequisites

- Visual Studio 2017. If required, you can download the [free community version](https://www.visualstudio.com/vs/community/).
- An API key is required to authenticate SDK calls. You can [sign up here](https://portal.azure.com/#cre(ate/microsoft.bingsearch) for the free trial key. This trial key is good for 30 days with 3 calls per second. Or, for production scenarios, [buy an access key]https://portal.azure.com/#create/microsoft.bingsearch). When buying an access key, consider which tier is appropriate for you. More information is available [here](https://docs.microsoft.com/en-us/bing/search-apis/bing-autosuggest/overview). 
- .NET Core SDK (with the ability to run .netcore 1.1 apps). You can get .NET Core, Framework, and Runtime from here: https://www.microsoft.com/net/download/. 

### Quickstart

To get the Bing AutoSuggest Search sample running locally, follow these steps:

1. From a repo on the command line, enter `git clone https://github.com/microsoft/bing-search-sdk-for-net.git`.
2. Open the project from Visual Studio 2017.
3. From the **Tools > Nuget Package Manager > Package Manager** console, run `npm install https://www.nuget.org/packages/Microsoft.Bing.Search.AutoSuggest/`. Or, go to **Project > Manage Nuget Packages** and search for Microsoft.Azure.CognitiveServices.Search.AutoSuggest under the **Browse** tab, and click **Install**. 
4. From the Visual Studio top menu, click Microsoft.Bing.Autosuggest.Samples for the debug/release version. This runs examples from the BingAutoSuggest\AutoSuggestSearchSamples.cs file.

### Note: 
Change TargetFramework in Microsoft.Bing.Autosuggest.Samples.csproj to `netcoreapp1.1` if you have .NET Framework version 2.1.2. 

If your version is older, run:

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
- [Bing AutoSuggest Search API Demo & capabilities](https://api.bing.microsoft.com/v7.0/suggestions)
- [Bing AutoSuggest Search Reference Document](https://docs.microsoft.com/en-us/bing/search-apis/bing-autosuggest/overview)
- [Bing AutoSuggest Search Nuget Package](https://www.nuget.org/packages/Microsoft.Bing.Search.AutoSuggest/)
- [Bing AutoSuggest Search Dotnet SDK (source code)](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples/BingAutoSuggest) 
- Support channels: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search) or [Azure Support](https://azure.microsoft.com/en-us/support/options/)
