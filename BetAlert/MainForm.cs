using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetAlert
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        private static System.Timers.Timer m_timer = new System.Timers.Timer();
        public static string _title;
        public static string _content;
        public static bool _project_type;
        public static double _start_price;
        public static double _end_price;
        public static string[] _skills;
        public static string _category;
        public static string _level;

        public List<UserSetting> _list = new List<UserSetting>();

        public MainForm()
        {
            InitializeComponent();
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            
            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);            

            txt_time.Text = MainApp.AuNow().ToString("dd/MM/yyyy hh:mm:ss");

            m_timer.Interval = 1000;
            m_timer.Elapsed += M_timer_Tick;
            m_timer.Start();

            _title = null;
            _content = null;
            
            //show the account info
            RefreshAccountGridView();
        }

        private void M_timer_Tick(object sender, EventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                txt_time.Text = MainApp.AuNow().ToString("dd/MM/yyyy hh:mm:ss");
            });            
        }         

        private void MainForm_Load(object sender, EventArgs e)
        {
            btn_end.Value = DateTime.Now;
            refreshHistoryTable();
            read();
        }
        

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                
            }
            catch (Exception) { }
        }

        private void refreshHistoryTable()
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                try
                {
                    string _start = btn_start.Value.ToString("yyyy-MM-dd");
                    string _end = btn_end.Value.ToString("yyyy-MM-dd");

                    DataTable dt = MainApp.m_sql.getHistory(_start, _end);
                    grid_note.Rows.Clear();
                    for (var k = 0; k < dt.Rows.Count; k++)
                    {
                        grid_note.Rows.Add(dt.Rows[k]["id"], dt.Rows[k]["bookmaker"], dt.Rows[k]["account_name"], dt.Rows[k]["time"], dt.Rows[k]["result"]);
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.StackTrace);
                }
            });            
        }

        private void RefreshAccountGridView()
        {
            try
            {
                //DataTable dt = MainApp.m_sql.getAccountInfo();
                m_grid_account.Rows.Clear();
                foreach(var item in _list)
                //for (var k =0; k <dt.Rows.Count; k++)
                {
                    //m_grid_account.Rows.Add(dt.Rows[k]["id"], dt.Rows[k]["bookmaker"], dt.Rows[k]["account_name"], "Delete");
                    m_grid_account.Rows.Add(item.bookmaker, item.username);
                }
            } catch(Exception) { }
        }

        private void btn_add_account_Click(object sender, EventArgs e)
        {
            AccountForm frm = new AccountForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefreshAccountGridView();
            }
        }

        private void m_grid_account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 3 && e.RowIndex < m_grid_account.Rows.Count)
            {
                string id = m_grid_account.Rows[e.RowIndex].Cells[0].Value.ToString();
                MainApp.m_sql.deleteAccountInfo(id);
                RefreshAccountGridView();
            }
        }

        public void read()
        {

            _list.Clear();

            // Read the setting files
            try
            {
                using (StreamReader r = new StreamReader("settings.json"))
                {

                    string json = r.ReadToEnd();
                    var items = JArray.Parse(json);
                    foreach (var item in items)
                    {
                        UserSetting _user = new UserSetting();
                        _user.bookmaker = item["bookmaker"].ToString();
                        _user.username = item["username"].ToString();
                        _user.password = item["password"].ToString();
                        _user.answer = item["answer"].ToString();
                        _user.title = item["title"].ToString();
                        _user.content = item["content"].ToString();
                        _user.project_type = item["project_type"].ToString();
                        _user.budget_from = item["budget_from"].ToString();
                        _user.budget_to = item["budget_to"].ToString();
                        _user.skills = item["skills"].ToString();
                        _list.Add(_user);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to read the setting file.");
            }

            // set the user
            RefreshAccountGridView();
        }

        private void btn_set_content_Click(object sender, EventArgs e)
        {
            read();  
        }

        public void setLog(string msg)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                txt_log.Text = msg;
            });
        }

        private void btn_bot_start_Click(object sender, EventArgs e)
        {
            //if (_title == null)
            //    return;

            new Thread(async () =>
            {
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    btn_bot_start.Enabled = false;
                });

                //bool flag = false;
                //DataTable dt1 = MainApp.m_sql.getContent();
                //for (var k = 0; k < dt1.Rows.Count; k++)
                //{
                //    if (dt1.Rows[k]["flag"].ToString().ToLower() == "true")
                //    {
                //        flag = true;
                //        break;
                //    }
                //}

                //if (!flag)
                //{
                //    MaterialMessageBox.Show("Not content.", "Error");
                //    return;
                //}

                //DataTable dt = MainApp.m_sql.getAccountInfo();
                foreach(var item in _list)
                //for (var k = 0; k < dt.Rows.Count; k++)
                {
                    string bookmaker = item.bookmaker;
                    string account_username = item.username;
                    string account_password = item.password;
                    string answer = item.answer;

                    if (bookmaker.ToLower().Trim() == "freelancer")
                    {
                        FreelancerHelper _helper = new FreelancerHelper(account_username, account_password);

                        MainApp.log_info("Staring the freelancer");
                        bool result = await _helper.StartBrowser();

                        if (result)
                        {                            
                            MainApp.log_info("Posting in the freelancer.");
                            string title = item.title;
                            string _contents = item.content;

                            string _result = await _helper.startPost(title, _contents, item.project_type.ToLower() == "fixed", item.budget_from, item.budget_to);

                            MainApp.m_sql.saveHistory(account_username, bookmaker, _result == null ? "Success" : _result);                            
                        }
                        else
                        {
                            MainApp.log_info("Can not sign in the freelancer. please check account username and userpassword.");
                        }
                        _helper.closeBrowser();
                    }

                    else if (bookmaker.ToLower().Trim() == "guru")
                    {
                        GuruHelper _helper = new GuruHelper(account_username, account_password, answer);

                        MainApp.log_info("Staring the guru bot");
                        bool result = await _helper.StartBrowser();

                        if (result)
                        {
                            
                            MainApp.log_info("Posting");
                            string _result = await _helper.startPost(item.title, item.content, item.project_type.ToLower() == "fixed", item.budget_from, item.budget_to);
                            MainApp.m_sql.saveHistory(account_username, bookmaker, _result == null ? "Success" : _result);                            
                        }
                        else
                        {
                            MainApp.log_info("Can not sign in the freelancer. please check account username and userpassword.");
                        }
                        _helper.closeBrowser();
                    }

                    else if (bookmaker.ToLower().Trim() == "upwork")
                    {
                        UpworkHelper _helper = new UpworkHelper(account_username, account_password, answer);

                        MainApp.log_info("Staring the upwork bot");
                        bool result = await _helper.StartBrowser();

                        if (result)
                        {

                            MainApp.log_info("Posting");
                            string _result = await _helper.startPost(item.title, item.content, item.project_type.ToLower() == "fixed", item.budget_from, item.budget_to);
                            MainApp.m_sql.saveHistory(account_username, bookmaker, _result == null ? "Success" : _result);
                        }
                        else
                        {
                            MainApp.log_info("Can not sign in the freelancer. please check account username and userpassword.");
                        }
                        _helper.closeBrowser();
                    }
                }
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    btn_bot_start.Enabled = true;
                });

                refreshHistoryTable();
            }).Start();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            refreshHistoryTable();
        }
    }
}


