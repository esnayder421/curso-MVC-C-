using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using CapaNegocio;
using CapaEntidad;

//los datos vienen de CAPA DE NEGOCIO

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> oLista = new List<Usuario>();

             oLista = new CN_Usuarios().Listar();

                
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarUsuario(Usuario objeto)
        {
            object resultado; // permite guardar cualquier tipo de valor 
            string mensaje = string.Empty;

            if (objeto.IdUsuario == 0)
            {
                // llamamos la capa de negocio y instanciamos la clase registrar  
                resultado = new CN_Usuarios().Registrar(objeto, out mensaje);

            }
            else
            {
                resultado = new CN_Usuarios().Editar(objeto, out mensaje);

            }


            return Json(new {resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;


            respuesta = new CN_Usuarios().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



    }
}
