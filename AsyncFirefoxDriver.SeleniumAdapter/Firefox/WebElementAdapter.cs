using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;
using System.Linq;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Interactions.Internal;
using System.Collections.Generic;

namespace Zu.AsyncFirefoxDriver.SeleniumAdapter
{
    public class WebElementAdapter : IWebElement, IFindsByLinkText, IFindsById, IFindsByName, IFindsByTagName, IFindsByClassName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, IWrapsDriver, ILocatable, ITakesScreenshot, IWebElementReference
    {
        private SyncWebElement syncWebElement;

        public WebElementAdapter(SyncWebElement syncWebElement)
        {
            this.syncWebElement = syncWebElement;
        }

        public SyncWebElement GetSyncWebElement() => syncWebElement;

        public string TagName => syncWebElement.TagName;

        public string Text => syncWebElement.Text;

        public bool Enabled => syncWebElement.Enabled;

        public bool Selected => syncWebElement.Selected;

        public Point Location
        {
            get
            {
                var l = syncWebElement.Location;
                return new Point(l.X, l.Y);
            }
        }

        public Size Size
        {
            get
            {
                var s = syncWebElement.Size;
                return new Size(s.Width, s.Height);
            }
        }

        public bool Displayed => syncWebElement.Displayed;

        public IWebDriver WrappedDriver => throw new System.NotImplementedException();

        public Point LocationOnScreenOnceScrolledIntoView => WebDriverConverters.ToDrawingPoint(syncWebElement.GetLocationOnScreenOnceScrolledIntoView());

        public ICoordinates Coordinates => new CoordinatesAdapter(syncWebElement.Coordinates);

        public string ElementReferenceId => syncWebElement.Id;

        public void Clear()
        {
            syncWebElement.Clear();
        }

        public void Click()
        {
            syncWebElement.Click();
        }

        public IWebElement FindElement(By by)
        {
            return new WebElementAdapter(syncWebElement.FindElement(WebDriverConverters.By(by)));
        }

        public IWebElement FindElementByClassName(string className)
        {
            return new WebElementAdapter(syncWebElement.FindElementByClassName(className));
        }

        public IWebElement FindElementByCssSelector(string cssSelector)
        {
            return new WebElementAdapter(syncWebElement.FindElementByCssSelector(cssSelector));
        }

        public IWebElement FindElementById(string id)
        {
            return new WebElementAdapter(syncWebElement.FindElementById(id));
        }

        public IWebElement FindElementByLinkText(string linkText)
        {
            return new WebElementAdapter(syncWebElement.FindElementByLinkText(linkText));
        }

        public IWebElement FindElementByName(string name)
        {
            return new WebElementAdapter(syncWebElement.FindElementByName(name));
        }

        public IWebElement FindElementByPartialLinkText(string partialLinkText)
        {
            return new WebElementAdapter(syncWebElement.FindElementByPartialLinkText(partialLinkText));
        }

        public IWebElement FindElementByTagName(string tagName)
        {
            return new WebElementAdapter(syncWebElement.FindElementByTagName(tagName));
        }

        public IWebElement FindElementByXPath(string xpath)
        {
            return new WebElementAdapter(syncWebElement.FindElementByXPath(xpath));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElements(WebDriverConverters.By(by)).Select(v => (IWebElement)new WebElementAdapter(v)).ToList());
        }

        public ReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByClassName(className).Select(v => (IWebElement)new WebElementAdapter(v)).ToList());
        }

        public ReadOnlyCollection<IWebElement> FindElementsByCssSelector(string cssSelector)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByCssSelector(cssSelector).Select(v => (IWebElement)new WebElementAdapter(v)).ToList());
        }

        public ReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsById(id).Select(v => (IWebElement)new WebElementAdapter(v)).ToList());
        }

        public ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByLinkText(linkText).Select(v => (IWebElement)new WebElementAdapter(v)).ToList());
        }

        public ReadOnlyCollection<IWebElement> FindElementsByName(string name)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByName(name).Select(v => (IWebElement)new WebElementAdapter(v)).ToList());
        }

        public ReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(string partialLinkText)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByPartialLinkText(partialLinkText).Select(v => (IWebElement)new WebElementAdapter(v)).ToList());
        }

        public ReadOnlyCollection<IWebElement> FindElementsByTagName(string tagName)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByTagName(tagName).Select(v => (IWebElement)new WebElementAdapter(v)).ToList());
        }

        public ReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByXPath(xpath).Select(v => (IWebElement)new WebElementAdapter(v)).ToList());
        }

        public string GetAttribute(string attributeName)
        {
            return syncWebElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return syncWebElement.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return syncWebElement.GetProperty(propertyName);
        }

        public Screenshot GetScreenshot()
        {
            return WebDriverConverters.SeleniumScreenshot(syncWebElement.GetScreenshot());
        }

        public void SendKeys(string text)
        {
            syncWebElement.SendKeys(text);
        }

        public void Submit()
        {
            syncWebElement.Submit();
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> elementDictionary = new Dictionary<string, object>();
            elementDictionary.Add("element-6066-11e4-a52e-4f735466cecf", this.ElementReferenceId);
            return elementDictionary;
        }
    }
}