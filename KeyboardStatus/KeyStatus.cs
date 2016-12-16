using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace KeyboardStatus
{
    class KeyStatus
    {
        /// <summary>
        /// 获取键盘状态
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        /// <summary>
        /// 大小写状态
        /// </summary>
        public static bool CapsLockStatus
        {
            get
            {
                return (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
            }
        }

        /// <summary>
        /// 数字键盘锁定状态
        /// </summary>
        public static bool NumLockStatus
        {
            get
            {
                return (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
            }
        }
    }
}
