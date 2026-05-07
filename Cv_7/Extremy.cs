
public class Extremy
{
    public static T Nejvetsi<T>(T[] pole) where T : IComparable
    {
        if (pole == null || pole.Length == 0) throw new ArgumentException("Pole je prazdne!");
        
        T max = pole[0];
        for (int i = 1; i < pole.Length; i++)
        {
            if (pole[i].CompareTo(max) > 0) 
            {
                max = pole[i];
            }
        }
        return max;
    }

    public static T Nejmensi<T>(T[] pole) where T : IComparable
    {
        if (pole == null || pole.Length == 0) throw new ArgumentException("Pole je prazdne!");
        
        T min = pole[0];
        for (int i = 1; i < pole.Length; i++)
        {
            if (pole[i].CompareTo(min) < 0) 
            {
                min = pole[i];
            }
        }
        return min;
    }
}