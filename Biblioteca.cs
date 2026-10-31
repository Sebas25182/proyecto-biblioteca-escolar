C#
using System;
using System.Collections.Generic;

public class Biblioteca {
    public List<string> Catalogo = new List<string>();

    public void RegistrarPrestamo(string libro) {
        Console.WriteLine("Préstamo registrado para: " + libro);
    }
}