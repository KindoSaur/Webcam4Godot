
namespace WebcamApp
{
    partial class GodotWebcamCaptureTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GodotWebcamCaptureTool));
            this.cboCamera = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VideoFeed = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.serverAddres = new System.Windows.Forms.Label();
            this.portAddres = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.debugText = new System.Windows.Forms.Label();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.connectToGodot = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCamera
            // 
            this.cboCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCamera.FormattingEnabled = true;
            this.cboCamera.Location = new System.Drawing.Point(395, 63);
            this.cboCamera.Name = "cboCamera";
            this.cboCamera.Size = new System.Drawing.Size(296, 21);
            this.cboCamera.TabIndex = 0;
            this.cboCamera.SelectedIndexChanged += new System.EventHandler(this.cboCamera_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Camera";
            // 
            // VideoFeed
            // 
            this.VideoFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VideoFeed.Location = new System.Drawing.Point(11, 11);
            this.VideoFeed.Name = "VideoFeed";
            this.VideoFeed.Size = new System.Drawing.Size(333, 275);
            this.VideoFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.VideoFeed.TabIndex = 2;
            this.VideoFeed.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(395, 227);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(126, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "&Test Recording";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(565, 227);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(126, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(395, 11);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(296, 20);
            this.serverTextBox.TabIndex = 5;
            this.serverTextBox.Text = "127.0.0.1";
            // 
            // serverAddres
            // 
            this.serverAddres.AutoSize = true;
            this.serverAddres.Location = new System.Drawing.Point(350, 14);
            this.serverAddres.Name = "serverAddres";
            this.serverAddres.Size = new System.Drawing.Size(38, 13);
            this.serverAddres.TabIndex = 6;
            this.serverAddres.Text = "Server";
            // 
            // portAddres
            // 
            this.portAddres.AutoSize = true;
            this.portAddres.Location = new System.Drawing.Point(350, 40);
            this.portAddres.Name = "portAddres";
            this.portAddres.Size = new System.Drawing.Size(26, 13);
            this.portAddres.TabIndex = 8;
            this.portAddres.Text = "Port";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(395, 37);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(296, 20);
            this.portTextBox.TabIndex = 7;
            this.portTextBox.Text = "13000";
            // 
            // debugText
            // 
            this.debugText.AutoSize = true;
            this.debugText.Location = new System.Drawing.Point(350, 93);
            this.debugText.Name = "debugText";
            this.debugText.Size = new System.Drawing.Size(25, 13);
            this.debugText.TabIndex = 10;
            this.debugText.Text = "Log";
            // 
            // debugTextBox
            // 
            this.debugTextBox.Location = new System.Drawing.Point(395, 90);
            this.debugTextBox.Multiline = true;
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.ReadOnly = true;
            this.debugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugTextBox.Size = new System.Drawing.Size(296, 102);
            this.debugTextBox.TabIndex = 9;
            // 
            // connectToGodot
            // 
            this.connectToGodot.Location = new System.Drawing.Point(565, 198);
            this.connectToGodot.Name = "connectToGodot";
            this.connectToGodot.Size = new System.Drawing.Size(126, 23);
            this.connectToGodot.TabIndex = 11;
            this.connectToGodot.Text = "Connect To Godot";
            this.connectToGodot.UseVisualStyleBackColor = true;
            this.connectToGodot.Click += new System.EventHandler(this.connectToGodot_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(395, 198);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(126, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search For Camera(s)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.SearchForCameras);
            // 
            // GodotWebcamCaptureTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 298);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.connectToGodot);
            this.Controls.Add(this.debugText);
            this.Controls.Add(this.debugTextBox);
            this.Controls.Add(this.portAddres);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.serverAddres);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.VideoFeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GodotWebcamCaptureTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Webcam 4 Godot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnStart);
            ((System.ComponentModel.ISupportInitialize)(this.VideoFeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox VideoFeed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.Label serverAddres;
        private System.Windows.Forms.Label portAddres;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label debugText;
        private System.Windows.Forms.TextBox debugTextBox;
        private System.Windows.Forms.Button connectToGodot;
        private System.Windows.Forms.Button btnSearch;
    }
}

