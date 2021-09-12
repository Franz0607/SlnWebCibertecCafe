using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WebCibertecCafe.Models
{
    public class Carrito
    {
        public int ID { get; set; }

        [Display(Name = "Producto")]
        public string NAME { get; set; }

        [Display(Name = "Imagen")]
        public string IMAGE { get; set; }

        [Display(Name = "Precio")]
        public decimal PRECIO { get; set; }

        [Display(Name = "Cantidad")]
        public int CANTIDAD { get; set; }

        [Display(Name = "Importe")]
        public decimal IMPORTE { get {
                return PRECIO * CANTIDAD;
            } }

        public Carrito() { }

        public Carrito(int xID, string xNAME, int xCANTIDAD, decimal xPRECIO, string xIMAGE) {
            this.ID = xID;
            this.NAME = xNAME;
            this.CANTIDAD = xCANTIDAD;
            this.PRECIO = xPRECIO;
            this.IMAGE = xIMAGE;
        }
    }
}