namespace Dominio.Modelos
{
    public class ModeloReferido
    {
        public int RowId { get; set; }
        public int RowIdEmpleado { get; set; }
        public long Documento { get; set; }
        public string Empleado { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Usado { get; set; }
    }
}
