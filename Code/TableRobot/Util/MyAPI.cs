using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Automation;
using System.Windows.Forms;

namespace TableRobot.Util
{
    public class MyAPI
    {
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point Point);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileSectionNames(byte[] buffer, int iLen, string lpFileName);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileSection(string lpAppName, byte[] lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern void mouse_event(int mouseEventFlag, int incrementX, int incrementY, uint data, int extraInfo);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lparam);
        [DllImport("User32.dll")]
        private static extern Int32 SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, StringBuilder lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, int wParam, int lparam);
        [DllImport("user32.dll ", CharSet = CharSet.Unicode)]
        public static extern IntPtr PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);
        [DllImport("user32.dll")]
        public static extern void BlockInput(bool Block);

        public const int MOUSEEVENTF_MOVE = 0x0001;
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int WM_CLOSE = 0x0010;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MAXIMIZE = 0xF030;     //最大化窗口

        /// <summary>
        /// 设置文本内容的消息
        /// </summary>
        public const int WM_SETTEXT = 0x000C;

        /// <summary>
        /// 鼠标点击消息
        /// </summary>
        public const int BM_CLICK = 0x00F5;

        public enum DMDO
        {
            DEFAULT = 0,
            D90 = 1,
            D180 = 2,
            D270 = 3
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct DEVMODE
        {
            public const int DM_DISPLAYFREQUENCY = 0x400000;
            public const int DM_PELSWIDTH = 0x80000;
            public const int DM_PELSHEIGHT = 0x100000;
            private const int CCHDEVICENAME = 32;
            private const int CCHFORMNAME = 32;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public DMDO dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        public static string config = Environment.CurrentDirectory + @"\config.ini";

        private static string LOG = "C:\\ABCDTEST";
        private static string AFILE = "C:\\ABCDTEST\\AFILE";
        private static string BFILE = "C:\\ABCDTEST\\BFILE";
        private static string CFILE = "C:\\ABCDTEST\\CFILE";
        private static string DFILE = "C:\\ABCDTEST\\DFILE";

        public static string sconfig()
        {
            return config;
        }

        public static void CreateDir()
        {
            if (!Directory.Exists(LOG))
            {
                Directory.CreateDirectory(LOG);
            }
            if (!Directory.Exists(AFILE))
            {
                Directory.CreateDirectory(AFILE);
            }
            if (!Directory.Exists(BFILE))
            {
                Directory.CreateDirectory(BFILE);
            }
            if (!Directory.Exists(CFILE))
            {
                Directory.CreateDirectory(CFILE);
            }
            if (!Directory.Exists(DFILE))
            {
                Directory.CreateDirectory(DFILE);
            }
        }

        public static void clear()
        {
            CreateDir();
            Thread.Sleep(100);

            if (Directory.Exists(AFILE))
            {
                String[] strAFILE = Directory.GetFiles(AFILE);
                if (strAFILE.GetLength(0) != 0)
                {
                    for (int i = 0; i < strAFILE.GetLength(0); i++)
                        File.Delete(strAFILE[i]);
                }
            }
            if (Directory.Exists(BFILE))
            {
                String[] strBFILE = Directory.GetFiles(BFILE);
                if (strBFILE.GetLength(0) != 0)
                {
                    for (int i = 0; i < strBFILE.GetLength(0); i++)
                        File.Delete(strBFILE[i]);
                }
            }
            if (Directory.Exists(CFILE))
            {
                String[] strCFILE = Directory.GetFiles(CFILE);
                if (strCFILE.GetLength(0) != 0)
                {
                    for (int i = 0; i < strCFILE.GetLength(0); i++)
                        File.Delete(strCFILE[i]);
                }
            }
            if (Directory.Exists(DFILE))
            {
                String[] strDFILE = Directory.GetFiles(DFILE);
                if (strDFILE.GetLength(0) != 0)
                {
                    for (int i = 0; i < strDFILE.GetLength(0); i++)
                        File.Delete(strDFILE[i]);
                }
            }
        }

        public static bool WriteAFile(string SN)
        {
            CreateDir();
            Thread.Sleep(100);

            SN = SN.ToUpper();      //SFCS需要的SN基本都是大写
            string AFile = string.Format("{0}\\{1}_A_P.ini", AFILE, SN);
            File.Delete(AFile);
            StreamWriter sw = new StreamWriter(AFile);
            sw.WriteLine("[SECTION]");
            sw.WriteLine("SN=" + SN);
            sw.Flush();
            sw.Close();

            if (File.Exists(AFile))
                return true;
            else
                return false;
        }

        public static int ReadBFile(string SN)     // 1——PASS, 0——FAIL, -1——TIMEOUT
        {
            CreateDir();
            Thread.Sleep(100);

            int iresult = 0;
            SN = SN.ToUpper();
            string BFile_PASS = string.Format("{0}\\{1}_B_P.ini", BFILE, SN);
            string BFile_FAIL = string.Format("{0}\\{1}_B_F.ini", BFILE, SN);
            int i = 0;
            while (true)
            {
                if (File.Exists(BFile_PASS))
                {
                    iresult = 1;
                    break;
                }
                else if (File.Exists(BFile_FAIL) || i > 30)
                {
                    if (File.Exists(BFile_FAIL))
                    {
                        iresult = 0;
                    }
                    else
                    {
                        iresult = -1;
                    }
                    break;
                }
                i++;
                Thread.Sleep(100);
            }

            return iresult;
        }

        public static string ReadBFile(string SN, string invalid)     //PASS, FAIL, TIMEOUT
        {
            CreateDir();
            Thread.Sleep(100);

            string result = "";
            SN = SN.ToUpper();
            string BFile_PASS = string.Format("{0}\\{1}_B_P.ini", BFILE, SN);
            string BFile_FAIL = string.Format("{0}\\{1}_B_F.ini", BFILE, SN);
            int i = 0;
            while (true)
            {
                if (File.Exists(BFile_PASS))
                {
                    result = "PASS";
                    break;
                }
                else if (File.Exists(BFile_FAIL) || i > 30)
                {
                    if (File.Exists(BFile_FAIL))
                    {
                        result = "FAIL";
                    }
                    else
                    {
                        result = "TIMEOUT";
                    }
                    break;
                }
                i++;
                Thread.Sleep(100);
            }

            return result;
        }

        public static bool WriteCFile(string SN, string value, Boolean status, string errcode)
        {
            CreateDir();
            Thread.Sleep(100);

            string CFile = "";
            if (status)
            {
                CFile = string.Format("{0}\\{1}_C_P.ini", CFILE, SN);
            }
            else
            {
                CFile = string.Format("{0}\\{1}_C_F.ini", CFILE, SN);
            }
            File.Delete(CFile);
            StreamWriter sw = new StreamWriter(CFile);
            sw.WriteLine("[SECTION]");
            sw.WriteLine("SN=" + SN);
            if (status)
            {
                sw.WriteLine("TEST_RESULT=PASS");
                sw.WriteLine("ERROR_CODE=NONE");
            }
            else
            {
                sw.WriteLine("TEST_RESULT=FAIL");
                sw.WriteLine("ERROR_CODE=" + errcode);
            }
            sw.WriteLine("ERROR_MSG=NONE");
            sw.WriteLine(value);
            sw.Flush();
            sw.Close();

            if (File.Exists(CFile))
                return true;
            else
                return false;
        }

        public static void SetPos(Point p)
        {
            SetCursorPos((int)p.X, (int)p.Y);
        }

        public static void Left_Click(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            Thread.Sleep(100);
        }

        public static void Left_Click(Point p)
        {
            int x = (int)p.X;
            int y = (int)p.Y;
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            Thread.Sleep(100);
        }

        public static void Left_Click(Point p, int i)
        {
            int x = (int)p.X;
            int y = (int)p.Y;
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            Thread.Sleep(i);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        public static void Right_Click(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
            Thread.Sleep(100);
        }

        public static void Right_Click(Point p)
        {
            int x = (int)p.X;
            int y = (int)p.Y;
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
            Thread.Sleep(100);
        }

        public static void Right_Click(Point p, int i)
        {
            int x = (int)p.X;
            int y = (int)p.Y;
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
            Thread.Sleep(i);
            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
        }

        static public AutomationElement aeDesk = AutomationElement.RootElement;

        public static bool CheckProcess(string sname)
        {
            bool b = false;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Equals(sname))
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        public static void KillProcess(string sname, int icount)
        {
            int i = 0;
            foreach (Process p in Process.GetProcesses())
            {
                if (i == icount)
                    break;

                if (p.ProcessName.Equals(sname))
                {
                    i++;
                    p.Kill();
                    p.WaitForExit();
                    p.Close();
                }
            }

        }

        /// <summary>
        /// Kill all process
        /// </summary>
        /// <param name="sname"></param>
        public static void KillProcess(string sname)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Equals(sname))
                {
                    p.Kill();
                    p.WaitForExit();
                    p.Close();
                }
            }
        }

        public static IntPtr Findwin(string sname, int itime)
        {
            IntPtr hwnd;
            int i = 0;
            while (true)
            {
                if ((hwnd = MyAPI.FindWindow(null, sname)) != IntPtr.Zero)
                {
                    break;
                }
                else if (i > (itime * 2))
                {
                    hwnd = IntPtr.Zero;
                    break;
                }
                i++;
                Thread.Sleep(500);
            }
            return hwnd;
        }

        public static AutomationElement FindChildByAutomationId(AutomationElement aeParent, string id, int itime)
        {
            int i = 0;
            AutomationElement aeChild = null;
            try
            {
                if (aeParent != null)
                {
                    while (true)
                    {
                        aeChild = aeParent.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
                        if (aeChild != null)
                        {
                            break;
                        }
                        else if (i > (itime * 2))
                        {
                            aeChild = null;
                            break;
                        }
                        i++;
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    aeChild = null;
                }
            }
            catch { }

            return aeChild;
        }

        public static AutomationElement FindChildByName(AutomationElement aeParent, string name, int itime)
        {
            int i = 0;
            AutomationElement aeChild = null;
            try
            {
                if (aeParent != null)
                {
                    while (true)
                    {
                        aeChild = aeParent.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, name));
                        if (aeChild != null)
                        {
                            break;
                        }
                        else if (i > (itime * 2))
                        {
                            aeChild = null;
                            break;
                        }
                        i++;
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    aeChild = null;
                }
            }
            catch { }

            return aeChild;
        }

        public static AutomationElement FindChildByClassname(AutomationElement aeParent, string classname, int itime)
        {
            int i = 0;
            AutomationElement aeChild = null;
            try
            {
                if (aeParent != null)
                {
                    while (true)
                    {
                        aeChild = aeParent.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, classname));
                        if (aeChild != null)
                        {
                            break;
                        }
                        else if (i > (itime * 2))
                        {
                            aeChild = null;
                            break;
                        }
                        i++;
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    aeChild = null;
                }
            }
            catch { }

            return aeChild;
        }

        public static AutomationElement FindChild(AutomationElement aeParent, AutomationProperty aptype, string s, int itime)  //通用，可根据各种属性寻找控件
        {
            int i = 0;
            AutomationElement aeChild = null;
            try
            {
                if (aeParent != null)
                {
                    while (true)
                    {
                        aeChild = aeParent.FindFirst(TreeScope.Children, new PropertyCondition(aptype, s));
                        if (aeChild != null)
                        {
                            break;
                        }
                        else if (i > (itime * 2))
                        {
                            aeChild = null;
                            break;
                        }
                        i++;
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    aeChild = null;
                }
            }
            catch { }

            return aeChild;
        }

        public static ValuePattern GetValuePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ValuePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the ValuePattern.",
                element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as ValuePattern;
        }

        public static SelectionItemPattern GetSelectionItemPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the SelectionItemPattern.",
                element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as SelectionItemPattern;
        }

        public static ArrayList ReadSections(string FileName)
        {
            byte[] buffer = new byte[65535];
            int rel = GetPrivateProfileSectionNames(buffer, buffer.GetUpperBound(0), FileName);
            return Conver2ArrayList(rel, buffer);
        }

        public static ArrayList Conver2ArrayList(int rel, byte[] buffer)
        {
            ArrayList arrayList = new ArrayList();
            if (rel > 0)
            {
                int iCnt, iPos;
                string tmp;
                iCnt = 0; iPos = 0;
                for (iCnt = 0; iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = System.Text.ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (tmp != "")
                            arrayList.Add(tmp);
                    }
                }
            }
            return arrayList;
        }

        public static List<string> GetIniSectionValue(string section, string sconfig_path)
        {
            List<string> s = new List<string>();
            byte[] buffer = new byte[5120];
            int rel = GetPrivateProfileSection(section, buffer, buffer.GetUpperBound(0), sconfig_path);
            int iCnt, iPos;
            string tmp;
            if (rel > 0)
            {
                iCnt = 0; iPos = 0;
                for (iCnt = 0; iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = System.Text.ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (tmp != "")
                            s.Add(tmp);
                    }
                }
            }
            return s;
        }

        public static void RunDosCommand(string cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.Arguments = "/c " + cmd;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        public static void ClickButton(IntPtr buttonHandle)
        {
            Message msg = Message.Create(buttonHandle, BM_CLICK, new IntPtr(0), new IntPtr(0));
            PostMessage(msg.HWnd, msg.Msg, msg.WParam, msg.LParam);
        }

        public static void SetTextBoxString(IntPtr textboxHandle, string content)
        {
            SendMessage(textboxHandle, WM_SETTEXT, IntPtr.Zero, new StringBuilder(content));
        }
    }
}