using System;
using System.Threading;
using System.Windows;

using NoelPush.Services;


namespace NoelPush
{
    public partial class App
    {
        private static Mutex mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            if (!IsSingleInstance())
                Environment.Exit(1);

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (mutex != null)
                mutex.ReleaseMutex();

            base.OnExit(e);
        }

        static bool IsSingleInstance()
        {
            try
            {
                Mutex.OpenExisting("NOELPUSHINSTALL");
            }
            catch
            {
                mutex = new Mutex(true, "NOELPUSHINSTALL");
                return true;
            }

            return false;
        }
    }
}
