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

    public void MedirBusquedasBinarias() {
        // 1. Crear copia y ordenar por ISBN (Inserción)
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

        // 2. Preparar arreglo para Array.BinarySearch
        string[] arrayISBNs = new string[copiaOrdenada.Count];
        for(int i = 0; i < copiaOrdenada.Count; i++) {
            arrayISBNs[i] = copiaOrdenada[i].ISBN;
        }

        // 3. Consultas de prueba (4 existentes, 1 inexistente)
        string[] consultas = { "978-01", "978-05", "978-08", "978-04", "978-99" };

        Console.WriteLine("\n--- TABLA DE COMPARACIONES (BÚSQUEDA BINARIA) ---");
        Console.WriteLine("{0,-10} | {1,-22} | {2,-20}", "ISBN", "Comparaciones (Propia)", "Resultado Array.BinarySearch");
        Console.WriteLine(new string('-', 60));

        foreach (var isbn in consultas) {
            int comparaciones = BusquedaBinariaPropiaConContador(copiaOrdenada, isbn);
            
            // Verificación con método nativo de C#
            int indiceArray = Array.BinarySearch(arrayISBNs, isbn);
            string resultadoNativo = indiceArray >= 0 ? "Encontrado" : "No encontrado";
            
            Console.WriteLine("{0,-10} | {1,-22} | {2,-20}", isbn, comparaciones, resultadoNativo);
        }
    }

    private int BusquedaBinariaPropiaConContador(List<TituloLibro> lista, string isbnBuscado) {
        int inicio = 0, fin = lista.Count - 1;
        int contador = 0;
        
        while (inicio <= fin) {
            contador++;
            int medio = inicio + (fin - inicio) / 2;
            int comparacion = string.Compare(lista[medio].ISBN, isbnBuscado);

            if (comparacion == 0) return contador; // Encontrado
            if (comparacion < 0) inicio = medio + 1;
            else fin = medio - 1;
        }
        return contador; // No encontrado
    }
}

public class Program {
    public static void Main() {
        Biblioteca biblio = new Biblioteca();
        biblio.CargarDatos();
        biblio.MedirBusquedasBinarias();
    }
}