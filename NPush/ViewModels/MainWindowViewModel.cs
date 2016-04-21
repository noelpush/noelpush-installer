using System.ComponentModel;

namespace NoelPush.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int progressValue;
        public int ProgressValue
        {
            get { return this.progressValue; }
            set
            {
                if (this.progressValue != value)
                {
                    this.progressValue = value;
                    this.FirePropertyChanged("ProgressValue");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void FirePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
