using OpenQA.Selenium;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    public class ChromeDriver: WebDriverAdapter
    {
        public ChromeDriver()
            : this("")
        {
        }
        public ChromeDriver(string profileName)
            :base(profileName)
        {
        }

        public ChromeDriver(Zu.Chrome.AsyncChromeDriver asyncChromeDriver)
                : base(asyncChromeDriver)
        {
        }

        public ChromeDriver(Zu.Chrome.ChromeDriverConfig config)
                 : base(config)
        {
        }

        public ChromeDriver(DriverOptions options)
                  : base(options)
        {
        }
    }
}
