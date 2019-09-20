using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TableLib.Controls
{
    public delegate void TimeLineSelectedChangedDelegate(object sender, TimeLineSelectedChangedEventArgs args);

    public class TimeLineSelectedChangedEventArgs : EventArgs
    {
        public TimeLineItemUI Selected { get; set; }
    }

    public partial class TimeLineControl : UserControl
    {
        internal TimeLineUI UIControl { get { return tlContent; } }

        /// <summary>
        /// 集合
        /// </summary>
        public TimeLineItemUICollection Items { get; private set; }

        /// <summary>
        /// 选择项改变事件
        /// </summary>
        public event TimeLineSelectedChangedDelegate SelectedChanged;

        public TimeLineControl()
        {
            InitializeComponent();

            Items = new TimeLineItemUICollection(this);
        }

        internal void item_Click(object sender, EventArgs e)
        {
            TimeLineItemUI current = ((TimeLineItemUI)sender);
            foreach (TimeLineItemUI tli in Items)
            {
                tli.Selected = false;
            }
            //设置当前项的选择项
            current.Selected = !current.Selected;

            if (SelectedChanged != null)
            {
                TimeLineSelectedChangedEventArgs args = new TimeLineSelectedChangedEventArgs();
                args.Selected = current;

                SelectedChanged(this, args);
            }
        }
    }

    /// <summary>
    /// TimeLineItem集合类
    /// </summary>
    public class TimeLineItemUICollection : IList<TimeLineItemUI>
    {
        private TimeLineControl parent;
        public TimeLineItemUICollection(TimeLineControl parent)
        {
            this.parent = parent;
        }

        public int IndexOf(TimeLineItemUI item)
        {
            return parent.UIControl.Items.IndexOf(item);
        }

        public void Insert(int index, TimeLineItemUI item)
        {
            //绑定事件
            item.Click += parent.item_Click;
            //设置位置
            item.Dock = DockStyle.Top;

            //判断是否可以运行
            if (parent.UIControl.Items.Count > index)
            {
                //将所有控件复制出来
                TimeLineItemUI[] tempArray = new TimeLineItemUI[parent.UIControl.Items.Count];                
                parent.UIControl.Items.CopyTo(tempArray, 0);

                //执行插入操作
                List<TimeLineItemUI> tempList = new List<TimeLineItemUI>(tempArray);
                tempList.Insert(index, item);

                //清空控件列表
                parent.UIControl.Items.Clear();

                //还原列表
                foreach (TimeLineItemUI tli in tempList)
                {
                    parent.UIControl.Items.Add(tli);
                }
            }
        }

        public void RemoveAt(int index)
        {
            parent.UIControl.Items.RemoveAt(index);
        }

        public TimeLineItemUI this[int index]
        {
            get
            {
                return (TimeLineItemUI)parent.UIControl.Items[index];
            }
            set
            {
                //parent.UIControl.Items[index] = value;
            }
        }

        public void Add(TimeLineItemUI item)
        {
            item.Click += parent.item_Click;
            item.Dock = DockStyle.Top;
            parent.UIControl.Items.Add(item);
        }

        public void Clear()
        {
            parent.UIControl.Items.Clear();
        }

        public bool Contains(TimeLineItemUI item)
        {
            return parent.UIControl.Items.Contains(item);
        }

        public void CopyTo(TimeLineItemUI[] array, int arrayIndex)
        {
            parent.UIControl.Items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return parent.UIControl.Items.Count; }
        }

        public bool IsReadOnly
        {
            get { return parent.UIControl.Items.IsReadOnly; }
        }

        public bool Remove(TimeLineItemUI item)
        {
            parent.UIControl.Items.Remove(item);
            return true;
        }

        public IEnumerator<TimeLineItemUI> GetEnumerator()
        {
            List<TimeLineItemUI> list = new List<TimeLineItemUI>();
            foreach (Control c in parent.UIControl.Items)
            {
                if (c is TimeLineItemUI)
                {
                    list.Add((TimeLineItemUI)c);
                }
            }
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return parent.UIControl.Items.GetEnumerator();
        }
    }
}