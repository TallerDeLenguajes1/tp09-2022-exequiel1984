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

for (int i = 0; i < CantidadProductosACrear; i++)
{
    producto producto = CrearProducto();
    CargarProductoALista(producto, ListaProductos);    
}

string NombreNuevoArchivoJson = "ListaProductos.json";

CrearYEscribirArchivoJson(ListaProductos, NombreNuevoArchivoJson);

string NombreArchivoJson = NombreNuevoArchivoJson;

var ListaProductosDesdeArchivoJson = new List<producto>();

ListaProductosDesdeArchivoJson = DeserealizarArchivoJson(NombreArchivoJson);

MostrarLista(ListaProductosDesdeArchivoJson);



static producto CrearProducto()
{
    Random rand = new Random();

        var NuevoProducto = new producto();

        int IndexNombre = rand.Next(0, Enum.GetValues(typeof(NombresProductos)).Length);
        NuevoProducto.Nombre = Enum.GetName(typeof(NombresProductos), IndexNombre);

        NuevoProducto.FechaVencimiento = new DateTime(rand.Next(2022, 2025), rand.Next(01, 13), rand.Next(01, 32));
        NuevoProducto.Precio = rand.Next(1000, 5001);

        int IndexTamanio = rand.Next(0, Enum.GetValues(typeof(TamanioProductos)).Length);
        NuevoProducto.Tamanio = Enum.GetName(typeof(TamanioProductos), IndexTamanio);

        return(NuevoProducto);
}

static void CargarProductoALista(producto producto, List<producto> Lista){
    Lista.Add(producto);
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

static List<producto> DeserealizarArchivoJson(string NombreArchivoJson)
{
    string StringADeserealizar;
    using (var archivoOpen = new FileStream(NombreArchivoJson, FileMode.Open))
    {
        using (var strReader = new StreamReader(archivoOpen))
        {
            StringADeserealizar = strReader.ReadToEnd();
            archivoOpen.Close();
        }
    }

    var ListaDeserealizada = JsonSerializer.Deserialize<List<producto>>(StringADeserealizar);
    return ListaDeserealizada;
}

static void MostrarLista(List<producto> Lista)
{
    foreach (var producto in Lista)
    {
        System.Console.WriteLine("Nombre: " + producto.Nombre);
        System.Console.WriteLine("Fecha de vencimiento: " + producto.FechaVencimiento.ToShortDateString());
        System.Console.WriteLine("Precio: $" + producto.Precio);
        System.Console.WriteLine("Tamaño: " + producto.Tamanio + "\n");

    }
}