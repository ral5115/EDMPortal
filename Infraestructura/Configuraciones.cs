namespace Infraestructura
{
    public class Configuraciones
    {
        public static WebServiceGTReal.wsGenerarPlano _WebServiceGTReal = new WebServiceGTReal.wsGenerarPlano();

        public static string Conexion = @"Data Source=10.10.21.5\EDMSQL;Initial Catalog=Integracion-VTEX-Portal;User ID=Intersol;Password=+1nt3rs0l";

        public static string RutaPlanoReal = @"C:\inetpub\wwwroot\GTIntegrationReal\Planos\";
    }
}
