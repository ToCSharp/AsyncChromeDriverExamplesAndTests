using OpenQA.Selenium;
using Zu.SeleniumAdapter;

namespace Zu.AsyncFirefoxDriver.SeleniumAdapter
{
    public class WebDriverAdapter : WebDriverAdapterBase
    {
        protected Zu.Firefox.AsyncFirefoxDriver asyncFirefoxDriver;

        public WebDriverAdapter()
               : this("")
        {
        }
        public WebDriverAdapter(string profileName)
        {
            asyncFirefoxDriver = string.IsNullOrWhiteSpace(profileName) ? new Zu.Firefox.AsyncFirefoxDriver() : new Zu.Firefox.AsyncFirefoxDriver(profileName);
            Create(asyncFirefoxDriver);
        }

        public WebDriverAdapter(Zu.Firefox.AsyncFirefoxDriver asyncFirefoxDriver)
        {
            this.asyncFirefoxDriver = asyncFirefoxDriver;
            Create(asyncFirefoxDriver);
        }

        public WebDriverAdapter(WebBrowser.BasicTypes.DriverConfig config)
        {
            this.asyncFirefoxDriver = new Firefox.AsyncFirefoxDriver(config);
            Create(asyncFirefoxDriver);
        }

        public WebDriverAdapter(DriverOptions options)
        {
            var config = ConvertDriverOptionsToFirefoxDriverConfig(options);
            this.asyncFirefoxDriver = new Firefox.AsyncFirefoxDriver(config);
            Create(asyncFirefoxDriver);
        }

        private WebBrowser.BasicTypes.DriverConfig ConvertDriverOptionsToFirefoxDriverConfig(DriverOptions options)
        {
            var res = new Firefox.FirefoxDriverConfig();
            //TODO Convert
            return res;
        }

        private void Create(Firefox.AsyncFirefoxDriver asyncFirefoxDriver)
        {
            AsyncWebDriver = new Zu.AsyncWebDriver.Remote.WebDriver(asyncFirefoxDriver);
            SyncWebDriver = new Zu.AsyncWebDriver.Remote.SyncWebDriver(AsyncWebDriver);
            SyncWebDriver.Open();
        }
    }
}
