using System;
using System.Collections.Generic;

public class TituloLibro {
    public string Nombre { get; set; }
    public int PrestamosHistoricos { get; set; }
    public List<string> CodigosEjemplares { get; set; } = new List<string>();
}

public class Biblioteca {
    public List<TituloLibro> Catalogo = new List<TituloLibro>();

    public void CargarDatos() {
        Catalogo.Add(new TituloLibro { Nombre = "Cien años de soledad", PrestamosHistoricos = 10, CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "1984", PrestamosHistoricos = 5, CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Fahrenheit 451", PrestamosHistoricos = 5, CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Crónicas marcianas", PrestamosHistoricos = 5, CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Un mundo feliz", PrestamosHistoricos = 12, CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "El Aleph", PrestamosHistoricos = 2, CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Rayuela", PrestamosHistoricos = 7, CodigosEjemplares = new List<string>{"Ej1"} });
        Catalogo.Add(new TituloLibro { Nombre = "Pedro Páramo", PrestamosHistoricos = 8, CodigosEjemplares = new List<string>{"Ej1"} });
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
}