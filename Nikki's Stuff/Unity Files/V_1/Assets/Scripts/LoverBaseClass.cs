/* Tried running this and the latest error I'm getting
 * is "CS0246: The type or namespace name 'UnityEngine'
   could not be found"
 */

using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

public class LoverBaseClass {

    public string firstName;
    public string lastName;
    public int age;
    public string occupation;

    public LoverBaseClass(string firstName, string lastName, int age, string occupation)
    {

        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.occupation = occupation;

    }

    public void LoverInfo(){
        Console.WriteLine("My name is " + this.firstName + " " + this.lastName + ".");
    }

}

class Lover {

    static void Main() {

        // Not sure where to put this declaration of the object
        LoverBaseClass lover = new LoverBaseClass("Jeremy", "Balls", 35, "Construction Worker");

    }

}