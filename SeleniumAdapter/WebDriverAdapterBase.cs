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
using Zu.SeleniumAdapter;

namespace Zu.SeleniumAdapter
{
    public class WebDriverAdapterBase : IWebDriverAdapter
    {
        public Zu.AsyncWebDriver.Remote.WebDriver AsyncWebDriver;
        public Zu.AsyncWebDriver.Remote.SyncWebDriver SyncWebDriver;

        public string Url { get => SyncWebDriver.Url; set => Navigate().GoToUrl(value); }

        public string Title => SyncWebDriver.Title();

        public string PageSource => SyncWebDriver.PageSource();

        public string CurrentWindowHandle => SyncWebDriver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => new ReadOnlyCollection<string>(SyncWebDriver.WindowHandles());

        public IKeyboard Keyboard => new KeyboardAdapter(SyncWebDriver.Keyboard);

        public IMouse Mouse => new MouseAdapter(SyncWebDriver.Mouse);

        public bool HasWebStorage => throw new NotImplementedException();

        public IWebStorage WebStorage => throw new NotImplementedException();

        public bool HasLocationContext => throw new NotImplementedException();

        public ILocationContext LocationContext => throw new NotImplementedException();

        public bool HasApplicationCache => throw new NotImplementedException();

        public IApplicationCache ApplicationCache => throw new NotImplementedException();

        public bool IsActionExecutor => true;

        public void Close()
        {
            SyncWebDriver.Close();
        }

        public void Dispose()
        {
            //Quit();
        }

        public object ExecuteAsyncScript(string script, params object[] args)
        {
            object res = null;
            try
            {
                res = SyncWebDriver.ExecuteAsyncScript(script, ReplaceWebElementsInArgs(args));
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
            res = ReplaceWebElements(res);
            return res;
        }

        public object ExecuteScript(string script, params object[] args)
        {
            object res = null;
            try
            {
                res = SyncWebDriver.ExecuteScript(script, ReplaceWebElementsInArgs(args));
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }

            res = ReplaceWebElements(res);
            return res;
        }

        private object ReplaceWebElements(object obj)
        {
            if (obj is string || obj is float || obj is double || obj is int || obj is long || obj is bool || obj == null) return obj;
            if (obj is Zu.AsyncWebDriver.Remote.SyncWebElement) return new WebElementAdapter(obj as Zu.AsyncWebDriver.Remote.SyncWebElement, this);
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
                if (list.Any() && list.All(v => v is WebElementAdapter)) return new ReadOnlyCollection<IWebElement>(list.Cast<IWebElement>().ToList());
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
            try
            {
                var el = SyncWebDriver.FindElement(WebDriverConverters.By(by));
                //if (el == null && syncWebDriver.Options().Timeouts.GetImplicitWait() != default(TimeSpan))
                //{
                //    var waitEnd = DateTime.Now + syncWebDriver.Options().Timeouts.GetImplicitWait();
                //    while (el == null && DateTime.Now < waitEnd)
                //    {
                //        Thread.Sleep(50);
                //        el = syncWebDriver.FindElement(WebDriverConverters.By(by));
                //    }
                //}
                return new WebElementAdapter(el, this);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
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
            try
            {
                var els = SyncWebDriver.FindElements(WebDriverConverters.By(by)).Select(v => (IWebElement)new WebElementAdapter(v, this)).ToList();
                //if (els == null && syncWebDriver.Options().Timeouts.GetImplicitWait() != default(TimeSpan))
                //{
                //    var waitEnd = DateTime.Now + syncWebDriver.Options().Timeouts.GetImplicitWait();
                //    while (els == null && DateTime.Now < waitEnd)
                //    {
                //        Thread.Sleep(50);
                //        els = syncWebDriver.FindElements(WebDriverConverters.By(by)).Select(v => (IWebElement)new WebElementAdapter(v)).ToList();
                //    }
                //}
                return new ReadOnlyCollection<IWebElement>(els);
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
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
            try
            {
                return WebDriverConverters.SeleniumScreenshot(SyncWebDriver.GetScreenshot());
            }
            catch (Zu.WebBrowser.BasicTypes.WebBrowserException webDriverException)
            {
                throw WebDriverConverters.ToSeleniumException(webDriverException);
            }
            catch { throw; }
        }

        public IOptions Manage()
        {
            return new WebDriverOptionsAdapter(SyncWebDriver.Options());
        }

        public INavigation Navigate()
        {
            return new NavigateAdapter(SyncWebDriver.Navigate());
        }

        public void PerformActions(IList<ActionSequence> actionSequenceList)
        {
            SyncWebDriver.PerformActions(WebDriverConverters.SeleniumActionSequenceList(SyncWebDriver, actionSequenceList));
        }

        public void Quit()
        {
            SyncWebDriver.Close();
        }

        public void ResetInputState()
        {
            SyncWebDriver.ResetInputState();
        }

        public ITargetLocator SwitchTo()
        {
            return new TargetLocatorAdapter(SyncWebDriver.SwitchTo(), this);
        }
    }
}
