using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetAlert
{
    public class Common
    {
    }

    public class Notification
    {
        public string competition { get; set; }
        public string event_number { get; set; }
        public string event_name { get; set; }
        public string selection_number { get; set; }
        public string selection_name { get; set; }
        public double rated_price { get; set; }
        public double back { get; set; }
        public double lay { get; set; }
        public double value { get; set; }
        public string date { get; set; }
        public string selection_id { get; set; }
        public string url { get; set; }        
    }


    public class UserSetting
    {
        public string bookmaker;
        public string username;
        public string password;
        public string answer;   //guru
        public string title;
        public string content;
        public string project_type;
        public string budget_from;
        public string budget_to;
        public string skills;
    }

}
