using System;
using System.Collections.Generic;

public class TituloLibro {
    public string Nombre { get; set; }
    public int PrestamosHistoricos { get; set; }
    public string ISBN { get; set; }
    public List<string> CodigosEjemplares { get; set; } = new List<string>();
}

public class Biblioteca {
    public List<TituloLibro> Catalogo = new List<TituloLibro>();

    public void CargarDatos() {
        Catalogo.Add(new TituloLibro { Nombre = "Cien años de soledad", PrestamosHistoricos = 10, ISBN = "978-01", CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "1984", PrestamosHistoricos = 5, ISBN = "978-05", CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Fahrenheit 451", PrestamosHistoricos = 5, ISBN = "978-03", CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Crónicas marcianas", PrestamosHistoricos = 5, ISBN = "978-04", CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Un mundo feliz", PrestamosHistoricos = 12, ISBN = "978-02", CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "El Aleph", PrestamosHistoricos = 2, ISBN = "978-08", CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Rayuela", PrestamosHistoricos = 7, ISBN = "978-07", CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Pedro Páramo", PrestamosHistoricos = 8, ISBN = "978-06", CodigosEjemplares = new List<string>{"Ej1"} });
    }

    public void OrdenarPorInsercion() {
        for (int i = 1; i < Catalogo.Count; i++) {
            TituloLibro actual = Catalogo[i];
            int j = i - 1;
            while (j >= 0 && (Catalogo[j].PrestamosHistoricos < actual.PrestamosHistoricos || (Catalogo[j].PrestamosHistoricos == actual.PrestamosHistoricos && string.Compare(Catalogo[j].Nombre, actual.Nombre) > 0))) {
                Catalogo[j + 1] = Catalogo[j];
                j--;
            }
            Catalogo[j + 1] = actual;
        }
    }

    public void BusquedaSecuencial(string tituloBuscado) {
        foreach (var libro in Catalogo) {
            if (libro.Nombre.ToLower() == tituloBuscado.ToLower()) {
                Console.WriteLine($"[Secuencial] Encontrado: {libro.Nombre} | Ejemplares: {libro.CodigosEjemplares.Count}");
                return;
            }
        }
        Console.WriteLine($"[Secuencial] El libro '{tituloBuscado}' no fue encontrado.");
    }

    public void BusquedaBinariaPorISBN(string isbnBuscado) {
        List<TituloLibro> copiaOrdenada = new List<TituloLibro>(Catalogo);
        for (int i = 1; i < copiaOrdenada.Count; i++) {
            TituloLibro actual = copiaOrdenada[i];
            int j = i - 1;
            while (j >= 0 && string.Compare(copiaOrdenada[j].ISBN, actual.ISBN) > 0) {
                copiaOrdenada[j + 1] = copiaOrdenada[j];
                j--;
            }
            copiaOrdenada[j + 1] = actual;
        }

        int inicio = 0, fin = copiaOrdenada.Count - 1;
        while (inicio <= fin) {
            int medio = inicio + (fin - inicio) / 2;
            int comparacion = string.Compare(copiaOrdenada[medio].ISBN, isbnBuscado);

            if (comparacion == 0) {
                Console.WriteLine($"[Binaria] Encontrado ISBN {isbnBuscado}: {copiaOrdenada[medio].Nombre} | Ejemplares: {copiaOrdenada[medio].CodigosEjemplares.Count}");
                return;
            } else if (comparacion < 0) {
                inicio = medio + 1;
            } else {
                fin = medio - 1;
            }
        }
        Console.WriteLine($"[Binaria] ISBN '{isbnBuscado}' no encontrado.");
    }
}