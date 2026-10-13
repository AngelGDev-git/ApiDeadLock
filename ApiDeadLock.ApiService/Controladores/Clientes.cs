using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeadLock.ApiService.Controladores
{
    public class Clientes : Controller
    {

        //// POST: Clientes/Create
        //[HttpPost]
        //public IActionResult CrearCliente([FromBody] Modelo.Clientes cliente)
        //{
        //    try
        //    {
        //        if (cliente == null)
        //        {
        //            return BadRequest("Faovr especificar los datos de el cliente.");
        //        }
        //        else if (cliente.IdCliente <= 0)
        //        {
        //            return BadRequest("El Id del cliente debe ser mayor a cero.");
        //        }

        //        else if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Apellido) || string.IsNullOrEmpty(cliente.Direccion) || string.IsNullOrEmpty(cliente.Telefono))
        //        {
        //            return BadRequest("Todos los campos son obligatorios.");
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [ApiController]
        [Route("api/[controller]")]
        public class ClientesController : ControllerBase
        {
            private readonly Interfaces.IDataStore _dataStore;
            public ClientesController(Interfaces.IDataStore dataStore)
            {
                _dataStore = dataStore;
            }
            [HttpPost]
            public IActionResult RegistrarCliente([FromBody] Modelo.Clientes cliente)
            {
                if (cliente == null)
                {
                    return BadRequest("Favor especificar los datos del cliente.");
                }

                _dataStore.Clientes.Add(cliente);
                return CreatedAtAction(nameof(RegistrarCliente), new { id = cliente.IdCliente }, cliente);
            }

        }
        [ApiController]
        [Route("api/[controller]")]
        public class OrdenesController : ControllerBase
        {
            private readonly Interfaces.IDataStore _dataStore;
            public OrdenesController(Interfaces.IDataStore dataStore)
            {
                _dataStore = dataStore;
            }
            [HttpPost]
            public IActionResult RegistrarOrden([FromBody] Modelo.Orden_Productos producto)
            {
                if (producto == null)
                {
                    return BadRequest("Favor especificar los datos de la orden.");
                }
                _dataStore.OrdenProductos.Add(producto);
                return CreatedAtAction(nameof(RegistrarOrden), new { id = producto.IdOrden }, producto);

            }

            [HttpPut("{id}/productos/{IdItem}")]
            public IActionResult ActualizarCantidad(int idOrden, string idItem, [FromBody] int nuevacantidad)
            {
                var orden = _dataStore.Ordenes.FirstOrDefault(o => o.IdOrden == idOrden);
                if (orden == null)
                {
                    return NotFound("La orden no existe");
                }

                var producto = _dataStore.OrdenProductos.FirstOrDefault(p => p.IdItem == idItem);
                if (producto == null)
                {
                    return NotFound("El producto no existe");
                }

                 var productorebaja = _dataStore.OrdenProductos.FirstOrDefault(p => p.IdItem == idItem);
                int cantidadrestar = productorebaja.Cantidad - nuevacantidad;


                if (cantidadrestar <= 0)
                {
                    return BadRequest("No hay inventario suficiente");
                }
                _dataStore.OrdenProductos.Update(idOrden, idItem, nuevacantidad);
                return Ok();
            }
        }
    }
}
