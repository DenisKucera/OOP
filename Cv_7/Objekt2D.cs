using System;
using System.Linq; 

public interface I2D
{
    double Plocha();
}

public abstract class Objekt2D : I2D, IComparable
{
    public abstract double Plocha();

    public int CompareTo(object? obj)
    {   
        if (obj is Objekt2D other)
        {
            return this.Plocha().CompareTo(other.Plocha());
        }
        throw new ArgumentException("Porovnavany objekt neni typu Objekt2D");
    }
}