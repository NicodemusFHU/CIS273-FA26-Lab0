namespace Vector;

public class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector() {X=3, Y=5};
        Vector v3 = new Vector(3, 5);

        Vector v2 = v1;

        //instance method
        Vector result = v1.Add(v2);

        // class method (static keyword)
        Vector result2 = Vector.Add(v1, v2);

        // operator overloading 
        Vector result3 = v1 + v2;
    }
}

