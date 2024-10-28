using Algorithms.DataStructures;

namespace UnitTests.DataStructureTests;

[TestClass]
public class BinaryTreeTests
{
  [TestMethod]
  public void ToArray_PreOrder_PreOrdered()
  {
    var tree = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };

    var result = tree.ToArray(BinaryTree.TraversalStrategy.PreOrder);
    var expected = new int[] { 7, 23, 5, 4, 3, 18, 21 };

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void ToArray_InOrder_InOrdered()
  {
    var tree = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };

    var result = tree.ToArray(BinaryTree.TraversalStrategy.InOrder);
    var expected = new int[] { 5, 23, 4, 7, 18, 3, 21 };

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void ToArray_PostOrder_PostOrdered()
  {
    var tree = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };

    var result = tree.ToArray(BinaryTree.TraversalStrategy.PostOrder);
    var expected = new int[] { 5, 4, 23, 18, 21, 3, 7 };

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void ToArray_BreathFirst_BreathFirstOrdered()
  {
    var tree = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };

    var result = tree.ToArray(BinaryTree.TraversalStrategy.BreadthFirst);
    var expected = new int[] { 7, 23, 3, 5, 4, 18, 21 };

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void Compare_Same_ReturnTrue()
  {
    var treeA = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };
    var treeB = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };

    Assert.IsTrue(BinaryTree.Compare(treeA, treeB));
  }

  [TestMethod]
  public void Compare_Same_Nullable_ReturnTrue()
  {
    var treeA = new BinaryTreeNode<int?>(7)
    {
      Left = new(23) { Left = new(null), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };
    var treeB = new BinaryTreeNode<int?>(7)
    {
      Left = new(23) { Left = new(null), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };

    Assert.IsTrue(BinaryTree.Compare(treeA, treeB));
  }

  [TestMethod]
  public void Compare_Different_ReturnFalse()
  {
    var treeA = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };
    var treeB = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(4) { Left = new(18), Right = new(21) }
    };

    Assert.IsFalse(BinaryTree.Compare(treeA, treeB));
  }

  [TestMethod]
  public void Compare_Different_Nullable_ReturnFalse()
  {
    var treeA = new BinaryTreeNode<int?>(7)
    {
      Left = new(23) { Left = new(null), Right = new(4) },
      Right = new(null) { Left = new(18), Right = new(21) }
    };
    var treeB = new BinaryTreeNode<int?>(7)
    {
      Left = new(23) { Left = new(null), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };

    Assert.IsFalse(BinaryTree.Compare(treeA, treeB));
  }
}