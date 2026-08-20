using Lab01_DAEA;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ===================== PARTE 3: PROGRAMA PRINCIPAL =====================

// Lista de tipo Vehiculo (Parte 3)
List<Vehiculo> vehiculos = new List<Vehiculo>();

// Se crean los objetos de las clases derivadas y se agregan a la lista (Parte 3)
vehiculos.Add(new Automovil("Toyota", "Yaris", 2022, "Gasolina"));
vehiculos.Add(new Camion("Volvo", "FH16", 2020, 25.50));

// La flota administra la lista de vehículos (Parte 3)
Flota flota = new Flota(vehiculos);

// Se muestra la flota registrada al iniciar el sistema
flota.MostrarFlota();

// Menú de opciones (Parte 3)
bool salir = false;

while (!salir)
{
    Console.WriteLine("========== MENU ==========");
    Console.WriteLine("1. Mostrar informacion de vehiculos");
    Console.WriteLine("2. Calcular costo de viaje");
    Console.WriteLine("3. Salir");
    Console.WriteLine("==========================");
    Console.Write("Seleccione una opcion: ");

    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            flota.MostrarFlota();
            break;

        case "2":
            CalcularCostoDeViaje(flota);
            break;

        case "3":
            salir = true;
            Console.WriteLine("\nSaliendo del sistema. Hasta pronto!\n");
            break;

        default:
            Console.WriteLine("\nOpcion no valida. Elija 1, 2 o 3.\n");
            break;
    }
}

// Permite elegir un vehículo, solicita los datos del viaje y calcula el costo (Parte 3)
static void CalcularCostoDeViaje(Flota flota)
{
    if (flota.Vehiculos.Count == 0)
    {
        Console.WriteLine("\nNo hay vehiculos disponibles.\n");
        return;
    }

    Console.WriteLine("\n=== CALCULO DE COSTO DE VIAJE ===");
    for (int i = 0; i < flota.Vehiculos.Count; i++)
    {
        Vehiculo v = flota.Vehiculos[i];
        Console.WriteLine($"{i + 1}. {v.Marca} {v.Modelo} ({v.Anio})");
    }

    int indice = LeerEntero($"Seleccione el vehiculo (1 - {flota.Vehiculos.Count}): ", 1, flota.Vehiculos.Count);
    double distancia = LeerDecimal("Distancia del viaje en km: ");
    double rendimiento = LeerDecimal("Rendimiento del vehiculo en km por galon: ");
    double precio = LeerDecimal("Precio del combustible por galon (S/): ");

    Vehiculo seleccionado = flota.Vehiculos[indice - 1];

    Console.WriteLine("\n---- RESULTADO ----");
    seleccionado.MostrarDetalleCosto(distancia, rendimiento, precio); // Enlace dinámico / Polimorfismo
    Console.WriteLine("-------------------\n");
}

// Valida que el usuario ingrese un numero entero dentro del rango permitido
static int LeerEntero(string mensaje, int minimo, int maximo)
{
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out int valor) && valor >= minimo && valor <= maximo)
        {
            return valor;
        }
        Console.WriteLine($"Valor no valido. Ingrese un numero entero entre {minimo} y {maximo}.");
    }
}

// Valida que el usuario ingrese un numero mayor a cero
static double LeerDecimal(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (double.TryParse(Console.ReadLine(), out double valor) && valor > 0)
        {
            return valor;
        }
        Console.WriteLine("Valor no valido. Ingrese un numero mayor a 0.");
    }
}
