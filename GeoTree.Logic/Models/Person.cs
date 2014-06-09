using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTree.Logic.Models
{
    public class Person : IGeneticTreeNode
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDead { get; set; }
        public Sex Sex { get; set; }
        public List<IGeneticTreeNode> Children { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}
