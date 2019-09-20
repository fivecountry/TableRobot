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
    internal partial class TimeLineUI : UserControl
    {
        public TimeLineUI()
        {
            InitializeComponent();
        }

        public Control.ControlCollection Items
        {
            get { return plItemList.Controls; }
        }
    }
}
