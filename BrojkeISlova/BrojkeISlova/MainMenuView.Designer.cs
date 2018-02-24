namespace BrojkeISlova {
  partial class MainMenuView {
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
      this.igrajButton = new System.Windows.Forms.Button();
      this.postavkeButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // igrajButton
      // 
      this.igrajButton.Location = new System.Drawing.Point(87, 46);
      this.igrajButton.Name = "igrajButton";
      this.igrajButton.Size = new System.Drawing.Size(117, 23);
      this.igrajButton.TabIndex = 0;
      this.igrajButton.Text = "IGRAJ";
      this.igrajButton.UseVisualStyleBackColor = true;
      this.igrajButton.Click += new System.EventHandler(this.igrajButton_Click);
      // 
      // postavkeButton
      // 
      this.postavkeButton.Location = new System.Drawing.Point(87, 130);
      this.postavkeButton.Name = "postavkeButton";
      this.postavkeButton.Size = new System.Drawing.Size(117, 23);
      this.postavkeButton.TabIndex = 1;
      this.postavkeButton.Text = "POSTAVKE";
      this.postavkeButton.UseVisualStyleBackColor = true;
      this.postavkeButton.Click += new System.EventHandler(this.postavkeButton_Click);
      // 
      // MainMenuView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.postavkeButton);
      this.Controls.Add(this.igrajButton);
      this.Name = "MainMenuView";
      this.Text = "MainMenuView";
      this.Load += new System.EventHandler(this.MainMenuView_Load);
      this.Resize += new System.EventHandler(this.MainMenuView_Resize);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button igrajButton;
    private System.Windows.Forms.Button postavkeButton;
  }
}