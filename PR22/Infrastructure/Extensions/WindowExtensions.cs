﻿using PR22.Infrastructure.Extensions;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace System.Windows
{
     static class WindowExtensions
    {
        private const string user32 = "user32.dll";

        [DllImport(user32, CharSet =CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd,uint Msg,IntPtr wParam,IntPtr lParam);
        [DllImport(user32, CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd,WM Msg,IntPtr wParam,IntPtr lParam);
        public static IntPtr SendMessage(this Window window, WM Msg, IntPtr wParam, IntPtr lParam = default)
        {
            return SendMessage(window.GetWindowHandle(), Msg,  wParam, lParam);
        }

        public static IntPtr SendMessage(this Window window, WM Msg, SC wParam, IntPtr lParam = default)
        {
            return SendMessage(
                window.GetWindowHandle(), 
                Msg: (uint)Msg, 
                (IntPtr)wParam,
                lParam == default ? (IntPtr)' ' : lParam);
        }

        private static IntPtr GetWindowHandle(this Window window)
        {
            var helper = new WindowInteropHelper(window);
            return helper.Handle;
        }
    }
}
