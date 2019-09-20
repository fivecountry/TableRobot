using CSScriptLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TableLib.Controls;

namespace TableRobot
{
    /// <summary>
    /// 回调函数代理
    /// </summary>
    public delegate bool CallBack(int hwnd, int lParam);

    public partial class MainForm : Form
    {
        public static string Time = DateTime.Now.ToString();

        public MainForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Win32.POINT point;
            Win32.User.GetCursorPos(out point);

            IntPtr activeWindowHwnd = new IntPtr(Win32.User.GetActiveWindow());
            Win32.RECT rects = new Win32.RECT();
            Win32.User.GetWindowRect(activeWindowHwnd, ref rects);

            int hwnd = Win32.User.ChildWindowFromPointEx(activeWindowHwnd, point.x - rects.Left, point.y - rects.Top, 0x0000);

            KeyValuePair<string, string> ctrlClassAndTextObj = GetClassAndText(new IntPtr(hwnd));

            if (richTextBox1.Lines != null && richTextBox1.Lines.Length >= 16)
            {
                richTextBox1.Clear();
            }

            int window = Win32.User.GetParent(new IntPtr(hwnd));

            int newHwnd = Win32.User.FindWindow(new StringBuilder(ctrlClassAndTextObj.Key), new StringBuilder(ctrlClassAndTextObj.Value));

            KeyValuePair<string, string> windowClassAndTextObj = GetClassAndText(new IntPtr(window));

            richTextBox1.AppendText("-----------------------------\n");
            richTextBox1.AppendText("ControlHandle:" + hwnd + "\n");
            richTextBox1.AppendText("ControlClass:" + ctrlClassAndTextObj.Key + "\n");
            richTextBox1.AppendText("ControlText:" + ctrlClassAndTextObj.Value + "\n");

            richTextBox1.AppendText("WindowClass:" + windowClassAndTextObj.Key + "\n");
            richTextBox1.AppendText("WindowText:" + windowClassAndTextObj.Value + "\n");

            richTextBox1.AppendText("-----------------------------\n");
        }

        public KeyValuePair<string, string> GetClassAndText(IntPtr hwnd)
        {
            KeyValuePair<string, string> result;
            StringBuilder ctrlClassStr = new StringBuilder(2000);
            StringBuilder ctrlNameStr = new StringBuilder(2000);
            Win32.User.GetClassName(hwnd, ctrlClassStr, 2000);
            Win32.User.GetWindowText(hwnd, ctrlNameStr, 2000);

            result = new KeyValuePair<string, string>(ctrlClassStr.ToString().Trim(), ctrlNameStr.ToString().Trim());
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 返回写字板主窗口句柄
            IntPtr hWnd = new IntPtr(Win32.User.FindWindow(new StringBuilder("CalcFrame"), new StringBuilder("计算器")));
            if (!hWnd.Equals(IntPtr.Zero))
            {
                //返回写字板编辑窗口句柄
                IntPtr edithWnd = new IntPtr(Win32.User.FindWindowEx(hWnd, IntPtr.Zero, new StringBuilder("Button"), new StringBuilder("9")));
                if (!edithWnd.Equals(IntPtr.Zero))
                {
                    // 发送WM_SETTEXT 消息： "Hello World!"
                    //SendMessage(edithWnd, WM_SETTEXT, IntPtr.Zero, new StringBuilder("Hello World!"));
                    Text = "1111111111";
                }
            }
            
            int hwnd = Win32.User.FindWindow(new StringBuilder(""), new StringBuilder());
            Message msg = Message.Create(new IntPtr(hwnd), 0x00F5, new IntPtr(0), new IntPtr(0));
            //点击hwnd_button句柄对应的按钮
            Win32.User.PostMessage(msg.HWnd, msg.Msg, msg.WParam.ToInt32(), msg.LParam.ToInt32());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = new IntPtr(Win32.User.FindWindow(new StringBuilder("CalcFrame"), new StringBuilder("计算器")));
            if (!hWnd.Equals(IntPtr.Zero))
            {
                CallBack cbb = new CallBack(enumChildWindowsCallBack);
                IntPtr methodHandle = Marshal.GetFunctionPointerForDelegate(cbb);
                Win32.User.EnumChildWindows(hWnd, methodHandle, 0);
                System.Console.WriteLine("VVVVVVVVVVVVVV");
            }
        }

        private bool enumChildWindowsCallBack(int hwnd, int lParam)
        {
            KeyValuePair<string, string> kvp = GetClassAndText(new IntPtr(hwnd));
            System.Console.WriteLine(kvp.Key + "," + kvp.Value);
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder dynamicString = new StringBuilder();
            dynamicString.AppendLine("using TableLib;");
            dynamicString.AppendLine("object shell(){");
            dynamicString.AppendLine("");
            dynamicString.AppendLine("");
            dynamicString.AppendLine("");
            dynamicString.AppendLine("");
            dynamicString.AppendLine("");
            dynamicString.AppendLine("");
            dynamicString.AppendLine("");
            dynamicString.AppendLine("");
            dynamicString.AppendLine(" return \"OK!!!!!!!!!!!!!!+\" + InputAPI.Time;");
            dynamicString.AppendLine("}");
            var shell = CSScript.CreateFunc<object>(dynamicString.ToString());
            object obj = shell();
            System.Console.WriteLine(obj.ToString());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int kk = 0; kk < 30; kk++)
            {
                TimeLineItemUI item1 = new TimeLineItemUI();
                item1.Dock = DockStyle.Top;
                item1.DisplayText = "AAAAA" + kk;
                item1.Height = 50;
                item1.Click += item1_Click;
                timeLineUI1.Items.Add(item1);
            }
        }

        void item1_Click(object sender, EventArgs e)
        {
            TimeLineItemUI item = ((TimeLineItemUI)sender);
            foreach (Control c in timeLineUI1.Items)
            {
                if (c is TimeLineItemUI)
                {
                    ((TimeLineItemUI)c).Selected = false;
                }
            }
            item.Selected = true;
        }
    }
}