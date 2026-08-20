namespace Lab01_DAEA;

// Clase Derivada: Automovil
internal class Automovil : Vehiculo
{
    // Propiedad Adicional (Parte 1)
    public string Combustible { get; private set; }

    // Rendimiento promedio de un automóvil (kilómetros por galón)
    private const double RendimientoKmPorGalon = 12.0;

    // Constructor usando 'base' para reutilizar inicialización (Parte 1)
    public Automovil(string marca, string modelo, int anio, string combustible)
        : base(marca, modelo, anio)
    {
        Combustible = combustible;
    }

    // Sobrescritura del Método (Parte 2)
    public override void MostrarInformacion()
    {
        Console.WriteLine($"[AUTOMOVIL] Marca: {Marca,-10} | Modelo: {Modelo,-10} | Año: {Anio} | Combustible: {Combustible}");
    }

    // Sobrescritura del cálculo de costo (Parte 3)
    public override double CalcularCostoViaje(double distanciaKm)
    {
        double galones = distanciaKm / RendimientoKmPorGalon;
        return galones * PrecioPorGalon(Combustible);
    }

    // Precio referencial del galón según el tipo de combustible
    private static double PrecioPorGalon(string combustible) => combustible.ToLower() switch
    {
        "diesel" => 13.20,
        "glp" => 8.90,
        "gnv" => 7.50,
        _ => 15.50   // gasolina
    };
}
