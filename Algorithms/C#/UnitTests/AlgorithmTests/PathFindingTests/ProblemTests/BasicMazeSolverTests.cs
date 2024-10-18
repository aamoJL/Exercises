using Algorithms.Algorithms.PathFinding.Problems;

namespace UnitTests.AlgorithmTests.PathFindingTests.ProblemTests;

[TestClass]
public class BasicMazeSolverTests
{
  [TestMethod]
  public void Solve_Solvable_ReturnPath()
  {
    char[][] maze = [
      ['#', ' ', '#', '#', '#', 'E', '#'],
      [' ', ' ', ' ', ' ', ' ', ' ', '#'],
      ['#', 'S', '#', '#', ' ', '#', ' '],
    ];
    (int row, int index)[] expectedPath = [
      (2,1),
      (1,1),
      (1,2),
      (1,3),
      (1,4),
      (1,5),
      (0,5),
      ];

    var actualPath = BasicMazeSolver.Solve(maze);

    CollectionAssert.AreEqual(expectedPath, actualPath);
  }

  [TestMethod]
  public void Solve_Solvable_Alternative_ReturnPath()
  {
    char[][] maze = [
      ['#', ' ', '#', '#', '#', '#', '#'],
      [' ', ' ', ' ', ' ', ' ', ' ', ' '],
      ['S', ' ', '#', '#', ' ', '#', 'E'],
    ];
    (int row, int index)[] expectedPath = [
      (2,0),
      (1,0),
      (1,1),
      (1,2),
      (1,3),
      (1,4),
      (1,5),
      (1,6),
      (2,6),
      ];

    var actualPath = BasicMazeSolver.Solve(maze);

    CollectionAssert.AreEqual(expectedPath, actualPath);
  }

  [TestMethod]
  public void Solve_Solvable_WithLoop_ReturnPath()
  {
    char[][] maze = [
      ['#', ' ', '#', '#', '#', 'E', '#'],
      ['#', ' ', ' ', ' ', ' ', ' ', '#'],
      ['#', ' ', '#', '#', ' ', '#', '#'],
      ['#', ' ', ' ', ' ', ' ', '#', '#'],
      ['#', 'S', '#', '#', ' ', '#', '#'],
    ];
    (int row, int index)[] expectedPath = [
      (4,1),
      (3,1),
      (2,1),
      (1,1),
      (1,2),
      (1,3),
      (1,4),
      (1,5),
      (0,5),
      ];

    var actualPath = BasicMazeSolver.Solve(maze);

    CollectionAssert.AreEqual(expectedPath, actualPath);
  }

  [TestMethod]
  public void Solve_Unsolvable_ReturnEmpty()
  {
    char[][] maze = [
      ['#', ' ', '#', '#', '#', 'E', '#'],
      [' ', ' ', '#', ' ', ' ', ' ', '#'],
      ['#', 'S', '#', '#', ' ', '#', ' '],
    ];

    var actualPath = BasicMazeSolver.Solve(maze);

    CollectionAssert.AreEqual(Array.Empty<(int, int)>(), actualPath);
  }

  [TestMethod]
  public void Solve_WithoutStart_ReturnEmpty()
  {
    char[][] maze = [
      ['#', ' ', '#', '#', '#', 'E', '#'],
      [' ', ' ', ' ', ' ', ' ', ' ', '#'],
      ['#', '#', '#', '#', ' ', '#', ' '],
    ];

    var actualPath = BasicMazeSolver.Solve(maze);

    CollectionAssert.AreEqual(Array.Empty<(int, int)>(), actualPath);
  }

  [TestMethod]
  public void Solve_WithoutEnd_ReturnEmpty()
  {
    char[][] maze = [
      ['#', ' ', '#', '#', '#', '#', '#'],
      [' ', ' ', ' ', ' ', ' ', ' ', '#'],
      ['#', 'S', '#', '#', ' ', '#', ' '],
    ];

    var actualPath = BasicMazeSolver.Solve(maze);

    CollectionAssert.AreEqual(Array.Empty<(int, int)>(), actualPath);
  }
}
