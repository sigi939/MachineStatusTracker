using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MachineStatusTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<MachineStatus> _myCollection = new ObservableCollection<MachineStatus>();
        public MachineStatus selectedMachineStatus { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();

            DataContext = _myCollection;
            _myCollection.Add(
              new MachineStatus
              {
                  Name = "PrinterA",
                  Model = "AAA",
                  Category = "Virtual Printer",
                  Manufacturer= "Microsoft",
                  Status=MachineStatus.OperationalStatus.Idle,
                  Description=""
              });

            _myCollection.Add(
              new MachineStatus
              {
                  Name = "PrinterB",
                  Model = "BBB",
                  Category = "Virtual Printer",
                  Manufacturer = "Microsoft",
                  Status = MachineStatus.OperationalStatus.Offline,
                  Description = ""
              });

            _myCollection.Add(
              new MachineStatus
              {
                  Name = "Fax12",
                  Model = "CCC",
                  Category = "Fax",
                  Manufacturer = "Microsoft",
                  Status = MachineStatus.OperationalStatus.Running,
                  Description = ""
              });

 
    }

        private void Button_ClickAdd(object sender, RoutedEventArgs e)
        {
            AddMachine machine = new AddMachine();
            machine.ShowDialog();
            
        }

        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ListBox.Items.Count; i++)
            {
                object myObject = ListBox.Items[i];
                ListBoxItem lbi = (ListBoxItem)ListBox.ItemContainerGenerator.ContainerFromItem(myObject);
                
                if (lbi.IsSelected)
                {
                    //bool res = MessageBox.Show("Are you sure you want to delete this machine?", MessageBoxButton.YesNo);
                    

                    //_myCollection.Remove(lbi);
                }
            }
        }

        private void Button_ClickUpdate(object sender, RoutedEventArgs e)
        {
            MachineStatus m = new MachineStatus();
            m.Name = ListBoxItem.SelectedEvent.Name;
            //...לעדכן את הערכים מהפריט שבפוקוס
            UpdateMachine machine = new UpdateMachine(m);
            machine.ShowDialog();
        }
    }

    public class MachineStatus: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get {  return _name; }
            set
            {
                _name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private string _model;
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Model"));
                }
            }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Category"));
                }
            }
        }

        private string _manufacturer;
        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                _manufacturer = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Manufacturer"));
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }


        public enum OperationalStatus {Running, Idle, Offline}
        
        private OperationalStatus _status;

        public OperationalStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Model: {1}, Category: {2}, Manufacturer: {3}, Status: {4}, Description: {5}",
              Name, Model, Category, Manufacturer, Status, Description);
        }
    }
}
