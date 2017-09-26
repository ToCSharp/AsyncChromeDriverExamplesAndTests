using System.Drawing;
using OpenQA.Selenium.Interactions.Internal;
using Zu.AsyncWebDriver.Remote;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    public class CoordinatesAdapter : ICoordinates
    {
        private SyncCoordinates coordinates;

        public CoordinatesAdapter(SyncCoordinates coordinates)
        {
            this.coordinates = coordinates;
        }

        public Point LocationOnScreen => WebDriverConverters.ToDrawingPoint(coordinates.LocationOnScreen());

        public Point LocationInViewport => WebDriverConverters.ToDrawingPoint(coordinates.LocationInViewport());

        public Point LocationInDom => WebDriverConverters.ToDrawingPoint(coordinates.LocationInDom());

        public object AuxiliaryLocator => coordinates.AuxiliaryLocator;
    }
}