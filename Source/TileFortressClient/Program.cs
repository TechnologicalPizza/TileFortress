﻿using System;
using GeneralShare;

namespace TileFortress.Client
{
    public static class Program
    {
        static void Main()
        {
            Log.Initialize("log.txt");
            try
            {
                AppInfo.SetType(AppType.Client);
                AppInfo.SetCultureInfo();

                using (var game = new ClientGame())
                    game.Run();

                Log.LineBreak();
                Log.Info("Successful exit after " + DebugUtils.TimeSinceStart.ToPreciseString(), false);
            }
#if RELEASE
            catch (Exception exc)
            {
                Log.Error(new Exception("Uncaught exception during execution.", exc));
                if (DebugUtils.IsDebuggerAttached)
                    throw;
            }
#endif
            finally
            {
                Log.Close();
            }
        }
    }
}
