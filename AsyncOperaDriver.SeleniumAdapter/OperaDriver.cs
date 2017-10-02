using OpenQA.Selenium;

namespace Zu.AsyncOperaDriver.SeleniumAdapter
{
    public class OperaDriver: WebDriverAdapter
    {
        public OperaDriver()
            : this("")
        {
        }
        public OperaDriver(string profileName)
            :base(profileName)
        {
        }

        public OperaDriver(Zu.Opera.AsyncOperaDriver asyncOperaDriver)
                : base(asyncOperaDriver)
        {
        }

        public OperaDriver(WebBrowser.BasicTypes.DriverConfig config)
                 : base(config)
        {
        }

        public OperaDriver(DriverOptions options)
                  : base(options)
        {
        }
    }
}
