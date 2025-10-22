public class Program
{
    public static void Main(string[] args)
    {
        Ejercicio1(args);
        Ejercicio2(args);
        Ejercicio3();
    }
    public static void Ejercicio1(string[] args)
    {
        Console.WriteLine(" === Nivel Básico === ");
        Console.WriteLine("Ejercicio 1:");
        var numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // 1. Usando sintaxis de consulta: filtra los números mayores a 5
        var mayoresA5 = from n in numeros
                        where n > 5
                        select n;

        Console.WriteLine("Números mayores a 5:");
        foreach (var n in mayoresA5)
            Console.WriteLine(n);

        // 2. Usando sintaxis de método: filtra los números pares
        var pares = numeros.Where(n => n % 2 == 0);
        var paresQuery = from n in numeros where n % 2 == 0 select n;   

        Console.WriteLine("\nNúmeros pares:");
        foreach (var n in pares)
            Console.WriteLine(n);

        // 3. Filtra los números que sean múltiplos de 3
        var multiplosDe3 = numeros.Where(n => n % 3 == 0);

        Console.WriteLine("\nNúmeros múltiplos de 3:");
        foreach (var n in multiplosDe3)
            Console.WriteLine(n);

    }

    public static void Ejercicio2(string[] args)
    {
        Console.WriteLine("\nEjercicio 2:");
        var palabras = new List<string> { "casa", "coche", "árbol", "mesa", "silla" };

        // 1. Selecciona solo las palabras que tengan más de 4 letras
        var largas = palabras.Where(p => p.Length > 4);
        var largasQuery = from p in palabras where p.Length > 4 select p;

        Console.WriteLine("Palabras con más de 4 letras:");
        foreach (var p in largas)
            Console.WriteLine(p);

        // 2. Transforma cada palabra a mayúsculas
        var mayusculas = palabras.Select(p => p.ToUpper());
        var mayusculasQuery = from p in palabras select p.ToUpper();

        Console.WriteLine("\nPalabras en mayúsculas:");
        foreach (var p in mayusculas)
            Console.WriteLine(p);

        // 3. Crea un nuevo tipo anónimo con la palabra y su longitud
        var palabraYLongitud = palabras.Select(p => new { Palabra = p, Longitud = p.Length });
        var palabraYLongitudQuery = from p in palabras select new { Palabra = p, Longitud = p.Length };

        Console.WriteLine("\nPalabra y su longitud:");
        foreach (var item in palabraYLongitud)
            Console.WriteLine($"Palabra: {item.Palabra}, Longitud: {item.Longitud}");

    }

    class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }

    public static void Ejercicio3()
    {
        Console.WriteLine("\nEjercicio 3:");
        var personas = new List<Persona>
    {
        new Persona { Nombre = "Ana", Edad = 25 },
        new Persona { Nombre = "Luis", Edad = 30 },
        new Persona { Nombre = "María", Edad = 22 }
    };

        // 1. Ordena por edad de forma ascendente
        var porEdadAsc = personas.OrderBy(p => p.Edad);
        var porEdadAscQuery = from p in personas orderby p.Edad ascending select p;

        Console.WriteLine("Ordenado por edad ascendente:");
        foreach (var p in porEdadAsc)
            Console.WriteLine($"{p.Nombre}, {p.Edad}");

        // 2. Ordena por nombre de forma descendente
        var porNombreDesc = personas.OrderByDescending(p => p.Nombre);
        var porNombreDescQuery = from p in personas orderby p.Nombre descending select p;

        Console.WriteLine("\nOrdenado por nombre descendente:");
        foreach (var p in porNombreDesc)
            Console.WriteLine($"{p.Nombre}, {p.Edad}");

        // 3. Ordena por edad descendente y luego por nombre ascendente
        var edadDescNombreAsc = personas
                                .OrderByDescending(p => p.Edad)
                                .ThenBy(p => p.Nombre);

        var edadDescNombreAscQuery = from p in personas orderby p.Edad descending, p.Nombre ascending select p;

        Console.WriteLine("\nOrdenado por edad descendente y nombre ascendente:");
        foreach (var p in edadDescNombreAsc)
            Console.WriteLine($"{p.Nombre}, {p.Edad}");
    }
    public static void Ejercicio4(string[] args)
    {
        Console.WriteLine("\n === Nivel Intermedio === ");
        Console.WriteLine("\nEjercicio 4: ");

    }
}