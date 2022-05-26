# IEnumerable & Xelement Notes
Some IEnumerable and Xelement notes in C#. This is more of a quick look at these concepts. I won't go too in detail or explain much.

IEnumerable interface is the base interface for many collections in C#. It is used to provide a way of iterating through a collection. Collections are classes we can use to store a collection of objects. They are not limited to one type of object and have no size constraints.

We use collections to store, manage, and manipulate groups of objects more efficiently (adding, deleting, replacing, searching, copying).

```cs
IEnumerable<T>; //For generic collections (System.Collections.Generic namespace)
IEnumerable; //For non-generic collections, can store any type of object (Systems.Collections namespace)
```

Non-generic types can include integers, floats, strings, and arrays.

```cs
var array = new int[] {1,2,3};

foreach(var element in array)
{
    Console.WriteLine("A is " + element);	
}

//Top is the same as this
var enumerator = array.GetEnumerator();
while(enumerator.MoveNext())
{
    Console.WriteLine("A is " + enumerator.Current);	
}
```
**GetEnumerator, MoveNext, Current**
-------------------------
```cs
var array = new int[] { 1, 2, 3 };

foreach (var element in array)
{
    Console.WriteLine("A is " + element);
}

//Top is the same as this
var enumerator = array.GetEnumerator();
while (enumerator.MoveNext())
{
    Console.WriteLine("A is " + enumerator.Current);
}
/*Output:
    A is 1
    A is 2
    A is 3
    A is 1
    A is 2
    A is 3
*/
```

**IEnumerable and Where**
-------------------------
System.Linq namespace is needed for Where.
```cs
List<int> numbers = new List<int> {1,2,3,4,5,6,7};
IEnumerable<int> filtered = numbers.Where(n => n % 2 == 0);
numbers.Add(8);
//filtered becomes an IEnumerable
foreach(int number in filtered)
{
    Console.Write(number + " ");
}
//Output is 2 4 6 8

//Same thing as above but we convert filtered2 to a list
numbers = new List<int> {1,2,3,4,5,6,7};
IEnumerable<int> filtered2 = numbers.Where(n => n % 2 == 0).ToList();
numbers.Add(8);

foreach(int number in filtered2)
{
    Console.Write(number + " ");
}
//Output is 2 4 6
```
