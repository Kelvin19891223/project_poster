using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetAlert
{
    public partial class AccountForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int _id = 0;

        public AccountForm()
        {
            InitializeComponent();
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;

            init();
            _id = 0;
        }

        public AccountForm(int _account_id)
        {
            _id = _account_id;
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;

            init();
        }

        public void init()
        {            
            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //Save the account
            try
            {
                string bookmaker = btn_betmaker.SelectedItem.ToString();
                string username = txt_username.Text.Trim();
                string password = txt_password.Text.Trim();
                string answer = txt_answer.Text.Trim();
                if (username == "")
                {
                    MaterialMessageBox.Show("Please input the username.", "Error");
                    return;
                }

                if (password == "")
                {
                    MaterialMessageBox.Show("Please input the password.", "Error");
                    return;
                }

                if (bookmaker == "")
                {
                    MaterialMessageBox.Show("Please select the bookmaker.", "Error");
                    return;
                }

                MainApp.m_sql.saveAccountInfo(bookmaker, username, password, answer);

                DialogResult = DialogResult.OK;
                Close();
            } catch(Exception)
            {
                MaterialMessageBox.Show("Please select the bookmaker.", "Error");
                return;
            }
        }
    }
}
