# Lab01 - DAEA: POO en C# (Flota Vehicular)

Examen de Programación Orientada a Objetos en C#.
**Desarrollo de Aplicaciones Web Avanzado — 6 - C24 - Sección C - D**

## Estructura del proyecto

```
Lab01_DAEA/
├── Vehiculo.cs    # Clase base (Marca, Modelo, Año) + método virtual
├── Automovil.cs   # Clase derivada (Combustible)
├── Camion.cs      # Clase derivada (CapacidadCarga)
├── Flota.cs       # Colección List<Vehiculo> + MostrarFlota()
└── Program.cs     # Programa principal con menú de opciones
```

## Conceptos aplicados

| Pilar POO | Dónde se aplica |
|---|---|
| Encapsulamiento | Campos privados con propiedades públicas en `Vehiculo` |
| Herencia | `Automovil` y `Camion` heredan de `Vehiculo` usando `: base(...)` |
| Polimorfismo | `MostrarInformacion()` y `CalcularCostoViaje()` con `virtual` / `override` |
| Abstracción | `Flota` depende de `Vehiculo`, no de las clases concretas |

## Menú del programa

1. Mostrar información de vehículos
2. Calcular costo de viaje (se elige el vehículo y se ingresa la distancia)
3. Salir

## Ejecución

```bash
cd Lab01_DAEA
dotnet run
```

## Requisitos

- .NET SDK 10.0
- Visual Studio 2022 o superior
