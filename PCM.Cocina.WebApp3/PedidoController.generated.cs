// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace PCM.Cocina.WebApp3.Controllers
{
    public partial class PedidoController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public PedidoController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected PedidoController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CrearPedido()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CrearPedido);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult AtenderPedido()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AtenderPedido);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public PedidoController Actions { get { return MVC.Pedido; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Pedido";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Pedido";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string RegistrarPedido = "RegistrarPedido";
            public readonly string ListarPedidos = "ListarPedidos";
            public readonly string CrearPedido = "CrearPedido";
            public readonly string AtenderPedido = "AtenderPedido";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string RegistrarPedido = "RegistrarPedido";
            public const string ListarPedidos = "ListarPedidos";
            public const string CrearPedido = "CrearPedido";
            public const string AtenderPedido = "AtenderPedido";
        }


        static readonly ActionParamsClass_CrearPedido s_params_CrearPedido = new ActionParamsClass_CrearPedido();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CrearPedido CrearPedidoParams { get { return s_params_CrearPedido; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CrearPedido
        {
            public readonly string Cantidad = "Cantidad";
            public readonly string cbMenu = "cbMenu";
        }
        static readonly ActionParamsClass_AtenderPedido s_params_AtenderPedido = new ActionParamsClass_AtenderPedido();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AtenderPedido AtenderPedidoParams { get { return s_params_AtenderPedido; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AtenderPedido
        {
            public readonly string CodigoPedido = "CodigoPedido";
        }
        static readonly ActionParamsClass_ListarPedidos s_params_ListarPedidos = new ActionParamsClass_ListarPedidos();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ListarPedidos ListarPedidosParams { get { return s_params_ListarPedidos; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ListarPedidos
        {
            public readonly string jtStartIndex = "jtStartIndex";
            public readonly string jtPageSize = "jtPageSize";
            public readonly string jtSorting = "jtSorting";
            public readonly string texto = "texto";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string EditarHuesped = "EditarHuesped";
                public readonly string ListarPedidos = "ListarPedidos";
                public readonly string RegistrarPedido = "RegistrarPedido";
            }
            public readonly string EditarHuesped = "~/Views/Pedido/EditarHuesped.cshtml";
            public readonly string ListarPedidos = "~/Views/Pedido/ListarPedidos.cshtml";
            public readonly string RegistrarPedido = "~/Views/Pedido/RegistrarPedido.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_PedidoController : PCM.Cocina.WebApp3.Controllers.PedidoController
    {
        public T4MVC_PedidoController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void RegistrarPedidoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult RegistrarPedido()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RegistrarPedido);
            RegistrarPedidoOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ListarPedidosOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ListarPedidos()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListarPedidos);
            ListarPedidosOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CrearPedidoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int Cantidad, int cbMenu);

        [NonAction]
        public override System.Web.Mvc.ActionResult CrearPedido(int Cantidad, int cbMenu)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CrearPedido);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Cantidad", Cantidad);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cbMenu", cbMenu);
            CrearPedidoOverride(callInfo, Cantidad, cbMenu);
            return callInfo;
        }

        [NonAction]
        partial void AtenderPedidoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int CodigoPedido);

        [NonAction]
        public override System.Web.Mvc.ActionResult AtenderPedido(int CodigoPedido)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AtenderPedido);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "CodigoPedido", CodigoPedido);
            AtenderPedidoOverride(callInfo, CodigoPedido);
            return callInfo;
        }

        [NonAction]
        partial void ListarPedidosOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int jtStartIndex, int jtPageSize, string jtSorting, string texto);

        [NonAction]
        public override System.Web.Mvc.ActionResult ListarPedidos(int jtStartIndex, int jtPageSize, string jtSorting, string texto)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListarPedidos);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "jtStartIndex", jtStartIndex);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "jtPageSize", jtPageSize);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "jtSorting", jtSorting);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "texto", texto);
            ListarPedidosOverride(callInfo, jtStartIndex, jtPageSize, jtSorting, texto);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114