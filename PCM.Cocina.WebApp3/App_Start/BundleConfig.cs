using System.Web;
using System.Web.Optimization;

namespace PCM.Cocina.WebApp3
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                        "~/Scripts/chosen.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/commons").Include(
                        "~/Scripts/sapro_comunes.js")
                        .Include(
                        "~/Scripts/autoNumeric.js"));

            bundles.Add(new ScriptBundle("~/jqueryvalidationengine").Include(
                        "~/Scripts/ValidationEngine/jquery.validationEngine.js",
                        "~/Scripts/ValidationEngine/jquery.validationEngine-es.js"
                ));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //A partir d  aqui agregamos
            bundles.Add(new StyleBundle("~/Content/bbootstrap")
            .Include("~/Content/bootstrap.css")
             //  
             .Include("~/Content/bootstrap-responsive.css")
            );
            bundles.Add(new StyleBundle("~/Content/bootstrap-theme")
           .Include("~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome")
            .Include("~/Content/font-awesome.css").Include("~/Content/fontawesome-animation.css")
            ); bundles.Add(new StyleBundle("~/Content/custom-css")
            .Include("~/Content/custom-css.css")
            );



            bundles.Add(new StyleBundle("~/MenuIndexStyles").Include(
            "~/Scripts/jtable/themes/jqueryui/jtable_jqueryui.css",
            "~/Content/themes/base/jquery-ui.css",
            "~/Content/bootstrap-datetimepicker.min.css",
            "~/Content/DataTables/css/jquery.dataTables.css"
            ));

            bundles.Add(new StyleBundle("~/PedidoIndexStyles").Include(
           "~/Scripts/jtable/themes/jqueryui/jtable_jqueryui.css",
           "~/Content/themes/base/jquery-ui.css",
           "~/Content/bootstrap-datetimepicker.min.css",
           "~/Content/DataTables/css/jquery.dataTables.css"
           ));
            //bundles.Add(new StyleBundle("~/DetraccionesIndexStyles").Include(
            //"~/Scripts/jtable/themes/jqueryui/jtable_jqueryui.css",
            //"~/Content/themes/base/jquery-ui.css",
            //"~/Content/bootstrap-datetimepicker.min.css",
            //"~/Content/DataTables/css/jquery.dataTables.css"
            //));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker")
                .Include("~/Scripts/moment.js")
                .Include("~/Scripts/moment-with-locales.js")
                .Include("~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/datetimepicker")
                      .Include("~/Content/bootstrap-datetimepicker.css"));
            bundles.Add(new StyleBundle("~/Content/chosen")
                      .Include("~/Content/chosen.css"));

            /*Scripts*/


            bundles.Add(new ScriptBundle("~/MenuIndexScripts").Include(
          "~/Scripts/jquery-ui-1.9.2.js",
          "~/Scripts/jtable/jquery.jtable.js",
           "~/Scripts/jtable/extension/jquery.jtable.aspnetpagemethods.js",
            "~/Scripts/jtable/extension/jquery.jtable.aspnetpagemethods.min.js",
          "~/Scripts/jtable/localization/jquery.jtable.es.js",
          "~/Scripts/DataTables/jquery.dataTables.js",
          "~/Scripts/DataTables/dataTables.colReorder.min.js",
          "~/Scripts/gbl_comunes.js",
          "~/Scripts/ViewController/HuespedesViewController.js",
          "~/Scripts/ValidationEngine/jquery.validationEngine-es.js",
          "~/Scripts/ValidationEngine/jquery.validationEngine.js"

          ));

            bundles.Add(new ScriptBundle("~/PedidoIndexScripts").Include(
"~/Scripts/jquery-ui-1.9.2.js",
"~/Scripts/jtable/jquery.jtable.js",
"~/Scripts/jtable/extension/jquery.jtable.aspnetpagemethods.js",
"~/Scripts/jtable/extension/jquery.jtable.aspnetpagemethods.min.js",
"~/Scripts/jtable/localization/jquery.jtable.es.js",
"~/Scripts/DataTables/jquery.dataTables.js",
"~/Scripts/DataTables/dataTables.colReorder.min.js",
"~/Scripts/gbl_comunes.js",
"~/Scripts/ViewController/PedidoViewController.js",
"~/Scripts/ValidationEngine/jquery.validationEngine-es.js",
"~/Scripts/ValidationEngine/jquery.validationEngine.js"

));
        }
    }
}
