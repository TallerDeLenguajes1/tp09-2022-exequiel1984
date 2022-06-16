using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using tp092022exequiel1984;




/* Console.WriteLine("Ingrese el directorio:");
string path = Console.ReadLine();

List<string> ListadodeCarpetasEnDirectorio = Directory.GetFiles(path).ToList();
List<string> archivos=new List<string>();

Console.WriteLine("\nCarpetas en repositorio " + path + "\n");

GuardarEnLista(ListadodeCarpetasEnDirectorio, archivos);

string Json = JsonSerializer.Serialize(archivos);

//File.WriteAllText("index.json", Json);

using (var archivo = new FileStream("index.json", FileMode.Create))
{
    using (var strWriter = new StreamWriter(archivo))
    {
        strWriter.WriteLine("{0}", Json);
        strWriter.Close();
    }
}

static void GuardarEnLista(List<string> ListadodeCarpetasEnDirectorio, List<string> archivos)
{
    foreach (var archivo in ListadodeCarpetasEnDirectorio)
    {
        Console.WriteLine(archivo);
        archivos.Add(Path.GetFileNameWithoutExtension(archivo) + Path.GetExtension(archivo));
    }
} */

int CantidadProductosACrear;
Random rand = new Random();
CantidadProductosACrear = rand.Next(1, 5);

var ListaProductos = new List<producto>();

CrearProducto(CantidadProductosACrear, ListaProductos);

//Creo y escribo el archivo Json

string NombreNuevoArchivoJson = "ListaProductos.json";

CrearYEscribirArchivoJson(ListaProductos, NombreNuevoArchivoJson);

string documento;
using (var archivoOpen = new FileStream(NombreNuevoArchivoJson, FileMode.Open))
{
    using (var strReader = new StreamReader(archivoOpen))
    {
        documento = strReader.ReadToEnd();
        archivoOpen.Close();
    }
}

var ListadoJson = JsonSerializer.Deserialize<List<producto>>(documento);

foreach (var producto in ListadoJson)
{
    System.Console.WriteLine("Nombre: " + producto.Nombre);
    System.Console.WriteLine("Fecha de vencimiento: " + producto.FechaVencimiento.ToShortDateString());
    System.Console.WriteLine("Precio: $" + producto.Precio);
    System.Console.WriteLine("Tamaño: " + producto.Tamanio + "\n");

}






static void CrearProducto(int cantidad, List<producto> ListaProductos)
{

    Random rand = new Random();

    for (int i = 0; i < cantidad; i++)
    {
        var producto = new producto();

        int IndexNombre = rand.Next(0, Enum.GetValues(typeof(NombresProductos)).Length);
        producto.Nombre = Enum.GetName(typeof(NombresProductos), IndexNombre);

        producto.FechaVencimiento = new DateTime(rand.Next(2022, 2025), rand.Next(01, 13), rand.Next(01, 32));
        producto.Precio = rand.Next(1000, 5001);

        int IndexTamanio = rand.Next(0, Enum.GetValues(typeof(TamanioProductos)).Length);
        producto.Tamanio = Enum.GetName(typeof(TamanioProductos), IndexTamanio);

        ListaProductos.Add(producto);
    }
}

static void CrearYEscribirArchivoJson(List<producto> Lista, string NombreNuevoArchivoJson)
{
    string ListaSerealizada = JsonSerializer.Serialize(Lista);

    using (var NuevoArchivoJson = new FileStream(NombreNuevoArchivoJson, FileMode.Create))
    {
        using (var strWriter = new StreamWriter(NuevoArchivoJson))
        {
            strWriter.WriteLine("{0}", ListaSerealizada);
            strWriter.Close();
        }
    }
}