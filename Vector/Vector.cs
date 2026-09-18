using System.Numerics;
using System.Runtime.InteropServices.Swift;

namespace Vector;

public struct Vector
{
    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }
    public double X { get; set; }
    public double Y { get; set; }
    
    public double Magnitude => Math.Sqrt(X*X+Y*Y);
    public double Direction => Math.Atan2(Y, X) * 180/Math.PI;

    public Vector Add(Vector v)
    {
        Vector result = new Vector();
        result.X = X+v.X;
        result.Y = Y+v.Y;
        return result;
    }
    public static Vector Add(Vector v1, Vector v2)
    {
        return v1.Add(v2);
    }
    public static Vector operator+(Vector v1, Vector v2)
    {
        return Vector.Add(v1,v2);
    }

    public Vector Subtract(Vector v)
    {
        Vector result = new Vector();
        result.X = X-v.X;
        result.Y = Y-v.Y;
        return result;
    }
    public static Vector Subtract(Vector v1, Vector v2)
    {
        return v1.Subtract(v2);
    }
    public static Vector operator-(Vector v1, Vector v2)
    {
        return Vector.Subtract(v1,v2);
    }

    public double AngleBetween(Vector v)
    {
        if (Direction < v.Direction)
        {
            return 0;
        }
        else
        {
            return Direction-v.Direction;
        }
    }
        public static double AngleBetween(Vector v1, Vector v2)
    {
        if (v1.Direction > v2.Direction)
        {
            return 0;
        }
        else
        {
            return v1.Direction-v2.Direction;
        }
    }

    public static Vector Multiply(Vector v, double scalar)
    {
        return v.Multiply(scalar);
    }
    public Vector Multiply(double scalar)
    {
        X = X*scalar;
        Y = Y*scalar;
        return new Vector(X,Y);
    }
    public static Vector operator*(Vector v, double scalar)
    {
        return Multiply(v, scalar);
    }

    public static Vector Divide(Vector v, double scalar)
    {
        return v.Divide(scalar);
    }
    public Vector Divide(double scalar)
    {
        X = X/scalar;
        Y = Y/scalar;
        return new Vector(X,Y);
    }

    public double Dot(Vector v)
    {
        double cosineinput;
        if (Direction < v.Direction)
        {
            cosineinput = 0;
        }
        else
        {
            cosineinput = Direction-v.Direction;
        }
        return Magnitude * v.Magnitude * Math.Cos(cosineinput);
    }
    public static double Dot(Vector v1, Vector v2)
    {
        double cosineinput;
        if (v1.Direction < v2.Direction)
        {
            cosineinput = 0;
        }
        else
        {
            cosineinput = v1.Direction-v2.Direction;
        }
        return v1.Magnitude * v2.Magnitude * Math.Cos(cosineinput);
    }
    public static double operator*(Vector v1, Vector v2)
    {
        return v1.Dot(v2);
    }

    public override string ToString()
    {
        return $"<{X}, {Y}>";
    }

    public Vector Normalize()
    {
        return Divide(Magnitude);
    }
    public static Vector Normalize(Vector v1)
    {
        return Divide(v1, v1.Magnitude);
    }
}