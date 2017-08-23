using System;
using System.IO;
using System.Threading.Tasks;
using Zu.AsyncWebDriver.Remote;

namespace AsyncChromeDriverExamplesAndTests
{
    internal class ExamplesHelper
    {
        internal async static Task LoadFile(WebDriver webDriver, string file)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, file);
            await webDriver.GoToUrl(filePath);
        }
    }
}