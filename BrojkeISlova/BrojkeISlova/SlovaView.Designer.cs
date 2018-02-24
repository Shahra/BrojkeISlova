namespace BrojkeISlova {
  partial class SlovaView {
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
      this.rjesenjeTextBox = new System.Windows.Forms.TextBox();
      this.remainingTimeProgressBar = new System.Windows.Forms.ProgressBar();
      this.stopButton = new System.Windows.Forms.Button();
      this.gotovButton = new System.Windows.Forms.Button();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // rjesenjeTextBox
      // 
      this.rjesenjeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.rjesenjeTextBox.Location = new System.Drawing.Point(2, 337);
      this.rjesenjeTextBox.Name = "rjesenjeTextBox";
      this.rjesenjeTextBox.Size = new System.Drawing.Size(903, 62);
      this.rjesenjeTextBox.TabIndex = 2;
      // 
      // remainingTimeProgressBar
      // 
      this.remainingTimeProgressBar.Location = new System.Drawing.Point(133, 208);
      this.remainingTimeProgressBar.MarqueeAnimationSpeed = 0;
      this.remainingTimeProgressBar.Maximum = 1200;
      this.remainingTimeProgressBar.Name = "remainingTimeProgressBar";
      this.remainingTimeProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.remainingTimeProgressBar.Size = new System.Drawing.Size(772, 60);
      this.remainingTimeProgressBar.Step = 100;
      this.remainingTimeProgressBar.TabIndex = 3;
      this.remainingTimeProgressBar.Value = 1200;
      // 
      // stopButton
      // 
      this.stopButton.Location = new System.Drawing.Point(2, 415);
      this.stopButton.Name = "stopButton";
      this.stopButton.Size = new System.Drawing.Size(1122, 119);
      this.stopButton.TabIndex = 4;
      this.stopButton.Text = "STOP";
      this.stopButton.UseVisualStyleBackColor = true;
      this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
      // 
      // gotovButton
      // 
      this.gotovButton.Location = new System.Drawing.Point(911, 337);
      this.gotovButton.Name = "gotovButton";
      this.gotovButton.Size = new System.Drawing.Size(199, 62);
      this.gotovButton.TabIndex = 5;
      this.gotovButton.Text = "GOTOVO";
      this.gotovButton.UseVisualStyleBackColor = true;
      this.gotovButton.Click += new System.EventHandler(this.gotovButton_Click);
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 50;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // SlovaView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1120, 533);
      this.Controls.Add(this.gotovButton);
      this.Controls.Add(this.stopButton);
      this.Controls.Add(this.remainingTimeProgressBar);
      this.Controls.Add(this.rjesenjeTextBox);
      this.Name = "SlovaView";
      this.Text = "SlovaView";
      this.Load += new System.EventHandler(this.SlovaView_Load);
      this.Resize += new System.EventHandler(this.SlovaView_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox rjesenjeTextBox;
    private System.Windows.Forms.ProgressBar remainingTimeProgressBar;
    private System.Windows.Forms.Button stopButton;
    private System.Windows.Forms.Button gotovButton;
    private System.Windows.Forms.Timer timer;
  }
}