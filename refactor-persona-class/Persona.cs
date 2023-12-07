using System;

public class Persona {
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Direccion { get; set; }

    public void MostrarDatos( ) {
        Console.WriteLine( $"Nombre: {Nombre} Edad: {Edad} Dirección: {Direccion}" );
    }

    public void CalcularIMC( ) {
        const int Peso = 75;
        const int Altura = 180;

        float imc = ( float ) Peso / ( Altura * Altura );
        Console.WriteLine( $"IMC: {imc}" );
    }

    public void ActualizarDatos( ) {
        // Obtiene los datos del usuario
        Console.WriteLine( "Introduce tu nombre:" );
        Nombre = Console.ReadLine( );

        Console.WriteLine( "Introduce tu edad:" );
        Edad = int.Parse( Console.ReadLine( ) );

        Console.WriteLine( "Introduce tu dirección:" );
        Direccion = Console.ReadLine( );
    }
}