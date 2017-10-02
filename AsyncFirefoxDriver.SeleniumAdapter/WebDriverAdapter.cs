using Zu.SeleniumAdapter;

namespace Zu.AsyncFirefoxDriver.SeleniumAdapter
{
    public class WebDriverAdapter : WebDriverAdapterBase
    {
        private Zu.Firefox.AsyncFirefoxDriver asyncFirefoxDriver;

        public WebDriverAdapter()
            :this(null)
        {

        }

        public WebDriverAdapter(string profileName)
        {
            asyncFirefoxDriver = profileName == null ? new Zu.Firefox.AsyncFirefoxDriver() : new Zu.Firefox.AsyncFirefoxDriver(profileName);
            AsyncWebDriver = new Zu.AsyncWebDriver.Remote.WebDriver(asyncFirefoxDriver);
            SyncWebDriver = new Zu.AsyncWebDriver.Remote.SyncWebDriver(AsyncWebDriver);
            SyncWebDriver.Open();
            //syncWebDriver.Options().Timeouts.SetImplicitWait(TimeSpan.FromMilliseconds(500));
        }
    }
}
