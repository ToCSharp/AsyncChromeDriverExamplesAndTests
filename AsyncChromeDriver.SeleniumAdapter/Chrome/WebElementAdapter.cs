using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;
using System.Linq;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Interactions.Internal;
using System.Collections.Generic;
using System.Threading;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    public class WebElementAdapter : IWebElement, IFindsByLinkText, IFindsById, IFindsByName, IFindsByTagName, IFindsByClassName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, IWrapsDriver, ILocatable, ITakesScreenshot, IWebElementReference
    {
        private SyncWebElement syncWebElement;
        private WebDriverAdapter driver;

        public WebElementAdapter(SyncWebElement syncWebElement, WebDriverAdapter driver)
        {
            this.syncWebElement = syncWebElement;
            this.driver = driver;
        }

        public SyncWebElement GetSyncWebElement() => syncWebElement;

        public string TagName
        {
            get
            {
                try
                {
                    return syncWebElement.TagName;
                }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public string Text
        {
            get
            {
                try
                {
                    return syncWebElement.Text;
                }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public bool Enabled
        {
            get
            {
                try
                {
                    return syncWebElement.Enabled;
                }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public bool Selected
        {
            get
            {
                try
                {
                    return syncWebElement.Selected;
                }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public Point Location
        {
            get
            {
                try
                {
                    var l = syncWebElement.Location;
                    return new Point(l.X, l.Y);
                }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public Size Size
        {
            get
            {
                try
                {
                    var s = syncWebElement.Size;
                    return new Size(s.Width, s.Height);
                }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public bool Displayed
        {
            get
            {
                try { return syncWebElement.Displayed; }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public IWebDriver WrappedDriver => driver;

        public Point LocationOnScreenOnceScrolledIntoView
        {
            get
            {
                try { return WebDriverConverters.ToDrawingPoint(syncWebElement.GetLocationOnScreenOnceScrolledIntoView()); }
                catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
                {
                    throw WebDriverConverters.ToSeleniumException(webDriverException);
                }
                catch { throw; }
            }
        }

        public ICoordinates Coordinates => new CoordinatesAdapter(syncWebElement.Coordinates);

        public string ElementReferenceId => syncWebElement.Id;
        public string Id => syncWebElement.Id;
        private string elementId => syncWebElement.Id;

        public void Clear()
        {
            try
            {
                syncWebElement.Clear();
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public void Click()
        {
            try
            {
                syncWebElement.Click();
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebElement FindElement(By by)
        {
            try
            {
                return new WebElementAdapter(syncWebElement.FindElement(WebDriverConverters.By(by)), driver);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebElement FindElementByClassName(string className)
        {
            try
            {
                return new WebElementAdapter(syncWebElement.FindElementByClassName(className), driver);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebElement FindElementByCssSelector(string cssSelector)
        {
            try
            {
                return new WebElementAdapter(syncWebElement.FindElementByCssSelector(cssSelector), driver);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebElement FindElementById(string id)
        {
            try
            {
                return new WebElementAdapter(syncWebElement.FindElementById(id), driver);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebElement FindElementByLinkText(string linkText)
        {
            try
            {
                return new WebElementAdapter(syncWebElement.FindElementByLinkText(linkText), driver);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebElement FindElementByName(string name)
        {
            try
            {
                return new WebElementAdapter(syncWebElement.FindElementByName(name), driver);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebElement FindElementByPartialLinkText(string partialLinkText)
        {
            try
            {
                return new WebElementAdapter(syncWebElement.FindElementByPartialLinkText(partialLinkText), driver);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebElement FindElementByTagName(string tagName)
        {
            try
            {
                return new WebElementAdapter(syncWebElement.FindElementByTagName(tagName), driver);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IWebElement FindElementByXPath(string xpath)
        {
            try
            {
                return new WebElementAdapter(syncWebElement.FindElementByXPath(xpath), driver);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            try
            {
                return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElements(WebDriverConverters.By(by)).Select(v => (IWebElement)new WebElementAdapter(v, driver)).ToList());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public ReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            try
            {
                return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByClassName(className).Select(v => (IWebElement)new WebElementAdapter(v, driver)).ToList());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public ReadOnlyCollection<IWebElement> FindElementsByCssSelector(string cssSelector)
        {
            try
            {
                return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByCssSelector(cssSelector).Select(v => (IWebElement)new WebElementAdapter(v, driver)).ToList());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public ReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            try
            {
                return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsById(id).Select(v => (IWebElement)new WebElementAdapter(v, driver)).ToList());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText)
        {
            try
            {
                return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByLinkText(linkText).Select(v => (IWebElement)new WebElementAdapter(v, driver)).ToList());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public ReadOnlyCollection<IWebElement> FindElementsByName(string name)
        {
            try
            {
                return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByName(name).Select(v => (IWebElement)new WebElementAdapter(v, driver)).ToList());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public ReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(string partialLinkText)
        {
            try
            {
                return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByPartialLinkText(partialLinkText).Select(v => (IWebElement)new WebElementAdapter(v, driver)).ToList());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public ReadOnlyCollection<IWebElement> FindElementsByTagName(string tagName)
        {
            try
            {
                return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByTagName(tagName).Select(v => (IWebElement)new WebElementAdapter(v, driver)).ToList());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public ReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath)
        {
            try
            {
                return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElementsByXPath(xpath).Select(v => (IWebElement)new WebElementAdapter(v, driver)).ToList());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public string GetAttribute(string attributeName)
        {
            try
            {
                var res = syncWebElement.GetProperty(attributeName);
                return res ?? syncWebElement.GetAttribute(attributeName);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public string GetCssValue(string propertyName)
        {
            try
            {
                return syncWebElement.GetCssValue(propertyName);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public string GetProperty(string propertyName)
        {
            try
            {
                return syncWebElement.GetProperty(propertyName);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public Screenshot GetScreenshot()
        {
            try
            {
                return WebDriverConverters.SeleniumScreenshot(syncWebElement.GetScreenshot());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public void SendKeys(string text)
        {
            try
            {
                syncWebElement.SendKeys(text);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public void Submit()
        {
            try
            {
                syncWebElement.Submit();
                //TODO remove Sleep
                Thread.Sleep(100);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> elementDictionary = new Dictionary<string, object>();
            elementDictionary.Add("element-6066-11e4-a52e-4f735466cecf", this.ElementReferenceId);
            return elementDictionary;
        }

        /// <summary>
        /// Method to get the hash code of the element
        /// </summary>
        /// <returns>Integer of the hash code for the element</returns>
        public override int GetHashCode()
        {
            return this.elementId.GetHashCode();
        }

        /// <summary>
        /// Compares if two elements are equal
        /// </summary>
        /// <param name="obj">Object to compare against</param>
        /// <returns>A boolean if it is equal or not</returns>
        public override bool Equals(object obj)
        {
            IWebElement other = obj as IWebElement;
            if (other == null)
            {
                return false;
            }

            //IWrapsElement objAsWrapsElement = obj as IWrapsElement;
            //if (objAsWrapsElement != null)
            //{
            //    other = objAsWrapsElement.WrappedElement;
            //}

            WebElementAdapter otherAsElement = other as WebElementAdapter;
            if (otherAsElement == null)
            {
                return false;
            }

            if (this.elementId == otherAsElement.Id)
            {
                // For drivers that implement ID equality, we can check for equal IDs
                // here, and expect them to be equal. There is a potential danger here
                // where two different elements are assigned the same ID.
                return true;
            }

            return false;
            //Dictionary<string, object> parameters = new Dictionary<string, object>();
            //parameters.Add("id", this.Id);
            //parameters.Add("other", otherAsElement.Id);

            //Response response = this.Execute(DriverCommand.ElementEquals, parameters);
            //object value = response.Value;
            //return value != null && value is bool && (bool)value;
        }

        /// <summary>
        /// Converts an object into an object that represents an element for the wire protocol.
        /// </summary>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that represents an element in the wire protocol.</returns>
        Dictionary<string, object> IWebElementReference.ToDictionary()
        {
            Dictionary<string, object> elementDictionary = new Dictionary<string, object>();
            elementDictionary.Add("element-6066-11e4-a52e-4f735466cecf", this.elementId);
            return elementDictionary;
        }
    }
}