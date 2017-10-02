using System;
using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;

namespace Zu.SeleniumAdapter
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
            get
            {
                try
                {
                    return timeouts.GetImplicitWait();
                }
                catch { throw; }
            }
            set
            {
                try
                {
                    timeouts.SetImplicitWait(value);
                }
                catch { throw; }
            }
        }
        public TimeSpan AsynchronousJavaScript
        {
            get
            {
                try
                {
                    return timeouts.GetAsynchronousJavaScript();
                }
                catch { throw; }
            }
            set
            {
                try
                {
                    timeouts.SetAsynchronousJavaScript(value);
                }
                catch { throw; }
            }
        }
        public TimeSpan PageLoad
        {
            get
            {
                try
                {
                    return timeouts.GetPageLoad();
                }
                catch { throw; }
            }
            set
            {
                try
                {
                    timeouts.SetPageLoad(value);
                }
                catch { throw; }
            }
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