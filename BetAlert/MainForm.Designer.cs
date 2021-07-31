namespace BetAlert
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_header = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_apply = new MaterialSkin.Controls.MaterialButton();
            this.txt_time = new MaterialSkin.Controls.MaterialLabel();
            this.btn_end = new System.Windows.Forms.DateTimePicker();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_start = new System.Windows.Forms.DateTimePicker();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.panel_footer = new System.Windows.Forms.Panel();
            this.txt_log = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.panel_sidebar = new System.Windows.Forms.Panel();
            this.btn_bot_start = new MaterialSkin.Controls.MaterialButton();
            this.btn_set_content = new MaterialSkin.Controls.MaterialButton();
            this.btn_add_account = new MaterialSkin.Controls.MaterialButton();
            this.m_grid_account = new System.Windows.Forms.DataGridView();
            this._bookmaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grid_note = new System.Windows.Forms.DataGridView();
            this.history_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.history_bookmaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.history_account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.history_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.history_result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image_status = new System.Windows.Forms.PictureBox();
            this.panel_header.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel_footer.SuspendLayout();
            this.panel_sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid_account)).BeginInit();
            this.panel_main.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_note)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_status)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_header.Controls.Add(this.panel4);
            this.panel_header.Location = new System.Drawing.Point(0, 64);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1112, 57);
            this.panel_header.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_apply);
            this.panel4.Controls.Add(this.txt_time);
            this.panel4.Controls.Add(this.btn_end);
            this.panel4.Controls.Add(this.materialLabel2);
            this.panel4.Controls.Add(this.btn_start);
            this.panel4.Controls.Add(this.materialLabel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1103, 55);
            this.panel4.TabIndex = 2;
            // 
            // btn_apply
            // 
            this.btn_apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_apply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_apply.Depth = 0;
            this.btn_apply.DrawShadows = true;
            this.btn_apply.HighEmphasis = true;
            this.btn_apply.Icon = null;
            this.btn_apply.Location = new System.Drawing.Point(980, 12);
            this.btn_apply.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_apply.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(117, 36);
            this.btn_apply.TabIndex = 10;
            this.btn_apply.Text = "Apply Filter";
            this.btn_apply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_apply.UseAccentColor = false;
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // txt_time
            // 
            this.txt_time.AutoSize = true;
            this.txt_time.Depth = 0;
            this.txt_time.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_time.Location = new System.Drawing.Point(3, 20);
            this.txt_time.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(33, 19);
            this.txt_time.TabIndex = 2;
            this.txt_time.Text = "Now";
            // 
            // btn_end
            // 
            this.btn_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.btn_end.Location = new System.Drawing.Point(800, 18);
            this.btn_end.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(137, 26);
            this.btn_end.TabIndex = 9;
            this.btn_end.Value = new System.DateTime(2021, 7, 30, 0, 0, 0, 0);
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(774, 22);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(20, 19);
            this.materialLabel2.TabIndex = 8;
            this.materialLabel2.Text = "To";
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.btn_start.Location = new System.Drawing.Point(540, 18);
            this.btn_start.Margin = new System.Windows.Forms.Padding(5);
            this.btn_start.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(145, 26);
            this.btn_start.TabIndex = 7;
            this.btn_start.Value = new System.DateTime(2021, 7, 30, 0, 0, 0, 0);
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(494, 22);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(38, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "From";
            // 
            // panel_footer
            // 
            this.panel_footer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_footer.Controls.Add(this.txt_log);
            this.panel_footer.Controls.Add(this.materialLabel1);
            this.panel_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_footer.Location = new System.Drawing.Point(0, 688);
            this.panel_footer.Name = "panel_footer";
            this.panel_footer.Size = new System.Drawing.Size(1111, 28);
            this.panel_footer.TabIndex = 1;
            // 
            // txt_log
            // 
            this.txt_log.AutoSize = true;
            this.txt_log.Depth = 0;
            this.txt_log.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_log.Location = new System.Drawing.Point(3, 6);
            this.txt_log.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(33, 19);
            this.txt_log.TabIndex = 4;
            this.txt_log.Text = "Now";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(957, 6);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(146, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Ineeds365 Company";
            // 
            // panel_sidebar
            // 
            this.panel_sidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_sidebar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_sidebar.Controls.Add(this.btn_bot_start);
            this.panel_sidebar.Controls.Add(this.btn_set_content);
            this.panel_sidebar.Controls.Add(this.btn_add_account);
            this.panel_sidebar.Controls.Add(this.m_grid_account);
            this.panel_sidebar.Location = new System.Drawing.Point(0, 120);
            this.panel_sidebar.Name = "panel_sidebar";
            this.panel_sidebar.Size = new System.Drawing.Size(497, 565);
            this.panel_sidebar.TabIndex = 2;
            // 
            // btn_bot_start
            // 
            this.btn_bot_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_bot_start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_bot_start.Depth = 0;
            this.btn_bot_start.DrawShadows = true;
            this.btn_bot_start.HighEmphasis = true;
            this.btn_bot_start.Icon = null;
            this.btn_bot_start.Location = new System.Drawing.Point(-9, 523);
            this.btn_bot_start.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_bot_start.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_bot_start.Name = "btn_bot_start";
            this.btn_bot_start.Size = new System.Drawing.Size(130, 36);
            this.btn_bot_start.TabIndex = 39;
            this.btn_bot_start.Text = "Start the Bot";
            this.btn_bot_start.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_bot_start.UseAccentColor = false;
            this.btn_bot_start.UseVisualStyleBackColor = true;
            this.btn_bot_start.Click += new System.EventHandler(this.btn_bot_start_Click);
            // 
            // btn_set_content
            // 
            this.btn_set_content.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_set_content.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_set_content.Depth = 0;
            this.btn_set_content.DrawShadows = true;
            this.btn_set_content.HighEmphasis = true;
            this.btn_set_content.Icon = null;
            this.btn_set_content.Location = new System.Drawing.Point(407, 525);
            this.btn_set_content.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_set_content.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_set_content.Name = "btn_set_content";
            this.btn_set_content.Size = new System.Drawing.Size(84, 36);
            this.btn_set_content.TabIndex = 38;
            this.btn_set_content.Text = "Refresh";
            this.btn_set_content.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_set_content.UseAccentColor = false;
            this.btn_set_content.UseVisualStyleBackColor = true;
            this.btn_set_content.Click += new System.EventHandler(this.btn_set_content_Click);
            // 
            // btn_add_account
            // 
            this.btn_add_account.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add_account.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_add_account.Depth = 0;
            this.btn_add_account.DrawShadows = true;
            this.btn_add_account.HighEmphasis = true;
            this.btn_add_account.Icon = null;
            this.btn_add_account.Location = new System.Drawing.Point(277, 525);
            this.btn_add_account.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_add_account.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_add_account.Name = "btn_add_account";
            this.btn_add_account.Size = new System.Drawing.Size(122, 36);
            this.btn_add_account.TabIndex = 37;
            this.btn_add_account.Text = "Add Account";
            this.btn_add_account.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_add_account.UseAccentColor = false;
            this.btn_add_account.UseVisualStyleBackColor = true;
            this.btn_add_account.Visible = false;
            this.btn_add_account.Click += new System.EventHandler(this.btn_add_account_Click);
            // 
            // m_grid_account
            // 
            this.m_grid_account.AllowDrop = true;
            this.m_grid_account.AllowUserToAddRows = false;
            this.m_grid_account.AllowUserToResizeColumns = false;
            this.m_grid_account.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.m_grid_account.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.m_grid_account.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_grid_account.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_grid_account.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.m_grid_account.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grid_account.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._bookmaker,
            this._account});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_grid_account.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_grid_account.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.m_grid_account.EnableHeadersVisualStyles = false;
            this.m_grid_account.Location = new System.Drawing.Point(3, 3);
            this.m_grid_account.MultiSelect = false;
            this.m_grid_account.Name = "m_grid_account";
            this.m_grid_account.ReadOnly = true;
            this.m_grid_account.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.m_grid_account.RowHeadersVisible = false;
            this.m_grid_account.Size = new System.Drawing.Size(492, 517);
            this.m_grid_account.TabIndex = 1;
            this.m_grid_account.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_grid_account_CellClick);
            // 
            // _bookmaker
            // 
            this._bookmaker.HeaderText = "Website";
            this._bookmaker.Name = "_bookmaker";
            this._bookmaker.ReadOnly = true;
            // 
            // _account
            // 
            this._account.HeaderText = "Account";
            this._account.Name = "_account";
            this._account.ReadOnly = true;
            // 
            // panel_main
            // 
            this.panel_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_main.Controls.Add(this.panel2);
            this.panel_main.Location = new System.Drawing.Point(498, 120);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(612, 565);
            this.panel_main.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grid_note);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(608, 561);
            this.panel2.TabIndex = 1;
            // 
            // grid_note
            // 
            this.grid_note.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_note.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.grid_note.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_note.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.history_id,
            this.history_bookmaker,
            this.history_account,
            this.history_time,
            this.history_result});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_note.DefaultCellStyle = dataGridViewCellStyle6;
            this.grid_note.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_note.Location = new System.Drawing.Point(3, 4);
            this.grid_note.MultiSelect = false;
            this.grid_note.Name = "grid_note";
            this.grid_note.ReadOnly = true;
            this.grid_note.RowHeadersVisible = false;
            this.grid_note.Size = new System.Drawing.Size(602, 554);
            this.grid_note.TabIndex = 0;
            // 
            // history_id
            // 
            this.history_id.HeaderText = "id";
            this.history_id.Name = "history_id";
            this.history_id.ReadOnly = true;
            this.history_id.Visible = false;
            // 
            // history_bookmaker
            // 
            this.history_bookmaker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.history_bookmaker.HeaderText = "Website";
            this.history_bookmaker.Name = "history_bookmaker";
            this.history_bookmaker.ReadOnly = true;
            // 
            // history_account
            // 
            this.history_account.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.history_account.HeaderText = "Account";
            this.history_account.Name = "history_account";
            this.history_account.ReadOnly = true;
            // 
            // history_time
            // 
            this.history_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.history_time.HeaderText = "Time";
            this.history_time.Name = "history_time";
            this.history_time.ReadOnly = true;
            // 
            // history_result
            // 
            this.history_result.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.history_result.HeaderText = "Result";
            this.history_result.Name = "history_result";
            this.history_result.ReadOnly = true;
            // 
            // image_status
            // 
            this.image_status.BackColor = System.Drawing.Color.Transparent;
            this.image_status.BackgroundImage = global::ProjectPoster.Properties.Resources.Circle_OFF;
            this.image_status.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image_status.Location = new System.Drawing.Point(5, 1);
            this.image_status.Name = "image_status";
            this.image_status.Size = new System.Drawing.Size(26, 22);
            this.image_status.TabIndex = 75;
            this.image_status.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1111, 716);
            this.Controls.Add(this.image_status);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_sidebar);
            this.Controls.Add(this.panel_footer);
            this.Controls.Add(this.panel_header);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Auto Poster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel_header.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel_footer.ResumeLayout(false);
            this.panel_footer.PerformLayout();
            this.panel_sidebar.ResumeLayout(false);
            this.panel_sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid_account)).EndInit();
            this.panel_main.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_note)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_status)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Panel panel_footer;
        private System.Windows.Forms.Panel panel_sidebar;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grid_note;
        private MaterialSkin.Controls.MaterialLabel txt_time;
        private System.Windows.Forms.PictureBox image_status;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btn_add_account;
        private MaterialSkin.Controls.MaterialButton btn_set_content;
        private MaterialSkin.Controls.MaterialButton btn_apply;
        private System.Windows.Forms.DateTimePicker btn_end;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DateTimePicker btn_start;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        public System.Windows.Forms.DataGridView m_grid_account;
        private MaterialSkin.Controls.MaterialButton btn_bot_start;
        private MaterialSkin.Controls.MaterialLabel txt_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn history_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn history_bookmaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn history_account;
        private System.Windows.Forms.DataGridViewTextBoxColumn history_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn history_result;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookmaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn _account;
    }
}

