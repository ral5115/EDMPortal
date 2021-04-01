namespace Dominio.Modelos
{
    public class ModeloClientesBonos
    {
        public int RowId { get; set; }
        public string IdCentroOperacion { get; set; }
        public string DescripcionCentroOperacion { get; set; }
        public string TipoDocumento { get; set; }
        public string Consecutivo { get; set; }
        public string Valor { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string FechaPedido { get; set; }
        public string CantidadBonos { get; set; }
        public string ValorBonos { get; set; }
        public string ConjuntoBonos { get; set; }
        public string UltimoBono { get; set; }
        public string Html { get; set; }
        public string Resultado { get; set; }
        public bool Usado { get; set; }
    }
}
