using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;
using System.Linq;

namespace AsyncWebDriver.SeleniumAdapter.Chrome
{
    internal class WebElement : IWebElement
    {
        private SyncWebElement syncWebElement;

        public WebElement(SyncWebElement syncWebElement)
        {
            this.syncWebElement = syncWebElement;
        }

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
            return new WebElement(syncWebElement.FindElement(WebDriverConverters.By(by)));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return new ReadOnlyCollection<IWebElement>(syncWebElement.FindElements(WebDriverConverters.By(by)).Select(v => (IWebElement)new WebElement(v)).ToList());
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

        public void SendKeys(string text)
        {
            syncWebElement.SendKeys(text);
        }

        public void Submit()
        {
            syncWebElement.Submit();
        }
    }
}