using GeoTree.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTree.UI
{
    class GeneticNode : IGeneticTreeNode
    {
        public List<IGeneticTreeNode> Children { get; set; }
        public string Name { get; set; }

        public GeneticNode()
        {
            Children = new List<IGeneticTreeNode>();
        }


        public DateTime DateOfBirth
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime? DateOfDead
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Sex Sex
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
