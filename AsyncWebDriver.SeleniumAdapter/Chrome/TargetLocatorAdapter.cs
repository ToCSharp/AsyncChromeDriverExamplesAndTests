using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;

namespace AsyncWebDriver.SeleniumAdapter.Chrome
{
    public class TargetLocatorAdapter : ITargetLocator
    {
        private SyncRemoteTargetLocator syncRemoteTargetLocator;
        private WebDriverAdapter webDriver;

        public TargetLocatorAdapter(SyncRemoteTargetLocator syncRemoteTargetLocator, WebDriverAdapter webDriver)
        {
            this.syncRemoteTargetLocator = syncRemoteTargetLocator;
            this.webDriver = webDriver;
        }

        public IWebElement ActiveElement()
        {
            return new WebElementAdapter(syncRemoteTargetLocator.ActiveElement());
        }

        public IAlert Alert()
        {
            return new Alert(syncRemoteTargetLocator.Alert());
        }

        public IWebDriver DefaultContent()
        {
            syncRemoteTargetLocator.DefaultContent();
            return webDriver;
        }

        public IWebDriver Frame(int frameIndex)
        {
            syncRemoteTargetLocator.DefaultContent();
            return webDriver;
        }

        public IWebDriver Frame(string frameName)
        {
            syncRemoteTargetLocator.DefaultContent();
            return webDriver;
        }

        public IWebDriver Frame(IWebElement frameElement)
        {
            syncRemoteTargetLocator.DefaultContent();
            return webDriver;
        }

        public IWebDriver ParentFrame()
        {
            syncRemoteTargetLocator.DefaultContent();
            return webDriver;
        }

        public IWebDriver Window(string windowName)
        {
            syncRemoteTargetLocator.DefaultContent();
            return webDriver;
        }
    }
}