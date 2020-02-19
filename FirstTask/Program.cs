using System;
using System.Collections.Generic;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Node> list = new List<Node>
            {
                new Node() { Name = "2", Parent = "1" },
                new Node() { Name = "1", Parent= string.Empty },
                new Node() { Name = "3", Parent = "1" },
                new Node() { Name = "14", Parent = "7" },
                new Node() { Name = "5", Parent = "2" },
                new Node() { Name = "6", Parent = "2" },
                new Node() { Name = "15", Parent = "8" },
                new Node() { Name = "8", Parent = "3" },
                new Node() { Name = "7", Parent = "3" },
                new Node() { Name = "10", Parent = "5" },
                new Node() { Name = "11", Parent = "6" },
                new Node() { Name = "12", Parent = "6" },
                new Node() { Name = "13", Parent = "7" },
                new Node() { Name = "4", Parent = "1" },
                new Node() { Name = "22", Parent = "13" },
                new Node() { Name = "9", Parent = "4" },
                new Node() { Name = "16", Parent = "9" },
                new Node() { Name = "17", Parent = "10" },
                new Node() { Name = "18", Parent = "10" },
                new Node() { Name = "23", Parent = "13" },
                new Node() { Name = "19", Parent = "10" },
                new Node() { Name = "20", Parent = "11" },
                new Node() { Name = "21", Parent = "12" },
                new Node() { Name = "24", Parent = "14" },
                new Node() { Name = "25", Parent = "15" },
                new Node() { Name = "26", Parent = "15" },
                new Node() { Name = "27", Parent = "15" },
                new Node() { Name = "28", Parent = "16" },
                new Node() { Name = "33", Parent = "32" },
                new Node() { Name = "29", Parent = "16" },
                new Node() { Name = "32", Parent = "30" },
                new Node() { Name = "31", Parent = "30" },
                new Node() { Name = "34", Parent = "33" },
                new Node() { Name = "30", Parent = "16" },
                new Node() { Name = "35", Parent = "34" }
            };
            Tree tree = new Tree(list);
            tree.BuildTree(list);
            Console.WriteLine(tree.GetParent("35", 7));
        }
    }
}
