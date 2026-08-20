namespace Lab01_DAEA;

// Clase Derivada: Camion
internal class Camion : Vehiculo
{
    // Propiedad Adicional (Parte 1)
    public double CapacidadCarga { get; private set; }

    // Un camión rinde menos y paga recargo por tonelaje
    private const double RendimientoKmPorGalon = 6.0;
    private const double PrecioDiesel = 13.20;
    private const double RecargoPorTonelada = 1.80;

    // Constructor usando 'base' para reutilizar inicialización (Parte 1)
    public Camion(string marca, string modelo, int anio, double capacidadCarga)
        : base(marca, modelo, anio)
    {
        CapacidadCarga = capacidadCarga;
    }

    // Sobrescritura del Método (Parte 2)
    public override void MostrarInformacion()
    {
        Console.WriteLine($"[CAMION]    Marca: {Marca,-10} | Modelo: {Modelo,-10} | Año: {Anio} | Capacidad de Carga: {CapacidadCarga,6:F2} Ton");
    }

    // Sobrescritura del cálculo de costo (Parte 3)
    public override double CalcularCostoViaje(double distanciaKm)
    {
        double galones = distanciaKm / RendimientoKmPorGalon;
        double costoCombustible = galones * PrecioDiesel;
        double recargoCarga = CapacidadCarga * RecargoPorTonelada;
        return costoCombustible + recargoCarga;
    }
}
