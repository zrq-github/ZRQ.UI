using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace ZRQ.UI._Test
{
    internal class _设置wpf的window的父窗体为当前进程主窗口句柄
    {
        public void Test()
        {
            //int id = Process.GetCurrentProcess().Id;
            //IntPtr mainPtr = ProcessHelper.GetProcessHandle(id);
            //var win = new Window();
            //new WindowInteropHelper(win) { Owner = mainPtr };
            //win.Show();
        }
    }
}
