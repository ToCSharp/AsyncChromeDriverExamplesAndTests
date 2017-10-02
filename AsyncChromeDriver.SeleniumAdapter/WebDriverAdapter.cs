using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Interactions;
using System.Collections;
using Zu.SeleniumAdapter;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    public class WebDriverAdapter : WebDriverAdapterBase
    {
        private Zu.Chrome.AsyncChromeDriver asyncChromeDriver;

        public WebDriverAdapter()
            :this(null)
        {
        }
        public WebDriverAdapter(string profileName)
        {
            asyncChromeDriver = profileName == null ? new Zu.Chrome.AsyncChromeDriver() : new Zu.Chrome.AsyncChromeDriver(profileName);
            AsyncWebDriver = new Zu.AsyncWebDriver.Remote.WebDriver(asyncChromeDriver);
            SyncWebDriver = new Zu.AsyncWebDriver.Remote.SyncWebDriver(AsyncWebDriver);
            SyncWebDriver.Open();
            //syncWebDriver.Options().Timeouts.SetImplicitWait(TimeSpan.FromMilliseconds(500));
        }
    }
}
