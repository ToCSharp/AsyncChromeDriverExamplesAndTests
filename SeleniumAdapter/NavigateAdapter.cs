using System;
using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;
using Zu.WebBrowser.AsyncInteractions;

namespace Zu.SeleniumAdapter
{
    public class NavigateAdapter : OpenQA.Selenium.INavigation
    {
        private SyncNavigation syncNavigation;

        public NavigateAdapter(SyncNavigation syncNavigation)
        {
            this.syncNavigation = syncNavigation;
        }

        public void Back()
        {
            try
            {
                syncNavigation.Back();
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public void Forward()
        {
            try
            {
                syncNavigation.Forward();
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public void GoToUrl(string url)
        {
            try
            {
                syncNavigation.GoToUrl(url);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public void GoToUrl(Uri url)
        {
            try
            {
                syncNavigation.GoToUrl(url);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public void Refresh()
        {
            try
            {
                syncNavigation.Refresh();
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }
    }
}