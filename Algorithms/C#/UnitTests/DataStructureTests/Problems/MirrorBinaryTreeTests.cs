using Algorithms.DataStructures;
using Algorithms.DataStructures.Problems;

namespace UnitTests.DataStructureTests.Problems;

[TestClass]
public class MirrorBinaryTreeTests
{
  [TestMethod]
  public void Invert()
  {
    var tree = new BinaryTreeNode<int>(0)
    {
      Left = new(1) { Left = new(3), Right = new(4) },
      Right = new(2) { Left = new(5) },
    };

    MirrorBinaryTree.Mirror(tree);

    var expected = new BinaryTreeNode<int>(0)
    {
      Left = new(2) { Right = new(5) },
      Right = new(1) { Left = new(4), Right = new(3) }
    };

    Assert.IsTrue(BinaryTree.Compare(tree, expected));
    Assert.AreSequenceEqual(
      tree.ToArray(BinaryTree.TraversalStrategy.BreadthFirst),
      expected.ToArray(BinaryTree.TraversalStrategy.BreadthFirst)
    );
  }
}
