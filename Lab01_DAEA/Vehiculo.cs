namespace Lab01_DAEA;

// Clase Base
internal class Vehiculo
{
    // Propiedades (Parte 1)
    public string Marca { get; private set; }
    public string Modelo { get; private set; }
    public int Anio { get; private set; }

    // Constructor (Parte 1)
    public Vehiculo(string marca, string modelo, int anio)
    {
        Marca = marca;
        Modelo = modelo;
        Anio = anio;
    }

    // Método Virtual para Polimorfismo (Parte 2)
    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Marca  : {Marca}");
        Console.WriteLine($"Modelo : {Modelo}");
        Console.WriteLine($"Año    : {Anio}");
    }

    // Método Virtual para el costo de viaje (Parte 3)
    public virtual double CalcularCostoViaje(double distanciaKm, double rendimientoKmPorGalon, double precioPorGalon)
    {
        double galones = distanciaKm / rendimientoKmPorGalon;
        return galones * precioPorGalon;
    }

    // Método Virtual que muestra el desglose del cálculo (Parte 3)
    public virtual void MostrarDetalleCosto(double distanciaKm, double rendimientoKmPorGalon, double precioPorGalon)
    {
        double galones = distanciaKm / rendimientoKmPorGalon;
        double costoCombustible = galones * precioPorGalon;

        MostrarInformacion();
        Console.WriteLine($"Distancia            : {distanciaKm:F2} km");
        Console.WriteLine($"Combustible          : {galones:F2} galones");
        Console.WriteLine($"Costo de combustible : S/ {costoCombustible:F2}");
        Console.WriteLine($"COSTO TOTAL          : S/ {CalcularCostoViaje(distanciaKm, rendimientoKmPorGalon, precioPorGalon):F2}");
    }
}
