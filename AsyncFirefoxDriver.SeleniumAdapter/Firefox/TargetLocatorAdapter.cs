using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;

namespace Zu.AsyncFirefoxDriver.SeleniumAdapter
{
    public class TargetLocatorAdapter : ITargetLocator
    {
        private SyncRemoteTargetLocator syncRemoteTargetLocator;
        private WebDriverAdapter webDriver;

        public TargetLocatorAdapter(SyncRemoteTargetLocator syncRemoteTargetLocator, WebDriverAdapter webDriver)
        {
            this.syncRemoteTargetLocator = syncRemoteTargetLocator;
            this.webDriver = webDriver;
        }

        public IWebElement ActiveElement()
        {
            try
            {
                return new WebElementAdapter(syncRemoteTargetLocator.ActiveElement());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IAlert Alert()
        {
            try
            {
                return new Alert(syncRemoteTargetLocator.Alert());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebDriver DefaultContent()
        {
            try
            {
                syncRemoteTargetLocator.DefaultContent();
                return webDriver;
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebDriver Frame(int frameIndex)
        {
            try
            {
                syncRemoteTargetLocator.Frame(frameIndex);
                return webDriver;
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebDriver Frame(string frameName)
        {
            try
            {
                syncRemoteTargetLocator.Frame(frameName);
                return webDriver;
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebDriver Frame(IWebElement frameElement)
        {
            try
            {
                syncRemoteTargetLocator.Frame(((WebElementAdapter)frameElement).GetSyncWebElement());
                return webDriver;
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebDriver ParentFrame()
        {
            try
            {
                syncRemoteTargetLocator.ParentFrame();
                return webDriver;
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebDriver Window(string windowName)
        {
            try
            {
                syncRemoteTargetLocator.Window(windowName);
                return webDriver;
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }
    }
}