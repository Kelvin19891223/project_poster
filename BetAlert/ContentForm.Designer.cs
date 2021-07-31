namespace BetAlert
{
    partial class ContentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_title = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_content = new System.Windows.Forms.RichTextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton9 = new MaterialSkin.Controls.MaterialButton();
            this.cmb_type = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_start_price = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_end_price = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_skills = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_category = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_level = new MaterialSkin.Controls.MaterialComboBox();
            this.btn_add_content = new MaterialSkin.Controls.MaterialButton();
            this.grid_note = new System.Windows.Forms.DataGridView();
            this.content_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content_action_1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.content_action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_note)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_title
            // 
            this.txt_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_title.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_title.Depth = 0;
            this.txt_title.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_title.Hint = "Type here";
            this.txt_title.Location = new System.Drawing.Point(12, 99);
            this.txt_title.MaxLength = 1000;
            this.txt_title.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_title.Multiline = false;
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(474, 50);
            this.txt_title.TabIndex = 1;
            this.txt_title.TabStop = false;
            this.txt_title.Text = "";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(9, 72);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(32, 19);
            this.materialLabel1.TabIndex = 76;
            this.materialLabel1.Text = "Title";
            // 
            // txt_content
            // 
            this.txt_content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_content.Location = new System.Drawing.Point(12, 152);
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(474, 108);
            this.txt_content.TabIndex = 2;
            this.txt_content.TabStop = false;
            this.txt_content.Text = "";
            // 
            // materialButton1
            // 
            this.materialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Depth = 0;
            this.materialButton1.DrawShadows = true;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(654, 686);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(168, 36);
            this.materialButton1.TabIndex = 81;
            this.materialButton1.Text = "CANCEL";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // materialButton9
            // 
            this.materialButton9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton9.AutoSize = false;
            this.materialButton9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton9.Depth = 0;
            this.materialButton9.DrawShadows = true;
            this.materialButton9.HighEmphasis = true;
            this.materialButton9.Icon = null;
            this.materialButton9.Location = new System.Drawing.Point(468, 686);
            this.materialButton9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton9.Name = "materialButton9";
            this.materialButton9.Size = new System.Drawing.Size(168, 36);
            this.materialButton9.TabIndex = 80;
            this.materialButton9.Text = "SAVE";
            this.materialButton9.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton9.UseAccentColor = false;
            this.materialButton9.UseVisualStyleBackColor = true;
            this.materialButton9.Click += new System.EventHandler(this.materialButton9_Click);
            // 
            // cmb_type
            // 
            this.cmb_type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_type.AutoResize = false;
            this.cmb_type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.cmb_type.Depth = 0;
            this.cmb_type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmb_type.DropDownHeight = 174;
            this.cmb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_type.DropDownWidth = 121;
            this.cmb_type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmb_type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Hint = "Select the Project Type";
            this.cmb_type.IntegralHeight = false;
            this.cmb_type.ItemHeight = 43;
            this.cmb_type.Items.AddRange(new object[] {
            "Fixed",
            "Hourly"});
            this.cmb_type.Location = new System.Drawing.Point(11, 314);
            this.cmb_type.MaxDropDownItems = 4;
            this.cmb_type.MouseState = MaterialSkin.MouseState.OUT;
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(810, 49);
            this.cmb_type.TabIndex = 3;
            this.cmb_type.TabStop = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(9, 292);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(89, 19);
            this.materialLabel2.TabIndex = 83;
            this.materialLabel2.Text = "Project Type";
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(9, 366);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(117, 19);
            this.materialLabel3.TabIndex = 85;
            this.materialLabel3.Text = "Estimate Budget";
            // 
            // txt_start_price
            // 
            this.txt_start_price.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_start_price.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_start_price.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_start_price.Depth = 0;
            this.txt_start_price.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_start_price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_start_price.Hint = "From";
            this.txt_start_price.Location = new System.Drawing.Point(11, 388);
            this.txt_start_price.MaxLength = 50;
            this.txt_start_price.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_start_price.Multiline = false;
            this.txt_start_price.Name = "txt_start_price";
            this.txt_start_price.Size = new System.Drawing.Size(387, 50);
            this.txt_start_price.TabIndex = 4;
            this.txt_start_price.TabStop = false;
            this.txt_start_price.Text = "20";
            // 
            // txt_end_price
            // 
            this.txt_end_price.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_end_price.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_end_price.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_end_price.Depth = 0;
            this.txt_end_price.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_end_price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_end_price.Hint = "To";
            this.txt_end_price.Location = new System.Drawing.Point(420, 388);
            this.txt_end_price.MaxLength = 50;
            this.txt_end_price.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_end_price.Multiline = false;
            this.txt_end_price.Name = "txt_end_price";
            this.txt_end_price.Size = new System.Drawing.Size(403, 50);
            this.txt_end_price.TabIndex = 5;
            this.txt_end_price.TabStop = false;
            this.txt_end_price.Text = "30";
            // 
            // txt_skills
            // 
            this.txt_skills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_skills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_skills.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_skills.Depth = 0;
            this.txt_skills.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_skills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_skills.Hint = "Type the skill";
            this.txt_skills.Location = new System.Drawing.Point(16, 463);
            this.txt_skills.MaxLength = 50;
            this.txt_skills.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_skills.Multiline = false;
            this.txt_skills.Name = "txt_skills";
            this.txt_skills.Size = new System.Drawing.Size(811, 50);
            this.txt_skills.TabIndex = 6;
            this.txt_skills.TabStop = false;
            this.txt_skills.Text = "process";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(9, 441);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(31, 19);
            this.materialLabel4.TabIndex = 88;
            this.materialLabel4.Text = "Skill";
            // 
            // materialLabel5
            // 
            this.materialLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(9, 516);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(95, 19);
            this.materialLabel5.TabIndex = 91;
            this.materialLabel5.Text = "Job Category";
            // 
            // txt_category
            // 
            this.txt_category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_category.AutoResize = false;
            this.txt_category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.txt_category.Depth = 0;
            this.txt_category.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.txt_category.DropDownHeight = 174;
            this.txt_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_category.DropDownWidth = 121;
            this.txt_category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txt_category.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_category.FormattingEnabled = true;
            this.txt_category.Hint = "Select the Project Type";
            this.txt_category.IntegralHeight = false;
            this.txt_category.ItemHeight = 43;
            this.txt_category.Items.AddRange(new object[] {
            "Scripting & Automation",
            "Desktop Software Development",
            "Full Stack Development",
            "Machine Learning",
            "Back-end Development"});
            this.txt_category.Location = new System.Drawing.Point(11, 538);
            this.txt_category.MaxDropDownItems = 4;
            this.txt_category.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_category.Name = "txt_category";
            this.txt_category.Size = new System.Drawing.Size(810, 49);
            this.txt_category.TabIndex = 7;
            this.txt_category.TabStop = false;
            // 
            // materialLabel6
            // 
            this.materialLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(9, 593);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(115, 19);
            this.materialLabel6.TabIndex = 93;
            this.materialLabel6.Text = "Freelancer Level";
            // 
            // txt_level
            // 
            this.txt_level.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_level.AutoResize = false;
            this.txt_level.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.txt_level.Depth = 0;
            this.txt_level.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.txt_level.DropDownHeight = 174;
            this.txt_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_level.DropDownWidth = 121;
            this.txt_level.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txt_level.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_level.FormattingEnabled = true;
            this.txt_level.Hint = "Select the Project Type";
            this.txt_level.IntegralHeight = false;
            this.txt_level.ItemHeight = 43;
            this.txt_level.Items.AddRange(new object[] {
            "Entry Level",
            "Intermediate",
            "Expert"});
            this.txt_level.Location = new System.Drawing.Point(11, 615);
            this.txt_level.MaxDropDownItems = 4;
            this.txt_level.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_level.Name = "txt_level";
            this.txt_level.Size = new System.Drawing.Size(810, 49);
            this.txt_level.TabIndex = 8;
            this.txt_level.TabStop = false;
            // 
            // btn_add_content
            // 
            this.btn_add_content.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add_content.AutoSize = false;
            this.btn_add_content.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_add_content.Depth = 0;
            this.btn_add_content.DrawShadows = true;
            this.btn_add_content.HighEmphasis = true;
            this.btn_add_content.Icon = null;
            this.btn_add_content.Location = new System.Drawing.Point(654, 269);
            this.btn_add_content.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_add_content.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_add_content.Name = "btn_add_content";
            this.btn_add_content.Size = new System.Drawing.Size(168, 36);
            this.btn_add_content.TabIndex = 94;
            this.btn_add_content.Text = "ADD";
            this.btn_add_content.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_add_content.UseAccentColor = false;
            this.btn_add_content.UseVisualStyleBackColor = true;
            this.btn_add_content.Click += new System.EventHandler(this.btn_add_content_Click);
            // 
            // grid_note
            // 
            this.grid_note.AllowUserToAddRows = false;
            this.grid_note.AllowUserToDeleteRows = false;
            this.grid_note.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_note.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.content_id,
            this.content_title,
            this.content_action_1,
            this.content_action});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_note.DefaultCellStyle = dataGridViewCellStyle1;
            this.grid_note.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_note.Location = new System.Drawing.Point(492, 99);
            this.grid_note.Name = "grid_note";
            this.grid_note.RowHeadersVisible = false;
            this.grid_note.Size = new System.Drawing.Size(329, 161);
            this.grid_note.TabIndex = 95;
            this.grid_note.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_note_CellClick);
            // 
            // content_id
            // 
            this.content_id.HeaderText = "id";
            this.content_id.Name = "content_id";
            this.content_id.Visible = false;
            // 
            // content_title
            // 
            this.content_title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.content_title.FillWeight = 112.4088F;
            this.content_title.HeaderText = "Title";
            this.content_title.Name = "content_title";
            // 
            // content_action_1
            // 
            this.content_action_1.HeaderText = "Flag";
            this.content_action_1.Name = "content_action_1";
            this.content_action_1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.content_action_1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.content_action_1.Width = 60;
            // 
            // content_action
            // 
            this.content_action.FillWeight = 87.59124F;
            this.content_action.HeaderText = "Action";
            this.content_action.Name = "content_action";
            this.content_action.Width = 60;
            // 
            // ContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 728);
            this.Controls.Add(this.grid_note);
            this.Controls.Add(this.btn_add_content);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.txt_level);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.txt_category);
            this.Controls.Add(this.txt_skills);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.txt_end_price);
            this.Controls.Add(this.txt_start_price);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.cmb_type);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.materialButton9);
            this.Controls.Add(this.txt_content);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.materialLabel1);
            this.Name = "ContentForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ContentForm";
            ((System.ComponentModel.ISupportInitialize)(this.grid_note)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txt_title;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.RichTextBox txt_content;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton9;
        private MaterialSkin.Controls.MaterialComboBox cmb_type;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox txt_start_price;
        private MaterialSkin.Controls.MaterialTextBox txt_end_price;
        private MaterialSkin.Controls.MaterialTextBox txt_skills;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialComboBox txt_category;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialComboBox txt_level;
        private MaterialSkin.Controls.MaterialButton btn_add_content;
        private System.Windows.Forms.DataGridView grid_note;
        private System.Windows.Forms.DataGridViewTextBoxColumn content_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn content_title;
        private System.Windows.Forms.DataGridViewCheckBoxColumn content_action_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn content_action;
    }
}