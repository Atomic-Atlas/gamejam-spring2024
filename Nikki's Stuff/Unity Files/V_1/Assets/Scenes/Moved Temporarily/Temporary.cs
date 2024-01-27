public class LoverBaseClass
{

    // Data Values to get and set
    public string FirstName { get; set };
    public string LastName { get; set };
    public int Age { get; set };
    public string Occupation { get; set };


    //  Constructer that will set these data values
    public LoverBaseClass (string firstName, string lastName, int age, string occupation) {

        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Occupation = occupation;

        Console.Write($"Reading {this.firstName}");

    }

    public static void(main[] args) {
        // Create a new instance of a lover
        LoverBaseClass lover = new LoverBaseClass("Jeremy", "Balls", "34", "Construction Worker");


        //Console.Write("Hi, my name is " + firstName + ", " + firstName + " " + firstName + " " + lastName ".");


    }

    

}