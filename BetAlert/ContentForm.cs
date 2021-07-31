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
    public partial class ContentForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        public ContentForm()
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

            refresh();

            cmb_type.SelectedIndex = 1;
            txt_category.SelectedIndex = 1;
            txt_level.SelectedIndex = 1;
        }

        private void refresh()
        {
            try
            {
                grid_note.Rows.Clear();
                DataTable dt = MainApp.m_sql.getContent();
                for (var k = 0; k < dt.Rows.Count; k++)
                {
                    grid_note.Rows.Add(dt.Rows[k]["id"].ToString(), dt.Rows[k]["title"].ToString(), dt.Rows[k]["flag"].ToString().ToLower() == "true", "Delete");
                }             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            try
            {                               
                bool _project_type = (cmb_type.SelectedItem.ToString() == "Fixed");
                double _start_price = double.Parse(txt_start_price.Text);
                double _end_price = double.Parse(txt_end_price.Text);
                string[] _skills = txt_skills.Text.Split(',');
                string _category = txt_category.SelectedItem.ToString();
                string _level = txt_category.Text;
                
                MainForm._project_type = _project_type;
                MainForm._start_price = _start_price;
                MainForm._end_price = _end_price;
                MainForm._skills = _skills;
                MainForm._category = _category;
                MainForm._level = _level;                
            } catch(Exception)
            {
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btn_add_content_Click(object sender, EventArgs e)
        {
            string title = txt_title.Text;
            if (title == null || title.Length == 0)
            {
                MaterialMessageBox.Show("Please input the title", "Error");
                return;
            }

            string _content = txt_content.Text;
            if (_content == null || _content.Length == 0)
            {
                MaterialMessageBox.Show("Please input the content", "Error");
                return;
            }

            if (_content.Length < 50)
            {
                MaterialMessageBox.Show("Must be at least 50 characters long", "Error");
                return;
            }

            MainApp.m_sql.saveContent(title, _content, "true");
            refresh();
        }

        private void showTitle(string id)
        {
            try
            {                
                DataTable dt = MainApp.m_sql.getContent();
                for (var k = 0; k < dt.Rows.Count; k++)
                {
                    if (dt.Rows[k]["id"].ToString() == id)
                    {
                        txt_title.Text = dt.Rows[k]["title"].ToString();
                        txt_content.Text = dt.Rows[k]["content"].ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }            
        }

        private void grid_note_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 2 && e.RowIndex < grid_note.Rows.Count)   //flag
            {
                string id = grid_note.Rows[e.RowIndex].Cells[0].Value.ToString();
                string flag = grid_note.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (flag == "False")
                    flag = "true";
                else
                    flag = "false";
                MainApp.m_sql.updateContentFlag(id, flag);
                refresh();
            }

            if (e.ColumnIndex == 3 && e.RowIndex < grid_note.Rows.Count)   //delete
            {
                string id = grid_note.Rows[e.RowIndex].Cells[0].Value.ToString();
                MainApp.m_sql.deleteContent(id);
                refresh();
            }

            if (e.ColumnIndex == 1 && e.RowIndex < grid_note.Rows.Count)
            {
                string id = grid_note.Rows[e.RowIndex].Cells[0].Value.ToString();
                showTitle(id);
            }
        }
    }
}
