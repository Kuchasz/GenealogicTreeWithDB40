using GeoTree.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTree.UI
{
    public class Generation
    {
        public List<IGeneticTreeNode> Nodes { get; set; }
        public int Level { get; set; }
    }
}
