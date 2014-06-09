using Db4objects.Db4o.Ext;
using GeoTree.Logic;
using GeoTree.Logic.Models;
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

namespace GeoTree.UI
{
    /// <summary>
    /// Interaction logic for AddPersonForm.xaml
    /// </summary>
    public partial class AddPersonForm : Window
    {
        private readonly Database db;
        private readonly Person oldPerson;
        public AddPersonForm(Database db, Person oldPerson)
        {
            InitializeComponent();
            this.oldPerson = oldPerson;
            this.db = db;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //perform any validation
            //if walid 
            // a gdzie person do walidacji?
            Person person = (this.DataContext as Person);

            if ((oldPerson.Name != person.Name)&&this.db.personService.NameAvailable(person))
            {
                //if (this.db.personService.NameAvailable(person))
                //{
                    MessageBox.Show("Taka nazwa jest już zajęta!");
                //}
            }
            else
                if (!this.db.personService.ChangeDateOfBirth(person))
                {
                    MessageBox.Show("Nie możesz ustalić takiej daty narodzin!");
                }
                else
                    if (this.cbox.IsChecked == true && !this.db.personService.ChangeDateOfDead(person.DateOfDead, person))
                    {
                        MessageBox.Show("Nie możesz ustalić takiej daty śmierci!");
                    }
                    else
                    {
                        this.DialogResult = true;
                        this.Close();
                    }
        }
    }
}
