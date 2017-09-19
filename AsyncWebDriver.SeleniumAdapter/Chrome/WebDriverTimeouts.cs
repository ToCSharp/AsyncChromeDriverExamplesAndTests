using System;

namespace AsyncWebDriver.SeleniumAdapter.Chrome
{
    internal class WebDriverTimeouts : OpenQA.Selenium.ITimeouts
    {
        private Zu.WebBrowser.BrowserOptions.ITimeouts timeouts;

        public WebDriverTimeouts(Zu.WebBrowser.BrowserOptions.ITimeouts timeouts)
        {
            this.timeouts = timeouts;
        }

        public TimeSpan ImplicitWait { get; set; }
        public TimeSpan AsynchronousJavaScript { get; set; }
        public TimeSpan PageLoad { get; set; }

        public OpenQA.Selenium.ITimeouts ImplicitlyWait(TimeSpan timeToWait)
        {
            ImplicitWait = timeToWait;
            return this;
        }

        public OpenQA.Selenium.ITimeouts SetPageLoadTimeout(TimeSpan timeToWait)
        {
            PageLoad = timeToWait;
            return this;
        }

        public OpenQA.Selenium.ITimeouts SetScriptTimeout(TimeSpan timeToWait)
        {
            AsynchronousJavaScript = timeToWait;
            return this;
        }
    }
}