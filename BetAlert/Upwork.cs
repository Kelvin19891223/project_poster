using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetAlert
{
    class UpworkHelper : IGoogle
    {
        public bool debug = false;

        public string url = "https://www.upwork.com/ab/account-security/login";
        public string user_name;
        public string password;
        public double current_balance = 0;
        public string answer;

        public UpworkHelper(string _user_name, string _password, string _answer)
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
                navigate(url, "//input[@id='login_username']", 5000);

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
                string xpath = "//h1[contains(text(),'Please verify you are a human')]";
                while (true)
                {
                    if (getText(xpath, 3000) == "")
                        break;                    
                }
                //Enter the username
                xpath = "//input[@id='login_username']";
                if (!await TryEnterText(xpath, user_name, "value", 3000, true))
                    return false;

                xpath = "//button[@id='login_password_continue']";
                TryClick(xpath, 1, 3000);

                //Enter the password
                xpath = "//input[@id='login_password']";
                if (!await TryEnterText(xpath, password, "value", 3000, true))
                    return false;

                await Task.Delay(1000);

                xpath = "//button[@id='login_control_continue']";
                TryClick(xpath, 1, 3000);

                return true;                
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public async Task<string> startPost(string _title, string _content, bool _fixed, string _start, string _end)
        {
            await Task.Delay(2000);

            string xpath = "(//section[@class='sb-dashboard-my-jobs']//section)[3]//a";
            if (getText(xpath, 3000).ToLower().Trim().Contains("post a job"))
            { 
                xpath = "//a[@data-ng-click='clickHeaderPostJobButton();']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //Click the short term or part time work
                xpath = "(//div[@data-ng-model='vm.hvPrompt'])[1]";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //Click continue button
                xpath = "//step-buttons//button[text()='Continue']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //input the title
                xpath = "//field-title//textarea";
                if (!waitForElement(xpath, 5000))
                    return "not found the job title";

                await Task.Delay(1000);

                if (await TryEnterText(xpath, _title, "value", 3000, true) == false)
                    return "not found the job title";

                await Task.Delay(1000);

                //CLick next button
                xpath = "//step-buttons//button[text()='Next']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //content
                xpath = "//field-description//textarea";
                await TryEnterText(xpath, _content, "value", 3000, true);

                await Task.Delay(1000);

                //CLick next button
                xpath = "//step-buttons//button[text()='Next']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //Click the detail (one-time project)
                xpath = "//field-segmentation//field-box[@item='item']//div";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //CLick next button
                xpath = "//step-buttons//button[text()='Next']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //click the expert level
                xpath = "(//field-experience-level//field-box[@item='item']//div)[5]";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //CLick next button
                xpath = "//step-buttons//button[text()='Next']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //click who can see your job?
                xpath = "//field-marketplace-visibility//field-box[@item='item']//div";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //CLick next button
                xpath = "//step-buttons//button[text()='Next']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //click budget type
                if (_fixed)
                {
                    xpath = "(//field-job-type//field-box[@item='item']//div)[3]";
                }
                else
                {
                    xpath = "(//field-job-type//field-box[@item='item']//div)[1]";
                }

                TryClick(xpath, 1, 3000);
                await Task.Delay(1000);

                if (_fixed)
                {
                    //input the budget
                    xpath = "//section[contains(@class,'content-section')]//form//div[@class='input-group']//input";
                    if (!await TryEnterText(xpath, _start, "value", 3000, true))
                        return "can not find the budget inputbox";
                }
                else
                {
                    // select hourly range
                    xpath = "(//hourly-budget//div[@class='radio'])[2]//label[contains(@class,'label-py')]";
                    TryClick(xpath, 1, 3000);
                    await Task.Delay(1000);

                    //click more than 6 months
                    xpath = "//field-engagement-duration//field-box[@item='item']//div";
                    TryClick(xpath, 1, 3000);
                    await Task.Delay(1000);

                    //click more than 30 hrs / week
                    xpath = "//field-engagement-type//field-box[@item='item']//div";
                    TryClick(xpath, 1, 3000);
                    await Task.Delay(1000);

                    //input from
                    xpath = "(//hourly-budget//div[@class='radio'])[2]//label[contains(@class,'label-py')]//input[@type='text']";
                    if (!await TryEnterText(xpath, _start, "value", 3000, true))
                        return "can not find the budget inputbox";

                    xpath = "((//hourly-budget//div[@class='radio'])[2]//label[contains(@class,'label-py')]//input[@type='text'])[2]";
                    if (!await TryEnterText(xpath, _start, "value", 3000, true))
                        return "can not find the budget inputbox";
                }


                //click next button
                xpath = "//step-buttons//button[text()='Next']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //click post job now
                xpath = "//footer//button";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);
                                
            } else
            {
                xpath = "//div[contains(@class,'container')]//div[contains(@class,'display-inline-block')]//a[@data-ng-click='clickHeaderPostJobButton();']";
                TryClick(xpath, 1, 3000);
                
                await Task.Delay(1000);

                //Click the short term or part time work
                xpath = "(//div[contains(@class,'container')]//section//fieldset//div[@data-cy='button-box'])[1]";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //Click continue button
                xpath = "//footer//button[contains(text(),'Continue')]";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //input the title
                xpath = "//div[contains(@class,'container')]//div[contains(@class,'content')]//input";
                if (!waitForElement(xpath, 5000))
                    return "not found the job title";

                await Task.Delay(1000);

                if (await TryEnterText(xpath, _title, "value", 3000, true) == false)
                    return "not found the job title";

                await Task.Delay(1000);

                //CLick next button
                xpath = "//div[contains(@class,'container')]//button[contains(text(),'Next')]";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //select popular skills
                var count = 0;
                while (count < 5)
                {
                    count++;

                    xpath = "//div[@label='Popular skills']//div//div[@data-cy='skill']";
                    TryClick(xpath, 1, 3000);

                    await Task.Delay(1000);
                }

                //CLick next button
                xpath = "//div[contains(@class,'container')]//button[contains(text(),'Next')]";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //click large
                xpath = "//div[@class='segmentation-radio']//fieldset//label[@class='up-checkbox-label']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //Click more than 6 months
                xpath = "//fieldset//label[@class='up-checkbox-label']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //Click Entry
                xpath = "//fieldset//label[@class='up-checkbox-label']";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //Click Next Budget
                xpath = "//div[contains(@class,'container')]//button[contains(text(),'Next')]";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //click budget type
                if (_fixed)
                {
                    xpath = "(//fieldset//div[contains(@class,'radio-button')])[2]";
                }
                else
                {
                    xpath = "(//fieldset//div[contains(@class,'radio-button')])[1]";
                }

                TryClick(xpath, 1, 3000);
                await Task.Delay(1000);

                if (_fixed)
                {
                    //input the budget
                    xpath = "//div[@class='fixed-price-budget']//input";
                    if (!await TryEnterText(xpath, _start, "value", 3000, true))
                        return "can not find the budget inputbox";
                }
                else
                {
                    //input from
                    xpath = "(//div[@class='up-currency']//input[@type='number'])[1]";
                    if (!await TryEnterText(xpath, _start, "value", 3000, true))
                        return "can not find the budget inputbox";

                    xpath = "(//div[@class='up-currency']//input[@type='number'])[2]";
                    if (!await TryEnterText(xpath, _start, "value", 3000, true))
                        return "can not find the budget inputbox";
                }

                //Click Review Job Post
                xpath = "//button[contains(text(),'Review Job Post')]";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);

                //content
                xpath = "//textarea[contains(@placeholder,'Paste it here!')]";
                await TryEnterText(xpath, _content, "value", 3000, true);

                await Task.Delay(1000);

                //CLick next button
                xpath = "//footer//button[contains(text(),'Post Your')]";
                TryClick(xpath, 1, 3000);

                await Task.Delay(1000);
            }
            
            
            return null;
        }

        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
