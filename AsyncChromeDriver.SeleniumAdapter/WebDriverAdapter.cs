using OpenQA.Selenium;
using Zu.SeleniumAdapter;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    public class WebDriverAdapter : WebDriverAdapterBase
    {
        protected Zu.Chrome.AsyncChromeDriver asyncChromeDriver;

        public WebDriverAdapter()
            : this("")
        {
        }
        public WebDriverAdapter(string profileName)
        {
            asyncChromeDriver = string.IsNullOrWhiteSpace(profileName) ? new Zu.Chrome.AsyncChromeDriver() : new Zu.Chrome.AsyncChromeDriver(profileName);
            Create(asyncChromeDriver);
        }

        public WebDriverAdapter(Zu.Chrome.AsyncChromeDriver asyncChromeDriver)
        {
            this.asyncChromeDriver = asyncChromeDriver;
            Create(asyncChromeDriver);
        }

        public WebDriverAdapter(Zu.Chrome.ChromeDriverConfig config)
        {
            this.asyncChromeDriver = new Chrome.AsyncChromeDriver(config);
            Create(asyncChromeDriver);
        }
        
        public WebDriverAdapter(DriverOptions options)
        {
            var config = ConvertDriverOptionsToChromeDriverConfig(options);
            this.asyncChromeDriver = new Chrome.AsyncChromeDriver(config);
            Create(asyncChromeDriver);
        }

        private Zu.Chrome.ChromeDriverConfig ConvertDriverOptionsToChromeDriverConfig(DriverOptions options)
        {
            var res = new Chrome.ChromeDriverConfig();
            //TODO Convert
            return res;
        }

        private void Create(Chrome.AsyncChromeDriver asyncChromeDriver)
        {
            AsyncWebDriver = new Zu.AsyncWebDriver.Remote.WebDriver(asyncChromeDriver);
            SyncWebDriver = new Zu.AsyncWebDriver.Remote.SyncWebDriver(AsyncWebDriver);
            SyncWebDriver.Open();
        }
    }
}
