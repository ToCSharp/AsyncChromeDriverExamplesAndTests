using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;

namespace AsyncWebDriver.SeleniumAdapter.Chrome
{
    internal class TargetLocator : ITargetLocator
    {
        private SyncRemoteTargetLocator syncRemoteTargetLocator;
        private WebDriver webDriver;

        public TargetLocator(SyncRemoteTargetLocator syncRemoteTargetLocator, WebDriver webDriver)
        {
            this.syncRemoteTargetLocator = syncRemoteTargetLocator;
            this.webDriver = webDriver;
        }

        public IWebElement ActiveElement()
        {
            return new WebElement(syncRemoteTargetLocator.ActiveElement());
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