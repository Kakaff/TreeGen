using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    
    public static class Debugger
    {
        public delegate void OnDebugEventHandler(string msg);
        public static event OnDebugEventHandler OnDebug;


        public static void Debug(string msg)
        {
            OnDebug?.Invoke(msg);
        }
    }
}
