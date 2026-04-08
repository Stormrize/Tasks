namespace Exercises;

public class Exercixe2
{
        public static int MostCommonNumber(int length, int min, int max)
    {
        int[] array = RandomArray(length, min, max);
        int result = -1;
        int counter = 0;
        int[] arr2 = new int[9];
        for (int i = 0; i < array.Length; i++)
        {
            arr2[array[i] - 1]++;
        }
        for (int i = 0; i < arr2.Length; i++)
        {
            if (arr2[i] > counter)
            {
                counter = arr2[i];
                result = i + 1;
            }
        }
        return result;
    }

    public static int[] UniqueNumbers(int length, int min, int max)
    {
        int[] array = RandomArray(length, min, max);
        HashSet<int> uniqueSet = new HashSet<int>();
        Random rnd = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            uniqueSet.Add(array[i]);
        }
        return uniqueSet.ToArray();
    }

    public static int[] Peaks(int length)
    {
        List<int> list = new List<int>();
        int[] array = RandomArray(length, 100, 900);
        int i = 1;
        if (length < 2)
        {
             Console.WriteLine("Length should be at least 2");
             return array;
        }
        if (array[0] > array[1])
        {
            list.Add(array[0]);
            i++;
        }
        for (i = 1; i < array.Length - 1; i++)
        {
            if(array[i] > array[i - 1] && array[i] > array[i + 1])
            {
                list.Add(array[i]);
                i++;
            }
        }
        int last = array.Length - 1;
        if (array[last] > array[last-1])
        {
            list.Add(array[last]);
        }
        return list.ToArray();
    }
    public static List<Dictionary<char, int>> CountSymbolsInPhrases (string text)
    {
        List<Dictionary<char, int>> list = new List<Dictionary<char, int>>();
        list.Add(new Dictionary<char, int>());
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            bool isEnd = c == '.' || c == '?' || c == '!' || c == ':';
            if (isEnd && i != text.Length -1)
            {
                list.Add(new Dictionary<char, int>());
            }    
            if (!isEnd)
            {
                if (!list[list.Count - 1].ContainsKey(c))
                {
                    list[list.Count - 1].Add(c, 1);
                }
                else list[list.Count - 1][c]++;
            }
        }
        return list;
    }
    public static int CountWords(string text)
    {
        int counter = 0;
        if (!string.IsNullOrWhiteSpace(text))
        {
            counter = 1;
        }
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ') {
                counter++;
            }
        }
        return counter;
    }

    public static int[] BiggestSubArr(int length)
    {
        int[] array = RandomArray(length, 100, 999);

        if (length < 3)
            return new int[0];

        int maxSum = array[0] + array[1] + array[2];
        int startIndex = 0;

        for (int i = 1; i < array.Length - 2; i++)
        {
            int subSum = array[i] + array[i + 1] + array[i + 2];
            if (subSum > maxSum)
            {
                maxSum = subSum;
                startIndex = i;
            }
        }

        return new int[] { startIndex, startIndex + 1, startIndex + 2 };
    }
    public static int[] RandomArray(int length, int min, int max)
    {
        if (length < 1)
        {
            Console.WriteLine("Length cant be negative");
            return new int[0];
        }
        int[] arr1 = new int[length];
        Random rnd = new Random();
        for (int i = 0; i < arr1.Length; i++)
        {
            arr1[i] = rnd.Next(min, max);
        }
        return arr1;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("The most common number is = " + MostCommonNumber(10, 1, 10));
        Console.WriteLine("This array has those unique numbers: ");
        int[] unique = UniqueNumbers(10, 1, 10);
        for (int i = 0; i < unique.Length; i++)
        {
            Console.Write(unique[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("This array has those peaks: ");
        int[] peaks = Peaks(10);
        for (int i = 0; i < peaks.Length; i++)
        {
            Console.Write(peaks[i] + " ");
        }
        Console.WriteLine();
        string text = "Hello world! This is a test. How are you? I hope you are doing well.";
        Console.WriteLine("This text has " + CountWords(text) + " words");
        Console.WriteLine();
        List<Dictionary<char, int>> symbolCounts = CountSymbolsInPhrases(text);
        for (int i = 0; i < symbolCounts.Count; i++)
        {
            Console.WriteLine($"Phrase {i + 1}:");
            foreach (var kvp in symbolCounts[i])
            {
                Console.WriteLine($"Symbol: '{kvp.Key}', Count: {kvp.Value}");
            }
        }
        Console.WriteLine();
        int[] biggestSubArr = BiggestSubArr(10);
        Console.WriteLine($"Biggest subarray of 3 elements starts at index: {biggestSubArr[0]}, {biggestSubArr[1]}, {biggestSubArr[2]}");
    }
}
