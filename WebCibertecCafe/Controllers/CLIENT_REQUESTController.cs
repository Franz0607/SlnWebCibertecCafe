using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCibertecCafe.Models;
using System.Transactions;

using System.Net.Mail;

namespace WebCibertecCafe.Controllers
{
    public class CLIENT_REQUESTController : Controller
    {
        private CIBER_COFFEEEntities db = new CIBER_COFFEEEntities();

        // GET: CLIENT_REQUEST
        public ActionResult Index()
        {
            return RedirectToAction("Index", "PRODUCT_LETTER");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAMES,SURNAMES,MAIL,TEL_NUM")] CLIENT_REQUEST cLIENT_REQUEST)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        db.CLIENT_REQUEST.Add(cLIENT_REQUEST);
                        db.SaveChanges();

                        List<Carrito> listaCarrito = (List<Carrito>)Session["carrito"];

                        foreach (Carrito carrito in listaCarrito)
                        {
                            SALE_DETAIL detalle = new SALE_DETAIL();
                            detalle.ID_CLIENT = cLIENT_REQUEST.ID;
                            detalle.ID_PRODUCT = carrito.ID;
                            detalle.QUANTITY_PRODUCT = carrito.CANTIDAD;
                            detalle.TOTAL = carrito.PRECIO;
                            detalle.TOTAL_SALE = carrito.IMPORTE;

                            db.SALE_DETAIL.Add(detalle);
                        }
                        db.SaveChanges();

                        string body =
                           "<body>" +
                           "<h1>Resultado Coffee</h1>" +
                           "<p>Gracias por su preferencia </p>"+ cLIENT_REQUEST.NAMES + " " + cLIENT_REQUEST.SURNAMES +
                           "</body>";


                        using (MailMessage mail = new MailMessage()) {

                            //Cambiar el correo propio de usted o uno de prueba.
                            mail.From = new MailAddress("**************", "CafeShop");//Correo-TituloDelMensaje
                            mail.To.Add(new MailAddress(cLIENT_REQUEST.MAIL));
                            mail.Subject = "Detalle de pedidos";
                            mail.Body = body;
                            mail.IsBodyHtml = true;

                            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)) {

                                smtp.EnableSsl = true;
                                smtp.UseDefaultCredentials = false;
                                //Aqui se establece la el usuario y contraseña de su correo
                                //Se enviara el mensaje del detalle de forma automatica a los clientes.
                                smtp.Credentials = new NetworkCredential("************", "*************");//Correo-Contraseña
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                                smtp.Send(mail);
                            }    
                        }
                        scope.Complete();

                        Session["carrito"] = null;

                        return RedirectToAction("Index", "PRODUCT_LETTER");
                    }
                }
                catch (TransactionAbortedException)
                {
                    return RedirectToAction("ListCar", "PRODUCT_LETTER");
                }
            }

            return View(cLIENT_REQUEST);
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
