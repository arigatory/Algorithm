// See https://aka.ms/new-console-template for more information


var tree = new Node(1);
tree.Left = new Node(3);
tree.Left.Left = new Node(8);
tree.Left.Left.Left = new Node(14);
tree.Left.Left.Right = new Node(15);
tree.Left.Right = new Node(10);
tree.Left.Right.Right = new Node(3);
tree.Right = new Node(5);
tree.Right.Left = new Node(2);
tree.Right.Right = new Node(6);
tree.Right.Right.Left = new Node(0);
tree.Right.Right.Right = new Node(1);

Console.WriteLine(Solution.Solve(tree));
