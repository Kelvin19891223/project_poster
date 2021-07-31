using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetAlert
{
    class IGoogle
    {        
        public RemoteWebDriver driver;
        object m_locker = new object();
        public IJavaScriptExecutor m_js;

        public object m_chr_data_dir = new object();
        public string m_chr_user_data_dir = "";       

        //Selenium
        public bool Start(bool flag = true, bool headless = false, bool incognite = false)
        {
            try
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--no-sandbox");
                if (headless)
                    chromeOptions.AddArguments("headless");

                chromeOptions.AddArguments("--disable-gpu");
                chromeOptions.AddArgument("--disable-extensions");
                chromeOptions.AddArgument("--profile-directory=Default");

                if (incognite)
                    chromeOptions.AddArgument("--incognito");
                chromeOptions.AddArgument("--log-level=3");
                chromeOptions.AddArgument("--disable-plugins-discovery");
                chromeOptions.AddExcludedArguments(new List<string>() { "enable-automation" });
                chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
                chromeOptions.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4389.114 Safari/537.36");
                chromeOptions.AddArgument("start-maximized");
                chromeOptions.AddArgument("--profile-directory=Default");

                var service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;
                try
                {
                    ChromeDriver d = new ChromeDriver(service, chromeOptions);
                    // driver = new ChromeDriver(service, chromeOptions);
                    if (flag)
                        d.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    d.Manage().Window.Size = new Size(1920, 1080);
                    d.Manage().Cookies.DeleteAllCookies();
                    d.Manage().Window.Maximize();

                    d.ExecuteChromeCommand("Page.addScriptToEvaluateOnNewDocument",
                        new System.Collections.Generic.Dictionary<string, object> {
                            { "source", @"
                                Object.defineProperty(navigator, 'webdriver', {
                                    get: () => false;
                                })"
                            }
                        }
                    );

                    driver = d;
                }
                catch (Exception)
                {
                    return false;
                }

                m_js = (IJavaScriptExecutor)driver;

                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    driver.Quit();
                }
                catch
                {
                    MainApp.log_info($"Failed to quit driver. Exception:{ex.Message}");
                }
                return false;
            }
        }

        public void new_tab()
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            catch (Exception)
            {
                //MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public bool navigate(string target, string element_xpath, int timeout = 30000, Boolean flag = false)
        {
            try
            {
                string url = driver.Url;

                if (flag)
                    driver.Navigate().GoToUrl(new Uri(target));
                else
                    driver.Navigate().GoToUrl(target);
                //driver.Url = target;                
                //Wait until element is visible
                if (element_xpath != null)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
                    wait.Until(ElementIsVisible(driver.FindElement(By.XPath(element_xpath))));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(element_xpath)));
                }
                return true;
            }
            catch (Exception)
            {
                //MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Displayed && element.Enabled;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    //MainApp.log_info($"Exception:{ex.Message}");
                    return false;
                }
            };
        }

        public Func<IWebDriver, bool> waitForElementEnable(string xpath)
        {
            return (driver) =>
            {
                try
                {
                    IWebElement element = driver.FindElement(By.XPath(xpath));

                    if (!element.GetAttribute("class").ToLower().Contains("disabled"))
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    //MainApp.log_info($"Exception:{ex.Message}");
                    return false;
                }
            };
        }

        public bool waitForElement(string xpath, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool waitForElementNotIncludeString(string xpath, string expected_string, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                return wait.Until(waitForElementTextNotContainsString(xpath, expected_string));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Func<IWebDriver, bool> waitForElementTextNotContainsString(string xpath, String expectedString)
        {
            return (driver) =>
            {
                try
                {
                    IWebElement element = driver.FindElement(By.XPath(xpath));

                    if (element.Text.Length != 0 && !element.Text.ToUpper().Contains(expectedString.ToUpper()))
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    //MainApp.log_info($"Exception:{ex.Message}");
                    return false;
                }
            };
        }

        //Enter the text
        public async Task<bool> TryEnterText(String xpath, string textToEnter, string atributeToEdit = "value", int TimeOut = 30000, bool manualyEnter = false)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));

                element.SendKeys((string)OpenQA.Selenium.Keys.Control + "a");

                if (manualyEnter)
                    element.SendKeys(textToEnter);
                else
                    driver.ExecuteScript($"arguments[0].value = '{textToEnter}';", element);

                for (int index = 0; index < 10; ++index)
                {
                    await TaskDelay(100);
                    if ((string)driver.ExecuteScript("return arguments[0].value;", element) == textToEnter)
                    {
                        return true;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                //MainApp.log_info($"Exception:{ex.Message} {ex.StackTrace}");
                return false;
            }
        }
        public async Task<bool> TryEnterTextSelf(String xpath, string textToEnter, string atributeToEdit = "value", int TimeOut = 30000, bool manualyEnter = false)
        {
            try
            {
                // var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                // var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                var element = driver.FindElementByXPath(xpath);
                element.Click();

                element.SendKeys((string)OpenQA.Selenium.Keys.Control + "a");

                if (manualyEnter)
                    element.SendKeys(textToEnter);
                else
                    driver.ExecuteScript($"arguments[0].value = '{textToEnter}';", element);

                for (int index = 0; index < 10; ++index)
                {
                    await TaskDelay(100);
                    if ((string)driver.ExecuteScript("return arguments[0].value;", element) == textToEnter)
                    {
                        return true;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                //MainApp.log_info($"Exception:{ex.Message} {ex.StackTrace}");
                return false;
            }
        }

        public async Task<bool> TaskDelay(int delay)
        {
            await Task.Delay(delay);
            return true;
        }

        public bool TryClick(String xpath, int mode = 0, int TimeOut = 3000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                wait.Until(ElementIsVisible(driver.FindElement(By.XPath(xpath))));
                wait.Until(waitForElementEnable(xpath));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));

                var element = driver.FindElement(By.XPath(xpath));
                if (mode == 0)
                {
                    driver.ExecuteScript("arguments[0].click('');", element);
                }
                else if (mode == 1)
                {
                    element.Click();
                }
                return true;
            }
            catch (Exception)
            {
                //MainApp.log_info(xpath);
                //MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
            return false;
        }

        public void TryClickElement(IWebElement element, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var tElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                tElement.Click();
            }
            catch (Exception)
            {
                //MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public string getText(string xpath, int TimeOut = 30000)
        {
            string result = "";

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                result = element.Text;
            }
            catch (Exception)
            {
                //MainApp.log_info("Get Text Error: " + xpath);
                //MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }

            return result;
        }

        public void runJavascript(string javascript)
        {
            try
            {
                driver.ExecuteScript(javascript);
            }
            catch (Exception)
            {
                //MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public bool waitToElementVisible(string xpath, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void waitToElementVisible(IWebElement ele, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                wait.Until(ElementIsVisible(ele));
            }
            catch (Exception)
            {

            }
        }

        public IWebElement getElementFromParent(IWebElement parent, string xpath, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var element = parent.FindElement(By.XPath(xpath));
                wait.Until(ElementIsVisible(element));
                return element;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> getElementsFromParent(IWebElement parent, string xpath, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var elements = parent.FindElements(By.XPath(xpath));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
                return elements;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> getElementsByXPath(string xpath, int timeout = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
                var elements = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));
                return elements;
            }
            catch (Exception ex)
            {
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
                return null;
            }
        }

        public void TakingHTML2CanvasFullPageScreenshot(string bookie_name)
        {
            try
            {
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string imageFoler = path + "\\images";
                if (!Directory.Exists(imageFoler))
                    Directory.CreateDirectory(imageFoler);

                string filename = String.Format("{0}\\images\\{1}_{2}.png", path, bookie_name, MainApp.AuNow().ToString("yyyy_MM_dd_HH_mm_ss"));
                //filename = Path.Combine(path, filename);

                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Png);
            }
            catch (Exception)
            {
                //MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void refresh()
        {
            try
            {
                lock (m_locker)
                {
                    driver.Navigate().Refresh();
                }
            }
            catch (Exception)
            {
                //MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public async Task<IWebElement> getElement(string xpath)
        {
            bool staleElement = true;
            IWebElement element = null;
            var count = 0;
            while (staleElement || count > 10)
            {
                try
                {
                    element = driver.FindElement(By.XPath(xpath));
                    staleElement = false;
                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    await Task.Delay(100);
                }
            }

            return element;
        }

        public void new_tab(string tabUrl)
        {
            lock (m_locker)
            {
                string newTabScript = "var d=document,a=d.createElement('a');"
                                + "a.target='_blank';a.href='{0}';"
                                + "a.innerHTML='new tab';"
                                + "d.body.appendChild(a);"
                                + "a.click();"
                                + "a.parentNode.removeChild(a);";
                if (String.IsNullOrEmpty(tabUrl))
                    tabUrl = "about:blank";

                m_js.ExecuteScript(String.Format(newTabScript, tabUrl));
            }
        }

        public bool TrySelectOption(String xpath, int index, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                wait.Until(ElementIsVisible(driver.FindElementByXPath(xpath)));

                var element = driver.FindElementByXPath(xpath);
                var item = new SelectElement(element);

                if (index != -1)
                    item.SelectByIndex(index);
                else
                    item.SelectByIndex(item.Options.Count-1);
                return true;
            }
            catch (Exception ex)
            {
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
            return false;
        }
    }
}
