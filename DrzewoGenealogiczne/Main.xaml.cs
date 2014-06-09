using GeoTree.Logic;
using GeoTree.Logic.Data;
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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private readonly Database db;

        public Main()
        {
            InitializeComponent();


            this.db = new Database();

            LoadEntities();
        }

        private void LoadEntities()
        {
            dgrid.ItemsSource = this.db.personService.GetPeople();
        }


        private void OpenAddPeopleForm(object sender, RoutedEventArgs e)
        {


            AddPersonForm apf = new AddPersonForm(db,new Person());
            var pp = new Person() { Children = new List<IGeneticTreeNode>(), DateOfBirth = new DateTime() };
            apf.DataContext = pp;
            apf.ShowDialog();
            if (apf.DialogResult == true)
            {
                this.db.GetDatabaseInstance().Store(pp);
                LoadEntities();
            }
        }

        private void RemovePeople(object sender, RoutedEventArgs e)
        {
            if (dgrid.SelectedItems.Count == 1)
            {
                var selected = (Person)this.dgrid.SelectedItem;
                this.db.GetDatabaseInstance().Delete(selected);
                LoadEntities();
            }

        }


        private void OpenEditPeopleForm(object sender, RoutedEventArgs e)
        {
           
            var ppedit = (Person)dgrid.SelectedItem;
            var ppcopy = new Person() { Children = ppedit.Children, DateOfBirth = ppedit.DateOfBirth, DateOfDead = ppedit.DateOfDead, Name = ppedit.Name, Sex = ppedit.Sex };
            AddPersonForm apf = new AddPersonForm(db, ppedit);
            apf.DataContext = ppcopy;
            apf.Title = "Edycja osoby";
            apf.ShowDialog();
            if (apf.DialogResult == true)
            {
                ppedit.Name = ppcopy.Name;
                ppedit.Sex = ppcopy.Sex;
                ppedit.DateOfBirth = ppcopy.DateOfBirth;
                ppedit.DateOfDead = ppcopy.DateOfDead;
                db.GetDatabaseInstance().Store(ppedit);
                LoadEntities();
            }
        }

        private void OpenAddRelationForm(object sender, RoutedEventArgs e)
        {


            var arfvm = new AddRelationFormViewModel();

            arfvm.People = new List<IGeneticTreeNode>();
            arfvm.MainPerson = (Person)this.dgrid.SelectedItem;

            arfvm.AddingChild = true;
            if (db.personService.GetParent(Sex.Male, arfvm.MainPerson) != null)
            {
                arfvm.AddingFather = false;
                arfvm.GotFather = true;
            }
            else
            {
                arfvm.AddingFather = true;
            }
            if (db.personService.GetParent(Sex.Female, arfvm.MainPerson) != null)
            {
                arfvm.AddingMather = false;
                arfvm.GotMother = true;
            }
            else
            {
                arfvm.AddingMather = true;
            }



            AddRelationForm arf = new AddRelationForm(db, arfvm);

            arf.DataContext = arfvm;
            arf.ShowDialog();
            LoadEntities();

        }

        private void OpenShowInheritorsForm(object sender, RoutedEventArgs e)
        {
            if (dgrid.SelectedItems.Count == 1)
            {
                ShowInheritorsForm sif = new ShowInheritorsForm();
                
                Person pp = (Person)dgrid.SelectedItem;
                sif.Title = "Spadkobiercy - "+pp.Name;
                sif.DataContext = this.db.personService.GetInheritors(pp);
                sif.ShowDialog();
            }
        }

        private void OpenShowCiugewaAncestors(object sender, RoutedEventArgs e)
        {


            if (dgrid.SelectedItems.Count == 2)
            {
                ShowInheritorsForm sif = new ShowInheritorsForm();
                Person per1 = (Person)dgrid.SelectedItems[0];
                Person per2 = (Person)dgrid.SelectedItems[1];

                sif.Title = "Wspólni przodkowie";
                sif.DataContext = this.db.personService.GetCommonAncestors(per1, per2);

                sif.ShowDialog();
            }

        }

        private void OpenShowTree(object sender, RoutedEventArgs e)
        {


            if (dgrid.SelectedItems.Count == 1)
            {
                ShowTree st = new ShowTree();

                var listaLudzi = new List<IGeneticTreeNode>() { };
                Person per = (Person)dgrid.SelectedItem;
                listaLudzi.Add(per);
                this.db.personService.GetSomeonesDescendants(listaLudzi, per);
                st.DataContext = listaLudzi;
                st.ShowDialog();
            }
            else
            {
                ShowTree st = new ShowTree();

                var listaLudzi = new List<IGeneticTreeNode>() { };
                
                listaLudzi.AddRange( this.db.personService.GetPeople());
                st.DataContext = listaLudzi;
                st.ShowDialog();
            }




        }




    }
}
