using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 屏幕工具
{
    public class PrScrnHelper
    {
        [DllImport("PrScrn.dll", EntryPoint = "PrScrn")]
        public static extern int PrScrn();
    }
}
