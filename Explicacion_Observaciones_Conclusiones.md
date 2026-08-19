# Explicación, Observaciones y Conclusiones

## Explicación Técnica de la Solución

**Herencia (Parte 1).** Se definió la clase base `Vehiculo` con los atributos comunes a
cualquier unidad de transporte (`Marca`, `Modelo`, `Anio`), declarados como campos privados
y expuestos mediante propiedades públicas para respetar el encapsulamiento. Las clases
`Automovil` y `Camion` extienden de `Vehiculo`, heredando dichos atributos e incorporando
los suyos propios (`Combustible` y `CapacidadCarga` respectivamente). En los constructores
derivados se empleó la instrucción `: base(...)` para reutilizar la lógica de inicialización
de la clase padre en lugar de duplicarla.

**Polimorfismo y métodos virtuales (Parte 2).** El método `MostrarInformacion()` se declaró
como `virtual` en `Vehiculo`, lo que permite que `Automovil` y `Camion` usen `override` para
aportar su propia implementación. Ambas versiones invocan `base.MostrarInformacion()` antes
de imprimir su dato exclusivo, evitando repetir el bloque de impresión común. El mismo
mecanismo se aplicó a `CalcularCostoViaje(double)`, donde cada tipo de vehículo define su
propia fórmula de costo (rendimiento por galón del automóvil frente al consumo y recargo por
tonelaje del camión).

**Colecciones heterogéneas (Parte 3).** La clase `Flota` mantiene una colección de tipo
`List<Vehiculo>`. Al recorrerla desde `MostrarFlota()`, el CLR resuelve en tiempo de
ejecución (*late binding*) qué implementación de `MostrarInformacion()` corresponde según la
instancia real almacenada, logrando un comportamiento polimórfico sin validaciones de tipo.
El programa principal utiliza esa misma lista para el menú interactivo, de modo que la
información mostrada y el cálculo del costo de viaje operan siempre sobre los mismos datos.

## Observaciones

1. **Reutilización de código mediante herencia.** Al concentrar las propiedades comunes
   (`Marca`, `Modelo`, `Anio`) en la clase base, las clases derivadas evitaron por completo la
   duplicación de código. Cada subclase administra únicamente el atributo que le es propio, lo
   que produjo una estructura modular y fácil de extender.

2. **Polimorfismo en tiempo de ejecución.** Al sobrescribir `MostrarInformacion()` con
   `virtual` / `override`, la lista `List<Vehiculo>` de la clase `Flota` ejecuta la versión
   específica del método según la instancia real, sin necesidad de comparar tipos con `is`,
   `as` o `switch`.

3. **Encapsulamiento con propiedades de escritura privada.** Declarar los campos como
   `private` y exponer propiedades con `private set` garantiza que el estado del vehículo solo
   pueda establecerse desde el constructor, protegiendo la integridad del objeto una vez creado.

4. **Invocación explícita del constructor base.** El uso de `: base(...)` en `Automovil` y
   `Camion` asegura que la inicialización del estado heredado ocurra de forma previa y
   ordenada, antes de asignar las propiedades exclusivas de la clase hija.

5. **Validación de la entrada del usuario.** En el cálculo del costo de viaje se emplearon
   `int.TryParse` y `double.TryParse` en lugar de `Convert.ToInt32`, evitando excepciones no
   controladas cuando el usuario ingresa un valor no numérico o una distancia negativa.

6. **Top-level statements en C# moderno.** Las versiones actuales de .NET permiten omitir el
   *boilerplate* tradicional (`namespace`, `class Program`, `static void Main`), lo que resultó
   en un `Program.cs` más limpio y centrado en la lógica del menú.

## Conclusiones

1. **Modelado orientado a objetos escalable.** La aplicación correcta de los pilares de la POO
   permite que el sistema de flota sea fácilmente extensible: incorporar un nuevo tipo de
   unidad (por ejemplo, `Motocicleta` o `Bus`) solo requiere crear una clase que herede de
   `Vehiculo` y sobrescribir sus métodos, sin modificar la clase `Flota` ni el programa
   principal. Esto evidencia el cumplimiento del principio abierto/cerrado.

2. **Reducción del acoplamiento mediante abstracción.** `Flota` no conoce las
   implementaciones concretas de `Automovil` ni `Camion`, sino únicamente la abstracción
   `Vehiculo`. Esta dependencia hacia el tipo base disminuye el acoplamiento del sistema y
   facilita su mantenimiento a largo plazo.

3. **Optimización del control de flujo con polimorfismo.** El polimorfismo elimina la
   necesidad de estructuras condicionales repetitivas para verificar el tipo de objeto antes de
   mostrar sus datos o calcular su costo; esa responsabilidad se delega al diseño de clases, lo
   que reduce la complejidad ciclomática del programa principal.

4. **Sustitución de Liskov aplicada en la práctica.** Almacenar objetos `Automovil` y `Camion`
   dentro de una misma `List<Vehiculo>` y operarlos de forma uniforme confirma que las clases
   derivadas pueden sustituir a la clase base sin alterar el comportamiento esperado del sistema.

5. **Organización modular del proyecto.** Separar cada clase en su propio archivo mejora la
   legibilidad, el mantenimiento y el trabajo colaborativo mediante Git, ya que facilita el
   rastreo de los cambios realizados sobre cada entidad del dominio.

6. **Separación de responsabilidades.** La solución distingue claramente tres capas:
   `Program.cs` gestiona la interacción con el usuario (entrada/salida), `Flota` administra la
   colección de datos, y `Vehiculo` junto a sus derivadas concentran la lógica del dominio.
