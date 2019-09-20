using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TableLib.Controls
{
    public partial class TimeLineItemUI : UserControl
    {
        private string displayText = "空";
        public string DisplayText
        {
            get { return displayText; }
            set
            { 
                displayText = value;
                Invalidate();
            }
        }

        private bool selected = false;
        public bool Selected
        {
            get { return selected; }
            set
            {
                 selected = value;
                 Invalidate();
            }
        }

        public object Data { get; set; }

        public TimeLineItemUI()
        {
            InitializeComponent();
        }

        private void TimeLineItemUI_Paint(object sender, PaintEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
            e.Graphics.DrawString(DisplayText, Font, new SolidBrush(ForeColor), new Rectangle(5, 5, Width - 10, Height - 10), sf);
            e.Graphics.DrawRectangle(new Pen(Selected ? Color.Red : Color.SteelBlue, 3), new Rectangle(5, 5, Width - 10, Height - 10));
            e.Graphics.DrawLine(new Pen(Selected ? Color.Red : Color.SteelBlue, 3), new Point(0, Height / 2), new Point(10, Height / 2));
        }
    }
}