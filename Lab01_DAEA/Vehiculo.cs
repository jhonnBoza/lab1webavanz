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
        Console.WriteLine($"Marca: {Marca} | Modelo: {Modelo} | Año: {Anio}");
    }

    // Método Virtual para el costo de viaje (Parte 3)
    public virtual double CalcularCostoViaje(double distanciaKm)
    {
        return distanciaKm * 0.50;
    }
}
