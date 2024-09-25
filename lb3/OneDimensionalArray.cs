namespace lb3;

public class OneDimensionalArray<T> where T : new()
{
    private T[]? array;
    
    public OneDimensionalArray(T[] arrayTemp)
    {
        array = new T[arrayTemp.Length];
        arrayTemp.CopyTo(array,0);
    }

    public OneDimensionalArray()
    {
        array = null;
    }
    
    // public void PrintArray()
    // {
    //     foreach (var element in array)
    //     {
    //         Console.Write(element + " ");
    //     }
    //     Console.WriteLine();
    // }
    public override string? ToString()
    {
        string result = "";
        foreach (var element in array)
        {
            result = string.Concat(result, element?.ToString(), " ");
        }
        return result;
    }

    public int Length()
    {
        return array?.Length ?? 0;
    }

    public void Push(T value)
    {
        Array.Resize(ref array, array.Length + 1);
        array[^1] = value;
    }
    
    //Task1
    public void SumBetween()
    {
        int K, L; 
        int n = array.Length;
        Console.Write("Put K: "); K = int.Parse(Console.ReadLine());
        Console.Write("Put L: "); L = int.Parse(Console.ReadLine());
        dynamic sum = default(T);
        sum = 0;
        if (K < -1 || L < K || L > n)
        {
            Console.WriteLine("Invalid K or L values.");
            return;
        }
        for (int i = 0; i < n; i++)
        {
            if (i > K && i < L) 
            {
                sum += array[i];
            }
        }
        Console.WriteLine($"Сумма элементов массива, исключая элементы с номерами от {K} до {L}: {sum}");
    }
    
    //Task2
    public void CopyToEvenOdd(OneDimensionalArray<T> dataFromStartedCopyArray)
    {
        array = new T[dataFromStartedCopyArray.Length()]; 
        int index = 0;
        for (int i = 0; i < dataFromStartedCopyArray.Length(); i += 2)
        {
            array[index++] = dataFromStartedCopyArray[i];
        }
        for (int i = 1; i < dataFromStartedCopyArray.Length(); i += 2)
        {
            array[index++] = dataFromStartedCopyArray[i];
        }
    }
    
    //indexer
    protected T this[int i]
    {
        get
        {
            if (array == null || i < 0 || i >= array.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            return array[i];
        }
        set
        {
            if (array == null || i < 0 || i >= array.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            array[i] = value;
        }
    }
}