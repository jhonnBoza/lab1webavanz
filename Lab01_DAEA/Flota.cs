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

        // Acceso de solo lectura para el menú del programa principal
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
                Console.WriteLine("\n--> No hay vehículos registrados en la flota.");
                return;
            }

            Console.WriteLine("\n===========================================================================================");
            Console.WriteLine("                            LISTA DE VEHICULOS DE LA FLOTA                                 ");
            Console.WriteLine("===========================================================================================");

            for (int i = 0; i < listaVehiculos.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                listaVehiculos[i].MostrarInformacion(); // Enlace dinámico / Polimorfismo
            }

            Console.WriteLine("===========================================================================================\n");
        }
    }
}
