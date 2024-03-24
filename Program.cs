internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();
        int[] array = new int[10];
        Console.WriteLine("Orginalna tablica: ");
        for (int i = 0; i < array.Length; i++)
        {

            array[i] = random.Next(1,100);
        }
        int[] array2 = array;
        int[] array3 = array2;
        foreach (int i in array)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n Posortowana tablica: ");
        int left = 0;
        int right = array.Length - 1;
        Quick_Sort(array, left, right);
        foreach (int i in array)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n Merge Sort: ");
        MergeSort(array2,left,right);
        foreach (int i in array2)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n Bubble Sort: ");
        BubbleSort(array3);
        foreach (int i in array3)
        {
            Console.Write(i + " ");
        }
    }
    private static void Quick_Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(array, left, right);

            if (pivot > 1)
            {
                Quick_Sort(array, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                Quick_Sort(array, pivot + 1, right);
            }
        }
    }
    public static int[] MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);
            MergeArray(array, left, middle, right);
        }
        return array;
    }

    private static int Partition(int[] array, int left, int right)
    {
        int pivot = array[left];

        while (true)
        {
            while (array[left] < pivot)
            {
                left++;
            }

            while (array[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                if (array[left] == array[right]) return right;

                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
            }
            else
            {
                return right;
            }
        }

    }
    public static void MergeArray(int[] array, int left, int middle, int right)
    {
        var leftArrayLength = middle - left + 1;
        var rightArrayLength = right - middle;
        var leftTempArray = new int[leftArrayLength];
        var rightTempArray = new int[rightArrayLength];
        int i, j;
        for (i = 0; i < leftArrayLength; ++i)
            leftTempArray[i] = array[left + i];
        for (j = 0; j < rightArrayLength; ++j)
            rightTempArray[j] = array[middle + 1 + j];
        i = 0;
        j = 0;
        int k = left;
        while (i < leftArrayLength && j < rightArrayLength)
        {
            if (leftTempArray[i] <= rightTempArray[j])
            {
                array[k++] = leftTempArray[i++];
            }
            else
            {
                array[k++] = rightTempArray[j++];
            }
        }
        while (i < leftArrayLength)
        {
            array[k++] = leftTempArray[i++];
        }
        while (j < rightArrayLength)
        {
            array[k++] = rightTempArray[j++];
        }
    }
    public static int[] BubbleSort(int[] array)
    {
        var n = array.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (array[j] > array[j + 1])
                {
                    var tempVar = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = tempVar;
                }
        return array;
    }
}