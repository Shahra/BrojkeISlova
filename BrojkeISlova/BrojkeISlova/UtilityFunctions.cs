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

    public static void PositionProgressBar(ProgressBar pb, double left, double top, double width, double height, Size size) {
      pb.Left = (int)(size.Width * left);
      pb.Top = (int)(size.Height * top);
      pb.Width = (int)(size.Width * width);
      pb.Height = (int)(size.Height * height);
    }

    public static void TextBoxSetCursorPositionEnd(TextBox t) {
      int endPosition = t.Text.Length;
      if (endPosition >= 0) {
        t.SelectionStart = t.Text.Length;
      }
    }
    public class Calculator {
      public static string RemoveWhitespace(string input) {
        return new string(input.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
      }
      public static bool IsNumber(char c) {
        if (c >= '0' && c <= '9') {
          return true;
        }
        return false;
      }
      public static String InfixToPostfix(String infixExpression) {
        Stack<char> s = new Stack<char>();
        infixExpression = RemoveWhitespace(infixExpression);

        StringBuilder postfixExpression = new StringBuilder();
        for (int i = 0; i < infixExpression.Length; i++) {
          if (IsNumber(infixExpression[i])) {
            postfixExpression.Append(infixExpression[i]);
          }
          else {
            postfixExpression.Append(' ');
            if (s.Count == 0) {
              s.Push(infixExpression[i]);
            }
            else if (infixExpression[i] == '(') {
              s.Push('(');
            }
            else if (infixExpression[i] == ')') {
              char g = s.Pop();
              while (g != '(') {
                postfixExpression.Append(g);
                g = s.Pop();
              }
            }
            else if (infixExpression[i] == '^') {
              s.Push('^');
            }
            else if (infixExpression[i] == '*' || infixExpression[i] == '/') {
              while (s.Count != 0 && s.Peek() == '^') {
                postfixExpression.Append(s.Pop());
              }
              s.Push(infixExpression[i]);
            }
            else if (infixExpression[i] == '+' || infixExpression[i] == '-') {
              while (s.Count != 0 && (s.Peek() == '^' || s.Peek() == '*' || s.Peek() == '/')) {
                postfixExpression.Append(s.Pop());
              }
              s.Push(infixExpression[i]);
            }
          }
        }
        while (s.Count != 0) {
          postfixExpression.Append(s.Pop());
        }

        return postfixExpression.ToString();
      }
      static string CalculatePostfixExpression(String postfixExpression) {
        /*
        1) Create a stack to store operands(or values).
        2) Scan the given expression and do following for every scanned element.
        …..a) If the element is a number, push it into the stack
          …..b) If the element is a operator, pop operands for the operator from stack.Evaluate the operator and push the result back to the stack
              3) When the expression is ended, the number in the stack is the final answer*/
        Stack<double> s = new Stack<double>();
        StringBuilder currNumber = new StringBuilder();
        double a, b;

        for (int i = 0; i < postfixExpression.Length; i++) {
          if (IsNumber(postfixExpression[i])) {
            while (IsNumber(postfixExpression[i])) {
              currNumber.Append(postfixExpression[i]);
              ++i;
              if(i >= postfixExpression.Length) {
                break;
              }
            }
            s.Push(Convert.ToDouble(currNumber.ToString()));
            currNumber.Clear();
            --i;
          }
          else {
            if (postfixExpression[i] == '^') {
              if (s.Count() == 0)
                return "greska";
              a = s.Pop();
              if (s.Count() == 0)
                return "greska";
              b = s.Pop();
              s.Push(Math.Pow(b, a));
            }
            else if (postfixExpression[i] == '*') {
              if (s.Count() == 0)
                return "greska";
              a = s.Pop();
              if (s.Count() == 0)
                return "greska";
              b = s.Pop();
              s.Push(a * b);
            }
            else if (postfixExpression[i] == '/') {
              if (s.Count() == 0)
                return "greska";
              a = s.Pop();
              if (s.Count() == 0)
                return "greska";
              b = s.Pop();
              s.Push(b / a);
            }
            else if (postfixExpression[i] == '+') {
              if (s.Count() == 0)
                return "greska";
              a = s.Pop();
              if (s.Count() == 0)
                return "greska";
              b = s.Pop();
              s.Push(a + b);
            }
            else if (postfixExpression[i] == '-') {
              if (s.Count() == 0)
                return "greska";
              a = s.Pop();
              if (s.Count() == 0)
                return "greska";
              b = s.Pop();
              s.Push(b - a);
            }
          }
        }

        return s.Pop().ToString();
      }
      public static string CalculateInfixExpression(String infixExpression) {
        String postfixExpression = InfixToPostfix(infixExpression);
        return CalculatePostfixExpression(postfixExpression);
      }
    }
  }
}
