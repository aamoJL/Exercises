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
  public static bool Exists(int[] array, int item)
  {
    var low = 0;
    var high = array.Length - 1;
    var index = high / 2;

    while (low < high)
    {
      if (array[index] == item) break;
      else if (array[index] > item) high = index - 1;
      else if (array[index] < item) low = index + 1;

      index = low + (high - low) / 2;
    };

    return array.Length > index && array[index] == item;
  }

  /// <summary>
  /// Searches the array for the given item.
  /// </summary>
  /// <returns><see langword="true"/> if the item exits in the array, otherwise <see langword="false"/></returns>
  public static bool ExistsAlternative(int[] array, int item)
  {
    // same as Exists, but without equality check inside the loop

    var low = 0;
    var high = array.Length - 1;
    var index = high / 2;

    while (low < high)
    {
      if (array[index] < item) low = index + 1;
      else high = index;

      index = low + (high - low) / 2;
    };

    return array.Length > index && array[index] == item;
  }
}
