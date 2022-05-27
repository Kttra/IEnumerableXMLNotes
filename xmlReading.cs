/*  C# program used to read xml files
*/
//using System;
//using System.Collections.Generic;
//using System.Text.RegularExpressions;
//using System.Xml;
using System.Xml.Linq;

public class Program
{
    public static string myFilePath = @"C:\Users\kevin\source\repos\CSharpTesting\randomFile.xml";
    public static void Main(string[] args)
    {
        Console.WriteLine("1. Read XML with XElement");
        ReadXMLWithXElement();
        Console.WriteLine(); Console.WriteLine("2. Read XML with XDocument");
        ReadXMLWithXDocument();
        Console.WriteLine(); Console.WriteLine("3. Access One Element (We look at the authors)");
        AccessOneElement();
        Console.WriteLine(); Console.WriteLine("4. Acess Multiple Elements (Authors and titles)");
        AccessElements();
        Console.WriteLine(); Console.WriteLine("5. Query XML File Based on Specific Criteria (Books written by Ralls, Kim)");
        GetSpecificElements();
        Console.WriteLine(); Console.WriteLine("6. Access XML Elements With Specific Attributes (we look for specific attribute book id)");
        GetSpecificAttributes();
        Console.WriteLine(); Console.WriteLine("7. Using Descendants to find computer books");
        UsingDescendants();
    }
    //1. Reading XML with XElement
    public static void ReadXMLWithXElement()
    {
        XElement xelement = XElement.Load(myFilePath);
        IEnumerable<XElement> items = xelement.Elements();

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    //2. Reading XML with XDocument
    public static void ReadXMLWithXDocument()
    {
        //Here we read a xml file
        XDocument doc = XDocument.Load(myFilePath);
        IEnumerable<XElement> items = doc.Elements("catalog").Elements();

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    //3. Access Single Element in an XML File
    public static void AccessOneElement()
    {
        //Here we read a xml file
        XElement xelement = XElement.Load(myFilePath);
        IEnumerable<XElement> items = xelement.Elements();

        foreach (var item in items)
        {
            //bool elementExists = item.Element("uikiu")?.Value != null;
            string? ourElement = item.Element("author")?.Value;
            Console.WriteLine(ourElement);
        }
        /*  Gambardella, Matthew
            Ralls, Kim
            Ralls, Kim
        */
    }
    //4. Access multiple elements in an XML File
    public static void AccessElements()
    {
        //Here we want to get the authors and their book titles
        XElement xelement = XElement.Load(myFilePath);
        IEnumerable<XElement> items = xelement.Elements();

        foreach (var item in items)
        {
            string? author = item.Element("author")?.Value;
            string? title = item.Element("title")?.Value;
            Console.WriteLine($"Author: {author} Title: {title}");
        }
        /*  Author: Gambardella, Matthew Title: XML Developer's Guide
            Author: Ralls, Kim Title: Midnight Rain
            Author: Ralls, Kim Title: Maeve Ascendant
        */
    }
    //5. Query XML File Based on Specific Criteria
    public static void GetSpecificElements()
    {
        //Here we look for the book titles from the author "Ralls, Kim"
        XElement xelement = XElement.Load(myFilePath);
        IEnumerable<XElement> items = xelement.Elements();

        var titles = from item in items where item.Element("author")?.Value == "Ralls, Kim" select item;
        //If you don't have the author's exact name, you can do something like this:
        //var titles = from item in items where item.Element("author").Value.Contains("Ralls") select item;

        //Check if IEnumerable<XElement> is null/empty
        if (titles?.Any() != true)
        {
            Console.WriteLine("Is null");
            return;
        }
        foreach (var item in titles)
        {
            Console.WriteLine(item.Element("title")?.Value);
        }
        /*  Midnight Rain
            Maeve Ascendant
        */
    }
    //6. Access XML Elements With Specific Attributes (we look for specific id)
    public static void GetSpecificAttributes()
    {
        XElement xelement = XElement.Load(myFilePath);
        IEnumerable<XElement> items = xelement.Elements();

        var books = from item in items where item.Attribute("id")?.Value == "bk102" select item;
        foreach (var book in books)
        {
            Console.WriteLine(book.Element("title")?.Value);
        }
        //Midnight Rain
    }
    //Descendants 
    public static void UsingDescendants()
    {
        XElement xelement = XElement.Load(myFilePath);

        Console.WriteLine("All Computer Books:");

        var ComputerBooks = from item in xelement.Descendants("book") where item.Element("genre")?.Value == "Computer"
                            select item;
        foreach(var book in ComputerBooks)
        {
            Console.WriteLine(book.Element("title")?.Value);
        }
        //XML Developer's Guide
    }
}

/* Output
1. Read XML with XElement
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

2. Read XML with XDocument
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

3. Access One Element (We look at the authors)
Gambardella, Matthew
Ralls, Kim
Ralls, Kim

4. Acess Multiple Elements (Authors and titles)
Author: Gambardella, Matthew Title: XML Developer's Guide
Author: Ralls, Kim Title: Midnight Rain
Author: Ralls, Kim Title: Maeve Ascendant

5. Query XML File Based on Specific Criteria (Books written by Ralls, Kim)
Midnight Rain
Maeve Ascendant

6. Access XML Elements With Specific Attributes (we look for specific attribute book id)
Midnight Rain

7. Using Descendants to find computer books
All Computer Books:
XML Developer's Guide
*/