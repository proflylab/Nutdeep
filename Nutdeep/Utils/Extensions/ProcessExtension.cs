﻿using System;
using System.Diagnostics;

using Nutdeep.Tools;
using Nutdeep.Tools.Flags;

namespace Nutdeep.Utils.Extensions
{
    public static class ProcessExtension
    {
        

        public static void Pause(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var handle = Pinvoke.OpenThread(ThreadAccess.SUSPEND_RESUME,
                    false, (uint)thread.Id);
                if (handle == IntPtr.Zero) break;

                Pinvoke.SuspendThread(handle);
                Pinvoke.CloseHandle(handle);
            }
        }
        public static void Resume(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var handle = Pinvoke.OpenThread(ThreadAccess.SUSPEND_RESUME,
                    false, (uint)thread.Id);
                if (handle == IntPtr.Zero) break;

                Pinvoke.ResumeThread(handle);
                Pinvoke.CloseHandle(handle);
            }
        }
    }
}
