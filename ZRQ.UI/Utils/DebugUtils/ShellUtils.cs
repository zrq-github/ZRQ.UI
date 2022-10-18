using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.Utils.DebugUtils;

namespace ZRQ.UI.Utils.DebugUtils
{
    /// <summary>  
    /// 与控制台交互  
    /// </summary>  
    public class ShellUtils : IDisposable
    {
        private static ShellUtils instance;

        public static ShellUtils Inst
        {
            get
            {
                if (instance == null)
                {
                    ConsoleManager.Show();
                    instance = new ShellUtils();
                }
                return instance;
            }
        }
        public static void Error(string error)
        {
            WriteLine(ref error, ShellMessageType.ERROR);
        }

        public static void Notice(string notice)
        {
            WriteLine(ref notice, ShellMessageType.NOTICE);
        }

        public static void Warning(string warning)
        {
            WriteLine(ref warning, ShellMessageType.WARNING);
        }

        public void Dispose()
        {
            ConsoleManager.Hide();
        }

        public void Error(string error, Exception ex = null)
        {
            if (null == ex)
            {
                ShellUtils.Error($"{error}");
                return;
            }
            ShellUtils.Error($"{error}\n{ex}");
        }

        /// <summary>
        /// 普通的记录信息
        /// </summary>
        /// <param name="output"></param>
        public void Info(string output)
        {
            ShellUtils.WriteLine(ref output);
        }

        public void Warning(string warning, Exception ex = null)
        {
            if (null == ex)
            {
                ShellUtils.Warning($"{warning}");
                return;
            }
            ShellUtils.Warning($"{warning}\n{ex}");
        }

        private static ConsoleColor GetConsoleColor(ShellMessageType shellMessageType)
        {
            if (shellMessageType == ShellMessageType.Info)
                return ConsoleColor.Gray;
            if (shellMessageType == ShellMessageType.ERROR)
                return ConsoleColor.Red;
            if (shellMessageType == ShellMessageType.WARNING)
                return ConsoleColor.Yellow;
            if (shellMessageType == ShellMessageType.NOTICE)
                return ConsoleColor.Green;

            return ConsoleColor.Gray;
        }

        private static void WriteLine(ref string output, ShellMessageType shellMessageType = ShellMessageType.Info)
        {
            Console.ForegroundColor = GetConsoleColor(shellMessageType);
            Console.WriteLine(@"[{0}]{1}", DateTimeOffset.Now, output);
        }
    }
}
