namespace AplicationProgrammingInterface.Clases
{
    public class ObjCliente
    {
        public string Nombres { get; set; } 
        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Contrasena { get; set; }

        public bool Estado { get; set; }


        public ObjCliente() { }
        public ObjCliente(string nombres, string direccion, string telefono, string contrasena, bool estado)
        { 
            this.Nombres = nombres;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Contrasena = contrasena;
            this.Estado = estado;
        
        }


    }
}
