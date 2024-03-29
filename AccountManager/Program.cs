﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccess;

namespace AccountManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                Application.Run(new LaneAccount());
            }
            else
            {
                Application.Run(new LaneAccount(args[0]));
            }
        }
    }
}
