﻿using System;
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
    /// Interaction logic for UpdateMachine.xaml
    /// </summary>
    public partial class UpdateMachine : Window
    {
        public UpdateMachine()
        {
            InitializeComponent();
        }
        public UpdateMachine(MachineStatus m)
        {
            InitializeComponent();

            //Name = m.Name;
            //Model = m.Model;
            //Category = m.Category;
            //Manufacturer = m.Manufacturer;
            ////Status = comboBoxStatus.SelectedItem.ToString(),
            //Description = m.Description;

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
                    Name = TextBoxName1.Text,
                    Model = TextBoxModel1.Text,
                    Category = TextBoxCategory1.Text,
                    Manufacturer = TextBoxManufacturer1.Text,
                    //Status = comboBoxStatus.SelectedItem.ToString(),
                    Description = TextBoxDescription1.Text
                });
            this.Close();
        }
    }
}
