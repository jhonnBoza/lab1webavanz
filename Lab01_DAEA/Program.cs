using Lab01_DAEA;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ---------------------------------------------------------------
// Parte 3: Programa principal
// ---------------------------------------------------------------

// Lista de tipo Vehiculo (colección heterogénea)
List<Vehiculo> vehiculos = new List<Vehiculo>();

// Se crean objetos de las clases derivadas y se agregan a la lista
vehiculos.Add(new Automovil("Toyota", "Yaris", 2022, "Gasolina"));
vehiculos.Add(new Camion("Volvo", "FH16", 2020, 25.5));

// La flota administra esa misma lista
Flota flota = new Flota(vehiculos);

Console.WriteLine("=========================================");
Console.WriteLine("   FLOTA REGISTRADA AL INICIAR EL SISTEMA");
Console.WriteLine("=========================================\n");
flota.MostrarFlota();

// ---------------------------------------------------------------
// Menú de opciones
// ---------------------------------------------------------------
bool salir = false;

while (!salir)
{
    Console.WriteLine("=========================================");
    Console.WriteLine("        GESTIÓN DE FLOTA VEHICULAR       ");
    Console.WriteLine("=========================================");
    Console.WriteLine("1. Mostrar información de vehículos");
    Console.WriteLine("2. Calcular costo de viaje");
    Console.WriteLine("3. Salir");
    Console.Write("Seleccione una opción: ");

    string? opcion = Console.ReadLine();
    Console.WriteLine();

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
            Console.WriteLine("Saliendo del sistema. ¡Hasta pronto!");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente nuevamente.\n");
            break;
    }
}

// ---------------------------------------------------------------
// Método local: elegir vehículo, pedir distancia y calcular el costo
// ---------------------------------------------------------------
static void CalcularCostoDeViaje(Flota flota)
{
    if (flota.Vehiculos.Count == 0)
    {
        Console.WriteLine("No hay vehículos disponibles.\n");
        return;
    }

    Console.WriteLine("Seleccione el vehículo:");
    for (int i = 0; i < flota.Vehiculos.Count; i++)
    {
        Vehiculo v = flota.Vehiculos[i];
        Console.WriteLine($"{i + 1}. {v.Marca} {v.Modelo} ({v.Anio})");
    }
    Console.Write("Opción: ");

    if (!int.TryParse(Console.ReadLine(), out int indice) ||
        indice < 1 || indice > flota.Vehiculos.Count)
    {
        Console.WriteLine("Vehículo inválido.\n");
        return;
    }

    Console.Write("Ingrese la distancia del viaje (km): ");
    if (!double.TryParse(Console.ReadLine(), out double distancia) || distancia <= 0)
    {
        Console.WriteLine("Distancia inválida.\n");
        return;
    }

    Vehiculo seleccionado = flota.Vehiculos[indice - 1];
    double costo = seleccionado.CalcularCostoViaje(distancia);   // polimorfismo

    Console.WriteLine();
    Console.WriteLine("--- RESULTADO DEL VIAJE ---");
    seleccionado.MostrarInformacion();
    Console.WriteLine($"Distancia    : {distancia} km");
    Console.WriteLine($"Costo total  : S/ {costo:F2}");
    Console.WriteLine();
}
