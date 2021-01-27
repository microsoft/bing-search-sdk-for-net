

# The Bing All Search SDK Samples

This sample will show you how to get up and running using the Bing Search SDKs. This example will cover some usecases and hopefully express best practices for interacting with the data from the Bing Search APIs. Examples are included for these offerings: Bing Web Search, Bing Image Search, Bing Video Search, Bing News Search, Bing Custom Search, Bing Entity Search, and Bing Spell Check. For more information on the Bing Search APIs, you can navigate to: https://aka.ms/bingapisignup. 

If you are interested in a specific Bing Search API, please check out the corresponding subfolder. This sample is meant for checking multiple samples at the same time and references packages for all the APIs.

## Features

This sample references the all Bing Search SDKs, which is the complete list of packages for the v7 version of Bing APIs. All-in-one package - including all the Bing Search APIs on Bing - will be available in future.

This example provides sample usecases of the the [Bing Search APIs v7](https://github.com/microsoft/bing-search-sdk-for-net/tree/main/samples/BingSearchSamples) using the below packages:


For ease, these packages are comntained in the TempPackage folder. 

## Getting Started

### Prerequisites

- Visual Studio 2017. If required, you can download free community version from here: https://www.visualstudio.com/vs/community/.
- A Bing API key is required to authenticate SDK calls. You can [sign up here](hhttps://aka.ms/bingapisignup) for the **free** trial key. This trial key is good for 30 days with 3 calls per second. **Alternately**, for production scenario, you can buy access key from here: https://aka.ms/bingapisignup. While buying access key you may want to consider which tier is appropriate for you. More information is [here](https://aka.ms/bingapisignup). 
- .NET core SDK (ability to run .netcore 1.1 apps). You can get CORE, Framework, and Runtime from here: https://www.microsoft.com/net/download/. 
- You will need Custom Config ID, if you are running the Bing Custom Search sample. You can get this from customsearch.ai by creating your own custom search instance. Here is a step-by-step guide to create a custom search instance: https://blogs.bing.com/search-quality-insights/2017-12/build-your-ads-free-search-engine-with-bing-custom-search.

### Quickstart

To get the Bing Search sample running locally, follow these steps:

1. git clone https://github.com/microsoft/bing-search-sdk-for-net.git
2. Open the project from Visual Studio 2017
3. You need not install individual packages as they are contained in the tempPackage folder. If these don't work you can get the latest by: npm install <packages as mentioned above in Features section> from Tools > Nuget Package Manager > Package Manager Console. **Alternately**, you can go to Project > Manage Nuget Packages and search for individual packages in the "Browse" tab, and click on "Install". 
4. Click on "bing-search-dotnet" for debug/release version from the top of Visual Studio. **Alternately** you can build and run solution in separate steps.

### Note: 
Change TargetFramework in bing-search-dotnet.csproj to “netcoreapp1.1” if you have .NET Framework version as 2.1.2. [ Older ] as follows:

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
- Bing Search Reference Documents: Please check documentation of the corresponding API
- Nuget Packages: As mentioned in "Features" section
- Bing Search Dotnet SDKs (source code): Please check corresponding entry in https://github.com/microsoft/bing-search-sdk-for-net
- Support channels: [Stack Overflow](https://stackoverflow.com/questions/tagged/bing-search) or [Azure Support](https://azure.microsoft.com/en-us/support/options/)
