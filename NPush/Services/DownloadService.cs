using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

using NoelPush.ViewModels;


namespace NoelPush.Services
{
    public static class DownloadService
    {
        private static MainWindowViewModel viewModel;
        private static Stopwatch watch;
        private static Timer timer;

        public static void Download(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
            watch = new Stopwatch();

            var client = new WebClient();
            client.DownloadProgressChanged += InProgress;
            client.DownloadFileCompleted += Completed;

            client.DownloadFileAsync(new Uri("http://noelpush.com/noelpush.exe"), "noelpush.exe");
            watch.Start();
        }

        private static void InProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            viewModel.ProgressValue = e.ProgressPercentage;

            var time = (100 - e.ProgressPercentage) * (watch.ElapsedMilliseconds / 1000.0) / e.ProgressPercentage + 1;
            time = Math.Round(time, 0);

            viewModel.RemainingTime = time.ToString();
        }

        private static void Completed(object sender, AsyncCompletedEventArgs e)
        {
            viewModel.RemainingTime = "0";

            var path = Directory.GetCurrentDirectory() + "\\noelpush.exe";
            Process.Start(path);

            timer = new Timer(Close, null, 1000, 1000);
        }

        private static void Close(object state)
        {
            Environment.Exit(0);
        }
    }
}
