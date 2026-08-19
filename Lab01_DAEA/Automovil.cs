namespace Lab01_DAEA;

/// <summary>
/// Clase derivada de Vehiculo. Agrega el tipo de combustible.
/// </summary>
public class Automovil : Vehiculo
{
    private string _combustible;

    public string Combustible { get => _combustible; private set => _combustible = value; }

    // Rendimiento promedio de un automóvil (kilómetros por galón)
    private const double RendimientoKmPorGalon = 12.0;

    // El constructor recibe también las propiedades heredadas y las envía con : base(...)
    public Automovil(string marca, string modelo, int anio, string combustible)
        : base(marca, modelo, anio)
    {
        _combustible = combustible;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("Tipo  : Automóvil");
        base.MostrarInformacion();          // reutiliza la impresión de la clase padre
        Console.WriteLine($"Combustible: {Combustible}");
    }

    public override double CalcularCostoViaje(double distanciaKm)
    {
        double galones = distanciaKm / RendimientoKmPorGalon;
        return galones * PrecioPorGalon(Combustible);
    }

    /// <summary>Precio referencial del galón según el combustible (S/).</summary>
    private static double PrecioPorGalon(string combustible) => combustible.ToLower() switch
    {
        "diesel" => 13.20,
        "glp" => 8.90,
        "gnv" => 7.50,
        _ => 15.50   // gasolina
    };
}
