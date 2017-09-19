namespace AsyncWebDriver.SeleniumAdapter.Chrome
{
    internal class WebDriverOptions : OpenQA.Selenium.IOptions
    {
        private Zu.WebBrowser.BrowserOptions.IOptions options;

        public WebDriverOptions(Zu.WebBrowser.BrowserOptions.IOptions options)
        {
            this.options = options;
        }

        public OpenQA.Selenium.ICookieJar Cookies => throw new System.NotImplementedException();

        public OpenQA.Selenium.IWindow Window => throw new System.NotImplementedException();

        public OpenQA.Selenium.ILogs Logs => throw new System.NotImplementedException();

        public OpenQA.Selenium.ITimeouts Timeouts()
        {
            return new WebDriverTimeouts(options.Timeouts);
        }
    }
}