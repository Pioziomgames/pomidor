
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
            this.Start_Button = new DarkUI.Controls.DarkButton();
            this.pathTextBox = new System.Windows.Forms.RichTextBox();
            this.newmdstextbox = new System.Windows.Forms.RichTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.CurrentFileProgressBar = new System.Windows.Forms.ProgressBar();
            this.AllFIlesProgressBar = new System.Windows.Forms.ProgressBar();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_Button.Location = new System.Drawing.Point(240, 272);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Padding = new System.Windows.Forms.Padding(5);
            this.Start_Button.Size = new System.Drawing.Size(154, 64);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.Text = "Start";
            this.Start_Button.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pathTextBox.ForeColor = System.Drawing.Color.White;
            this.pathTextBox.Location = new System.Drawing.Point(61, 85);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(120, 96);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.Text = "";
            // 
            // newmdstextbox
            // 
            this.newmdstextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newmdstextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newmdstextbox.ForeColor = System.Drawing.Color.White;
            this.newmdstextbox.Location = new System.Drawing.Point(447, 86);
            this.newmdstextbox.Name = "newmdstextbox";
            this.newmdstextbox.Size = new System.Drawing.Size(127, 96);
            this.newmdstextbox.TabIndex = 2;
            this.newmdstextbox.Text = "";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(61, 67);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(120, 13);
            this.darkLabel1.TabIndex = 3;
            this.darkLabel1.Text = "Path to folder with amds";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(444, 67);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(142, 13);
            this.darkLabel2.TabIndex = 4;
            this.darkLabel2.Text = "Path to mds with new things:";
            // 
            // CurrentFileProgressBar
            // 
            this.CurrentFileProgressBar.Location = new System.Drawing.Point(186, 231);
            this.CurrentFileProgressBar.Name = "CurrentFileProgressBar";
            this.CurrentFileProgressBar.Size = new System.Drawing.Size(248, 23);
            this.CurrentFileProgressBar.TabIndex = 5;
            // 
            // AllFIlesProgressBar
            // 
            this.AllFIlesProgressBar.Location = new System.Drawing.Point(186, 188);
            this.AllFIlesProgressBar.Name = "AllFIlesProgressBar";
            this.AllFIlesProgressBar.Size = new System.Drawing.Size(248, 23);
            this.AllFIlesProgressBar.TabIndex = 6;
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(187, 172);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(93, 13);
            this.darkLabel3.TabIndex = 7;
            this.darkLabel3.Text = "Progress in all files";
            // 
            // darkLabel4
            // 
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(183, 214);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(129, 13);
            this.darkLabel4.TabIndex = 8;
            this.darkLabel4.Text = "Progress in the current file";
            this.darkLabel4.Click += new System.EventHandler(this.darkLabel4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 361);
            this.Controls.Add(this.darkLabel4);
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.AllFIlesProgressBar);
            this.Controls.Add(this.CurrentFileProgressBar);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.newmdstextbox);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.Start_Button);
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
        private DarkUI.Controls.DarkLabel darkLabel4;
    }
}

