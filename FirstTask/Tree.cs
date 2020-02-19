using System;
using System.Collections.Generic;

namespace FirstTask
{
    class Tree
    {
        public List<Tree> Children = new List<Tree>();
        public Tree Parent { get; set; }
        public Node nodeData { get; set; }

        private List<Node> nodeList = new List<Node>();
        private Dictionary<string, Tree> treeStructure = new Dictionary<string, Tree>();

        public Tree() { }

        public Tree(List<Node> nodeList)
        {
            this.nodeList = nodeList;
        }

        public void BuildTree(List<Node> nodeList)
        {
            try
            {
                nodeList.ForEach(x => treeStructure.Add(x.Name, new Tree { nodeData = x }));
                foreach (var item in treeStructure.Values)
                {
                    Tree parent;
                    if (treeStructure.TryGetValue(item.nodeData.Parent, out parent))
                    {
                        item.Parent = parent;
                        parent.Children.Add(item);
                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An Item with the same name already exists.");
            }
        }

        public string GetParent(string child, int level)
        {
            try
            {
                foreach (var a in treeStructure)
                {
                    Tree treeNode;
                    bool isChildExist = treeStructure.TryGetValue(child, out treeNode);
                    var parent = treeNode.Parent.nodeData.Name;
                    level--;
                    if (level == 0)
                    {
                        return parent;
                    }
                    else
                    {
                        return GetParent(parent, level);
                    }
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("The specified element was not found.");
            }
            return string.Empty;
        }
    }
}
