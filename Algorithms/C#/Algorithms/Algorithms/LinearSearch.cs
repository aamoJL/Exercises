namespace Algorithms;

/// <summary>
/// Search algorithm for unsorted array.
/// </summary>
/// Big O: O(n)
public static class LinearSearch
{
  /// <summary>
  /// Searches the index of the item in the array.
  /// </summary>
  /// <returns>Index of the item in the array. Returns -1 if the item is not in the array.</returns>
  public static int IndexOf(int[] array, int item)
  {
    for (var i = 0; i < array.Length; i++)
      if (array[i] == item) return i;

    return -1;
  }
}
