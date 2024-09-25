namespace lb3;

public class TwoDimensionalArray<T> where T : new()
{
    private T[,]? array;
    
    public TwoDimensionalArray(T[,] arrayTemp)
    {
        array = new T[arrayTemp.GetLength(0), arrayTemp.GetLength(1)];
        Array.Copy(arrayTemp, array, arrayTemp.Length);
    }

    public TwoDimensionalArray()
    {
        array = null;
    }
    
    public override string? ToString()
    {
        if (array == null) return "Array is null";

        string result = "";
        for (int i = 0; i < array.GetLength(0); i++) 
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                result += $"{array[i, j]} ";
            }
            result += "\n"; 
        }
        return result;
    }
    
    //Indexer
    protected T this[int row, int col]
    {
        get
        {
            if (array == null)
            {
                throw new InvalidOperationException("Array is not initialized.");
            }
            return array[row, col];
        }
        set
        {
            if (array == null)
            {
                throw new InvalidOperationException("Array is not initialized.");
            }
            array[row, col] = value;
        }
    }
    //Task3
    public double ArifmOdd()
    {
        dynamic sum = default(T);
        sum = 0;
        int oddRow = 0;
        for (int i = 1; i < array.GetLength(0); i += 2)
        {
            if (i % 2 != 0) oddRow++;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                sum += array[i, j];
            }
        }
        return double.Parse(sum/(array.GetLength(1) * oddRow));
    }
    
    //Task4
    public void Swap()
    {
        if (array.GetLength(0) % 2 != 0 || array.GetLength(1) % 2 != 0)
        {
            throw new ArgumentException("Size of array must be even.");
        }
        for (int i = 0; i < array.GetLength(0) / 2; i++)
        {
            for (int j = 0; j < array.GetLength(1)/2; j++)
            {
                var temp = array[i, j];
                array[i, j] = array[i + array.GetLength(0)/2, j + array.GetLength(1)/2];
                array[i + array.GetLength(0)/2, j + array.GetLength(1)/2] = temp;
            }
        }
    }
}