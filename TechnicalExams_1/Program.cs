// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

// difference between prefix and postfix operator
// ++u = prefix = Increment happens on the variable first.
// u++ = postfix = Increment happens after variable’s value is used.
int t, u = 1, v;
for (t = 0; t < 5; t++)
{
    v = u++ + ++u;
    Console.Write(v + " ");
}
Console.WriteLine();

// Arithmetic Exception
try
{
    Console.WriteLine("CSharp" + " " + 1 / Convert.ToInt32(0));
}
catch (ArithmeticException e)
{
    Console.WriteLine("Java");
}

// The == Operator compares the reference identity while the Equals() method compares only contents.
StringBuilder az = new StringBuilder("Ram");
StringBuilder ar = new StringBuilder("Ram");
Console.WriteLine(az == ar);
Console.WriteLine(az.Equals(ar));

Console.WriteLine(15 / 2 + " " + 13 % 2);
Console.WriteLine("-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+-----");

// Count equal elements indexes in the given array
int T, N;
string a = "";
List<int> outputs = new List<int>();

try
{
    Console.Write("Number of Test Cases: ");
    T = Convert.ToInt32(Console.ReadLine());

    for (int k = 0; k < T; k++)
    {
        try
        {
            Console.Write("Number of Objects: ");
            N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter object value with space seperated: ");
            a = Console.ReadLine();

            if (a.Contains('\t') || a.Contains(','))
            {
                Console.WriteLine("Please enter object value with space seperated.");
            }
            else if (a.Any(char.IsLetter))
            {
                Console.WriteLine("Please do not enter string or special character.");
            }
            else
            {
                try
                {
                    List<int> Ai = new List<int>();
                    foreach (string x in a.Split(' '))
                    {
                        Ai.Add(Convert.ToInt32(x));
                    }

                    if (N != Ai.Count())
                    {
                        Console.WriteLine("List count is not similar as mentioned.");
                    }

                    outputs.Add(countPairs(Ai.ToArray(), Ai.Count()));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message.ToString());
        }
    }

    Console.WriteLine();
    Console.WriteLine("Output");
    foreach (int x in outputs)
    {
        Console.WriteLine(x);
    }
}
catch (FormatException e)
{
    Console.WriteLine(e.Message.ToString());
}

// Return the number of pairs with
// equal values.
static int countPairs(int[] arr, int n)
{
    // A method to return number of pairs
    // with equal values
    Dictionary<int, int> hm = new Dictionary<int, int>();

    // Finding frequency of each number.
    for (int i = 0; i < n; i++)
    {
        if (hm.ContainsKey(arr[i]))
        {
            int a = hm[arr[i]];
            hm.Remove(arr[i]);
            hm.Add(arr[i], a + 1);
        }
        else
            hm.Add(arr[i], 1);
    }
    int ans = 0;

    // Calculating count of pairs with
    // equal values
    foreach (var it in hm)
    {
        int count = it.Value;
        ans += (count * (count - 1));
    }
    return ans;
}