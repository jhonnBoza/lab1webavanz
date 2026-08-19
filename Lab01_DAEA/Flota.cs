namespace Lab01_DAEA;

/// <summary>
/// Colección heterogénea: almacena Automovil y Camion bajo el tipo base Vehiculo.
/// </summary>
public class Flota
{
    private readonly List<Vehiculo> _vehiculos;

    public IReadOnlyList<Vehiculo> Vehiculos => _vehiculos;

    public Flota()
    {
        _vehiculos = new List<Vehiculo>();
    }

    public Flota(List<Vehiculo> vehiculos)
    {
        _vehiculos = vehiculos;
    }

    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        _vehiculos.Add(vehiculo);
    }

    /// <summary>
    /// Recorre la lista y llama a MostrarInformacion de cada vehículo.
    /// Gracias al polimorfismo se ejecuta la versión de Automovil o Camion.
    /// </summary>
    public void MostrarFlota()
    {
        if (_vehiculos.Count == 0)
        {
            Console.WriteLine("La flota no tiene vehículos registrados.");
            return;
        }

        for (int i = 0; i < _vehiculos.Count; i++)
        {
            Console.WriteLine($"--- Vehículo N° {i + 1} ---");
            _vehiculos[i].MostrarInformacion();
            Console.WriteLine();
        }
    }
}
