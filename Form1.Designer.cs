
namespace Pomidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Start_Button = new DarkUI.Controls.DarkButton();
            this.pathTextBox = new System.Windows.Forms.RichTextBox();
            this.newmdstextbox = new System.Windows.Forms.RichTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.CurrentFileProgressBar = new System.Windows.Forms.ProgressBar();
            this.AllFIlesProgressBar = new System.Windows.Forms.ProgressBar();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.LabelProgressBar = new DarkUI.Controls.DarkLabel();
            this.ParttoDeleteTextBox = new System.Windows.Forms.RichTextBox();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Start_Button.Location = new System.Drawing.Point(250, 240);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Padding = new System.Windows.Forms.Padding(5);
            this.Start_Button.Size = new System.Drawing.Size(127, 64);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.Text = "Start";
            this.Start_Button.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pathTextBox.ForeColor = System.Drawing.Color.White;
            this.pathTextBox.Location = new System.Drawing.Point(12, 34);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(205, 66);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.Text = "";
            this.pathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.pathTextBox_DragDrop);
            this.pathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.pathTextBox_DragEnter);
            this.pathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pathTextBox_KeyDown);
            // 
            // newmdstextbox
            // 
            this.newmdstextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newmdstextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newmdstextbox.ForeColor = System.Drawing.Color.White;
            this.newmdstextbox.Location = new System.Drawing.Point(414, 35);
            this.newmdstextbox.Name = "newmdstextbox";
            this.newmdstextbox.Size = new System.Drawing.Size(203, 66);
            this.newmdstextbox.TabIndex = 2;
            this.newmdstextbox.Text = "";
            this.newmdstextbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.newmdstextbox_DragDrop);
            this.newmdstextbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.newmdstextbox_DragEnter);
            this.newmdstextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.newmdstextbox_KeyDown);
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(37, 20);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(153, 13);
            this.darkLabel1.TabIndex = 3;
            this.darkLabel1.Text = "Path to a folder with amds files:";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(411, 20);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(201, 13);
            this.darkLabel2.TabIndex = 4;
            this.darkLabel2.Text = "Path to mds with things to be added mds;";
            // 
            // CurrentFileProgressBar
            // 
            this.CurrentFileProgressBar.Location = new System.Drawing.Point(12, 200);
            this.CurrentFileProgressBar.Name = "CurrentFileProgressBar";
            this.CurrentFileProgressBar.Size = new System.Drawing.Size(605, 23);
            this.CurrentFileProgressBar.TabIndex = 5;
            // 
            // AllFIlesProgressBar
            // 
            this.AllFIlesProgressBar.Location = new System.Drawing.Point(12, 157);
            this.AllFIlesProgressBar.Name = "AllFIlesProgressBar";
            this.AllFIlesProgressBar.Size = new System.Drawing.Size(605, 23);
            this.AllFIlesProgressBar.TabIndex = 6;
            this.AllFIlesProgressBar.Click += new System.EventHandler(this.AllFIlesProgressBar_Click);
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(9, 141);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(83, 13);
            this.darkLabel3.TabIndex = 7;
            this.darkLabel3.Text = "Overall progress";
            // 
            // LabelProgressBar
            // 
            this.LabelProgressBar.AutoSize = true;
            this.LabelProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.LabelProgressBar.Location = new System.Drawing.Point(9, 184);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new System.Drawing.Size(129, 13);
            this.LabelProgressBar.TabIndex = 8;
            this.LabelProgressBar.Text = "Progress in the current file";
            this.LabelProgressBar.Click += new System.EventHandler(this.darkLabel4_Click);
            // 
            // ParttoDeleteTextBox
            // 
            this.ParttoDeleteTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ParttoDeleteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParttoDeleteTextBox.ForeColor = System.Drawing.Color.White;
            this.ParttoDeleteTextBox.Location = new System.Drawing.Point(223, 34);
            this.ParttoDeleteTextBox.Name = "ParttoDeleteTextBox";
            this.ParttoDeleteTextBox.Size = new System.Drawing.Size(185, 96);
            this.ParttoDeleteTextBox.TabIndex = 9;
            this.ParttoDeleteTextBox.Text = "";
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(251, 7);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(124, 26);
            this.darkLabel5.TabIndex = 10;
            this.darkLabel5.Text = "Things to delete\r\n(separated by new lines):";
            this.darkLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.darkLabel5.Click += new System.EventHandler(this.darkLabel5_Click);
            // 
            // darkButton1
            // 
            this.darkButton1.AllowDrop = true;
            this.darkButton1.Location = new System.Drawing.Point(414, 108);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton1.Size = new System.Drawing.Size(203, 23);
            this.darkButton1.TabIndex = 11;
            this.darkButton1.Text = "Browse";
            this.darkButton1.DragDrop += new System.Windows.Forms.DragEventHandler(this.newmdstextbox_DragDrop);
            this.darkButton1.DragEnter += new System.Windows.Forms.DragEventHandler(this.newmdstextbox_DragEnter);
            this.darkButton1.Click += new System.EventHandler(this.darkButton1_Click_1);
            // 
            // darkButton2
            // 
            this.darkButton2.AllowDrop = true;
            this.darkButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.darkButton2.Location = new System.Drawing.Point(12, 108);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton2.Size = new System.Drawing.Size(205, 23);
            this.darkButton2.TabIndex = 12;
            this.darkButton2.Text = "Browse";
            this.darkButton2.DragDrop += new System.Windows.Forms.DragEventHandler(this.pathTextBox_DragDrop);
            this.darkButton2.DragEnter += new System.Windows.Forms.DragEventHandler(this.pathTextBox_DragEnter);
            this.darkButton2.Click += new System.EventHandler(this.darkButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 320);
            this.Controls.Add(this.darkButton2);
            this.Controls.Add(this.darkButton1);
            this.Controls.Add(this.darkLabel5);
            this.Controls.Add(this.LabelProgressBar);
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.AllFIlesProgressBar);
            this.Controls.Add(this.CurrentFileProgressBar);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.newmdstextbox);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.ParttoDeleteTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Pomidor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkButton Start_Button;
        private System.Windows.Forms.RichTextBox pathTextBox;
        private System.Windows.Forms.RichTextBox newmdstextbox;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private System.Windows.Forms.ProgressBar CurrentFileProgressBar;
        private System.Windows.Forms.ProgressBar AllFIlesProgressBar;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkLabel LabelProgressBar;
        private System.Windows.Forms.RichTextBox ParttoDeleteTextBox;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkButton darkButton1;
        private DarkUI.Controls.DarkButton darkButton2;
    }
}

