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
    int offset = 2;
    TextBox[] slova = new TextBox[15];

    public SlovaView(int brojSlova = 15) {
      InitializeComponent();
      this.brojSlova = brojSlova;
    }

    private void SlovaView_Load(object sender, EventArgs e) {
      for (int i = 0; i < brojSlova; i++) {
        slova[i] = new TextBox();
        slova[i].TextAlign = HorizontalAlignment.Center;
        Controls.Add(slova[i]);
      }
      ResizeSlova();
      ResizeRjesenje();

    }

    private void SlovaView_Resize(object sender, EventArgs e) {
      ResizeSlova();
      ResizeRjesenje();
    }

    private void ResizeSlova() {
      int top = (int)(0.2 * ClientSize.Height);
      int width = (int)(0.8 * ClientSize.Width - 16 * offset) / 15;
      int height = (int)(0.15 * ClientSize.Height);
      int left = (int)(0.8 * ClientSize.Width - (brojSlova * width + (brojSlova - 1) * offset)) / 2;

      for (int i = 0; i < brojSlova; i++) {
        left += offset;
        UtilityFunctions.PositionTextBox(slova[i], left, top, width, height);
        left += width;
      }
    }

    private void ResizeRjesenje() {
      int top = (int)(0.6 * ClientSize.Height);
      int width = (int)(0.8 * ClientSize.Width) - 2 * 10;
      int height = (int)(0.15 * ClientSize.Height);
      int left = 10;
      UtilityFunctions.PositionTextBox(rjesenjeTextBox, left, top, width, height);
    }
  }
}
