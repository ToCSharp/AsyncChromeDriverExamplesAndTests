using OpenQA.Selenium;

namespace Zu.AsyncFirefoxDriver.SeleniumAdapter
{
    public class FirefoxDriver : WebDriverAdapter
    {
        public FirefoxDriver()
               : this("")
        {
        }
        public FirefoxDriver(string profileName)
            :base(profileName)
        {
        }

        public FirefoxDriver(Zu.Firefox.AsyncFirefoxDriver asyncFirefoxDriver)
              : base(asyncFirefoxDriver)
        {
        }

        public FirefoxDriver(WebBrowser.BasicTypes.DriverConfig config)
                  : base(config)
        {
        }

        public FirefoxDriver(DriverOptions options)
                 : base(options)
        {
        }

        /// <summary>
        /// The name of the ICapabilities setting to use to define a custom Firefox profile.
        /// </summary>
        public static readonly string ProfileCapabilityName = "firefox_profile";

        /// <summary>
        /// The name of the ICapabilities setting to use to define a custom location for the
        /// Firefox executable.
        /// </summary>
        public static readonly string BinaryCapabilityName = "firefox_binary";

        /// <summary>
        /// The default port on which to communicate with the Firefox extension.
        /// </summary>
        public static readonly int DefaultPort = 7055;

        /// <summary>
        /// Indicates whether native events is enabled by default for this platform.
        /// </summary>
        public static readonly bool DefaultEnableNativeEvents = OpenQA.Selenium.Platform.CurrentPlatform.IsPlatformType(OpenQA.Selenium.PlatformType.Windows);

        /// <summary>
        /// Indicates whether the driver will accept untrusted SSL certificates.
        /// </summary>
        public static readonly bool AcceptUntrustedCertificates = true;

        /// <summary>
        /// Indicates whether the driver assume the issuer of untrusted certificates is untrusted.
        /// </summary>
        public static readonly bool AssumeUntrustedCertificateIssuer = true;

    }
}
