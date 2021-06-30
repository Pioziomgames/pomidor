
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
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            resources.ApplyResources(this.Start_Button, "Start_Button");
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // pathTextBox
            // 
            resources.ApplyResources(this.pathTextBox, "pathTextBox");
            this.pathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pathTextBox.ForeColor = System.Drawing.Color.White;
            this.pathTextBox.Name = "pathTextBox";
            // 
            // newmdstextbox
            // 
            resources.ApplyResources(this.newmdstextbox, "newmdstextbox");
            this.newmdstextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newmdstextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newmdstextbox.ForeColor = System.Drawing.Color.White;
            this.newmdstextbox.Name = "newmdstextbox";
            // 
            // darkLabel1
            // 
            resources.ApplyResources(this.darkLabel1, "darkLabel1");
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Name = "darkLabel1";
            // 
            // darkLabel2
            // 
            resources.ApplyResources(this.darkLabel2, "darkLabel2");
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Name = "darkLabel2";
            // 
            // CurrentFileProgressBar
            // 
            resources.ApplyResources(this.CurrentFileProgressBar, "CurrentFileProgressBar");
            this.CurrentFileProgressBar.Name = "CurrentFileProgressBar";
            // 
            // AllFIlesProgressBar
            // 
            resources.ApplyResources(this.AllFIlesProgressBar, "AllFIlesProgressBar");
            this.AllFIlesProgressBar.Name = "AllFIlesProgressBar";
            this.AllFIlesProgressBar.Click += new System.EventHandler(this.AllFIlesProgressBar_Click);
            // 
            // darkLabel3
            // 
            resources.ApplyResources(this.darkLabel3, "darkLabel3");
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Name = "darkLabel3";
            // 
            // LabelProgressBar
            // 
            resources.ApplyResources(this.LabelProgressBar, "LabelProgressBar");
            this.LabelProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Click += new System.EventHandler(this.darkLabel4_Click);
            // 
            // ParttoDeleteTextBox
            // 
            resources.ApplyResources(this.ParttoDeleteTextBox, "ParttoDeleteTextBox");
            this.ParttoDeleteTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ParttoDeleteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParttoDeleteTextBox.ForeColor = System.Drawing.Color.White;
            this.ParttoDeleteTextBox.Name = "ParttoDeleteTextBox";
            // 
            // darkLabel5
            // 
            resources.ApplyResources(this.darkLabel5, "darkLabel5");
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Click += new System.EventHandler(this.darkLabel5_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximizeBox = false;
            this.Name = "Form1";
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
    }
}

