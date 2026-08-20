namespace Lab01_DAEA
{
    internal class Flota
    {
        // Lista heterogénea de tipo Vehiculo (Parte 2)
        private List<Vehiculo> listaVehiculos;

        public Flota()
        {
            listaVehiculos = new List<Vehiculo>();
        }

        // Constructor que recibe una lista ya creada
        public Flota(List<Vehiculo> vehiculos)
        {
            listaVehiculos = vehiculos;
        }

        // Acceso de solo lectura para el programa principal
        public IReadOnlyList<Vehiculo> Vehiculos => listaVehiculos;

        // Método para registrar automóviles o camiones
        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            listaVehiculos.Add(vehiculo);
        }

        // Método polimórfico para listar vehículos (Parte 2)
        public void MostrarFlota()
        {
            if (listaVehiculos.Count == 0)
            {
                Console.WriteLine("\n--> No hay vehículos registrados en la flota.\n");
                return;
            }

            Console.WriteLine("\n===== FLOTA REGISTRADA =====");
            foreach (Vehiculo vehiculo in listaVehiculos)
            {
                vehiculo.MostrarInformacion(); // Enlace dinámico / Polimorfismo
                Console.WriteLine("----------------------------");
            }
            Console.WriteLine();
        }
    }
}
