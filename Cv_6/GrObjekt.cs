using System;

//Parent class
public abstract class GrObjekt 
{
    public abstract void Kresli(); 
}

//Child classes Objects
public abstract class Objekt2D : GrObjekt 
{
    public abstract double SpoctiPlochu(); 
}

public abstract class Objekt3D : GrObjekt 
{
    public abstract double SpoctiPovrch(); 
    public abstract double SpoctiObjem(); 
}

// 2D Objekty : Objekt2D
public class Kruh : Objekt2D 
{
    private double r;
    public Kruh(double r)
    {
        this.r = r; 
    }

    public override void Kresli()
    {
        Console.WriteLine($"Kruh (r={r:F2})");
    } 
    public override double SpoctiPlochu()
    {
        return Math.PI * r * r;
    } 
}

public class Obdelnik : Objekt2D
{
    private double a, b;
    public Obdelnik(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Obdelnik (a={a:F2}; b={b:F2})");
    }
    public override double SpoctiPlochu()
    {
        return a * b;
    }
}

public class Trojuhelnik : Objekt2D
{
    private double a, v;
    public Trojuhelnik(double a, double v)
    {
        this.a = a;
        this.v = v;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Trojuhelnik (a={a:F2}; v={v:F2})");
    }
    public override double SpoctiPlochu()
    { 
        return (a * v) / 2.0;
    }
}

public class Elipsa : Objekt2D
{
    private double a; 
    private double b; 

    public Elipsa(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Elipsa (a={a:F2}; b={b:F2})");
    }

    public override double SpoctiPlochu()
    {
        return Math.PI * a * b;
    }
}

// 3D Objekty : Objekt3D
public class Kvadr : Objekt3D
{
    private double a, b, c;
    public Kvadr(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Kvadr (a={a:F2}; b={b:F2}; c={c:F2})");
    }
    public override double SpoctiPovrch()
    {
        return 2 * (a * b + b * c + a * c);
    }
    public override double SpoctiObjem()
    {
        return a * b * c;
    }
}

public class Koule : Objekt3D
{
    private double r;
    public Koule(double r)
    { 
        this.r = r;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Koule (r={r:F2})");
    }
    public override double SpoctiPovrch()
    {
        return 4 * Math.PI * r * r;
    }
    public override double SpoctiObjem()
    {
        return (4.0 / 3.0) * Math.PI * Math.Pow(r, 3);
    }
}

public class Valec : Objekt3D 
{
    private double r, v;
    public Valec(double r, double v)
    { 
        this.r = r; 
        this.v = v; 
    } 

    public override void Kresli()
    {
        Console.WriteLine($"Valec (r={r:F2}; v={v:F2})"); 
    }
    public override double SpoctiPovrch()
    {
        return 2 * Math.PI * r * (r + v); 
    }
    public override double SpoctiObjem()
    {
        return Math.PI * r * r * v;
    } 
}

public class Jehlan : Objekt3D
{
    private double a; 
    private double v; 

    public Jehlan(double a, double v)
    {
        this.a = a;
        this.v = v;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Jehlan (a={a:F2}; v={v:F2})");
    }

    public override double SpoctiPovrch()
    {
        double vyskaSteny = Math.Sqrt(Math.Pow(a / 2, 2) + Math.Pow(v, 2));
        return Math.Pow(a, 2) + 2 * a * vyskaSteny;
    }

    public override double SpoctiObjem()
    {
         return (1.0 / 3.0) * Math.Pow(a, 2) * v;
    }
}

