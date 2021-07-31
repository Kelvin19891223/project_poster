using System;
using System.Threading.Tasks;

namespace BetAlert
{
    class FreelancerHelper : IGoogle
    {
        public bool debug = false;
        public double odds;
        public bool working;
        System.Timers.Timer m_timer = new System.Timers.Timer();

        public string url = "https://www.freelancer.com/login";
        public string user_name;
        public string password;
        public double current_balance = 0;
        public FreelancerHelper(string _user_name, string _password)
        {
            user_name = _user_name;
            password = _password;
        }

        public async Task<bool> StartBrowser()
        {
            try
            {
                working = true;
                if (!Start(false))
                    return false;

                //Navigate to the url
                navigate(url, "//input[@placeholder='Email or Username']", 10000);

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
            //Enter the username
            string xpath = "//input[@placeholder='Email or Username']";
            if (!await TryEnterText(xpath, user_name, "value", 3000, true))
                return false;

            //Enter the password
            xpath = "//input[@placeholder='Password']";
            if (!await TryEnterText(xpath, password, "value", 3000, true))
                return false;

            await Task.Delay(1000);

            //Press the login button
            xpath = "//app-login-signup-button//button";
            if (!TryClick(xpath, 1, 500))
                return false;

            await Task.Delay(5000);

            xpath = "//app-user-card//fl-text[@data-type='paragraph']//div";
            if (!waitToElementVisible(xpath, 5000))
                return false;

            return true;
        }

        public async Task<string> startPost(string _title, string _content, bool _fixed, string _start, string _end)
        {
            await Task.Delay(2000);

            navigate("https://www.freelancer.com/manage/jobs/projects/open?query=&filter=All&show=10", "//fl-button//a[@href='/post-project?ref=MyProjects']");            

            if (!TryClick("//fl-button//a[@href='/post-project?ref=MyProjects']", 1, 1000))
                return "Error to go to the post project.";

            //title
            string xpath = "//app-title//fl-bit//input";
            if (!waitForElement(xpath, 5000))
                return "not found the input box.";

            if (await TryEnterText(xpath, _title, "value", 3000, true) == false)
                return "not found the title.";

            //content
            xpath = "//app-description//fl-textarea//textarea";
            if (await TryEnterText(xpath, _content, "value", 3000, true) == false)
                return "not found the content.";

            //click next
            xpath = "//fl-button//button[contains(text(),'Next')]";
            if (!TryClick(xpath, 1, 3000))
                return "not found the next button.";

            //click next
            xpath = "//fl-button//button[contains(text(),'Next')]";
            if (!TryClick(xpath, 1, 3000))
                return "not found the next button.";

            //click post a project
            xpath = "//app-job-type//fl-radio-card";
            if (!TryClick(xpath, 1, 3000))
                return "not found the radio button.";

            if (_fixed)            
                xpath = "//app-project-budget-type//fl-radio-card[contains(@picturealt,'Fixed')]";                
            else
                xpath = "//app-project-budget-type//fl-radio-card[contains(@picturealt,'Hourly')]";

            if (!TryClick(xpath, 1, 3000))
                return "not found the fixed or hourly button.";

            xpath = "//fl-select[@fltrackinglabel='SelectCurrency']//select";
            TrySelectOption(xpath, 0);

            xpath = "//fl-select[@fltrackinglabel='SelectBudgetRange']//select";
            TrySelectOption(xpath, -1);
            
            //input the price            
            xpath = "//input[@id='customMinBudget']";
            if (await TryEnterText(xpath, _start, "value", 5000, true) == false)
                return "not found the custom budget setting.";

            xpath = "//input[@id='customMaxBudget']";
            if (await TryEnterText(xpath, _end, "value", 5000, true) == false)
                return "fail to find input button(budget input).";

            //click next
            xpath = "//fl-button//button[contains(text(),'Next')]";
            TryClick(xpath, 1, 3000);

            xpath = "//app-project-upgrades//fl-radio-card[contains(@picturealt,'Standard')]";
            if (!TryClick(xpath, 1, 3000))
                return "not found the standard button.";

            //click submit button
            xpath = "//app-submit//fl-button//button[contains(text(),'post')]";
            if (!TryClick(xpath, 1, 3000))
                return "not found the post button.";

            xpath = "//fl-banner-alert//div[contains(text(),'Failed to create project')]";
            var error = getText(xpath, 5000);
            if (error != "")
                return error;
            else
                return null;            
        }
        
        public void closeBrowser()
        {
            driver.Close();
        }
    }    
}
