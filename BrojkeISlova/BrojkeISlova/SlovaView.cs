using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrojkeISlova {
  public partial class SlovaView : Form {
    int brojSlova;
    Random random = new Random();
    TextBox[] slova = new TextBox[15];
    String[] mogucaSlova = { "a", "b", "c", "č", "ć", "d", "đ", "dž", "e", "f", "g", "h", "i", "j", "k", "l", "lj", "m", "n", "nj", "o", "p", "r", "s", "š", "t", "u", "v", "z", "ž" };
    int[] brojPojavljivanjaZadanihSlova = new int[30];
    int trenutnoSlovo = 0;
    int offset = 2;

    public SlovaView(int brojSlova = 15) {
      InitializeComponent();
      this.brojSlova = brojSlova;
      WindowState = FormWindowState.Maximized;
    }

    private void SlovaView_Load(object sender, EventArgs e) {
      for (int i = 0; i < brojSlova; i++) {
        slova[i] = new TextBox();
        slova[i].TextAlign = HorizontalAlignment.Center;
        Controls.Add(slova[i]);
      }
      ResizeSlova();
      ResizeRjesenje();
      ResizeRemainingTime();
      ResizeGotovButton();
      ResizeStopButton();
    }

    private void SlovaView_Resize(object sender, EventArgs e) {
      ResizeSlova();
      ResizeRjesenje();
      ResizeRemainingTime();
      ResizeGotovButton();
      ResizeStopButton();
    }

    private void ResizeSlova() {
      int top = (int)(0.2 * ClientSize.Height);
      int width = (int)(ClientSize.Width - 16 * offset) / 15;
      int height = (int)(0.15 * ClientSize.Height);
      int left = (int)(ClientSize.Width - (brojSlova * width + (brojSlova - 1) * offset)) / 2;

      for (int i = 0; i < brojSlova; i++) {
        left += offset;
        UtilityFunctions.PositionTextBox(slova[i], left, top, width, height);
        left += width;
      }
    }

    private void ResizeRjesenje() {
      int top = (int)(0.6 * ClientSize.Height);
      int width = (int)(0.7 * ClientSize.Width) - 2 * 10;
      int height = (int)(0.15 * ClientSize.Height);
      int left = 10;
      UtilityFunctions.PositionTextBox(rjesenjeTextBox, left, top, width, height);
    }

    private void ResizeGotovButton() {
      UtilityFunctions.PositionButton(gotovButton, 0.71, 0.6, 0.28, 0.15, ClientSize);
    }

    private void ResizeStopButton() {
      UtilityFunctions.PositionButton(stopButton, 0, 0.8, 1, 0.2, ClientSize);
    }

    private void ResizeRemainingTime() {
      UtilityFunctions.PositionProgressBar(remainingTimeProgressBar, 0.2, 0.45, 0.6, 0.05, ClientSize);
    }

    private void timer_Tick(object sender, EventArgs e) {
      if (trenutnoSlovo < brojSlova) {
        stopButton.Focus();
        slova[trenutnoSlovo].Text = mogucaSlova[random.Next(0, 30)];
      }
      else {
        if (remainingTimeProgressBar.Value - 1 >= 0) {
          remainingTimeProgressBar.Value -= 1;
        }
        else {
          Kraj();
        }
      }
    }

    private void Kraj() {
      timer.Enabled = false;
      remainingTimeProgressBar.Value = 0;
      if (IsWordPossible(rjesenjeTextBox.Text)) {
        MessageBox.Show("Vaše rješenje: " + rjesenjeTextBox.Text + "\n" + "Najbolje rješenje: " + "placeholder");
      }
      if (!IsWordPossible(rjesenjeTextBox.Text)) {
        MessageBox.Show("Vaša riječ je neispravna budući da ste koristili nedopuštena slova.\n" + "Najbolje rješenje: " + "placeholder");
      }
      this.Close();
    }

    private void stopButton_Click(object sender, EventArgs e) {
      ++trenutnoSlovo;
      if (trenutnoSlovo - 1 < brojSlova) {
        AddSlovo(slova[trenutnoSlovo - 1].Text);
      }
    }

    private void gotovButton_Click(object sender, EventArgs e) {
      Kraj();
    }

    private void AddSlovo(String slovo) {
      for (int i = 0; i < 30; i++) {
        if (slovo == mogucaSlova[i]) {
          brojPojavljivanjaZadanihSlova[i] += 1;
        }
      }
    }

    private Boolean IsWordPossible(String s) {
      int[] brojPojavljivanjaSlovaRijeci = new int[30];
      for (int i = 0; i < s.Length - 1; i++) {
        if (s[i] == 'd' && s[i + 1] == 'ž') {
          brojPojavljivanjaSlovaRijeci[SlovoGetIndex("dž")] += 1;
        }
        else if (s[i] == 'l' && s[i + 1] == 'j') {
          brojPojavljivanjaSlovaRijeci[SlovoGetIndex("lj")] += 1;
        }
        else if (s[i] == 'n' && s[i + 1] == 'j') {
          brojPojavljivanjaSlovaRijeci[SlovoGetIndex("nj")] += 1;
        }
      }
      for (int i = 0; i < s.Length; i++) {
        brojPojavljivanjaSlovaRijeci[SlovoGetIndex(s[i].ToString())] += 1;
      }
      brojPojavljivanjaSlovaRijeci[SlovoGetIndex("d")] -= brojPojavljivanjaSlovaRijeci[SlovoGetIndex("dž")];
      brojPojavljivanjaSlovaRijeci[SlovoGetIndex("ž")] -= brojPojavljivanjaSlovaRijeci[SlovoGetIndex("dž")];
      brojPojavljivanjaSlovaRijeci[SlovoGetIndex("l")] -= brojPojavljivanjaSlovaRijeci[SlovoGetIndex("lj")];
      brojPojavljivanjaSlovaRijeci[SlovoGetIndex("j")] -= brojPojavljivanjaSlovaRijeci[SlovoGetIndex("lj")];
      brojPojavljivanjaSlovaRijeci[SlovoGetIndex("n")] -= brojPojavljivanjaSlovaRijeci[SlovoGetIndex("nj")];
      brojPojavljivanjaSlovaRijeci[SlovoGetIndex("j")] -= brojPojavljivanjaSlovaRijeci[SlovoGetIndex("nj")];

      for (int i = 0; i < 30; i++) {
        if (brojPojavljivanjaSlovaRijeci[i] > brojPojavljivanjaZadanihSlova[i]) {
          return false;
        }
      }
      return true;
    }

    private int SlovoGetIndex(string s) {
      for (int i = 0; i < 30; i++) {
        if (s == mogucaSlova[i]) {
          return i;
        }
      }
      return -1;
    }
  }
}
