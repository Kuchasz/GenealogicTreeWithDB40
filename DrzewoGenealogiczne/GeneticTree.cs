using GeoTree.Logic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MisiekPodejscieNrJeden"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MisiekPodejscieNrJeden;assembly=MisiekPodejscieNrJeden"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:GeneticTree/>
    ///
    /// </summary>

    [TemplatePart(Name = "PART_ContentHostNodes", Type = typeof(ItemsControl))]
    [TemplatePart(Name = "PART_ContentHostLines", Type = typeof(ItemsControl))]
    public class GeneticTree : Control
    {
        private ItemsControl Surface;
        private ItemsControl Surface2;

        public int VerticalNodeSpace { get; set; }
        public int HorizontalNodeSpace { get; set; }
        public int NodeThickness { get; set; }   

        public List<Generation> Generations
        {
            get { return (List<Generation>)GetValue(GenerationsProperty); }
            private set { SetValue(GenerationsProperty, value); }
        }

        public static readonly DependencyProperty GenerationsProperty =
            DependencyProperty.Register("Generations", typeof(List<Generation>), typeof(GeneticTree), new PropertyMetadata(new List<Generation>()));

        public List<DrawableNode> DrawableNodes
        {
            get { return (List<DrawableNode>)GetValue(DrawableNodesProperty); }
            private set { SetValue(DrawableNodesProperty, value); }
        }

        public static readonly DependencyProperty DrawableNodesProperty =
            DependencyProperty.Register("DrawableNodes", typeof(List<DrawableNode>), typeof(GeneticTree), new PropertyMetadata(new List<DrawableNode>()));

        public List<DrawableLine> DrawableLines
        {
            get { return (List<DrawableLine>)GetValue(DrawableLinesProperty); }
            private set { SetValue(DrawableLinesProperty, value); }
        }

        public static readonly DependencyProperty DrawableLinesProperty =
            DependencyProperty.Register("DrawableLines", typeof(List<DrawableLine>), typeof(GeneticTree), new PropertyMetadata(new List<DrawableLine>()));

        public List<IGeneticTreeNode> Nodes
        {
            get { return (List<IGeneticTreeNode>)GetValue(NodesProperty); }
            set { SetValue(NodesProperty, value); }
        }

        public static readonly DependencyProperty NodesProperty =
            DependencyProperty.Register("Nodes", typeof(List<IGeneticTreeNode>), typeof(GeneticTree), new PropertyMetadata(new List<IGeneticTreeNode>()));

        public DataTemplate NodeTemplate
        {
            get { return (DataTemplate)GetValue(NodeTemplateProperty); }
            set { SetValue(NodeTemplateProperty, value); }
        }

        public static readonly DependencyProperty NodeTemplateProperty =
            DependencyProperty.Register("NodeTemplate", typeof(DataTemplate), typeof(GeneticTree), new PropertyMetadata(new DataTemplate()));

        static GeneticTree()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GeneticTree), new FrameworkPropertyMetadata(typeof(GeneticTree)));
        }

        private void AllocateNodes(List<IGeneticTreeNode> nodes, int generation = 0)
        {
            foreach (var gene in Generations)
            {
                foreach (var node in gene.Nodes)
                {
                    DrawableNodes.Add(new DrawableNode(){
                        Node=node,
                        X = (1 / (double)gene.Nodes.Count / 2) * Surface.Width + (Surface.Width * ((double)GetIndexInGeneration(gene,node) / (double)gene.Nodes.Count)),
                        Y = Surface.Height * (1 - ((double)gene.Level / (double)Generations.Count)) - (1 / (double)Generations.Count) * Surface.Height,
                        NodeThickness = NodeThickness
                    });
                }
            }

        }

        private void AllocateLines()
        {
            foreach (var item in DrawableNodes)
            {
                foreach (var it in item.Node.Children)
                {
                    var child = DrawableNodes.SingleOrDefault(n => n.Node == it);
                    var line = new DrawableLine() { From = new Point(item.X + NodeThickness / 2, item.Y + NodeThickness / 2), To = new Point(child.X + NodeThickness / 2, child.Y + NodeThickness / 2) };
                    DrawableLines.Add(line);
                }
            }
        }

        private void CalculateGenerations()
        {
            var nodes = Nodes;
            var roots = GetRootNodes(nodes);
            AddFamily(roots);
            var foreigners = GetPartners();
            AddPartners(foreigners);
        }

        private void AddFamily(List<IGeneticTreeNode> nodes, int level=0)
        {
            AddRangeToGeneration(level, nodes);
            foreach (var node in nodes)
            {
                AddFamily(node.Children, level + 1);
            }
        }

        private void AddPartners(List<IGeneticTreeNode> nodes)
        {
            foreach (var node in nodes)
            {
                var wifeOrHusband = GetPartner(node);
                var rightGeneration = GetSomeonesGeneration(wifeOrHusband);
                AddPartner(node, wifeOrHusband);
                AddFamily(node.Children, rightGeneration.Level+1);
            }
        }

        private void AddChildren(List<IGeneticTreeNode> nodes, int level)
        {
            AddRangeToGeneration(level, nodes);
        }

        private void AddPartner(IGeneticTreeNode node, IGeneticTreeNode to)
        {
            var generation = GetSomeonesGeneration(to);
            AddToGeneration(generation, node, to);
        }

        private bool GotParents(IGeneticTreeNode node)
        {
            return Nodes.Any(n => n.Children.Contains(node));
        }

        private bool GotChildren(IGeneticTreeNode node)
        {
            return node.Children.Count > 0;
        }

        private List<IGeneticTreeNode> GetPartners()
        {
            return Nodes.Where(n => GotChildrenWithSomeonesChild(n) && !GotParents(n)).ToList();
        }

        private bool GotChildrenWithSomeonesChild(IGeneticTreeNode node)
        {
            return Nodes.Where(n => n != node).Any(n => n.Children.ContainsAny<IGeneticTreeNode>(node.Children));
        }

        private IGeneticTreeNode GetPartner(IGeneticTreeNode node)
        {
            return Nodes.SingleOrDefault(n => n != node && n.Children.ContainsAny<IGeneticTreeNode>(node.Children));
        }

        private List<IGeneticTreeNode> GetRootNodes(List<IGeneticTreeNode> nodes)
        {
            return nodes.Where(n => !GotParents(n) && !GotChildrenWithSomeonesChild(n)).ToList();
        }

        private void AddRangeToGeneration(int level, List<IGeneticTreeNode> nodes)
        {
            foreach (var node in nodes)
            {
                AddToGeneration(level, node);
            }
        }

        private Generation GetSomeonesGeneration(IGeneticTreeNode node)
        {
            return Generations.SingleOrDefault(n => n.Nodes.Contains(node));
        }

        private void AddToGeneration(int level, IGeneticTreeNode node)
        {
            var generation = GetGeneration(level);
            if (generation == null)
            {
                Generations.Add(new Generation() { Level = level, Nodes = new List<IGeneticTreeNode>() });
                generation = GetGeneration(level);
            }
            if (!generation.Nodes.Contains(node))
            {
                AddToGeneration(generation, node);
            }
        }

        private void AddToGeneration(Generation generation, IGeneticTreeNode node)
        {
                generation.Nodes.Add(node);
        }

        private void AddToGeneration(Generation generation, IGeneticTreeNode node, IGeneticTreeNode to)
        {
            generation.Nodes.Insert(GetIndexInGeneration(generation, to), node);
        }

        private int GetIndexInGeneration(Generation generation, IGeneticTreeNode node)
        {
            return generation.Nodes.IndexOf(node);
        }

        private Generation GetGeneration(int level)
        {
            return Generations.SingleOrDefault(n => n.Level == level);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Surface = (GetTemplateChild("PART_ContentHostNodes") as ItemsControl);
            Surface2 = (GetTemplateChild("PART_ContentHostLines") as ItemsControl);

            CalculateGenerations();

            Surface.Width = Generations.Max(n => n.Nodes.Count) * HorizontalNodeSpace;
            Surface.Height = Generations.Count * VerticalNodeSpace;
            Surface2.Width = Surface.Width;
            Surface2.Height = Surface.Height;

            AllocateNodes(Nodes);
            AllocateLines();
        }
    }

    public static class Entensions
    {
        public static bool ContainsAny<T>(this IEnumerable<T> list, IEnumerable<T> members)
        {
            foreach (var item in members)
            {
                if (list.Contains(item)) return true;
            }
            return false;
        }
    }
}
