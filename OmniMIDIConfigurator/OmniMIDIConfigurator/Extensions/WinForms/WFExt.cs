﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OmniMIDIConfigurator
{
    public partial class ListViewEx : ListView
    {
        private const int WM_PAINT = 0x000F;

        public ListViewEx()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private int _LineBefore = -1;
        public int LineBefore
        {
            get { return _LineBefore; }
            set { _LineBefore = value; }
        }

        private int _LineAfter = -1;
        public int LineAfter
        {
            get { return _LineAfter; }
            set { _LineAfter = value; }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                if (LineBefore >= 0 && LineBefore < Items.Count)
                {
                    Rectangle rc = Items[LineBefore].GetBounds(ItemBoundsPortion.Entire);
                    DrawInsertionLine(rc.Left, rc.Right, rc.Top);
                }
                if (LineAfter >= 0 && LineBefore < Items.Count)
                {
                    Rectangle rc = Items[LineAfter].GetBounds(ItemBoundsPortion.Entire);
                    DrawInsertionLine(rc.Left, rc.Right, rc.Bottom);
                }
            }
        }

        private void DrawInsertionLine(int X1, int X2, int Y)
        {
            using (Graphics g = this.CreateGraphics())
            {
                Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 2);
                blackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                g.DrawLine(blackPen, X1, Y, X2, Y);

            }
        }
    }

    public class LinkLabelEx : LinkLabel
    {
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // If the base class decided to show the ugly hand cursor
            if (OverrideCursor == Cursors.Hand)
            {
                // Show the system hand cursor instead
                OverrideCursor = Program.SystemHandCursor;
            }
        }
    }

    public class BufferedPanel : Panel
    {
        public BufferedPanel()
        {
            DoubleBuffered = true;
        }
    }

    public partial class HexNumericUpDown : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            base.Text = string.Format(@"0x{0:X4}", (Int32)base.Value);
        }
    }
}
