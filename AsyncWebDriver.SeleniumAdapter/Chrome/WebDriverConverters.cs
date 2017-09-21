using System;
using System.Collections.Generic;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Zu.AsyncWebDriver;
using Zu.WebBrowser.BasicTypes;

namespace AsyncWebDriver.SeleniumAdapter.Chrome
{
    public class WebDriverConverters
    {
        public static Zu.AsyncWebDriver.By By(OpenQA.Selenium.By by)
        {
            var description = by.ToString();
            if (description.StartsWith("By.Id: ")) return Zu.AsyncWebDriver.By.Id(description.Substring("By.Id: ".Length));
            if (description.StartsWith("By.LinkText: ")) return Zu.AsyncWebDriver.By.LinkText(description.Substring("By.LinkText: ".Length));
            if (description.StartsWith("By.Name: ")) return Zu.AsyncWebDriver.By.Name(description.Substring("By.Name: ".Length));
            if (description.StartsWith("By.XPath: ")) return Zu.AsyncWebDriver.By.XPath(description.Substring("By.XPath: ".Length));
            if (description.StartsWith("By.ClassName[Contains]: ")) return Zu.AsyncWebDriver.By.ClassName(description.Substring("By.ClassName[Contains]: ".Length));
            if (description.StartsWith("By.PartialLinkText: ")) return Zu.AsyncWebDriver.By.PartialLinkText(description.Substring("By.PartialLinkText: ".Length));
            if (description.StartsWith("By.TagName: ")) return Zu.AsyncWebDriver.By.TagName(description.Substring("By.TagName: ".Length));
            if (description.StartsWith("By.CssSelector: ")) return Zu.AsyncWebDriver.By.CssSelector(description.Substring("By.CssSelector: ".Length));
            throw new NotSupportedException(description);
        }

        internal static OpenQA.Selenium.Screenshot SeleniumScreenshot(Zu.WebBrowser.BasicTypes.Screenshot screenshot)
        {
            return new OpenQA.Selenium.Screenshot(screenshot.AsBase64EncodedString) ;
        }

        internal static Point ToDrawingPoint(WebPoint webPoint)
        {
            return new Point(webPoint.X, webPoint.Y);
        }

        internal static IList<Zu.WebBrowser.BasicTypes.ActionSequence> SeleniumActionSequenceList(IList<OpenQA.Selenium.Interactions.ActionSequence> actionSequenceList)
        {
            throw new NotImplementedException();
        }
    }
}