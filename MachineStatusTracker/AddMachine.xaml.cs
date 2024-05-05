using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MachineStatusTracker
{
    /// <summary>
    /// Interaction logic for AddMachine.xaml
    /// </summary>
    public partial class AddMachine : Window
    {
        public AddMachine()
        {
            InitializeComponent();

            ComboBoxItem newItem = new ComboBoxItem();
            
            foreach (var data in Enum.GetNames(typeof(MachineStatus.OperationalStatus)))
            {
                comboBoxStatus.Items.Add(data);
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            MainWindow._myCollection.Add(
                new MachineStatus()
                {
                    Name = TextBoxName.Text,
                    Model = TextBoxModel.Text,
                    Category = TextBoxCategory.Text,
                    Manufacturer = TextBoxManufacturer.Text,
                    //Status = comboBoxStatus.SelectedItem.ToString(),
                    Description = TextBoxDescription.Text
                });
            this.Close();
        }
    }
}
