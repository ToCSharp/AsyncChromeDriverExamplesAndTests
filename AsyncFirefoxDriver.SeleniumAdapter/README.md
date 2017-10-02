## AsyncFirefoxDriver.SeleniumAdapter

Adapter to run Selenium tests through AsyncFirefoxDriver.  
It is experimental project, firstly for testing my other projects: [IAsyncWebBrowserClient](https://github.com/ToCSharp/IAsyncWebBrowserClient), [AsyncFirefoxDriver and AsyncWebDriver](https://github.com/ToCSharp/AsyncWebDriver).  

### Usage

### Install AsyncFirefoxDriver.SeleniumAdapter via NuGet

Remove Selenium.WebDriver from NuGet References,  
Add AsyncFirefoxDriver.SeleniumAdapter [from NuGet](https://www.nuget.org/packages/AsyncFirefoxDriver.SeleniumAdapter/)
```
PM> Install-Package AsyncFirefoxDriver.SeleniumAdapter
```

Change 
``` 
using OpenQA.Selenium.Firefox;
to
using Zu.AsyncFirefoxDriver.SeleniumAdapter
```