namespace GR_King
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.status = new System.Windows.Forms.Label();
            this.expiry = new Siticone.UI.WinForms.SiticoneLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.openemulatorbutton = new Siticone.UI.WinForms.SiticoneRoundedGradientButton();
            this.startgamebutton = new Siticone.UI.WinForms.SiticoneRoundedGradientButton();
            this.safeExitbutton = new Siticone.UI.WinForms.SiticoneRoundedGradientButton();
            this.tickinlobbybox = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.cracklable = new System.Windows.Forms.Label();
            this.siticoneComboBox2 = new Siticone.UI.WinForms.SiticoneComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnkillgameloop = new Siticone.UI.WinForms.SiticoneRoundedGradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(512, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.Transparent;
            this.CloseBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseBox.BackgroundImage")));
            this.CloseBox.Location = new System.Drawing.Point(539, 0);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(28, 28);
            this.CloseBox.TabIndex = 1;
            this.CloseBox.TabStop = false;
            this.CloseBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.Color.Transparent;
            this.radioButton4.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton4.Location = new System.Drawing.Point(336, 14);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(86, 24);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Vietnam";
            this.radioButton4.UseVisualStyleBackColor = false;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Transparent;
            this.radioButton3.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton3.Location = new System.Drawing.Point(150, 14);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(68, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Korea";
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton2.Location = new System.Drawing.Point(237, 14);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Taiwan";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton1.Location = new System.Drawing.Point(63, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Global";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status.Location = new System.Drawing.Point(144, 325);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(287, 19);
            this.status.TabIndex = 10;
            this.status.Text = "Open Emulator First !";
            this.status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.status.Click += new System.EventHandler(this.label3_Click);
            // 
            // expiry
            // 
            this.expiry.BackColor = System.Drawing.Color.Transparent;
            this.expiry.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expiry.ForeColor = System.Drawing.Color.LightGray;
            this.expiry.Location = new System.Drawing.Point(1, 331);
            this.expiry.Margin = new System.Windows.Forms.Padding(2);
            this.expiry.Name = "expiry";
            this.expiry.Size = new System.Drawing.Size(139, 14);
            this.expiry.TabIndex = 46;
            this.expiry.Text = "Expiry: 9999-06-30 18:45:20";
            this.expiry.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // openemulatorbutton
            // 
            this.openemulatorbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.openemulatorbutton.CheckedState.Parent = this.openemulatorbutton;
            this.openemulatorbutton.CustomImages.Parent = this.openemulatorbutton;
            this.openemulatorbutton.FillColor = System.Drawing.Color.Empty;
            this.openemulatorbutton.FillColor2 = System.Drawing.Color.Empty;
            this.openemulatorbutton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openemulatorbutton.ForeColor = System.Drawing.Color.White;
            this.openemulatorbutton.HoveredState.Parent = this.openemulatorbutton;
            this.openemulatorbutton.Location = new System.Drawing.Point(387, 122);
            this.openemulatorbutton.Name = "openemulatorbutton";
            this.openemulatorbutton.ShadowDecoration.Parent = this.openemulatorbutton;
            this.openemulatorbutton.Size = new System.Drawing.Size(150, 33);
            this.openemulatorbutton.TabIndex = 49;
            this.openemulatorbutton.Text = "OPEN EMULATOR";
            this.openemulatorbutton.Click += new System.EventHandler(this.siticoneRoundedGradientButton1_Click);
            // 
            // startgamebutton
            // 
            this.startgamebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.startgamebutton.CheckedState.Parent = this.startgamebutton;
            this.startgamebutton.CustomImages.Parent = this.startgamebutton;
            this.startgamebutton.FillColor = System.Drawing.Color.Empty;
            this.startgamebutton.FillColor2 = System.Drawing.Color.Empty;
            this.startgamebutton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startgamebutton.ForeColor = System.Drawing.Color.White;
            this.startgamebutton.HoveredState.Parent = this.startgamebutton;
            this.startgamebutton.Location = new System.Drawing.Point(387, 174);
            this.startgamebutton.Name = "startgamebutton";
            this.startgamebutton.ShadowDecoration.Parent = this.startgamebutton;
            this.startgamebutton.Size = new System.Drawing.Size(150, 33);
            this.startgamebutton.TabIndex = 50;
            this.startgamebutton.Text = "START GAME";
            this.startgamebutton.Click += new System.EventHandler(this.siticoneRoundedGradientButton2_Click);
            // 
            // safeExitbutton
            // 
            this.safeExitbutton.BackColor = System.Drawing.Color.Crimson;
            this.safeExitbutton.CheckedState.Parent = this.safeExitbutton;
            this.safeExitbutton.CustomImages.Parent = this.safeExitbutton;
            this.safeExitbutton.FillColor = System.Drawing.Color.Empty;
            this.safeExitbutton.FillColor2 = System.Drawing.Color.Empty;
            this.safeExitbutton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.safeExitbutton.ForeColor = System.Drawing.Color.White;
            this.safeExitbutton.HoveredState.Parent = this.safeExitbutton;
            this.safeExitbutton.Location = new System.Drawing.Point(387, 225);
            this.safeExitbutton.Name = "safeExitbutton";
            this.safeExitbutton.ShadowDecoration.Parent = this.safeExitbutton;
            this.safeExitbutton.Size = new System.Drawing.Size(150, 33);
            this.safeExitbutton.TabIndex = 51;
            this.safeExitbutton.Text = "SAFE EXIT /98";
            this.safeExitbutton.Click += new System.EventHandler(this.siticoneRoundedGradientButton3_Click);
            // 
            // tickinlobbybox
            // 
            this.tickinlobbybox.BackColor = System.Drawing.Color.Transparent;
            this.tickinlobbybox.CheckedState.BorderColor = System.Drawing.Color.LimeGreen;
            this.tickinlobbybox.CheckedState.BorderRadius = 2;
            this.tickinlobbybox.CheckedState.BorderThickness = 0;
            this.tickinlobbybox.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
            this.tickinlobbybox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickinlobbybox.ForeColor = System.Drawing.Color.Red;
            this.tickinlobbybox.Location = new System.Drawing.Point(14, 27);
            this.tickinlobbybox.Name = "tickinlobbybox";
            this.tickinlobbybox.Size = new System.Drawing.Size(137, 20);
            this.tickinlobbybox.TabIndex = 53;
            this.tickinlobbybox.Text = "Tick in Lobby";
            this.tickinlobbybox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tickinlobbybox.UncheckedState.BorderColor = System.Drawing.Color.White;
            this.tickinlobbybox.UncheckedState.BorderRadius = 2;
            this.tickinlobbybox.UncheckedState.BorderThickness = 0;
            this.tickinlobbybox.UncheckedState.FillColor = System.Drawing.Color.White;
            this.tickinlobbybox.UseVisualStyleBackColor = false;
            this.tickinlobbybox.CheckedChanged += new System.EventHandler(this.siticoneCheckBox2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 57;
            this.label1.Text = "GR King Gameloop 1.6";
            // 
            // timer5
            // 
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // cracklable
            // 
            this.cracklable.AutoSize = true;
            this.cracklable.Location = new System.Drawing.Point(55, 171);
            this.cracklable.Name = "cracklable";
            this.cracklable.Size = new System.Drawing.Size(79, 13);
            this.cracklable.TabIndex = 58;
            this.cracklable.Text = "crackable lable";
            // 
            // siticoneComboBox2
            // 
            this.siticoneComboBox2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.siticoneComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siticoneComboBox2.FocusedColor = System.Drawing.Color.Tan;
            this.siticoneComboBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneComboBox2.ForeColor = System.Drawing.Color.Black;
            this.siticoneComboBox2.FormattingEnabled = true;
            this.siticoneComboBox2.HoveredState.Parent = this.siticoneComboBox2;
            this.siticoneComboBox2.IntegralHeight = false;
            this.siticoneComboBox2.ItemHeight = 22;
            this.siticoneComboBox2.Items.AddRange(new object[] {
            "4.4",
            "7.1"});
            this.siticoneComboBox2.ItemsAppearance.Parent = this.siticoneComboBox2;
            this.siticoneComboBox2.Location = new System.Drawing.Point(42, 163);
            this.siticoneComboBox2.Name = "siticoneComboBox2";
            this.siticoneComboBox2.ShadowDecoration.Parent = this.siticoneComboBox2;
            this.siticoneComboBox2.Size = new System.Drawing.Size(103, 28);
            this.siticoneComboBox2.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(49, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 81;
            this.label2.Text = "GAMELOOP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(48, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 47);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Version";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.tickinlobbybox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(15, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 64);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lobby Antiban";
            // 
            // btnkillgameloop
            // 
            this.btnkillgameloop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnkillgameloop.CheckedState.Parent = this.btnkillgameloop;
            this.btnkillgameloop.CustomImages.Parent = this.btnkillgameloop;
            this.btnkillgameloop.FillColor = System.Drawing.Color.Empty;
            this.btnkillgameloop.FillColor2 = System.Drawing.Color.Empty;
            this.btnkillgameloop.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnkillgameloop.ForeColor = System.Drawing.Color.White;
            this.btnkillgameloop.HoveredState.Parent = this.btnkillgameloop;
            this.btnkillgameloop.Location = new System.Drawing.Point(387, 277);
            this.btnkillgameloop.Name = "btnkillgameloop";
            this.btnkillgameloop.ShadowDecoration.Parent = this.btnkillgameloop;
            this.btnkillgameloop.Size = new System.Drawing.Size(150, 33);
            this.btnkillgameloop.TabIndex = 84;
            this.btnkillgameloop.Text = "Force Kill Emulator";
            this.btnkillgameloop.Click += new System.EventHandler(this.siticoneRoundedGradientButton1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(566, 349);
            this.Controls.Add(this.btnkillgameloop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.siticoneComboBox2);
            this.Controls.Add(this.cracklable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.safeExitbutton);
            this.Controls.Add(this.startgamebutton);
            this.Controls.Add(this.openemulatorbutton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.expiry);
            this.Controls.Add(this.status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRKing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label status;
        private Siticone.UI.WinForms.SiticoneLabel expiry;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Timer timer3;
        private Siticone.UI.WinForms.SiticoneRoundedGradientButton openemulatorbutton;
        private Siticone.UI.WinForms.SiticoneRoundedGradientButton safeExitbutton;
        private Siticone.UI.WinForms.SiticoneRoundedGradientButton startgamebutton;
        private Siticone.UI.WinForms.SiticoneCheckBox tickinlobbybox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Label cracklable;
        private System.Windows.Forms.Label label2;
        private Siticone.UI.WinForms.SiticoneComboBox siticoneComboBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Siticone.UI.WinForms.SiticoneRoundedGradientButton btnkillgameloop;
    }
}

