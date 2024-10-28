using Algorithms.Algorithms.Search;
using Algorithms.DataStructures;

namespace UnitTests.AlgorithmTests.SearchTests;

[TestClass]
public class BinaryTreeSearchTests
{
  [TestMethod]
  public void Exists_Exists_ReturnTrue()
  {
    var tree = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };

    foreach (var item in new int[] { 23, 5, 4, 3, 18, 21 })
      Assert.IsTrue(BinaryTreeSearch.Exists(tree, item));
  }

  [TestMethod]
  public void Exists_DoesNotExist_ReturnFalse()
  {
    var tree = new BinaryTreeNode<int>(7)
    {
      Left = new(23) { Left = new(5), Right = new(4) },
      Right = new(3) { Left = new(18), Right = new(21) }
    };

    var result = BinaryTreeSearch.Exists(tree, 10);

    Assert.IsFalse(result);
  }
}