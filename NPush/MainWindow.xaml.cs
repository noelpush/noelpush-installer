using NoelPush.Services;
using NoelPush.ViewModels;

namespace NoelPush
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
            DownloadService.Download(this.DataContext as MainWindowViewModel);
        }
    }
}
