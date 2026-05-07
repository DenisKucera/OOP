
public class Kruh : Objekt2D
{
    private double r;
    public Kruh(double r) => this.r = r;
    public override double Plocha() => Math.PI * r * r;
    public override string ToString() => $"Kruh (r={r}, plocha={Plocha():F2})";
}

public class Obdelnik : Objekt2D
{
    private double a, b;
    public Obdelnik(double a, double b) { this.a = a; this.b = b; }
    public override double Plocha() => a * b;
    public override string ToString() => $"Obdelnik (a={a}, b={b}, plocha={Plocha():F2})";
}

public class Elipsa : Objekt2D
{
    private double a, b;
    public Elipsa(double a, double b) { this.a = a; this.b = b; }
    public override double Plocha() => Math.PI * a * b;
    public override string ToString() => $"Elipsa (a={a}, b={b}, plocha={Plocha():F2})";
}

public class Trojuhelnik : Objekt2D
{
    private double a, v;
    public Trojuhelnik(double a, double v) { this.a = a; this.v = v; }
    public override double Plocha() => (a * v) / 2.0;
    public override string ToString() => $"Trojuhelnik (a={a}, v={v}, plocha={Plocha():F2})";
}

public class Ctverec : Objekt2D
{
    private double a;
    public Ctverec(double a) => this.a = a;
    public override double Plocha() => a * a;
    public override string ToString() => $"Ctverec (a={a}, plocha={Plocha():F2})";
}