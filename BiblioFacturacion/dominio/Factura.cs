namespace Actividad02WebApiFacturacion.dominio
{
    public class Factura
    {
        public int NroFactura {  get; set; }
        public DateTime Fecha { get; set; }
        public FormasPago FormasPago { get; set; }
        public Cliente Cliente { get; set; }

        public List<DetalleFactura> Detalles { get; set; }

        public Factura()
        {
           Detalles = new List<DetalleFactura>();
        }

        public void AgregarDetalle(DetalleFactura detalle)
        {
            Detalles.Add(detalle);
        }

        public void BorrarDetalle(int index)
        {
            Detalles.RemoveAt(index);
        }
        public double Total()
        {
            double total = 0;
            foreach (DetalleFactura detalle in Detalles)
            {
                total += detalle.Subtotal();
            }
            return total;
        }

    }
}
