namespace Lab01_DAEA;

/// <summary>
/// Clase base del dominio. Encapsula los datos comunes a todo vehículo.
/// </summary>
public class Vehiculo
{
    // Campos privados (encapsulamiento)
    private string _marca;
    private string _modelo;
    private int _anio;

    // Propiedades públicas de solo lectura hacia afuera
    public string Marca { get => _marca; private set => _marca = value; }
    public string Modelo { get => _modelo; private set => _modelo = value; }
    public int Anio { get => _anio; private set => _anio = value; }

    // Constructor de la clase base
    public Vehiculo(string marca, string modelo, int anio)
    {
        _marca = marca;
        _modelo = modelo;
        _anio = anio;
    }

    /// <summary>
    /// Método virtual: las clases derivadas lo sobrescriben con override.
    /// </summary>
    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Marca : {Marca}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Año   : {Anio}");
    }

    /// <summary>
    /// Costo base de viaje por kilómetro. Cada tipo de vehículo lo redefine.
    /// </summary>
    public virtual double CalcularCostoViaje(double distanciaKm)
    {
        return distanciaKm * 0.50;
    }
}
