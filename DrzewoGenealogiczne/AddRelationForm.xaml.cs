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
using Db4objects.Db4o;

namespace GeoTree.UI
{
    /// <summary>
    /// Interaction logic for AddRelationForm.xaml
    /// </summary>
    public partial class AddRelationForm : Window
    {
        //DataContext = AddRelationFormViewModel

        private AddRelationFormViewModel datacontext;

        private readonly Database db;

        public AddRelationForm(Database db, AddRelationFormViewModel _datacontext)
        {
            InitializeComponent();
            datacontext = _datacontext;
            this.db = db;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // dodaj matke
            // AddRelationFormViewModel datacontext = (AddRelationFormViewModel)this.DataContext;
            datacontext.AddingMather = true;
            datacontext.AddingChild = false;
            datacontext.AddingFather = false;

            this.datacontext.People = this.db.personService.GetAllMothers(this.datacontext.MainPerson);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // usun matke



            //var dbPerson = this.db.GetDatabaseInstance().QueryByExample(new Person() { 
            //    Name = person.Name
            //});

            var person = db.personService.GetParent(Sex.Female, datacontext.MainPerson);
            person.Children.Remove(datacontext.MainPerson);
            this.db.GetDatabaseInstance().Store(person);
            datacontext.GotMother = false;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // usun ojca

            // var person = ((Person)this.gridList.SelectedItem);

            //var dbPerson = this.db.GetDatabaseInstance().QueryByExample(new Person() { 
            //    Name = person.Name
            //});
            var person = db.personService.GetParent(Sex.Male, datacontext.MainPerson);
            person.Children.Remove(datacontext.MainPerson);
            this.db.GetDatabaseInstance().Store(person);
            datacontext.GotFather = false;
            //this.db.GetDatabaseInstance().Store()

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // dodaj ojca
            //  AddRelationFormViewModel datacontext = (AddRelationFormViewModel)this.DataContext;
            datacontext.AddingMather = false;
            datacontext.AddingChild = false;
            datacontext.AddingFather = true;

            //lec moze na chama gridem :D ok teraz ten datacontext zadziala
            this.datacontext.People = this.db.personService.GetAllFathers(this.datacontext.MainPerson);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            // dodaj dziecko
            //  AddRelationFormViewModel datacontext = (AddRelationFormViewModel)this.DataContext;
            datacontext.AddingMather = false;
            datacontext.AddingChild = true;
            datacontext.AddingFather = false;

            //niemamy listy dziecek // zrob testy :D nie, zrób :D
            this.datacontext.People = this.db.personService.GetAllChildren(this.datacontext.MainPerson);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // if addingChild|Nather|Father perform right action

            if (this.gridList.SelectedItems.Count == 1)
            {
                var selected = (Person)this.gridList.SelectedItem;

                if (datacontext.AddingMather)
                {
                    selected.Children.Add(this.datacontext.MainPerson);
                    db.GetDatabaseInstance().Store(selected.Children);
                    Button_Click_3(sender, e);
                }

                if (datacontext.AddingFather)
                {
                    selected.Children.Add(this.datacontext.MainPerson);
                    db.GetDatabaseInstance().Store(selected.Children);
                    Button_Click_5(sender, e);
                }

                if (datacontext.AddingChild)
                {
                    this.datacontext.MainPerson.Children.Add(selected); // testy?
                    db.GetDatabaseInstance().Store(this.datacontext.MainPerson.Children);
                    Button_Click_6(sender, e);
                }
            }


        }
    }
}
