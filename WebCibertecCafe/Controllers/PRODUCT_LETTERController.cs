using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCibertecCafe.Models;

namespace WebCibertecCafe.Controllers
{
    public class PRODUCT_LETTERController : Controller
    {
        private CIBER_COFFEEEntities db = new CIBER_COFFEEEntities();
        List<Carrito> Lista;

        // GET: PRODUCT_LETTER
        public ActionResult Index()
        {
            if (Session["carrito"] is null) {
                Lista = new List<Carrito>();
                Session["carrito"] = Lista;
            }
            
            return View(db.PRODUCT_LETTER.ToList());
        }

        //Metodo
        public ActionResult AddCarShop(int id)
        {
            PRODUCT_LETTER producto = db.PRODUCT_LETTER.Find(id);

            Carrito carrito = new Carrito(id, producto.NAME, 1, producto.PRECIO, producto.IMAGE);

            Lista = (List<Carrito>)Session["carrito"];

            Carrito buscado = Lista.Find(x => x.ID == id);

            if (buscado is null)
            {
                Lista.Add(carrito);
            }
            else
            {
                buscado.CANTIDAD++;
            }

            Session["carrito"] = Lista;

            return RedirectToAction("ListCar");
        }

        public ActionResult ListCar(string mensaje) {

            Lista = (List<Carrito>)Session["carrito"];

            decimal xTOTAL = Lista.Sum(x => x.IMPORTE);
            ViewBag.total = xTOTAL;
            ViewBag.mensaje = mensaje;

            return View(Lista);
        }

        //Metodo
        public ActionResult DeleteItemCar(int id) {

            Lista = (List<Carrito>)Session["carrito"];

            Carrito car = Lista.Find(x => x.ID == id);
            Lista.Remove(car);

            Session["carrito"] = Lista;

            return RedirectToAction("ListCar");
        }

        //Metodo
        public ActionResult GoToPayment() {

            Lista = (List<Carrito>)Session["carrito"];

            if (Lista.Count is 0) {
                string mensaje = "Carrito de compra vacio.";
                return RedirectToAction("ListCar", new { mensaje = mensaje });
            }
            return RedirectToAction("Create", "CLIENT_REQUEST");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
