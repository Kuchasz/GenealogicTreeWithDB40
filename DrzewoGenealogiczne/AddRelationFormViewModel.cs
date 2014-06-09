using GeoTree.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GeoTree.UI
{
    public class AddRelationFormViewModel : INotifyPropertyChanged
    {

        //tu go daj 

        public Person MainPerson { get; set; }
       // public IEnumerable<IGeneticTreeNode> People { get; set; }
        public bool MyProperty { get; set; }

        private IEnumerable<IGeneticTreeNode> people;
        public IEnumerable<IGeneticTreeNode> People
        {
            get
            {
                return this.people;
            }

            set
            {
                if (value != this.people)
                {
                    this.people = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool gotMother;
        public bool GotMother
        {
            get
            {
                return this.gotMother;
            }

            set
            {
                if (value != this.gotMother)
                {
                    this.gotMother = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool gotFather;
        public bool GotFather
        {
            get
            {
                return this.gotFather;
            }

            set
            {
                if (value != this.gotFather)
                {
                    this.gotFather = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool addingFather;
        public bool AddingFather
        {
            get
            {
                return this.addingFather;
            }

            set
            {
                if (value != this.addingFather)
                {
                    this.addingFather = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool addingMather;
        public bool AddingMather
        {
            get
            {
                return this.addingMather;
            }

            set
            {
                if (value != this.addingMather)
                {
                    this.addingMather = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool addingChild;
        public bool AddingChild
        {
            get
            {
                return this.addingChild;
            }

            set
            {
                if (value != this.addingChild)
                {
                    this.addingChild = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
