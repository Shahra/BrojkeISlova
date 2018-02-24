using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrojkeISlova {
  static class UtilityFunctions {
    public static Font GetFontForTextBoxHeight(int TextBoxHeight, Font OriginalFont) {
      // What is the target size of the textbox?
      float desiredheight = (float)TextBoxHeight;

      // Set the font from the existing TextBox font.
      // We use the fnt = new Font(...) method so we can ensure that
      //  we're setting the GraphicsUnit to Pixels.  This avoids all
      //  the DPI conversions between point & pixel.
      Font fnt = new Font(OriginalFont.FontFamily,
                          OriginalFont.Size,
                          OriginalFont.Style,
                          GraphicsUnit.Pixel);

      // TextBoxes never size below 8 pixels. This consists of the
      // 4 pixels above & 3 below of whitespace, and 1 pixel line of
      // greeked text.
      if (desiredheight < 8)
        desiredheight = 8;

      // Determine the Em sizes of the font and font line spacing
      // These values are constant for each font at the given font style.
      // and screen DPI.
      float FontEmSize = fnt.FontFamily.GetEmHeight(fnt.Style);
      float FontLineSpacing = fnt.FontFamily.GetLineSpacing(fnt.Style);

      // emSize is the target font size.  TextBoxes have a total of
      // 7 pixels above and below the FontHeight of the font.
      float emSize = (desiredheight - 7) * FontEmSize / FontLineSpacing;

      // Create the font, with the proper size.
      fnt = new Font(fnt.FontFamily, emSize, fnt.Style, GraphicsUnit.Pixel);

      return fnt;
    }
    public static void PositionButton(Button b, double left, double top, double width, double height, Size size) {
      b.Left = (int)(size.Width * left);
      b.Top = (int)(size.Height * top);
      b.Width = (int)(size.Width * width);
      b.Height = (int)(size.Height * height);
    }

    public static void PositionTextBox(TextBox t, int left, int top, int width, int height) {
      t.Left = left;
      t.Top = top;
      t.Width = width;
      t.Font = UtilityFunctions.GetFontForTextBoxHeight(height, t.Font);
    }
  }
}
