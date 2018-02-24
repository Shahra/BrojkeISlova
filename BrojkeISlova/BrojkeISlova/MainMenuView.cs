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
  public partial class MainMenuView : Form {
    public string dozvoljeneOperacije;
    public int brojBrojki;
    public int brojSlova;
    public int brojIgara;
    public string nizIgara;

    public MainMenuView(string dozvoljeneOperacije = "+-*/^", int brojBrojki = 10, int brojSlova = 15, int brojIgara = 1, string nizIgara = "B") {
      InitializeComponent();
      this.dozvoljeneOperacije = dozvoljeneOperacije;
      this.brojBrojki = brojBrojki;
      this.brojSlova = brojSlova;
      this.brojIgara = brojIgara;
      this.nizIgara = nizIgara;
      CenterToScreen();
    }

    private void MainMenuView_Load(object sender, EventArgs e) {
      UtilityFunctions.PositionButton(igrajButton, 0.2, 0.2, 0.6, 0.2, ClientSize);
      UtilityFunctions.PositionButton(postavkeButton, 0.2, 0.6, 0.6, 0.2, ClientSize);
    }

    private void MainMenuView_Resize(object sender, EventArgs e) {
      UtilityFunctions.PositionButton(igrajButton, 0.2, 0.2, 0.6, 0.2, ClientSize);
      UtilityFunctions.PositionButton(postavkeButton, 0.2, 0.6, 0.6, 0.2, ClientSize);
    }

    private void igrajButton_Click(object sender, EventArgs e) {
      Hide();
      BrojkeView brojkeView;
      SlovaView slovaView;
      for (int i = 0; i < nizIgara.Length; i++) {
        if(nizIgara[i] == 'B') {
          brojkeView = new BrojkeView(brojBrojki, dozvoljeneOperacije);
          brojkeView.ShowDialog();
        }
        else {
          slovaView = new SlovaView(brojSlova);
          slovaView.ShowDialog();
        }
      }
      Show();
    }

    private void postavkeButton_Click(object sender, EventArgs e) {
      Hide();
      SettingsView settingsView = new SettingsView(dozvoljeneOperacije, brojBrojki, brojSlova, brojIgara, nizIgara);
      settingsView.Owner = this;
      settingsView.ShowDialog();
      Show();
    }
  }
}
