namespace Lab01_DAEA;

// Clase Derivada: Camion
internal class Camion : Vehiculo
{
    // Propiedad Adicional (Parte 1)
    public double CapacidadCarga { get; private set; }

    // Recargo aplicado por cada tonelada de capacidad de carga
    private const double RecargoPorTonelada = 15.00;

    // Constructor usando 'base' para reutilizar inicialización (Parte 1)
    public Camion(string marca, string modelo, int anio, double capacidadCarga)
        : base(marca, modelo, anio)
    {
        CapacidadCarga = capacidadCarga;
    }

    // Sobrescritura del Método (Parte 2)
    public override void MostrarInformacion()
    {
        Console.WriteLine("Tipo   : Camión");
        base.MostrarInformacion();
        Console.WriteLine($"Capacidad de carga : {CapacidadCarga:F2} toneladas");
    }

    // El camión suma un recargo por su capacidad de carga (Parte 3)
    public override double CalcularCostoViaje(double distanciaKm, double rendimientoKmPorGalon, double precioPorGalon)
    {
        double costoCombustible = base.CalcularCostoViaje(distanciaKm, rendimientoKmPorGalon, precioPorGalon);
        return costoCombustible + (CapacidadCarga * RecargoPorTonelada);
    }

    // Se agrega la línea del recargo al desglose (Parte 3)
    public override void MostrarDetalleCosto(double distanciaKm, double rendimientoKmPorGalon, double precioPorGalon)
    {
        double galones = distanciaKm / rendimientoKmPorGalon;
        double costoCombustible = galones * precioPorGalon;
        double recargoCarga = CapacidadCarga * RecargoPorTonelada;

        MostrarInformacion();
        Console.WriteLine($"Distancia            : {distanciaKm:F2} km");
        Console.WriteLine($"Combustible          : {galones:F2} galones");
        Console.WriteLine($"Costo de combustible : S/ {costoCombustible:F2}");
        Console.WriteLine($"Recargo por carga    : S/ {recargoCarga:F2}");
        Console.WriteLine($"COSTO TOTAL          : S/ {(costoCombustible + recargoCarga):F2}");
    }
}
