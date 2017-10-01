using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    public class KeyboardAdapter : IKeyboard
    {
        private SyncKeyboard keyboard;

        public KeyboardAdapter(SyncKeyboard keyboard)
        {
            this.keyboard = keyboard;
        }

        public void PressKey(string keyToPress)
        {
            try
            {
                keyboard.PressKey(keyToPress);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public void ReleaseKey(string keyToRelease)
        {
            try
            {
                keyboard.ReleaseKey(keyToRelease);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public void SendKeys(string keySequence)
        {
            try
            {
                keyboard.SendKeys(keySequence);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }
    }
}