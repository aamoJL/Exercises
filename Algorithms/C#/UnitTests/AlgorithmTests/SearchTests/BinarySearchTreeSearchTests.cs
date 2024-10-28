using Algorithms.Algorithms.Search;
using Algorithms.DataStructures;

namespace UnitTests.AlgorithmTests.SearchTests;

[TestClass]
public class BinarySearchTreeSearchTests
{
  [TestMethod]
  public void Exists_Exists_ReturnTrue()
  {
    var tree = new BinaryTreeNode<int>(17)
    {
      Left = new(15) { Left = new(4), Right = new(16) },
      Right = new(50)
      {
        Left = new(25) { Left = new(18), Right = new(49) },
      }
    };

    foreach (var item in new int[] { 17, 15, 4, 16, 50, 25, 18, 49 })
      Assert.IsTrue(BinarySearchTreeSearch.Exists(tree, item));
  }

  [TestMethod]
  public void Exists_DoesNotExist_ReturnFalse()
  {
    var tree = new BinaryTreeNode<int>(17)
    {
      Left = new(15) { Left = new(4), Right = new(16) },
      Right = new(50)
      {
        Left = new(25) { Left = new(18), Right = new(49) },
      }
    };

    Assert.IsFalse(BinarySearchTreeSearch.Exists(tree, 48));
  }
}
