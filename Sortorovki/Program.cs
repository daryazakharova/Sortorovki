// See https://aka.ms/new-console-template for more information
using Sortorovki;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("I am sure that I will fill out the form by 11:00 am on July 4, 2022.");
string X = "X0";

string Y = "Y0";
string Z = "Z0";
Exchange(X, Y, Z);

void Exchange(string x, string y, string z)
{
    y = z; z = x; x = "Y0";
    Console.WriteLine($"x = {x}, y={y}, z={z}");
}

Console.Read();
var heapMax = new MaxHeap<int>();
heapMax.Insert(24);
heapMax.Insert(37);
heapMax.Insert(17);
heapMax.Insert(28);
heapMax.Insert(31);
heapMax.Insert(29);
heapMax.Insert(15);
heapMax.Insert(12);
heapMax.Insert(20);

heapMax.Sort();
//Console.WriteLine(heapMax.Peek());
//Console.WriteLine(heapMax.Remove());
//Console.WriteLine(heapMax.Peek());
//heapMax.Insert(40);
//Console.WriteLine(heapMax.Peek());

foreach (var item in heapMax.Values())
{
    Console.Write($"{item} ");
}

Console.Read();

var bstTest = new Bst<int>();
bstTest.Insert(37);
bstTest.Insert(24);
bstTest.Insert(17);
bstTest.Insert(28);
bstTest.Insert(31);
bstTest.Insert(29);
bstTest.Insert(15);
bstTest.Insert(12);
foreach (var item in bstTest.TraverseOrder())
{
    Console.Write($"{item} ");
}
Console.WriteLine();
Console.WriteLine(bstTest.Min());
Console.WriteLine(bstTest.Max());
Console.WriteLine(bstTest.Get(12).Value);
Console.Read();
//foreach (var prime in Prime.Sieve(30))
//{
//    Console.WriteLine(prime);
//}
//Console.Read();
var numberOfSets = int.Parse(Console.ReadLine());
for (int m = 0; m < numberOfSets; m++)
{
    string password = Console.ReadLine();

    if (Regex.IsMatch(password, @"[a-z]"))
    {
        if (Regex.IsMatch(password, "a") || Regex.IsMatch(password, "e") || Regex.IsMatch(password, "u") || Regex.IsMatch(password, "i") || Regex.IsMatch(password, "o") || Regex.IsMatch(password, "y"))
        {
            password = password + "K";
        }
    }
    else
    {
        Random random = new Random();
        var s = new StringBuilder();
        s.Append((char)random.Next('a', 'z'));
        password = $"{password}{s}";

    }
    if (Regex.IsMatch(password, @"[A-Z]"))
    {
        if (Regex.IsMatch(password, "A") || Regex.IsMatch(password, "E") || Regex.IsMatch(password, "U") || Regex.IsMatch(password, "I") || Regex.IsMatch(password, "O") || Regex.IsMatch(password, "Y"))
        {
            password = password + "k";
        }
    }
    else
    {
        Random random = new Random();
        var s = new StringBuilder();
        s.Append((char)random.Next('A', 'Z'));
        password = $"{password}{s}";
    }
    if (Regex.IsMatch(password, @"[0-9]"))
    { }
    else
    {
        Random random = new Random();
        password = $"{password}{random.Next(0, 100)}";
    }
    Console.WriteLine(password);
}
//}
//for (int m = 0; m < numberOfSets; m++)
//{
//    string password = Console.ReadLine();

//    if (Regex.IsMatch(password, @"[a-z]") && (Regex.IsMatch(password, "A") || Regex.IsMatch(password, "E") || Regex.IsMatch(password, "U") || Regex.IsMatch(password, "I") || Regex.IsMatch(password, "O") || Regex.IsMatch(password, "Y")))
//    { }
//    else
//    {
//        password = password + "K";
//    }
//    if (Regex.IsMatch(password, @"[A-Z]") && (Regex.IsMatch(password, "a") || Regex.IsMatch(password, "e") || Regex.IsMatch(password, "u") || Regex.IsMatch(password, "i") || Regex.IsMatch(password, "o") || Regex.IsMatch(password, "y")))
//    { }
//    else
//    {
//        password = password + "a";
//    }
//    if (Regex.IsMatch(password, @"[0-9]"))
//    { }
//    else
//    {
//        password = password + "1";
//    }
//    if (Regex.IsMatch(password, @"[a-z]"))
//    { 
//    }
//    else
//    {
//        password = password + "a";
//    }
//    if (Regex.IsMatch(password, @"[A-Z]"))
//    {
//    }
//    else
//    {
//        password = password + "k";
//    }



