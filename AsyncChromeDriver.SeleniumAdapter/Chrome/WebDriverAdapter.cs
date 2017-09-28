using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    public class WebDriverAdapter : IWebDriver, ISearchContext, IJavaScriptExecutor, IFindsById, IFindsByClassName, IFindsByLinkText, IFindsByName, IFindsByTagName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, ITakesScreenshot, IHasInputDevices,/* IHasCapabilities, */IHasWebStorage, IHasLocationContext, IHasApplicationCache, /*IAllowsFileDetection, IHasSessionId, */IActionExecutor
    {
        private Zu.Chrome.AsyncChromeDriver asyncChromeDriver;
        private Zu.AsyncWebDriver.Remote.WebDriver asyncWebDriver;
        private Zu.AsyncWebDriver.Remote.SyncWebDriver syncWebDriver;

        public WebDriverAdapter()
        {
            asyncChromeDriver = new Zu.Chrome.AsyncChromeDriver();
            asyncChromeDriver.Session.ImplicitWait = TimeSpan.FromMilliseconds(500);
            asyncWebDriver = new Zu.AsyncWebDriver.Remote.WebDriver(asyncChromeDriver);
            syncWebDriver = new Zu.AsyncWebDriver.Remote.SyncWebDriver(asyncWebDriver);
        }
        public string Url { get => syncWebDriver.Url; set => Navigate().GoToUrl(value); }

        public string Title => syncWebDriver.Title();

        public string PageSource => syncWebDriver.PageSource();

        public string CurrentWindowHandle => syncWebDriver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => new ReadOnlyCollection<string>(syncWebDriver.WindowHandles());

        public IKeyboard Keyboard => new KeyboardAdapter(syncWebDriver.Keyboard);

        public IMouse Mouse => new MouseAdapter(syncWebDriver.Mouse);

        public bool HasWebStorage => throw new NotImplementedException();

        public IWebStorage WebStorage => throw new NotImplementedException();

        public bool HasLocationContext => throw new NotImplementedException();

        public ILocationContext LocationContext => throw new NotImplementedException();

        public bool HasApplicationCache => throw new NotImplementedException();

        public IApplicationCache ApplicationCache => throw new NotImplementedException();

        public bool IsActionExecutor => true;

        public void Close()
        {
            asyncChromeDriver.CloseSync();
        }

        public void Dispose()
        {
            //Quit();
        }

        public object ExecuteAsyncScript(string script, params object[] args)
        {
            var res = syncWebDriver.ExecuteAsyncScript(script, ReplaceWebElementsInArgs(args));
            res = ReplaceWebElements(res);
            return res;
        }

        public object ExecuteScript(string script, params object[] args)
        {
            var res = syncWebDriver.ExecuteScript(script, ReplaceWebElementsInArgs(args));
            res = ReplaceWebElements(res);
            return res;
        }

        private object ReplaceWebElements(object obj)
        {
            if (obj is string || obj is float || obj is double || obj is int || obj is long || obj is bool || obj == null) return obj;
            if (obj is Zu.AsyncWebDriver.Remote.SyncWebElement) return new WebElementAdapter(obj as Zu.AsyncWebDriver.Remote.SyncWebElement);
            var col = obj as IEnumerable;
            var dic = obj as IDictionary;
            if (dic != null)
            {
                var resDic = new Dictionary<string, object>();
                foreach (DictionaryEntry item in dic)
                {
                    resDic.Add(item.Key.ToString(), ReplaceWebElements(item.Value));
                }
                return resDic;
            }
            else if (col != null)
            {
                var list = new List<object>();
                foreach (var item in col)
                {
                    list.Add(ReplaceWebElements(item));
                }
                if (list.All(v => v is WebElementAdapter)) return new ReadOnlyCollection<IWebElement>(list.Cast<IWebElement>().ToList());
                return new ReadOnlyCollection<object>(list);
            }
            else return obj;
        }

        private object[] ReplaceWebElementsInArgs(object[] args)
        {
            if (args == null) return new object[] { null };
            var list = new List<object>();
            foreach (var item in args)
            {
                list.Add(ReplaceWebElementsInArg(item));
            }
            return list.ToArray();
        }

        private object ReplaceWebElementsInArg(object obj)
        {
            if (obj is string || obj is float || obj is double || obj is int || obj is long || obj is bool || obj == null) return obj;
            if (obj is WebElementAdapter) return (obj as WebElementAdapter).GetSyncWebElement();
            var dic = obj as IDictionary;
            var col = obj as IEnumerable;
           
            if (dic != null)
            {
                var resDic = new Dictionary<string, object>();
                foreach (DictionaryEntry item in dic)
                {
                    resDic.Add(item.Key.ToString(), ReplaceWebElementsInArg(item.Value));
                }
                return resDic;
            }
            else if (col != null)
            {
                var list = new List<object>();
                foreach (var item in col)
                {
                    list.Add(ReplaceWebElementsInArg(item));
                }
                return list;
            }
            else return obj;

        }


        public IWebElement FindElement(By by)
        {
            var el = syncWebDriver.FindElement(WebDriverConverters.By(by));
            if (el == null && asyncChromeDriver.Session.ImplicitWait != default(TimeSpan))
            {
                var waitEnd = DateTime.Now + asyncChromeDriver.Session.ImplicitWait;
                while (el == null && DateTime.Now < waitEnd)
                {
                    Thread.Sleep(50);
                    el = syncWebDriver.FindElement(WebDriverConverters.By(by));
                }
            }
            return new WebElementAdapter(el);
        }

        public IWebElement FindElementByClassName(string className)
        {
            return FindElement(By.ClassName(className));
        }

        public IWebElement FindElementByCssSelector(string cssSelector)
        {
            return FindElement(By.CssSelector(cssSelector));
        }

        public IWebElement FindElementById(string id)
        {
            return FindElement(By.Id(id));
        }

        public IWebElement FindElementByLinkText(string linkText)
        {
            return FindElement(By.LinkText(linkText));
        }

        public IWebElement FindElementByName(string name)
        {
            return FindElement(By.Name(name));
        }

        public IWebElement FindElementByPartialLinkText(string partialLinkText)
        {
            return FindElement(By.PartialLinkText(partialLinkText));
        }

        public IWebElement FindElementByTagName(string tagName)
        {
            return FindElement(By.TagName(tagName));
        }

        public IWebElement FindElementByXPath(string xpath)
        {
            return FindElement(By.XPath(xpath));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var els = syncWebDriver.FindElements(WebDriverConverters.By(by)).Select(v => (IWebElement)new WebElementAdapter(v)).ToList();
            if (els == null && asyncChromeDriver.Session.ImplicitWait != default(TimeSpan))
            {
                var waitEnd = DateTime.Now + asyncChromeDriver.Session.ImplicitWait;
                while (els == null && DateTime.Now < waitEnd)
                {
                    Thread.Sleep(50);
                    els = syncWebDriver.FindElements(WebDriverConverters.By(by)).Select(v => (IWebElement)new WebElementAdapter(v)).ToList();
                }
            }
            return new ReadOnlyCollection<IWebElement>(els);
        }

        public ReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            return FindElements(By.ClassName(className));
        }

        public ReadOnlyCollection<IWebElement> FindElementsByCssSelector(string cssSelector)
        {
            return FindElements(By.CssSelector(cssSelector));
        }

        public ReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            return FindElements(By.Id(id));
        }

        public ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText)
        {
            return FindElements(By.LinkText(linkText));
        }

        public ReadOnlyCollection<IWebElement> FindElementsByName(string name)
        {
            return FindElements(By.Name(name));
        }

        public ReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(string partialLinkText)
        {
            return FindElements(By.PartialLinkText(partialLinkText));
        }

        public ReadOnlyCollection<IWebElement> FindElementsByTagName(string tagName)
        {
            return FindElements(By.TagName(tagName));
        }

        public ReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath)
        {
            return FindElements(By.XPath(xpath));
        }

        public Screenshot GetScreenshot()
        {
            return WebDriverConverters.SeleniumScreenshot(syncWebDriver.GetScreenshot());
        }

        public IOptions Manage()
        {
            return new WebDriverOptionsAdapter(syncWebDriver.Options());
        }

        public INavigation Navigate()
        {
            return new NavigateAdapter(syncWebDriver.Navigate());
        }

        public void PerformActions(IList<ActionSequence> actionSequenceList)
        {
            syncWebDriver.PerformActions(WebDriverConverters.SeleniumActionSequenceList(syncWebDriver, actionSequenceList));
        }

        public void Quit()
        {
            asyncChromeDriver.CloseSync();
        }

        public void ResetInputState()
        {
            syncWebDriver.ResetInputState();
        }

        public ITargetLocator SwitchTo()
        {
            return new TargetLocatorAdapter(syncWebDriver.SwitchTo(), this);
        }
    }
}
