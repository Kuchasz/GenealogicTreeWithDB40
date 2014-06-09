using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using GeoTree.Logic.Models;

namespace GeoTree.Logic.Data
{
    public class PersonService
    {
        private readonly IObjectContainer _db;

        public PersonService(IObjectContainer db)
        {
            _db = db;
        }

        public IEnumerable<Person> GetPeople()
        {
            return this._db.Query<Person>();
        }

        public bool CheckChildRelation(IGeneticTreeNode child, IGeneticTreeNode parent)
        {
            return (parent.Sex == Sex.Male)
                ? CheckFatherRelation(parent, child)
                : CheckMotherRelation(parent, child);
        }

        public bool CheckChildRelationWithChildEntity(IGeneticTreeNode child, IGeneticTreeNode parent)
        {
            return (parent.Sex == Sex.Male)
                ? CheckFatherRelationWithChildEntity(parent, child)
                : CheckMotherRelationWithChildEntity(parent, child);
        }

        public bool CheckMotherRelation(IGeneticTreeNode mother, IGeneticTreeNode child)
        {
            return mother.Name != child.Name &&
                    mother.Sex == Sex.Female &&
                    !mother.Children.Contains(child) &&
                    GetParent(Sex.Female, child) == null &&
                    mother.DateOfBirth.AddYears(10) < child.DateOfBirth &&
                    mother.DateOfBirth.AddYears(60) > child.DateOfBirth &&
                    ((mother.DateOfDead == null) || (mother.DateOfDead.Value > child.DateOfBirth));
        }

        public bool CheckMotherRelationWithChildEntity(IGeneticTreeNode mother, IGeneticTreeNode child)
        {
            return CheckMotherRelation(mother, child) &&
                !mother.Children.Contains(child) &&
                GetParent(Sex.Female, child) == null;
        }

        public bool CheckPartensDateOfBirth(IGeneticTreeNode parent, IGeneticTreeNode child)
        {
            return (parent.Sex == Sex.Male) ? CheckFathersDateOfBirth(parent, child) : CheckMothersDateOfBirth(parent, child);
        }

        public bool CheckFathersDateOfBirth(IGeneticTreeNode parent, IGeneticTreeNode child)
        {
            return child.DateOfBirth > parent.DateOfBirth.AddYears(12);
        }

        public bool CheckMothersDateOfBirth(IGeneticTreeNode parent, IGeneticTreeNode child)
        {
            return child.DateOfBirth > parent.DateOfBirth.AddYears(10);
        }


        public bool CheckFatherRelation(IGeneticTreeNode father, IGeneticTreeNode child)
        {
            return father.Name != child.Name &&
                    father.Sex == Sex.Male &&
                    father.DateOfBirth.AddYears(12) < child.DateOfBirth &&
                    father.DateOfBirth.AddYears(70) > child.DateOfBirth &&
                    ((father.DateOfDead == null) || father.DateOfDead.Value.AddDays(270) > child.DateOfBirth);
        }


        public bool CheckFatherRelationWithChildEntity(IGeneticTreeNode father, IGeneticTreeNode child)
        {
            return CheckFatherRelation(father, child) &&
                !father.Children.Contains(child) &&
                GetParent(Sex.Male, child) == null;
        }

        public List<IGeneticTreeNode> GetParents(IGeneticTreeNode person)
        {
            var list = new List<IGeneticTreeNode>();
            var parent1 = GetParent(Sex.Male, person);
            if (parent1 != null)
            {
                list.Add(parent1);
            }
            var parent2 = GetParent(Sex.Female, person);
            if (parent2 != null)
            {
                list.Add(parent2);
            }
            return list;
        }

        public Person GetParent(Sex sex, IGeneticTreeNode person)
        {
            var parent = this._db.Query<Person>(n => n.Sex == sex && n.Children.Contains(person)).FirstOrDefault();
            return parent;
        }

        public bool ChangeDateOfBirth(IGeneticTreeNode person)
        {
            var parent = new Person()
            {
                DateOfBirth = person.DateOfBirth,
                DateOfDead = person.DateOfDead,
            };

            if (person.Children != null)
            {
                if (person.Children.Any(child => !CheckPartensDateOfBirth(parent, child)))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ChangeDateOfDead(DateTime? newDate, IGeneticTreeNode person)
        {
            var parent = new Person()
            {
                DateOfBirth = person.DateOfBirth,
                DateOfDead = newDate,
            };

            if (person.Children != null)
            {
                if (person.Children.Any(child => !CheckChildRelation(child, parent)))
                {
                    return false;
                }
            }

            person.DateOfDead = newDate;
            return true;
        }

        public bool NameAvailable(Person per)
        {
            var pers = this._db.Query<Person>(n => n.Name == per.Name).Where(n => n != per);

            return pers.Any();
        }

        public IEnumerable<Person> GetAllFathers(IGeneticTreeNode child)
        {
            return this._db.Query<Person>().Where(n => CheckFatherRelation(n, child));
        }

        public IEnumerable<Person> GetAllMothers(IGeneticTreeNode child)
        {
            return this._db.Query<Person>().Where(n => CheckMotherRelation(n, child));
        }

        public IEnumerable<Person> GetAllChildren(IGeneticTreeNode parent)
        {
            return this._db.Query<Person>().Where(n => CheckChildRelationWithChildEntity(n, parent));
        }

        private void AddInheritors(List<IGeneticTreeNode> inheritors, IGeneticTreeNode person)
        {

            foreach (var item in person.Children)
            {
                
                if (item.DateOfDead!=null)
                {
                    AddInheritors(inheritors, item);
                }
                else
                {
                    inheritors.Add(item);
                }
            }
        }

        public List<IGeneticTreeNode> GetInheritors(IGeneticTreeNode person)
        {
            List<IGeneticTreeNode> list = new List<IGeneticTreeNode>();
            AddInheritors(list, person);
            return list;
        }

        public void GetSomeonesAncestors(List<IGeneticTreeNode> ancestors, IGeneticTreeNode person)
        {
            foreach (var item in GetParents(person))
            {
                ancestors.Add(item);
                GetSomeonesAncestors(ancestors, item);
            }
        }

        public void GetSomeonesDescendants(List<IGeneticTreeNode> descendants, IGeneticTreeNode person)
        {
            foreach (var item in person.Children)
            {
                descendants.Add(item);
                GetSomeonesDescendants(descendants, item);
            }
        }

        public List<IGeneticTreeNode> GetCommonAncestors(IGeneticTreeNode person1, IGeneticTreeNode person2)
        {
            var family1 = new List<IGeneticTreeNode>();
            var family2 = new List<IGeneticTreeNode>();

            GetSomeonesAncestors(family1, person1);
            GetSomeonesAncestors(family2, person2);

            return family1.Intersect<IGeneticTreeNode>(family2).ToList();
        }

    }
}