//    Console.WriteLine(password);
//}
/*if (Regex.IsMatch(password, @"[A-Z]") && Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"[0-9]"))
    Console.WriteLine(password);
if (Regex.IsMatch(password, @"[A-Z]") && Regex.IsMatch(password, @"[a-z]") && !Regex.IsMatch(password, @"[0-9]"))
{
    Random random = new Random();
    Console.WriteLine($"{password}{random.Next(0, 100)}");
}
if (Regex.IsMatch(password, @"[A-Z]") && !Regex.IsMatch(password, @"[a-z]") && !Regex.IsMatch(password, @"[0-9]"))
{
    Random random = new Random();
    var s = new StringBuilder();
    s.Append((char)random.Next('a', 'z'));
    string password2 = $"{password}{random.Next(0, 100)}{s}";
    Console.WriteLine($"{password2}");
}
if (Regex.IsMatch(password, @"[a-z]") && !Regex.IsMatch(password, @"[A-Z]") && !Regex.IsMatch(password, @"[0-9]"))
{
    Random random = new Random();
    var s = new StringBuilder();
    s.Append((char)random.Next('A', 'Z'));
    string password2 = $"{password}{random.Next(0, 100)}{s}";
    Console.WriteLine($"{password2}");
}
if (!Regex.IsMatch(password, @"[a-z]") && !Regex.IsMatch(password, @"[A-Z]") && Regex.IsMatch(password, @"[0-9]"))
{
    Random random = new Random();
    var s = new StringBuilder();
    var a = new StringBuilder();
    a.Append((char)random.Next('a', 'z'));
    s.Append((char)random.Next('A', 'Z'));
    string password2 = $"{password}{a}{s}";
    Console.WriteLine($"{password2}");
}
if (Regex.IsMatch(password, @"[a-z]") && !Regex.IsMatch(password, @"[A-Z]") && Regex.IsMatch(password, @"[0-9]"))
{
    if (Regex.IsMatch(password, "a"))
    {
        Random random = new Random();
        var s = new StringBuilder();
        s.Append((char)random.Next('B', 'Z'));
        string password2 = $"{password}{s}";
        Console.WriteLine($"{password2}");
    }
    if (Regex.IsMatch(password, "e"))
    {
        Random random = new Random();
        var s = new StringBuilder();
        s.Append((char)random.Next('F', 'Z'));
        string password2 = $"{password}{s}";
        Console.WriteLine($"{password2}");
    }
    if (Regex.IsMatch(password, "i"))
    {
        Random random = new Random();
        var s = new StringBuilder();
        s.Append((char)random.Next('J', 'Z'));
        string password2 = $"{password}{s}";
        Console.WriteLine($"{password2}");
    }
    if (Regex.IsMatch(password, "o"))
    {
        Random random = new Random();
        var s = new StringBuilder();
        s.Append((char)random.Next('J', 'Z'));
        string password2 = $"{password}{s}";
        Console.WriteLine($"{password2}");
    }
    else
    {
Random random = new Random();
    var s = new StringBuilder();
    s.Append((char)random.Next('A', 'Z'));
    string password2 = $"{password}{s}";
    Console.WriteLine($"{password2}");
    }

}
if (!Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"[A-Z]") && Regex.IsMatch(password, @"[0-9]"))
{
    Random random = new Random();
    var a = new StringBuilder();
    a.Append((char)random.Next('a', 'z'));
    string password2 = $"{password}{a}";
    Console.WriteLine($"{password2}");
}
}*/
//|| Regex.IsMatch(password, "e") || Regex.IsMatch(password, "i") || Regex.IsMatch(password, "o") || Regex.IsMatch(password, "y")
