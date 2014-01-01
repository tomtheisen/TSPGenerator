namespace TspGenerator {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label DestinationsLabel;
            this.DestinationsTextbox = new System.Windows.Forms.TextBox();
            this.GenerateDestinationsButton = new System.Windows.Forms.Button();
            this.DestinationsPictureBox = new System.Windows.Forms.PictureBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.BreakerDestinationsButton = new System.Windows.Forms.Button();
            DestinationsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DestinationsLabel
            // 
            DestinationsLabel.AutoSize = true;
            DestinationsLabel.Location = new System.Drawing.Point(12, 12);
            DestinationsLabel.Name = "DestinationsLabel";
            DestinationsLabel.Size = new System.Drawing.Size(98, 20);
            DestinationsLabel.TabIndex = 0;
            DestinationsLabel.Text = "Destinations";
            // 
            // DestinationsTextbox
            // 
            this.DestinationsTextbox.Location = new System.Drawing.Point(116, 12);
            this.DestinationsTextbox.Name = "DestinationsTextbox";
            this.DestinationsTextbox.Size = new System.Drawing.Size(75, 26);
            this.DestinationsTextbox.TabIndex = 1;
            this.DestinationsTextbox.Text = "10";
            // 
            // GenerateDestinationsButton
            // 
            this.GenerateDestinationsButton.Location = new System.Drawing.Point(16, 52);
            this.GenerateDestinationsButton.Name = "GenerateDestinationsButton";
            this.GenerateDestinationsButton.Size = new System.Drawing.Size(175, 60);
            this.GenerateDestinationsButton.TabIndex = 2;
            this.GenerateDestinationsButton.Text = "Generate Destinations";
            this.GenerateDestinationsButton.UseVisualStyleBackColor = true;
            this.GenerateDestinationsButton.Click += new System.EventHandler(this.GenerateDestinationsButton_Click);
            // 
            // DestinationsPictureBox
            // 
            this.DestinationsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationsPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DestinationsPictureBox.Location = new System.Drawing.Point(395, 12);
            this.DestinationsPictureBox.Name = "DestinationsPictureBox";
            this.DestinationsPictureBox.Size = new System.Drawing.Size(432, 514);
            this.DestinationsPictureBox.TabIndex = 3;
            this.DestinationsPictureBox.TabStop = false;
            this.DestinationsPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.DestinationsPictureBox_Paint);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(16, 127);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(175, 59);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AbortButton
            // 
            this.AbortButton.Enabled = false;
            this.AbortButton.Location = new System.Drawing.Point(16, 203);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(175, 59);
            this.AbortButton.TabIndex = 5;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Interval = 1000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // BreakerDestinationsButton
            // 
            this.BreakerDestinationsButton.Location = new System.Drawing.Point(205, 54);
            this.BreakerDestinationsButton.Name = "BreakerDestinationsButton";
            this.BreakerDestinationsButton.Size = new System.Drawing.Size(175, 58);
            this.BreakerDestinationsButton.TabIndex = 6;
            this.BreakerDestinationsButton.Text = "Breaker Destinations";
            this.BreakerDestinationsButton.UseVisualStyleBackColor = true;
            this.BreakerDestinationsButton.Click += new System.EventHandler(this.BreakerDestinationsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 538);
            this.Controls.Add(this.BreakerDestinationsButton);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DestinationsPictureBox);
            this.Controls.Add(this.GenerateDestinationsButton);
            this.Controls.Add(this.DestinationsTextbox);
            this.Controls.Add(DestinationsLabel);
            this.Name = "MainForm";
            this.Text = "Traveler";
            ((System.ComponentModel.ISupportInitialize)(this.DestinationsPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DestinationsTextbox;
        private System.Windows.Forms.Button GenerateDestinationsButton;
        private System.Windows.Forms.PictureBox DestinationsPictureBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.Button BreakerDestinationsButton;
    }
}

