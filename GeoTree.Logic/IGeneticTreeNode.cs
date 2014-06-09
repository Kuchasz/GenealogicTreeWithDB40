using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTree.Logic.Models
{
    public interface IGeneticTreeNode
    {
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        DateTime? DateOfDead { get; set; }
        Sex Sex { get; set; }
        List<IGeneticTreeNode> Children { get; set; }
    }
}
