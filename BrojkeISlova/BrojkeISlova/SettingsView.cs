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
      igraPanel[i].Location = new Point(19 + i * 43, 335);
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
  }
}
