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
      this.rjesenjeTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // rjesenjeTextBox
      // 
      this.rjesenjeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.rjesenjeTextBox.Location = new System.Drawing.Point(12, 273);
      this.rjesenjeTextBox.Name = "rjesenjeTextBox";
      this.rjesenjeTextBox.Size = new System.Drawing.Size(772, 62);
      this.rjesenjeTextBox.TabIndex = 2;
      // 
      // SlovaView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1119, 654);
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
  }
}