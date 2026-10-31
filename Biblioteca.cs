using System;
using System.Collections.Generic;

public class Biblioteca {
    public List<string> Catalogo = new List<string>();
    public int LibrosDisponibles = 100;

    public void RegistrarPrestamo(string libro) {
        if (LibrosDisponibles > 0) {
            LibrosDisponibles--;
            Console.WriteLine("Préstamo registrado: " + libro + " (Quedan: " + LibrosDisponibles + ")");
        } else {
            Console.WriteLine("No hay ejemplares disponibles de " + libro);
        }
    }
}

public class Program {
    public static void Main() {
        Biblioteca miBiblioteca = new Biblioteca();
        Console.WriteLine("--- Simulación de 3 préstamos ---");
        miBiblioteca.RegistrarPrestamo("El Principito");
        miBiblioteca.RegistrarPrestamo("1984");
        miBiblioteca.RegistrarPrestamo("Cien años de soledad");
    }
}