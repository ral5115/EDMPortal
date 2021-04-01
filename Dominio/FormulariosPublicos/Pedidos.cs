using System.Data;

namespace Dominio.FormulariosPublicos
{
    public class Pedidos
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();

        public DataSet Nacional()
        {
            return _BDConsultar.Query("Sp_PedidosNacional");
        }

        public DataSet Internacional()
        {
            return _BDConsultar.Query("Sp_PedidosInternacional");
        }
    }
}
