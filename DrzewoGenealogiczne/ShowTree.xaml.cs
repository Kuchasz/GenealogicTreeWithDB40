using GeoTree.Logic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeoTree.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShowTree : Window
    {

        public int VerticalNodesSpace = 50;
        public int HorizontalNodesSpace = 100;
        public int NodeRadius = 30;

        public ShowTree()
        {
            InitializeComponent();

            gt.Generations.Clear();
            gt.DrawableNodes.Clear();
            gt.DrawableLines.Clear();

            /*
            ////GeneticTree gt = new GeneticTree();
            GeneticNode anna = new GeneticNode() { Name = "Anna" };
            GeneticNode bogdan = new GeneticNode() { Name = "Bogdan" };
            GeneticNode celina = new GeneticNode() { Name = "Celina" };
            GeneticNode dawid = new GeneticNode() { Name = "Dawid" };
            GeneticNode elzbieta = new GeneticNode() { Name = "Elżbieta" };
            GeneticNode franciszek = new GeneticNode() { Name = "Franciszek" };
            GeneticNode grazyna = new GeneticNode() { Name = "Grażyna" };
            GeneticNode henryk = new GeneticNode() { Name = "Henryk" };
            GeneticNode irena = new GeneticNode() { Name = "Irena" };
            GeneticNode jan = new GeneticNode() { Name = "Jan" };
            GeneticNode kamila = new GeneticNode() { Name = "Kamila" };
            GeneticNode leszek = new GeneticNode() { Name = "Leszek" };
            GeneticNode malgorzata = new GeneticNode() { Name = "Małogrzata" };
            GeneticNode natalia = new GeneticNode() { Name = "Natalia" };

            anna.Children.Add(celina);
            anna.Children.Add(dawid);
            bogdan.Children.Add(elzbieta);
            bogdan.Children.Add(franciszek);
            celina.Children.Add(franciszek);
            dawid.Children.Add(grazyna);
            dawid.Children.Add(henryk);
            elzbieta.Children.Add(irena);
            elzbieta.Children.Add(jan);
            franciszek.Children.Add(kamila);
            grazyna.Children.Add(leszek);
            grazyna.Children.Add(malgorzata);
            henryk.Children.Add(natalia);

            var nodes = new List<IGeneticTreeNode>()
            {
                anna,bogdan,celina,dawid,elzbieta,franciszek,grazyna,henryk,irena,jan,kamila,leszek,malgorzata,natalia
            };

            gt.Nodes = nodes;
            //gt.VerticalNodeSpace = 100;
            //gt.HorizontalNodeSpace = 100;
            //gt.NodeThickness = 25;
            */

        }

    }
}
