using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App313
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new ViewModel() { bindNoModel = new NoModel(){ Amt = "amt" } };
        }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            else
            {
                return;
            }
        }
    }

    public class NoModel
    {
        public string No { get; set; }
        public string Amt { get; set; }
    }

    public class ViewModel : BaseViewModel {

        public ViewModel() {

            this.saveCommand = new Command(save);
        }

        public NoModel bindNoModel { get; set; }

        public NoModel BindNoModel
        {
            get { return bindNoModel; }
            set
            {
                bindNoModel = value;
                OnPropertyChanged(nameof(BindNoModel));
            }
        }

        public ICommand saveCommand { get; set; }

        public void save() {

            BindNoModel = new NoModel() {Amt = "test" };

            //BindNoModel.No = string.Empty;
            //BindNoModel.Amt = string.Empty;
        }
    }
}
