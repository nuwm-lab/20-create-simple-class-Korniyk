using System;

public class Tetrahedron
{
    // Кожна вершина тетраедра
    private (double x, double y, double z) A, B, C, D;

    // Конструктор для ініціалізації координат вершин
    public Tetrahedron((double, double, double) a, (double, double, double) b, (double, double, double) c, (double, double, double) d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    // Метод для обчислення об'єму тетраедра
    public double CalculateVolume()
    {
        double volume = Math.Abs(
            (A.x - D.x) * ((B.y - D.y) * (C.z - D.z) - (C.y - D.y) * (B.z - D.z)) -
            (A.y - D.y) * ((B.x - D.x) * (C.z - D.z) - (C.x - D.x) * (B.z - D.z)) +
            (A.z - D.z) * ((B.x - D.x) * (C.y - D.y) - (C.x - D.x) * (B.y - D.y))
        ) / 6.0;

        return volume;
    }
}

public class Program
{
    // Метод для зчитування координат однієї точки з консолі
    private static (double, double, double) ReadPoint(string pointName)
    {
        Console.WriteLine($"Введiть координати точки {pointName} (у форматi x y z):");
        string[] input = Console.ReadLine().Split();

        double x = double.Parse(input[0]);
        double y = double.Parse(input[1]);
        double z = double.Parse(input[2]);

        return (x, y, z);
    }

    public static void Main()
    {
        // Зчитуємо координати вершин з консолі
        var A = ReadPoint("A");
        var B = ReadPoint("B");
        var C = ReadPoint("C");
        var D = ReadPoint("D");

        // Створюємо об'єкт тетраедра з введеними координатами
        var tetrahedron = new Tetrahedron(A, B, C, D);

        // Обчислюємо об'єм
        double volume = tetrahedron.CalculateVolume();
        Console.WriteLine($"Об'єм тетраедра: {volume}");
    }
}
