public class Program
{
    public static void Main(string[] args)
    {
        Ejercicio1(args);
        Ejercicio2(args);
        Ejercicio3();
        Ejercicio4();
        Ejercicio5();
        Ejercicio6();
        Ejercicio7();
        Ejercicio8();
        Ejercicio9();
        Ejercicio10();
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
    class Producto
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
    }

    static void Ejercicio4()
    {
        Console.WriteLine("\nEjercicio 4:");

        var productos = new List<Producto>
    {
        new Producto { Nombre = "Laptop", Categoria = "Electrónicos", Precio = 800 },
        new Producto { Nombre = "Mouse", Categoria = "Electrónicos", Precio = 25 },
        new Producto { Nombre = "Silla", Categoria = "Muebles", Precio = 150 },
        new Producto { Nombre = "Mesa", Categoria = "Muebles", Precio = 300 }
    };

        // 1. Agrupa los productos por categoría
        var grupos = productos.GroupBy(p => p.Categoria);
        var gruposQuery = from p in productos group p by p.Categoria;

        Console.WriteLine("Productos agrupados por categoría:");
        foreach (var grupo in grupos)
        {
            Console.WriteLine($"\nCategoría: {grupo.Key}");
            foreach (var p in grupo)
                Console.WriteLine($" - {p.Nombre} (${p.Precio})");
        }

        // 2. Para cada categoría, calcula el precio promedio
        var promedios = productos
            .GroupBy(p => p.Categoria)
            .Select(g => new { Categoria = g.Key, Promedio = g.Average(p => p.Precio) });
        var promediosQuery = from p in productos
                            group p by p.Categoria into g
                            select new { Categoria = g.Key, Promedio = g.Average(p => p.Precio) };

        Console.WriteLine("\nPrecio promedio por categoría:");
        foreach (var item in promedios)
            Console.WriteLine($"{item.Categoria}: ${item.Promedio:F2}");

        // 3. Encuentra la categoría con el producto más caro
        var categoriaMasCaro = productos
            .OrderByDescending(p => p.Precio)
            .First()
            .Categoria;
        var categoriaMasCaroQuery = (from p in productos
                                     orderby p.Precio descending
                                     select p).First().Categoria;

        Console.WriteLine($"\nCategoría con el producto más caro: {categoriaMasCaro}");
    }

    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public double Total { get; set; }
    }

    static void Ejercicio5()
    {
        Console.WriteLine("\nEjercicio 5:");

        var clientes = new List<Cliente>
    {
        new Cliente { Id = 1, Nombre = "Carlos" },
        new Cliente { Id = 2, Nombre = "Elena" }
    };

        var pedidos = new List<Pedido>
    {
        new Pedido { Id = 1, ClienteId = 1, Total = 100 },
        new Pedido { Id = 2, ClienteId = 1, Total = 200 },
        new Pedido { Id = 3, ClienteId = 2, Total = 150 }
    };

        // 1. Une clientes con pedidos para mostrar nombre del cliente y total del pedido
        var union = from c in clientes
                    join p in pedidos on c.Id equals p.ClienteId
                    select new { c.Nombre, p.Total };

        Console.WriteLine("Clientes con sus pedidos:");
        foreach (var item in union)
            Console.WriteLine($"{item.Nombre} - Total del pedido: ${item.Total}");

        // 2. Calcula el total de pedidos por cliente
        var totalPorCliente = from c in clientes
                              join p in pedidos on c.Id equals p.ClienteId
                              group p by c.Nombre into grupo
                              select new { Cliente = grupo.Key, Total = grupo.Sum(x => x.Total) };

        Console.WriteLine("\nTotal de pedidos por cliente:");
        foreach (var item in totalPorCliente)
            Console.WriteLine($"{item.Cliente}: ${item.Total}");
        

        // 3. Encuentra clientes que no han realizado pedidos
        var sinPedidos = from c in clientes
                         where !(from p in pedidos select p.ClienteId).Contains(c.Id)
                         select c.Nombre;

        Console.WriteLine("\nClientes sin pedidos:");
        foreach (var c in sinPedidos)
            Console.WriteLine(c);
    }

    static void Ejercicio6()
    {
        Console.WriteLine("\nEjercicio 6:");

        var numeros = new List<int> { 10, 20, 30, 40, 50 };

        // 1. Encuentra el primer número mayor a 25
        var primeroMayor25 = numeros.First(n => n > 25);
        var promeroMayor25Query = (from n in numeros where n > 25 select n).First();
        Console.WriteLine($"Primer número mayor a 25: {primeroMayor25}");

        // 2. Encuentra el último número menor a 35
        var ultimoMenor35 = numeros.Last(n => n < 35);
        var ultimoMenor35Query = (from n in numeros where n < 35 select n).Last();
        Console.WriteLine($"Último número menor a 35: {ultimoMenor35}");

        // 3. Usa SingleOrDefault para encontrar el número 30
        var numero30 = numeros.SingleOrDefault(n => n == 30);
        var numero30Query = (from n in numeros where n == 30 select n).SingleOrDefault();
        Console.WriteLine($"Número encontrado con SingleOrDefault: {numero30}");

        // 4. ¿Qué pasa si usas Single con un número que no existe?
        try
        {
            var noExiste = numeros.Single(n => n == 99);
            Console.WriteLine(noExiste);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Error: 'Single' lanzó una excepción porque no encontró el elemento.");
        }
    }

    class Producto1
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }

    static void Ejercicio7()
    {
        Console.WriteLine("\nEjercicio 7:");

        Console.WriteLine(" == Nivel Avanzado == ");

        var productos = new List<Producto1>();
        for (int i = 1; i <= 20; i++)
            productos.Add(new Producto1 { Nombre = $"Producto {i}", Precio = i * 10 });
        var productosQuery = (from p in productos select p).ToList();

        // 1. Página 1 con 5 productos
        var pagina1 = productos.Skip(0).Take(5);
        var pagina1Query = (from p in productos select p).Skip(0).Take(5);

        Console.WriteLine("Página 1 (productos 1-5):");
        foreach (var p in pagina1)
            Console.WriteLine($"{p.Nombre} - ${p.Precio}");

        // 2. Página 2 con 5 productos
        var pagina2 = productos.Skip(5).Take(5);
        var pagina2Query = (from p in productos select p).Skip(5).Take(5);

        Console.WriteLine("\nPágina 2 (productos 6-10):");
        foreach (var p in pagina2)
            Console.WriteLine($"{p.Nombre} - ${p.Precio}");

        // 3. Método genérico que recibe número de página y tamaño
        IEnumerable<Producto1> Paginacion(List<Producto1> lista, int numeroPagina, int tamPagina)
        {
            return lista.Skip((numeroPagina - 1) * tamPagina).Take(tamPagina);
        }

        Console.WriteLine("\nPágina 3 (productos 11-15) usando método:");
        var pagina3 = Paginacion(productos, 3, 5);
        foreach (var p in pagina3)
            Console.WriteLine($"{p.Nombre} - ${p.Precio}");
    }

    class Venta1
    {
        public string Producto { get; set; }
        public string Vendedor { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }

    static void Ejercicio8()
    {
        Console.WriteLine("\nEjercicio 8:");

        var ventas = new List<Venta1>
    {
        new Venta1 { Producto = "Laptop", Vendedor = "Ana", Cantidad = 2, Precio = 800 },
        new Venta1 { Producto = "Mouse", Vendedor = "Ana", Cantidad = 5, Precio = 25 },
        new Venta1 { Producto = "Laptop", Vendedor = "Luis", Cantidad = 1, Precio = 800 },
        new Venta1 { Producto = "Teclado", Vendedor = "Luis", Cantidad = 3, Precio = 50 }
    };

        // 1. Total vendido por cada vendedor
        var totalPorVendedor = ventas
            .GroupBy(v => v.Vendedor)
            .Select(g => new { Vendedor = g.Key, Total = g.Sum(v => v.Cantidad * v.Precio) });
        var totalPorVendedorQuery = from v in ventas
                                   group v by v.Vendedor into g
                                   select new { Vendedor = g.Key, Total = g.Sum(v => v.Cantidad * v.Precio) };

        Console.WriteLine("Total vendido por cada vendedor:");
        foreach (var v in totalPorVendedor)
            Console.WriteLine($"{v.Vendedor}: ${v.Total}");

        // 2. Producto más vendido (por cantidad)
        var masVendido = ventas
            .GroupBy(v => v.Producto)
            .Select(g => new { Producto = g.Key, TotalCantidad = g.Sum(v => v.Cantidad) })
            .OrderByDescending(x => x.TotalCantidad)
            .First();

        Console.WriteLine($"\nProducto más vendido: {masVendido.Producto} ({masVendido.TotalCantidad} unidades)");

        // 3. Valor total de todas las ventas
        var totalVentas = ventas.Sum(v => v.Cantidad * v.Precio);
        var totalVentasQuery = (from v in ventas select v.Cantidad * v.Precio).Sum();
        Console.WriteLine($"\nValor total de todas las ventas: ${totalVentas}");

        // 4. Agrupa por producto y calcula cantidad total vendida
        var totalPorProducto = ventas
            .GroupBy(v => v.Producto)
            .Select(g => new { Producto = g.Key, CantidadTotal = g.Sum(v => v.Cantidad) });
        var totalPorProductoQuery = from v in ventas
                                 group v by v.Producto into g
                                 select new { Producto = g.Key, CantidadTotal = g.Sum(v => v.Cantidad) };

        Console.WriteLine("\nCantidad total vendida por producto:");
        foreach (var item in totalPorProducto)
            Console.WriteLine($"{item.Producto}: {item.CantidadTotal} unidades");
    }

    class Empleado1
    {
        public string Nombre { get; set; }
        public double Salario { get; set; }
    }

    class Departamento1
    {
        public string Nombre { get; set; }
        public List<Empleado1> Empleados { get; set; }
    }

    static void Ejercicio9()
    {
        Console.WriteLine("\nEjercicio 9:");

        var departamentos = new List<Departamento1>
    {
        new Departamento1
        {
            Nombre = "Ventas",
            Empleados = new List<Empleado1>
            {
                new Empleado1 { Nombre = "Ana", Salario = 3000 },
                new Empleado1 { Nombre = "Luis", Salario = 3500 }
            }
        },
        new Departamento1
        {
            Nombre = "IT",
            Empleados = new List<Empleado1>
            {
                new Empleado1 { Nombre = "Carlos", Salario = 4000 },
                new Empleado1 { Nombre = "María", Salario = 4200 }
            }
        }
    };

        // 1. Departamento con el salario promedio más alto
        var deptoMayorSalario = departamentos
            .Select(d => new { d.Nombre, Promedio = d.Empleados.Average(e => e.Salario) })
            .OrderByDescending(x => x.Promedio)
            .First();
        var deptoMayorSalarioQuery = (from d in departamentos
                                     select new { d.Nombre, Promedio = d.Empleados.Average(e => e.Salario) } into deptoProm
                                     orderby deptoProm.Promedio descending
                                     select deptoProm).First();

        Console.WriteLine($"Departamento con mayor salario promedio: {deptoMayorSalario.Nombre} (${deptoMayorSalario.Promedio:F2})");

        // 2. Lista todos los empleados con su departamento
        Console.WriteLine("\nEmpleados con su departamento:");
        var empleadosConDepto = departamentos
            .SelectMany(d => d.Empleados.Select(e => new { Empleado = e.Nombre, Departamento = d.Nombre }));

        foreach (var e in empleadosConDepto)
            Console.WriteLine($"{e.Empleado} - {e.Departamento}");

        // 3. Empleados que ganan más de 3500
        Console.WriteLine("\nEmpleados que ganan más de 3500:");
        var empleadosAltos = departamentos
            .SelectMany(d => d.Empleados.Where(e => e.Salario > 3500)
            .Select(e => new { e.Nombre, e.Salario, Departamento = d.Nombre }));
        var empleadosAltosQuery = from d in departamentos
                                 from e in d.Empleados
                                 where e.Salario > 3500
                                 select new { e.Nombre, e.Salario, Departamento = d.Nombre };

        foreach (var e in empleadosAltos)
            Console.WriteLine($"{e.Nombre} - {e.Departamento} (${e.Salario})");
    }

    class Estudiante1
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Curso { get; set; }
    }

    static void Ejercicio10()
    {
        Console.WriteLine("\nEjercicio 10:");

        var estudiantes = new List<Estudiante1>
    {
        new Estudiante1 { Id = 1, Nombre = "Ana", Curso = "Matemáticas" },
        new Estudiante1 { Id = 2, Nombre = "Luis", Curso = "Matemáticas" },
        new Estudiante1 { Id = 3, Nombre = "Carlos", Curso = "Historia" }
    };

        // 1. Convertir a Dictionary<int, Estudiante1> usando Id como clave
        var diccionario = estudiantes.ToDictionary(e => e.Id);
        var diccionarioQuery = (from e in estudiantes
                               select e).ToDictionary(e => e.Id);
        Console.WriteLine("Diccionario de estudiantes:");
        foreach (var kvp in diccionario)
            Console.WriteLine($"Id: {kvp.Key}, Nombre: {kvp.Value.Nombre}");

        // 2. Crear un Lookup por curso
        var lookup = estudiantes.ToLookup(e => e.Curso);
        Console.WriteLine("\nEstudiantes agrupados por curso:");
        foreach (var grupo in lookup)
        {
            Console.WriteLine($"\nCurso: {grupo.Key}");
            foreach (var e in grupo)
                Console.WriteLine($" - {e.Nombre}");
        }

        // 3. Convertir a array y luego de vuelta a lista
        var array = estudiantes.ToArray();
        var listaNueva = array.ToList();

        Console.WriteLine("\nConversión a array y luego a lista:");
        foreach (var e in listaNueva)
            Console.WriteLine($"{e.Nombre} ({e.Curso})");
    }


}