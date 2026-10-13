namespace ApiDeadLock.ApiService.Interfaces
{
    public interface IDataStore
    {
        List<Modelo.Clientes> Clientes { get; }
        List<Modelo.Ordenes> Ordenes { get; }   
        List<Modelo.Orden_Productos> OrdenProductos { get; }

    }

    public class GuardandoEnMemoria : IDataStore
    {
        public List<Modelo.Clientes> Clientes { get; } = new();
        public List<Modelo.Ordenes> Ordenes { get; } = new();
        public List<Modelo.Orden_Productos> OrdenProductos { get; } = new();

        public GuardandoEnMemoria()
        {
            OrdenProductos.AddRange(new List<Modelo.Orden_Productos>
            {
                new Modelo.Orden_Productos { IdOrden = 1, IdItem = "A001", Descripcion = "Agua", Cantidad = 2, Precio = 10 },
                new Modelo.Orden_Productos { IdOrden = 1, IdItem = "A002", Descripcion = "Refresco", Cantidad = 1, Precio = 30},
                new Modelo.Orden_Productos { IdOrden = 2, IdItem = "A003", Descripcion = "Aceite", Cantidad = 3, Precio = 200 }
            });
        }

    }
}
