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
    public MainMenuView() {
      InitializeComponent();
      //FormBorderStyle = FormBorderStyle.None;
      //WindowState = FormWindowState.Maximized;
    }

    private void MainMenuView_Load(object sender, EventArgs e) {
      UtilityFunctions.PositionButton(igrajButton, 0.2, 0.2, 0.6, 0.2, ClientSize);
      UtilityFunctions.PositionButton(postavkeButton, 0.2, 0.6, 0.6, 0.2, ClientSize);
    }

    private void MainMenuView_Resize(object sender, EventArgs e) {
      UtilityFunctions.PositionButton(igrajButton, 0.2, 0.2, 0.6, 0.2, ClientSize);
      UtilityFunctions.PositionButton(postavkeButton, 0.2, 0.6, 0.6, 0.2, ClientSize);
    }
  }
}
