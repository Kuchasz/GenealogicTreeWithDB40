using GeoTree.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTree.UI
{
    public class DrawableNode
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int NodeThickness { get; set; }
        public IGeneticTreeNode Node { get; set; }
    }
}
