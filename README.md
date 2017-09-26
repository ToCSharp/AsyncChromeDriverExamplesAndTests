### AsyncChromeDriverExamplesAndTests
Examples of AsyncChromeDriver usage.  
It is AsyncChromeDriver playground. I will experiment here.  
You may write any pull requests, any issues here. Feel free.  

[![Join the chat at https://gitter.im/AsyncWebDriver/Lobby](https://badges.gitter.im/AsyncWebDriver/Lobby.svg)](https://gitter.im/AsyncWebDriver/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


[SeleniumAdapter](https://github.com/ToCSharp/AsyncChromeDriverExamplesAndTests/tree/master/AsyncWebDriver.SeleniumAdapter) is adapter of [Selenium interfaces](https://github.com/ToCSharp/AsyncChromeDriverExamplesAndTests/tree/master/AsyncWebDriver.SeleniumAdapter/Selenium) to [SyncWebDriver](https://github.com/ToCSharp/AsyncWebDriver/tree/master/AsyncWebDriver/SyncWrapper). So we can run Selenium tests on [AsyncWebDriver](https://github.com/ToCSharp/AsyncWebDriver). [Here is Unit Tests from Selenuim](https://github.com/ToCSharp/AsyncChromeDriverExamplesAndTests/tree/master/AsyncWebDriver.SeleniumAdapter.Common.Tests), which we can run to test functionality of all projects and its connections.



## AsyncChromeDriver.SeleniumAdapter

Adapter to run Selenium tests through AsyncChromeDriver.  
It is experimental project, firstly for testing my other projects: [IAsyncWebBrowserClient](https://github.com/ToCSharp/IAsyncWebBrowserClient), [AsyncChromeDriver](https://github.com/ToCSharp/AsyncChromeDriver), [AsyncWebDriver](https://github.com/ToCSharp/AsyncWebDriver).  

### Usage

### Install AsyncChromeDriver.SeleniumAdapter via NuGet

Remove Selenium.WebDriver from NuGet References,  
Add AsyncChromeDriver.SeleniumAdapter [from NuGet](https://www.nuget.org/packages/AsyncChromeDriver.SeleniumAdapter/)
```
PM> Install-Package AsyncChromeDriver.SeleniumAdapter
```

Change 
``` 
using OpenQA.Selenium.Chrome;
to
using Zu.AsyncChromeDriver.SeleniumAdapter
```