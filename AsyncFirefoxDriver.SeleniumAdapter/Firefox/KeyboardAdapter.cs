using OpenQA.Selenium;
using Zu.AsyncWebDriver.Remote;

namespace Zu.AsyncFirefoxDriver.SeleniumAdapter
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
            keyboard.PressKey(keyToPress);
        }

        public void ReleaseKey(string keyToRelease)
        {
            keyboard.ReleaseKey(keyToRelease);
        }

        public void SendKeys(string keySequence)
        {
            keyboard.SendKeys(keySequence);
        }
    }
}