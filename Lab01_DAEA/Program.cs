using Lab01_DAEA;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ===================== PARTE 3: PROGRAMA PRINCIPAL =====================

// Lista de tipo Vehiculo (Parte 3)
List<Vehiculo> vehiculos = new List<Vehiculo>();

// Se crean los objetos de las clases derivadas y se agregan a la lista (Parte 3)
vehiculos.Add(new Automovil("Toyota", "Yaris", 2022, "Gasolina"));
vehiculos.Add(new Camion("Volvo", "FH16", 2020, 25.5));

// La flota administra la lista de vehículos (Parte 3)
Flota flota = new Flota(vehiculos);

// Se muestra la flota registrada al iniciar el sistema
flota.MostrarFlota();

// Menú de opciones (Parte 3)
bool salir = false;

while (!salir)
{
    Console.WriteLine("===============================================");
    Console.WriteLine("           GESTION DE FLOTA VEHICULAR          ");
    Console.WriteLine("===============================================");
    Console.WriteLine(" 1. Mostrar información de vehículos");
    Console.WriteLine(" 2. Calcular costo de viaje");
    Console.WriteLine(" 3. Salir");
    Console.WriteLine("===============================================");
    Console.Write("Seleccione una opción: ");

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
            Console.WriteLine("\n--> Saliendo del sistema. ¡Hasta pronto!");
            break;

        default:
            Console.WriteLine("\n--> Opción inválida. Intente nuevamente.\n");
            break;
    }
}

// Permite elegir un vehículo, solicita la distancia y calcula el costo (Parte 3)
static void CalcularCostoDeViaje(Flota flota)
{
    if (flota.Vehiculos.Count == 0)
    {
        Console.WriteLine("\n--> No hay vehículos disponibles.\n");
        return;
    }

    Console.WriteLine("\n--- SELECCIONE EL VEHICULO ---");
    for (int i = 0; i < flota.Vehiculos.Count; i++)
    {
        Vehiculo v = flota.Vehiculos[i];
        Console.WriteLine($"{i + 1}. {v.Marca} {v.Modelo} ({v.Anio})");
    }
    Console.Write("Opción: ");

    if (!int.TryParse(Console.ReadLine(), out int indice) ||
        indice < 1 || indice > flota.Vehiculos.Count)
    {
        Console.WriteLine("\n--> Vehículo inválido.\n");
        return;
    }

    Console.Write("Ingrese la distancia del viaje (Km): ");
    if (!double.TryParse(Console.ReadLine(), out double distancia) || distancia <= 0)
    {
        Console.WriteLine("\n--> Distancia inválida.\n");
        return;
    }

    Vehiculo seleccionado = flota.Vehiculos[indice - 1];
    double costo = seleccionado.CalcularCostoViaje(distancia); // Enlace dinámico / Polimorfismo

    Console.WriteLine("\n===============================================");
    Console.WriteLine("            RESULTADO DEL COSTO DE VIAJE       ");
    Console.WriteLine("===============================================");
    seleccionado.MostrarInformacion();
    Console.WriteLine($"Distancia recorrida : {distancia:F2} Km");
    Console.WriteLine($"COSTO TOTAL DEL VIAJE: S/ {costo:F2}");
    Console.WriteLine("===============================================\n");
}
