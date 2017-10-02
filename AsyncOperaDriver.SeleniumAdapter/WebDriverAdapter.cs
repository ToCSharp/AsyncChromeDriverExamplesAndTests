using Zu.SeleniumAdapter;

namespace Zu.AsyncOperaDriver.SeleniumAdapter
{
    public class WebDriverAdapter : WebDriverAdapterBase
    {
        private Zu.Opera.AsyncOperaDriver asyncOperaDriver;

        public WebDriverAdapter()
            :this(null)
        {
        }
        public WebDriverAdapter(string profileName)
        {
            asyncOperaDriver = profileName == null ? new Zu.Opera.AsyncOperaDriver() : new Zu.Opera.AsyncOperaDriver(profileName);
            AsyncWebDriver = new Zu.AsyncWebDriver.Remote.WebDriver(asyncOperaDriver);
            SyncWebDriver = new Zu.AsyncWebDriver.Remote.SyncWebDriver(AsyncWebDriver);
            SyncWebDriver.Open();
            //syncWebDriver.Options().Timeouts.SetImplicitWait(TimeSpan.FromMilliseconds(500));
        }
    }
}
