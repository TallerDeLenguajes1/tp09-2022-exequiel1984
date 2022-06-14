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

var producto1 = new producto();



var ListaProductos = new List<producto>();
CrearProducto(producto1, ListaProductos);

string Json = JsonSerializer.Serialize(ListaProductos);

using (var archivo = new FileStream("ListaProductos.json", FileMode.Create))
{
    using (var strWriter = new StreamWriter(archivo))
    {
        strWriter.WriteLine("{0}", Json);
        strWriter.Close();
    }
}

string documento;
              using (var archivoOpen = new FileStream("ListaProductos.Json", FileMode.Open))
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
    System.Console.WriteLine(producto.Nombre);
}







static void CrearProducto(producto producto, List<producto> ListaProductos){

    Random rand = new Random();

    int prod=rand.Next(0,Enum.GetValues(typeof(NombresProductos)).Length);

    producto.Nombre =Enum.GetName(typeof(NombresProductos),prod);
    producto.FechaVencimiento=

    ListaProductos.Add(producto);
            
}

