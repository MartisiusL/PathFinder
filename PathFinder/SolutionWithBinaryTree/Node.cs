namespace PathFinder.SolutionWithBinaryTree
    {
    public class Node
        {
        public int Value { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }

        public Node (int value = 1)
            {
            Value = value;
            LeftNode = null;
            RightNode = null;
            }
        }
    }
