namespace BrojkeISlova {
  partial class BrojkeView {
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
      this.gotovButton = new System.Windows.Forms.Button();
      this.stopButton = new System.Windows.Forms.Button();
      this.remainingTimeProgressBar = new System.Windows.Forms.ProgressBar();
      this.rjesenjeTextBox = new System.Windows.Forms.TextBox();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.trazeniBrojTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // gotovButton
      // 
      this.gotovButton.Location = new System.Drawing.Point(908, 371);
      this.gotovButton.Name = "gotovButton";
      this.gotovButton.Size = new System.Drawing.Size(199, 62);
      this.gotovButton.TabIndex = 9;
      this.gotovButton.Text = "GOTOVO";
      this.gotovButton.UseVisualStyleBackColor = true;
      this.gotovButton.Click += new System.EventHandler(this.gotovButton_Click);
      // 
      // stopButton
      // 
      this.stopButton.Location = new System.Drawing.Point(-1, 449);
      this.stopButton.Name = "stopButton";
      this.stopButton.Size = new System.Drawing.Size(1122, 119);
      this.stopButton.TabIndex = 8;
      this.stopButton.Text = "STOP";
      this.stopButton.UseVisualStyleBackColor = true;
      this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
      // 
      // remainingTimeProgressBar
      // 
      this.remainingTimeProgressBar.Location = new System.Drawing.Point(130, 242);
      this.remainingTimeProgressBar.MarqueeAnimationSpeed = 0;
      this.remainingTimeProgressBar.Maximum = 1200;
      this.remainingTimeProgressBar.Name = "remainingTimeProgressBar";
      this.remainingTimeProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.remainingTimeProgressBar.Size = new System.Drawing.Size(772, 60);
      this.remainingTimeProgressBar.Step = 100;
      this.remainingTimeProgressBar.TabIndex = 7;
      this.remainingTimeProgressBar.Value = 1200;
      // 
      // rjesenjeTextBox
      // 
      this.rjesenjeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.rjesenjeTextBox.Location = new System.Drawing.Point(-1, 371);
      this.rjesenjeTextBox.Name = "rjesenjeTextBox";
      this.rjesenjeTextBox.Size = new System.Drawing.Size(903, 62);
      this.rjesenjeTextBox.TabIndex = 6;
      this.rjesenjeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 50;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // trazeniBrojTextBox
      // 
      this.trazeniBrojTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.trazeniBrojTextBox.Location = new System.Drawing.Point(425, 71);
      this.trazeniBrojTextBox.Name = "trazeniBrojTextBox";
      this.trazeniBrojTextBox.Size = new System.Drawing.Size(236, 62);
      this.trazeniBrojTextBox.TabIndex = 10;
      this.trazeniBrojTextBox.Text = "1000";
      this.trazeniBrojTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // BrojkeView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1120, 569);
      this.Controls.Add(this.trazeniBrojTextBox);
      this.Controls.Add(this.gotovButton);
      this.Controls.Add(this.stopButton);
      this.Controls.Add(this.remainingTimeProgressBar);
      this.Controls.Add(this.rjesenjeTextBox);
      this.Name = "BrojkeView";
      this.Text = "BrojkeView";
      this.Load += new System.EventHandler(this.BrojkeView_Load);
      this.Resize += new System.EventHandler(this.BrojkeView_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button gotovButton;
    private System.Windows.Forms.Button stopButton;
    private System.Windows.Forms.ProgressBar remainingTimeProgressBar;
    private System.Windows.Forms.TextBox rjesenjeTextBox;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.TextBox trazeniBrojTextBox;
  }
}