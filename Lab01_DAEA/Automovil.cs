namespace Lab01_DAEA;

// Clase Derivada: Automovil
internal class Automovil : Vehiculo
{
    // Propiedad Adicional (Parte 1)
    public string Combustible { get; private set; }

    // Constructor usando 'base' para reutilizar inicialización (Parte 1)
    public Automovil(string marca, string modelo, int anio, string combustible)
        : base(marca, modelo, anio)
    {
        Combustible = combustible;
    }

    // Sobrescritura del Método (Parte 2)
    public override void MostrarInformacion()
    {
        Console.WriteLine("Tipo   : Automóvil");
        base.MostrarInformacion();
        Console.WriteLine($"Combustible : {Combustible}");
    }
}
