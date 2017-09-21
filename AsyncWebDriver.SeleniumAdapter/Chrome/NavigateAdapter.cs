using System;
using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;
using Zu.WebBrowser.AsyncInteractions;

namespace AsyncWebDriver.SeleniumAdapter.Chrome
{
    internal class NavigateAdapter : OpenQA.Selenium.INavigation
    {
        private SyncNavigation syncNavigation;

        public NavigateAdapter(SyncNavigation syncNavigation)
        {
            this.syncNavigation = syncNavigation;
        }

        public void Back()
        {
            syncNavigation.Back();
        }

        public void Forward()
        {
            syncNavigation.Forward();
        }

        public void GoToUrl(string url)
        {
            syncNavigation.GoToUrl(url);
        }

        public void GoToUrl(Uri url)
        {
            syncNavigation.GoToUrl(url);
        }

        public void Refresh()
        {
            syncNavigation.Refresh();
        }
    }
}