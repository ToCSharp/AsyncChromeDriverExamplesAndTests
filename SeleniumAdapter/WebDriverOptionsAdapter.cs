using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;

namespace Zu.SeleniumAdapter
{
    public class WebDriverOptionsAdapter : OpenQA.Selenium.IOptions
    {
        private SyncOptions syncOptions;

        public WebDriverOptionsAdapter(SyncOptions syncOptions)
        {
            this.syncOptions = syncOptions;
        }

        public ICookieJar Cookies => throw new System.NotImplementedException();

        public IWindow Window => throw new System.NotImplementedException();

        public ILogs Logs => throw new System.NotImplementedException();

        public ITimeouts Timeouts()
        {
            return new WebDriverTimeoutsAdapter(syncOptions.Timeouts);
        }
    }
}