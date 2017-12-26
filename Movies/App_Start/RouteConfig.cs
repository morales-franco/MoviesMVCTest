using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Movies
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Las rutas custom se colocan en orden de prioridades 
            //Singular to General

            //http://localhost:52616/movies/Released todo las url que arranquen asi /movies/released las atrapa este filtro
            //http://localhost:52616/movies/Released/1/2 OK sin las restricciones
            //http://localhost:52616/movies/Released/ 404 por mas que el action method tenga default values 
            //si en el default de este patrón de rutas especificamos default values entonces esta ruta sera valida
            //defaults: new { Controller = "Movies", action = "ByReleaseDate", month = 90, year=100 });
            //http://localhost:52616/movies/Released/01/2018 valido

            routes.MapRoute("dateFilterMovie", //debe ser unique
                url: "movies/released/{month}/{year}", //url: formato esperado en el browser
                defaults: new { Controller = "Movies", action = "ByReleaseDate" },
                constraints: new { year =  @"2017|2018", month =@"\d{2}" }); //Constraints month solo 2 digitos - años permitidos: 2017/2018


            //Lo malo de lo anterior es que si cambias el nombre del metodo ByReleaseDate en el controller y te olvidas de cambiarlo
            //aca no va a funcar. Para evitar esto no tenemos que usar "magicString" 
            //Podemos configurar la ruta directamente en el actionMethod --> Para esto tenemos que usar AttributesRoutes
            //ejemplo de ruta en movies/released2
            routes.MapMvcAttributeRoutes();


            //http://localhost:52616/movies/ByReleaseDate la captura este filtro
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
