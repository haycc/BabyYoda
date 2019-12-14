﻿using System;
using System.Runtime.InteropServices;

namespace BabyYodaBot.Core
{
    public class WindowFinder
    {
        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static IntPtr FindWindow(string caption)
        {
            return FindWindow(String.Empty, caption);
        }

    }
}