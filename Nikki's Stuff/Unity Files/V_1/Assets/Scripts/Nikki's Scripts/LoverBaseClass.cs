using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoverBaseClass : MonoBehaviour
{

public class Book{
        public string title;
        public string author;
        public static string staticAttribute = "My Static Attribute";

        public void ReadBook(){
        Console.WriteLine($"Reading {this.title} by {this.author}");
     }
}

    Book book1 = new Book();
    book1.title = "Harry Potter";
    book1.author = "JK Rowling";

    book1.ReadBook();
    Console.WriteLine(book1.title);
}
