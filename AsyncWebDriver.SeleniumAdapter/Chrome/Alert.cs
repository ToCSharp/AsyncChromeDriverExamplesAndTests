using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;

namespace AsyncWebDriver.SeleniumAdapter.Chrome
{
    internal class Alert : IAlert
    {
        private SyncAlert syncAlert;

        public Alert(SyncAlert syncAlert)
        {
            this.syncAlert = syncAlert;
        }

        public string Text => throw new System.NotImplementedException();

        public void Accept()
        {
            throw new System.NotImplementedException();
        }

        public void Dismiss()
        {
            throw new System.NotImplementedException();
        }

        public void SendKeys(string keysToSend)
        {
            throw new System.NotImplementedException();
        }

        public void SetAuthenticationCredentials(string userName, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}