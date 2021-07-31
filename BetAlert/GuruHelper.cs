using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetAlert
{
    class GuruHelper: IGoogle
    {
        public bool debug = false;

        public string url = "https://www.guru.com/login.aspx";
        public string user_name;
        public string password;
        public double current_balance = 0;
        public string answer;

        public GuruHelper(string _user_name, string _password, string _answer)
        {
            user_name = _user_name;
            password = _password;
            answer = _answer;
        }

        public async Task<bool> StartBrowser()
        {
            try
            {
                if (!Start(false))
                    return false;

                //Navigate to the url
                navigate(url, "//input[@id='userId']", 10000);

                await Task.Delay(1000);

                //Login
                if (!await Login())
                    return false;
            }
            catch (Exception) { }

            return true;
        }

        public async Task<bool> Login()
        {
            try
            {
                //Enter the username
                string xpath = "//input[@id='userId']";
                if (!await TryEnterText(xpath, user_name, "value", 3000, true))
                    return false;

                //Enter the password
                xpath = "//input[@id='password']";
                if (!await TryEnterText(xpath, password, "value", 3000, true))
                    return false;

                await Task.Delay(1000);

                //Press the login button
                xpath = "//button[@id='login-button']";
                if (!TryClick(xpath, 1, 500))
                    return false;

                xpath = "//div[@class='SeqQuestion']//label";
                string question = getText(xpath, 3000);
                string __answer = "";
                string[] _answer = answer.Split(',');
                for(var k=0; k< _answer.Length; k++)
                {
                    if (_answer[k].ToString().Split(':')[0] == question)
                    {
                        __answer = _answer[k].ToString().Split(':')[1];
                    }
                }

                xpath = "//div[@class='SeqQuestion']//input";
                await TryEnterText(xpath, __answer, "value", 3000, true);
                TryClick("//div[contains(@class,'account-btn-save')]//input[@type='submit']");                

                await Task.Delay(5000);

                xpath = "//input[@placeholder='Search Freelancers']";
                if (waitForElement(xpath, 30000))
                    return true;
                else
                    return false;

            } catch(Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<string> startPost(string _title, string _content, bool _fixed, string _start, string _end)
        {
            await Task.Delay(2000);

            navigate("https://www.guru.com/hire/post", "//input[@id='job-title']");
            
            //title
            string xpath = "//input[@id='job-title']";
            if (!waitForElement(xpath, 5000))
                return "not found the job title";

            await Task.Delay(1000);

            if (await TryEnterText(xpath, _title, "value", 3000, true) == false)
                return "not found the job title";

            await Task.Delay(1000);

            //content
            xpath = "//div[@class='postJobInput']//div[contains(@class,'fr-element')]//p";
            await TryEnterText(xpath, _content, "value", 3000, true);                

            await Task.Delay(1000);

            //select 
            xpath = "//div[@class='postJobInput']//div[@class='categorySelect']//button[1]";
            if (!TryClick(xpath, 1, 3000))
                return "not found the category button";

            await Task.Delay(3000);

            try
            {
                xpath = "//label[@for='subCatRadio_1']";
                waitForElement(xpath, 5000);
                driver.FindElementByXPath(xpath).Click();
            } catch(Exception) {
                return "not found the sub category button";
            }

            await Task.Delay(1000);

            if (_fixed)
            {
                double start = double.Parse(_start);
                double end = double.Parse(_end);
                if (start >= 250 && start < 500)
                    xpath = "//div[@class='agreementTerms__form']//ul[contains(@class,'columnSelection')]//li[2]//label";
                else if (start >= 500 && start < 1000)
                    xpath = "//div[@class='agreementTerms__form']//ul[contains(@class,'columnSelection')]//li[3]//label";
                else if (start >= 1000 && start < 2500)
                    xpath = "//div[@class='agreementTerms__form']//ul[contains(@class,'columnSelection')]//li[4]//label";
                else if (start >= 2500 && start < 5000)
                    xpath = "//div[@class='agreementTerms__form']//ul[contains(@class,'columnSelection')]//li[5]//label";
                else if (start >= 5000 && start < 10000)
                    xpath = "//div[@class='agreementTerms__form']//ul[contains(@class,'columnSelection')]//li[6]//label";
                else if (start >= 10000 && start < 25000)
                    xpath = "//div[@class='agreementTerms__form']//ul[contains(@class,'columnSelection')]//li[7]//label";
                else
                    xpath = "//div[@class='agreementTerms__form']//ul[contains(@class,'columnSelection')]//li[1]//label";

                TryClick(xpath, 1, 3000);
            } else
            {
                xpath = "//div[@class='agreementTerms']//button[2]";
                if (!TryClick(xpath, 1, 3000))
                    return "not found the agree term button";

                TrySelectOption("//select[@id='hourlyDurationSelect']", 4, 5000);
                TrySelectOption("//select[@id='hourlyDurationSelectPerWeek']", 2, 5000);

                //input min
                xpath = "//input[@id='hourly-rate-min']";
                if (await TryEnterText(xpath, _start, "value", 3000, true) == false)
                    return "not found the min value";

                xpath = "//input[@id='hourly-rate-max']";
                if (await TryEnterText(xpath, _end, "value", 3000, true) == false)
                    return "not found the max value";
            }

            await Task.Delay(1000);

            //click submit button
            xpath = "//button[@id='submit-job']";
            if (!TryClick(xpath, 1, 3000))
                return "not found the submit button";

            await Task.Delay(5000);

            return null;
        }

        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
