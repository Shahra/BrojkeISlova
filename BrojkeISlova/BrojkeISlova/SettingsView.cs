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
  public partial class SettingsView : Form {
    String dozvoljeneOperacije;
    int brojBrojki;
    int brojSlova;
    int brojIgara;
    String nizIgara;

    Panel[] igraPanel = new Panel[10];
    RadioButton[] brojkaRadioButton = new RadioButton[10];
    RadioButton[] slovoRadioButton = new RadioButton[10];

    public SettingsView(String dozvoljeneOperacije = "+-*/^", int brojBrojki = 4, int brojSlova = 5, int brojIgara = 1, String nizIgara = "B") {
      InitializeComponent();
      CenterToScreen();
      this.dozvoljeneOperacije = dozvoljeneOperacije;
      this.brojBrojki = brojBrojki;
      this.brojSlova = brojSlova;
      this.brojIgara = brojIgara;
      this.nizIgara = nizIgara;
    }

    private void SettingsView_Load(object sender, EventArgs e) {
      brojBrojkiNumUpDown.Value = brojBrojki;
      brojSlovaNumUpDown.Value = brojSlova;
      brojIgaraNumUpDown.Value = brojIgara;
      if (dozvoljeneOperacije.Contains("+")) {
        plusCheckBox.Checked = true;
      }
      if (dozvoljeneOperacije.Contains("-")) {
        minusCheckBox.Checked = true;
      }
      if (dozvoljeneOperacije.Contains("*")) {
        multiplyCheckBox.Checked = true;
      }
      if (dozvoljeneOperacije.Contains("/")) {
        divideCheckBox.Checked = true;
      }
      if (dozvoljeneOperacije.Contains("^")) {
        powerCheckBox.Checked = true;
      }
      InitializeRadioGroup(0);
      ResizeOdustaniButton();
      ResizeSpremiButton();
    }

    private void SettingsView_Resize(object sender, EventArgs e) {
      ResizeOdustaniButton();
      ResizeSpremiButton();
    }


    private void InitializeRadioGroup(int i) {
      brojkaRadioButton[i] = new RadioButton();
      brojkaRadioButton[i].Text = "B";
      brojkaRadioButton[i].Location = new Point(3, 3);
      brojkaRadioButton[i].Size = new Size(85, 17);
      brojkaRadioButton[i].Checked = true;

      slovoRadioButton[i] = new RadioButton();
      slovoRadioButton[i].Text = "S";
      slovoRadioButton[i].Location = new Point(3, 26);
      slovoRadioButton[i].Size = new Size(85, 17);

      igraPanel[i] = new Panel();
      igraPanel[i].Controls.Add(brojkaRadioButton[i]);
      igraPanel[i].Controls.Add(slovoRadioButton[i]);
      igraPanel[i].Location = new Point(19 + i * 43, 300);
      igraPanel[i].Size = new Size(37, 49);

      if (i < nizIgara.Length) {
        if (nizIgara[i] == 'S') {
          slovoRadioButton[i].Checked = true;
        }
      }

      Controls.Add(igraPanel[i]);
    }

    private void brojIgaraNumUpDown_ValueChanged(object sender, EventArgs e) {
      for (int i = 0; i < brojIgaraNumUpDown.Value; i++) {
        if (igraPanel[i] == null) { 
          InitializeRadioGroup(i);
        }
        else {
          igraPanel[i].Show();
        }
      }
      for(int i = (int) brojIgaraNumUpDown.Value; i < 10; i++) {
        if (igraPanel[i] != null) {
          igraPanel[i].Hide();
        }
      }
    }

    private void ResizeOdustaniButton() {
      UtilityFunctions.PositionButton(odustaniButton, 0.55, 0.85, 0.2, 0.1, ClientSize);
    }

    private void ResizeSpremiButton() {
      UtilityFunctions.PositionButton(SpremiButton, 0.75, 0.85, 0.2, 0.1, ClientSize);
    }

    private void odustaniButton_Click(object sender, EventArgs e) {
      Close();
    }

    private void SpremiButton_Click(object sender, EventArgs e) {
      MainMenuView mmv = (MainMenuView)Owner;
      mmv.dozvoljeneOperacije = GetDozvoljeneOperacije();
      mmv.brojBrojki = (int)brojBrojkiNumUpDown.Value;
      mmv.brojSlova = (int)brojSlovaNumUpDown.Value;
      mmv.brojIgara = (int)brojIgaraNumUpDown.Value;
      mmv.nizIgara = GetNizIgara();
      Close();
    }

    private string GetDozvoljeneOperacije() {
      StringBuilder dozvoljeneOperacije = new StringBuilder("");
      if (plusCheckBox.Checked) {
        dozvoljeneOperacije.Append("+");
      }
      if (minusCheckBox.Checked) {
        dozvoljeneOperacije.Append("-");
      }
      if (multiplyCheckBox.Checked) {
        dozvoljeneOperacije.Append("*");
      }
      if (divideCheckBox.Checked) {
        dozvoljeneOperacije.Append("/");
      }
      if (powerCheckBox.Checked) {
        dozvoljeneOperacije.Append("^");
      }
      return dozvoljeneOperacije.ToString();
    }

    private string GetNizIgara() {
      StringBuilder dozvoljeneOperacije = new StringBuilder("");
      for(int i = 0; i < brojIgaraNumUpDown.Value; i++) {
        if (brojkaRadioButton[i].Checked) {
          dozvoljeneOperacije.Append("B");
        }
        else {
          dozvoljeneOperacije.Append("S");
        }
      }
      return dozvoljeneOperacije.ToString();
    }
  }
}
