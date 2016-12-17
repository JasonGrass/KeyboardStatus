using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using Grass.Windows;
using Microsoft.Win32;

namespace KeyboardStatus
{
    class OptionSet
    {
        private static Register Register;

        private static Register.RegDomain RegDomain = Register.RegDomain.LocalMachine;

        private static string SubKey = @"SOFTWARE\KeyboradStatus";
        private static string SubKeyRun = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        private static string RegValueCaps = "Capslock";
        private static string RegValueNum = "Numlock";
        private static string RegValueStartWithSys = "KeyboradStatus";


        private OptionSet()
        {
            Register = new Register(SubKey, RegDomain);
        }

        private static volatile OptionSet option;
        public static OptionSet Option
        {
            get { return option ?? (option = new OptionSet()); }
        } 

        public void ReadOption(out bool capslock, out bool numlock, out bool startWithSys)
        {
            if (!IsAdministrator())
            {
                capslock = true;
                numlock = true;
                startWithSys = false;
                return;
            }

            if (Register.IsRegeditKeyExist(RegValueCaps))
            {
                capslock = Register.ReadRegeditKey(RegValueCaps).ToString().ToLower() == "true";
            }
            else
            {
                capslock = true;
                SaveCapslockOption(true);
            }

            if (Register.IsRegeditKeyExist(RegValueNum))
            {
                numlock = Register.ReadRegeditKey(RegValueNum).ToString().ToLower() == "true";               
            }
            else
            {
                numlock = true;
                SaveNumlockOption(true);
            }

            startWithSys = Register.IsRegeditKeyExist(RegValueStartWithSys, SubKeyRun);

        }

        public void SaveCapslockOption(bool capslock)
        {
            if (!IsAdministrator())
            {
                return;
            }
            Register.WriteRegeditKey(RegValueCaps, capslock);
        }

        public void SaveNumlockOption(bool numlock)
        {
            if (!IsAdministrator())
            {
                return;
            }
            Register.WriteRegeditKey(RegValueNum, numlock);
        }

        public void SaveStartWithSysOption(bool stratWithSys)
        {
            if (!IsAdministrator())
            {
                return;
            }
            if (stratWithSys)
            {
                //获取程序执行路径..
                string starupPath = Application.ExecutablePath;
                //class Micosoft.Win32.RegistryKey. 表示Window注册表中项级节点,此类是注册表装.
                RegistryKey loca = Registry.LocalMachine;
                RegistryKey run = loca.CreateSubKey(SubKeyRun);

                try
                {
                    //SetValue:存储值的名称
                    run.SetValue(RegValueStartWithSys, starupPath);
                    loca.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                //获取程序执行路径..
                string starupPath = Application.ExecutablePath;
                //class Micosoft.Win32.RegistryKey. 表示Window注册表中项级节点,此类是注册表装.
                RegistryKey loca = Registry.LocalMachine;
                RegistryKey run = loca.CreateSubKey(SubKeyRun);

                try
                {
                    //SetValue:存储值的名称
                    run.DeleteValue(RegValueStartWithSys);
                    loca.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

    }
}
