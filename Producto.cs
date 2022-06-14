namespace tp092022exequiel1984
{
    public enum NombresProductos{
        Galletas= 0,
        Chicles=1,
        Chocolate=2,
        Alfajor=3
    };

    public class producto {
        private string nombre;
        private DateTime fechaVencimiento;
        private float precio;
        private string tamanio;

        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Tamanio { get => tamanio; set => tamanio = value; }

        public producto(){
            Nombre ="";
            //FechaVencimiento = new DateTime(0,0,0);
            Precio = 0;
            Tamanio = "";
        }

        public producto(string _nombre, DateTime _fechaVencimiento, float _precio, string _tamanio){
            Nombre = _nombre;
            FechaVencimiento = _fechaVencimiento;
            Precio = _precio;
            Tamanio = _tamanio;
        }

        

    }
}