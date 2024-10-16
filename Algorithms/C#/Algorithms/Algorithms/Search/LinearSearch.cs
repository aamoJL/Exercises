namespace Algorithms.Algorithms.Search;

/// <summary>
/// Search algorithm for unsorted array.
/// </summary>
/// Performance: O(n)
public static class LinearSearch
{
  /// <summary>
  /// Searches the index of the item in the array.
  /// </summary>
  /// <returns>Index of the item in the array. Returns -1 if the item is not in the array.</returns>
  public static int IndexOf<T>(T[] array, T item)
  {
    for (var i = 0; i < array.Length; i++)
      if (array[i]?.Equals(item) == true) return i;

    return -1;
  }
}
