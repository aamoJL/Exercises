namespace Algorithms.Algorithms.Sort;

/// <summary>
/// Sorting algorithm
/// </summary>
/// Performance: (n^2)
public static class BubbleSort
{
  public static void Sort<T>(T[] array)
  {
    for (var i = 0; i < array.Length - 1; i++)
      for (var index = 0; index < array.Length - 1 - i; index++)
        if (Comparer<T>.Default.Compare(array[index], array[index + 1]) > 0)
          Swap(ref array[index], ref array[index + 1]);
  }

  public static void SortOptimized<T>(T[] array)
  {
    for (var i = 0; i < array.Length - 1; i++)
    {
      var swapped = false;

      for (var index = 0; index < array.Length - 1 - i; index++)
      {
        if (Comparer<T>.Default.Compare(array[index], array[index + 1]) > 0)
        {
          Swap(ref array[index], ref array[index + 1]);
          swapped = true;
        }
      }

      // If no changes was made during the loop, return
      if (!swapped)
        return;
    }
  }

  private static void Swap<T>(ref T left, ref T right)
    => (right, left) = (left, right);
}
