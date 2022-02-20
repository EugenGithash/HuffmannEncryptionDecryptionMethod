using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Static_csharp
{
    public class Node
    {
        public int Apparition { get; set; }
        public uint Character_to_encode { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node()
        {

        }
        public Node(uint character_to_encode, int data)
        {
            this.Apparition = data;
            this.Character_to_encode = character_to_encode;
        }

        public List<bool> GoThroughTree(uint symbol, List<bool> code)
        {

            if (Left == null && Right == null)
            {
                if (symbol.Equals(Character_to_encode))
                {
                    return code;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(code);
                    leftPath.Add(false);

                    left = Left.GoThroughTree(symbol, leftPath);
                }

                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(code);
                    rightPath.Add(true);

                    right = Right.GoThroughTree(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }

            }
        }
    }

        class Huffmann
        {
            public Dictionary<uint, int> statistic = new Dictionary<uint, int>();
            private List<Node> huffmann_nodes = new List<Node>();
            private Node Root { get; set; }
            private void CreateStatistic(List<uint> text)
            {
                foreach (uint word in text)
                {
                    if (!statistic.ContainsKey(word))
                    {
                        statistic.Add(word, 1);
                    }
                    else
                    {
                        statistic[word]++;
                    }

                }
                statistic = statistic.OrderBy(character_apparition => character_apparition.Value).ToDictionary(character_apparition => character_apparition.Key, character_apparition => character_apparition.Value);
            }

            private void SortListOfNodes()
            {
                huffmann_nodes = huffmann_nodes.OrderBy(huffmann_node => huffmann_node.Character_to_encode).ToList();
                huffmann_nodes = huffmann_nodes.OrderBy(huffmann_node => huffmann_node.Apparition).ToList();

        }

        private void CreateHuffmannTree()
        {
                foreach (KeyValuePair<uint, int> character_to_encode in statistic)
                {
                    huffmann_nodes.Add(new Node(character_to_encode.Key, character_to_encode.Value));
                }

                while (huffmann_nodes.Count > 1)
                {
                    SortListOfNodes();
                    if (huffmann_nodes.Count >= 2)
                    {
                        Node parent = new Node()
                        {
                            Character_to_encode = 256,
                            Apparition = huffmann_nodes[0].Apparition + huffmann_nodes[1].Apparition,
                            Left = huffmann_nodes[0],
                            Right = huffmann_nodes[1]
                        };
                        huffmann_nodes.Remove(huffmann_nodes[0]);
                        huffmann_nodes.Remove(huffmann_nodes[0]);

                        huffmann_nodes.Add(parent);
                    }

                }
                this.Root = huffmann_nodes.First();
            
        }

            public Node EncodeHuffmann(List<uint> text)
            {
                CreateStatistic(text);
                CreateHuffmannTree();
                
            return Root;
            }
        ~Huffmann()
        { 
        
        }

        public Node DecodeHuffmann()
        {
            statistic = statistic.OrderBy(character_apparition => character_apparition.Value).ToDictionary(character_apparition => character_apparition.Key, character_apparition => character_apparition.Value);
            CreateHuffmannTree();
            return Root;
        }

        }
}