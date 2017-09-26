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