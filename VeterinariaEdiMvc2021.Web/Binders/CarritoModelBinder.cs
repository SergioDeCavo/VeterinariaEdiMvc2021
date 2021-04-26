using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Web.Binders
{
    public class CarritoModelBinder:IModelBinder
    {
        private const string sessionkey = "eVeterinaria";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Carrito carrito = null;

            if (controllerContext.HttpContext.Session[sessionkey] != null)
            {
                carrito = (Carrito)controllerContext.HttpContext.Session[sessionkey];
            }

            if (carrito == null)
            {
                carrito = new Carrito();

                if (controllerContext.HttpContext.Session[sessionkey] == null)
                {
                    controllerContext.HttpContext.Session[sessionkey] = carrito;
                }
            }

            return carrito;
        }
    }
}