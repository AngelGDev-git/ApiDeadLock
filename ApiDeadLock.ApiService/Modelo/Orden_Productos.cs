namespace ApiDeadLock.ApiService.Modelo
{
    public class Orden_Productos
    {
        public int IdOrden { get; set; }
        public string IdItem { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Total => Cantidad * Precio;

    }
}
