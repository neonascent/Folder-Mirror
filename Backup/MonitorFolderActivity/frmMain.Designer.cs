namespace MonitorFolderActivity
{
    partial class frmMain
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
            this.btnStart_Stop = new System.Windows.Forms.Button();
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.lblToMonitor = new System.Windows.Forms.Label();
            this.lblActivity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart_Stop
            // 
            this.btnStart_Stop.Location = new System.Drawing.Point(439, 23);
            this.btnStart_Stop.Name = "btnStart_Stop";
            this.btnStart_Stop.Size = new System.Drawing.Size(75, 23);
            this.btnStart_Stop.TabIndex = 0;
            this.btnStart_Stop.Text = "Start";
            this.btnStart_Stop.UseVisualStyleBackColor = true;
            this.btnStart_Stop.Click += new System.EventHandler(this.btnStart_Stop_Click);
            // 
            // txtActivity
            // 
            this.txtActivity.Location = new System.Drawing.Point(12, 64);
            this.txtActivity.Multiline = true;
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(502, 188);
            this.txtActivity.TabIndex = 2;
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(12, 25);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(421, 20);
            this.txtFolderPath.TabIndex = 3;
            // 
            // lblToMonitor
            // 
            this.lblToMonitor.AutoSize = true;
            this.lblToMonitor.Location = new System.Drawing.Point(12, 9);
            this.lblToMonitor.Name = "lblToMonitor";
            this.lblToMonitor.Size = new System.Drawing.Size(88, 13);
            this.lblToMonitor.TabIndex = 5;
            this.lblToMonitor.Text = "Folder to monitor:";
            // 
            // lblActivity
            // 
            this.lblActivity.AutoSize = true;
            this.lblActivity.Location = new System.Drawing.Point(12, 48);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(41, 13);
            this.lblActivity.TabIndex = 6;
            this.lblActivity.Text = "Activity";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 264);
            this.Controls.Add(this.lblActivity);
            this.Controls.Add(this.lblToMonitor);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.txtActivity);
            this.Controls.Add(this.btnStart_Stop);
            this.Name = "frmMain";
            this.Text = "Monitor Folder Activity - by Max Persson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart_Stop;
        private System.Windows.Forms.TextBox txtActivity;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label lblToMonitor;
        private System.Windows.Forms.Label lblActivity;
    }
}

