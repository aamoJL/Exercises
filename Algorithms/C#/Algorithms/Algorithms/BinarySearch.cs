namespace Algorithms.Algorithms;

/// <summary>
/// Search algorithm for sorted array
/// </summary>
/// Big O: O(log(n))
public static class BinarySearch
{
  /// <summary>
  /// Searches the array for the given item.
  /// </summary>
  /// <returns><see langword="true"/> if the item exits in the array, otherwise <see langword="false"/></returns>
  public static bool Exists<T>(T[] array, T item)
  {
    var low = 0;
    var high = array.Length - 1;
    var index = high / 2;

    while (low < high)
    {
      if (array[index]?.Equals(item) == true) break;
      else if (Comparer<T>.Default.Compare(array[index], item) > 0) high = index - 1;
      else if (Comparer<T>.Default.Compare(array[index], item) < 0) low = index + 1;

      index = low + (high - low) / 2;
    };

    return array.Length > index && array[index]?.Equals(item) == true;
  }

  /// <summary>
  /// Searches the array for the given item.
  /// </summary>
  /// <returns><see langword="true"/> if the item exits in the array, otherwise <see langword="false"/></returns>
  public static bool ExistsAlternative<T>(T[] array, T item)
  {
    // same as Exists, but without equality check inside the loop

    var low = 0;
    var high = array.Length - 1;
    var index = high / 2;

    while (low < high)
    {
      if (Comparer<T>.Default.Compare(array[index], item) < 0) low = index + 1;
      else high = index;

      index = low + (high - low) / 2;
    };

    return array.Length > index && array[index]?.Equals(item) == true;
  }
}
