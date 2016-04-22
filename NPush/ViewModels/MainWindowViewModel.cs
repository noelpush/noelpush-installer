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

        private string remainingTime;
        public string RemainingTime
        {
            get { return this.remainingTime; }
            set
            {
                if (this.remainingTime != value)
                {
                    this.remainingTime = value + " s";
                    this.FirePropertyChanged("RemainingTime");
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
