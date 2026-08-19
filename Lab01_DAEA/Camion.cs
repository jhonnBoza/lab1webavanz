namespace Lab01_DAEA;

/// <summary>
/// Clase derivada de Vehiculo. Agrega la capacidad de carga en toneladas.
/// </summary>
public class Camion : Vehiculo
{
    private double _capacidadCarga;

    public double CapacidadCarga { get => _capacidadCarga; private set => _capacidadCarga = value; }

    // Un camión rinde menos que un automóvil
    private const double RendimientoKmPorGalon = 6.0;
    private const double PrecioDiesel = 13.20;
    private const double RecargoPorTonelada = 1.80;

    public Camion(string marca, string modelo, int anio, double capacidadCarga)
        : base(marca, modelo, anio)
    {
        _capacidadCarga = capacidadCarga;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("Tipo  : Camión");
        base.MostrarInformacion();
        Console.WriteLine($"Capacidad de carga: {CapacidadCarga} toneladas");
    }

    public override double CalcularCostoViaje(double distanciaKm)
    {
        double galones = distanciaKm / RendimientoKmPorGalon;
        double costoCombustible = galones * PrecioDiesel;
        double recargoCarga = CapacidadCarga * RecargoPorTonelada;   // desgaste y peajes por tonelaje
        return costoCombustible + recargoCarga;
    }
}
