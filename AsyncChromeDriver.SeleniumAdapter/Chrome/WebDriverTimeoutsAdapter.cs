using System;
using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    internal class WebDriverTimeoutsAdapter : OpenQA.Selenium.ITimeouts
    {
        private SyncTimeouts timeouts;

        public WebDriverTimeoutsAdapter(SyncTimeouts timeouts)
        {
            this.timeouts = timeouts;
        }


        public TimeSpan ImplicitWait
        {
            get => timeouts.GetImplicitWait();
            set => timeouts.SetImplicitWait(value);
        }
        public TimeSpan AsynchronousJavaScript
        {
            get => timeouts.GetAsynchronousJavaScript();
            set => timeouts.SetAsynchronousJavaScript(value);
        }
        public TimeSpan PageLoad
        {
            get => timeouts.GetPageLoad();
            set => timeouts.SetPageLoad(value);
        }

        public ITimeouts ImplicitlyWait(TimeSpan timeToWait)
        {
            throw new NotImplementedException();
        }

        public ITimeouts SetPageLoadTimeout(TimeSpan timeToWait)
        {
            throw new NotImplementedException();
        }

        public ITimeouts SetScriptTimeout(TimeSpan timeToWait)
        {
            throw new NotImplementedException();
        }
    }
}