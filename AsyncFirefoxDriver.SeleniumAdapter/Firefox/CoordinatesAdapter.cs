using System.Drawing;
using OpenQA.Selenium.Interactions.Internal;
using Zu.AsyncWebDriver.Remote;

namespace Zu.AsyncFirefoxDriver.SeleniumAdapter
{
    public class CoordinatesAdapter : ICoordinates
    {
        private SyncCoordinates coordinates;

        public CoordinatesAdapter(SyncCoordinates coordinates)
        {
            this.coordinates = coordinates;
        }

        public Point LocationOnScreen
        {
            get
            {
                try { return WebDriverConverters.ToDrawingPoint(coordinates.LocationOnScreen()); }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public Point LocationInViewport
        {
            get
            {
                try
                {
                    return WebDriverConverters.ToDrawingPoint(coordinates.LocationInViewport());
                }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public Point LocationInDom
        {
            get
            {
                try
                {
                    return WebDriverConverters.ToDrawingPoint(coordinates.LocationInDom());
                }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public object AuxiliaryLocator => coordinates.AuxiliaryLocator;
    }
}