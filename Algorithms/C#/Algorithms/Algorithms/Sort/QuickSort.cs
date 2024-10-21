namespace Algorithms.Algorithms.Sort;

public static class QuickSort
{
  public static void Sort<T>(T[] array)
    => Sort(array, 0, array.Length - 1);

  private static void Sort<T>(T[] array, int low, int high)
  {
    if (low >= high)
      return;

    var partitionIndex = Partition(array, low, high);

    // Recursion
    Sort(array, low, partitionIndex - 1); // Lower than pivot
    Sort(array, partitionIndex + 1, high); // Higher than pivot
  }

  /// <summary>
  /// Returns the index between the divisions.
  /// </summary>
  private static int Partition<T>(T[] array, int low, int high)
  {
    // Pivot can be any item in the array,
    // here we use the middle element as the pivot.

    // Swap the pivot with the last element of the array
    Swap(ref array[high], ref array[low + (high - low) / 2]);

    var lastSwapIndex = low;

    for (var i = low; i < high; i++)
    {
      if (Comparer<T>.Default.Compare(array[i], array[high]) < 0)
      {
        Swap(ref array[lastSwapIndex], ref array[i]);
        lastSwapIndex++;
      }
    }

    // Swap pivot with the last swap index
    Swap(ref array[lastSwapIndex], ref array[high]);

    return lastSwapIndex;
  }

  private static void Swap<T>(ref T left, ref T right)
    => (left, right) = (right, left);
}
