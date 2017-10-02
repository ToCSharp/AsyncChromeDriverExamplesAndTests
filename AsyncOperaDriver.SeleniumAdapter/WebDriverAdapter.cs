using OpenQA.Selenium;
using Zu.SeleniumAdapter;

namespace Zu.AsyncOperaDriver.SeleniumAdapter
{
    public class WebDriverAdapter : WebDriverAdapterBase
    {
        protected Zu.Opera.AsyncOperaDriver asyncOperaDriver;

        public WebDriverAdapter()
            : this("")
        {
        }
        public WebDriverAdapter(string profileName)
        {
            asyncOperaDriver = string.IsNullOrWhiteSpace(profileName) ? new Zu.Opera.AsyncOperaDriver() : new Zu.Opera.AsyncOperaDriver(profileName);
            Create(asyncOperaDriver);
        }

        public WebDriverAdapter(Zu.Opera.AsyncOperaDriver asyncOperaDriver)
        {
            this.asyncOperaDriver = asyncOperaDriver;
            Create(asyncOperaDriver);
        }

        public WebDriverAdapter(WebBrowser.BasicTypes.DriverConfig config)
        {
            this.asyncOperaDriver = new Opera.AsyncOperaDriver(config);
            Create(asyncOperaDriver);
        }

        public WebDriverAdapter(DriverOptions options)
        {
            var config = ConvertDriverOptionsToOperaDriverConfig(options);
            this.asyncOperaDriver = new Opera.AsyncOperaDriver(config);
            Create(asyncOperaDriver);
        }

        private WebBrowser.BasicTypes.DriverConfig ConvertDriverOptionsToOperaDriverConfig(DriverOptions options)
        {
            var res = new WebBrowser.BasicTypes.DriverConfig();
            //TODO Convert
            return res;
        }

        private void Create(Opera.AsyncOperaDriver asyncChromeDriver)
        {
            AsyncWebDriver = new Zu.AsyncWebDriver.Remote.WebDriver(asyncChromeDriver);
            SyncWebDriver = new Zu.AsyncWebDriver.Remote.SyncWebDriver(AsyncWebDriver);
            SyncWebDriver.Open();
        }
    }
}
