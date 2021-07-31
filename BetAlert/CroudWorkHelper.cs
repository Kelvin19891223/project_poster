using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetAlert
{
    class CroudWorkHelper : IGoogle
    {
        public bool debug = false;

        public string url = "https://crowdworks.jp/login?ref=toppage_hedder";
        public string user_name;
        public string password;
        public double current_balance = 0;
        public string answer;

        public CroudWorkHelper(string _user_name, string _password, string _answer)
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
                navigate(url, "//input[@id='username']", 10000);

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
                string xpath = "//input[@id='username']";
                if (!await TryEnterText(xpath, user_name, "value", 3000, true))
                    return false;

                //Enter the password
                xpath = "//input[@id='password']";
                if (!await TryEnterText(xpath, password, "value", 3000, true))
                    return false;

                await Task.Delay(1000);

                //Press the login button
                xpath = "//form//input[@type='submit']";
                if (!TryClick(xpath, 1, 500))
                    return false;
                
                await Task.Delay(5000);

                xpath = "//input[@placeholder='Search Freelancers']";
                if (waitForElement(xpath, 30000))
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> startPost(string _title, string _content, bool _fixed, string _start, string _end)
        {
            await Task.Delay(2000);

            navigate("https://www.guru.com/hire/post", "//input[@id='job-title']");

            //title
            string xpath = "//input[@id='job-title']";
            if (!waitForElement(xpath, 5000))
                return false;

            await Task.Delay(1000);

            if (await TryEnterText(xpath, _title, "value", 3000, true) == false)
                return false;

            await Task.Delay(1000);

            //content
            xpath = "//div[@class='postJobInput']//div[contains(@class,'fr-element')]//p";
            await TryEnterText(xpath, _content, "value", 3000, true);

            await Task.Delay(1000);

            //select 
            xpath = "//div[@class='postJobInput']//div[@class='categorySelect']//button[1]";
            if (!TryClick(xpath, 1, 3000))
                return false;

            await Task.Delay(3000);

            try
            {
                xpath = "//label[@for='subCatRadio_1']";
                waitForElement(xpath, 5000);
                driver.FindElementByXPath(xpath).Click();
            }
            catch (Exception) { return false; }

            await Task.Delay(1000);

            if (_fixed)
            {
                xpath = "//input[@id='54__9']";
                if (!TryClick(xpath, 1, 3000))
                    return false;
            }
            else
            {
                xpath = "//div[@class='agreementTerms']//button[2]";
                if (!TryClick(xpath, 1, 3000))
                    return false;

                TrySelectOption("//select[@id='hourlyDurationSelect']", 4, 5000);
                TrySelectOption("//select[@id='hourlyDurationSelectPerWeek']", 2, 5000);

                //input min
                xpath = "//input[@id='hourly-rate-min']";
                if (await TryEnterText(xpath, _start, "value", 3000, true) == false)
                    return false;

                xpath = "//input[@id='hourly-rate-max']";
                if (await TryEnterText(xpath, _end, "value", 3000, true) == false)
                    return false;
            }

            await Task.Delay(1000);

            //click submit button
            xpath = "//button[@id='submit-job']";
            if (!TryClick(xpath, 1, 3000))
                return false;

            await Task.Delay(5000);

            return true;
        }

        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
