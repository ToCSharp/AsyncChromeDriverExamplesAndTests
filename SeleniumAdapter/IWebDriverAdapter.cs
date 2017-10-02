using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;

namespace Zu.SeleniumAdapter
{
    public interface IWebDriverAdapter: IWebDriver, ISearchContext, IJavaScriptExecutor, IFindsById, IFindsByClassName, IFindsByLinkText, IFindsByName, IFindsByTagName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, ITakesScreenshot, IHasInputDevices, IHasWebStorage, IHasLocationContext, IHasApplicationCache, IActionExecutor
    {

    }
}