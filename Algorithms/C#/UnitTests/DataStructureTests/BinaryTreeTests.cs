using Algorithms.DataStructures;
using static Algorithms.DataStructures.BinaryTree;

namespace UnitTests.DataStructureTests;

[TestClass]
public class BinaryTreeTests
{
  [TestMethod]
  public void ToArray_PreOrder_PreOrdered()
  {
    var tree = new BinaryTree<int>(new BinaryTree<int>.Node(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    });

    var result = tree.ToArray(TraversalStrategy.PreOrder);
    var expected = new int[] { 7, 23, 5, 4, 3, 18, 21 };

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void ToArray_InOrder_InOrdered()
  {
    var tree = new BinaryTree<int>(new BinaryTree<int>.Node(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    });

    var result = tree.ToArray(TraversalStrategy.InOrder);
    var expected = new int[] { 5, 23, 4, 7, 18, 3, 21 };

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void ToArray_PostOrder_PostOrdered()
  {
    var tree = new BinaryTree<int>(new BinaryTree<int>.Node(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    });

    var result = tree.ToArray(TraversalStrategy.PostOrder);
    var expected = new int[] { 5, 4, 23, 18, 21, 3, 7 };

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void ToArray_BreathFirst_BreathFirstOrdered()
  {
    var tree = new BinaryTree<int>(new BinaryTree<int>.Node(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    });

    var result = tree.ToArray(TraversalStrategy.BreadthFirst);
    var expected = new int[] { 7, 23, 3, 5, 4, 18, 21 };

    CollectionAssert.AreEqual(expected, result);
  }
}