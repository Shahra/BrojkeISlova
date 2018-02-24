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
  public partial class BrojkeView : Form {
    int brojBrojki;
    String dopusteneOperacije;
    Random random = new Random();
    TextBox[] brojke = new TextBox[15];
    String[] moguceBrojke = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "25", "35", "50", "75" };
    int trenutnaBrojka = -1;
    int offset = 2;
    //int[] brojPojavljivanjaZadanihSlova = new int[30];

    public BrojkeView(int brojBrojki = 10, string dopusteneOperacije = "+-*/^") {
      InitializeComponent();
      this.brojBrojki = brojBrojki;
      this.dopusteneOperacije = dopusteneOperacije;
      CenterToScreen();
    }

    private void BrojkeView_Load(object sender, EventArgs e) {
      for (int i = 0; i < brojBrojki; i++) {
        brojke[i] = new TextBox();
        brojke[i].TextAlign = HorizontalAlignment.Center;
        Controls.Add(brojke[i]);
      }
      ResizeBrojki();
      ResizeRjesenje();
      ResizeRemainingTime();
      ResizeGotovButton();
      ResizeStopButton();
      ResizeTrazeniBrojButton();
    }

    private void ResizeBrojki() {
      int top = (int)(0.47 * ClientSize.Height);
      int width = (int)(ClientSize.Width - 11 * offset) / 10;
      int height = (int)(0.15 * ClientSize.Height);
      int left = (int)(ClientSize.Width - (brojBrojki * width + (brojBrojki - 1) * offset)) / 2;
      for (int i = 0; i < brojBrojki; i++) {
        left += offset;
        UtilityFunctions.PositionTextBox(brojke[i], left, top, width, height);
        left += width;
      }
    }

    private void BrojkeView_Resize(object sender, EventArgs e) {
      ResizeBrojki();
      ResizeRjesenje();
      ResizeRemainingTime();
      ResizeGotovButton();
      ResizeStopButton();
      ResizeTrazeniBrojButton();
    }

    private void ResizeRjesenje() {
      int left = 10;
      int top = (int)(0.78 * ClientSize.Height);
      int width = (int)(0.7 * ClientSize.Width) - 2 * 10;
      int height = (int)(0.1 * ClientSize.Height);
      UtilityFunctions.PositionTextBox(rjesenjeTextBox, left, top, width, height);
    }

    private void ResizeGotovButton() {
      UtilityFunctions.PositionButton(gotovButton, 0.71, 0.78, 0.28, 0.1, ClientSize);
    }

    private void ResizeStopButton() {
      UtilityFunctions.PositionButton(stopButton, 0, 0.9, 1, 0.1, ClientSize);
    }

    private void ResizeRemainingTime() {
      UtilityFunctions.PositionProgressBar(remainingTimeProgressBar, 0.2, 0.71, 0.6, 0.05, ClientSize);
    }

    private void ResizeTrazeniBrojButton() {
      int top = (int)(0.19 * ClientSize.Height);
      int width = (int)(0.3 * ClientSize.Width);
      int height = (int)(0.15 * ClientSize.Height);
      int left = (ClientSize.Width - width) / 2;
      UtilityFunctions.PositionTextBox(trazeniBrojTextBox, left, top, width, height);
    }

    private void timer_Tick(object sender, EventArgs e) {
      if (trenutnaBrojka == -1) {
        stopButton.Focus();
        trazeniBrojTextBox.Text = random.Next(1, 1001).ToString();
      }
      else if (trenutnaBrojka < brojBrojki) {
        stopButton.Focus();
        brojke[trenutnaBrojka].Text = moguceBrojke[random.Next(0, 24)];
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

    private void stopButton_Click(object sender, EventArgs e) {
      ++trenutnaBrojka;
    }

    private void Kraj() {
      timer.Enabled = false;
      remainingTimeProgressBar.Value = 0;
      if (true) {
        MessageBox.Show("Vaše rješenje: " + rjesenjeTextBox.Text + "\n" + "Najbolje rješenje: " + "placeholder");
      }
      else {
        MessageBox.Show("Neispravan unos.\n" + "Najbolje rješenje: " + "placeholder");
      }
      this.Close();
    }

    private void gotovButton_Click(object sender, EventArgs e) {
      Kraj();
    }
  }
}
