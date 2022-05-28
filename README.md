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
**XML**
-----------------------
Below is the xml file we'll be using for examples. The xml file consists of book elements with the attribute id. Inside of the book elements are more elements (author, title, genre, price, public_date, and description).
```xml
<catalog>
	<book id="bk101">
		<author>Gambardella, Matthew</author>
		<title>XML Developer's Guide</title>
		<genre>Computer</genre>
		<price>44.95</price>
		<publish_date>2000-10-01</publish_date>
		<description>
			An in-depth look at creating applications
			with XML.
		</description>
	</book>
	<book id="bk102">
		<author>Ralls, Kim</author>
		<title>Midnight Rain</title>
		<genre>Fantasy</genre>
		<price>5.95</price>
		<publish_date>2000-12-16</publish_date>
		<description>
			A former architect battles corporate zombies,
			an evil sorceress, and her own childhood to become queen
			of the world.
		</description>
	</book>
	<book id="bk103">
		<author>Ralls, Kim</author>
		<title>Maeve Ascendant</title>
		<genre>Fantasy</genre>
		<price>5.95</price>
		<publish_date>2000-11-17</publish_date>
		<description>
			After the collapse of a nanotechnology
			society in England, the young survivors lay the
			foundation for a new society.
		</description>
	</book>
</catalog>
```

**Reading an XML File**
----------------------------
There are two ways to read an XML file. One using XElement and XDocument. For the most part, we'll be using XElement.
```cs
string myFilePath = @"C:\Users\kevin\source\repos\CSharpTesting\randomFile.xml"; //My file location
XElement xelement = XElement.Load(myFilePath); //XDocument doc = XDocument.Load(myFilePath);
IEnumerable<XElement> items = xelement.Elements(); //IEnumerable<XElement> items = doc.Elements("catalog").Elements();

//Print out each item
foreach (var item in items)
{
    Console.WriteLine(item);
}
```
