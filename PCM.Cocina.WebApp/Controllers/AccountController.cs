﻿using Microsoft.Owin.Security;
using Microsoft.Web.WebPages.OAuth;
using PCE.Cocina.Service.Lib.Contracts;
using PCE.Cocina.Service.Lib.Realizations;
using PCE.Cocina.ViewModel.ViewModels.UsuarioDTO;
using PCM.Cocina.Web.Models;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Security;

namespace PCM.Cocina.WebApp.Controllers
{ 
[Authorize]
public partial class AccountController : Controller
{
    //private ApplicationSignInManager _signInManager;
    //private ApplicationUserManager _userManager;
    private IUsuarioServices _accountServices = new UsuarioServices();

    public AccountController()
    {
    }

    //public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
    //{
    //    UserManager = userManager;
    //    SignInManager = signInManager;
    //}

    //public ApplicationSignInManager SignInManager
    //{
    //    get
    //    {
    //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
    //    }
    //    private set 
    //    { 
    //        _signInManager = value; 
    //    }
    //}

    //public ApplicationUserManager UserManager
    //{
    //    get
    //    {
    //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //    }
    //    private set
    //    {
    //        _userManager = value;
    //    }
    //}

    //
    // GET: /Account/Login
    [AllowAnonymous]
    public virtual ActionResult Login(string returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    //
    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public virtual async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        //if (!ModelState.IsValid)
        //{
        //    return View(model);
        //}

        //// No cuenta los errores de inicio de sesión para el bloqueo de la cuenta
        //// Para permitir que los errores de contraseña desencadenen el bloqueo de la cuenta, cambie a shouldLockout: true
        //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        //switch (result)
        //{
        //    case SignInStatus.Success:
        //        return RedirectToLocal(returnUrl);
        //    case SignInStatus.LockedOut:
        //        return View("Lockout");
        //    case SignInStatus.RequiresVerification:
        //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        //    case SignInStatus.Failure:
        //    default:
        //        ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
        //        return View(model);
        //}

        if (ModelState.IsValid == false)
        {
                //int tipoAutenticacion = Int32.Parse(ConfigurationManager.AppSettings["AuthenticationType"]);

                UsuarioDTO dto = new UsuarioDTO();
                dto.CodigoUsuario = 1;
                dto.Password = "123456";
                dto.Usuario = "cocinero";
                UsuarioDTO accountLoginDTO = dto;
                    //_accountServices.ObtenerUsuario(model.UserName);
                var usuario = HttpContext.Session["currentUser"];

            //accountLoginDTO.Code = "000";
            if (accountLoginDTO.Usuario != null)
            {
                //accountLoginDTO = _accountServices.VerificarContrasena(model.UserName, model.Password);
                if (accountLoginDTO.Usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);

                        UsuarioDTO loginDTO = dto; 
                            //_accountServices.(model.UserName);
                    LoginViewModel loginDTOEntry = new LoginViewModel();
                    loginDTOEntry.UserName = loginDTO.Usuario;
                    loginDTOEntry.NameIdentified = loginDTO.Usuario;
                    loginDTOEntry.CodigoUsuario = loginDTO.CodigoUsuario;

                    //loginDTOEntry.NombreCompleto = "Wilmer Romero Ampuero";
                    //loginDTOEntry.UserId = 32;
                    //loginDTOEntry.EstadoUsurio = "1";
                    HttpContext.Session["currentUser"] = loginDTOEntry;
                    /**/
                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;
                    authManager.SignOut("ApplicationCookie");
                    var user = loginDTOEntry;
                    var identity = new ClaimsIdentity();

                    identity = new ClaimsIdentity(new[]
         {
                                new Claim(ClaimTypes.Name, user.UserName),
                                new Claim(ClaimTypes.NameIdentifier, user.NameIdentified + "")

                            },
             "ApplicationCookie");
                    /**/
                    ctx = Request.GetOwinContext();
                    authManager = ctx.Authentication;
                    authManager.SignIn(identity);

                    if (this.Url.IsLocalUrl(returnUrl))
                    {
                        //return Redirect(returnUrl);
                        //return RedirectToAction("Solicitud", "Rendiciones");
                        return Redirect(returnUrl);
                    }
                    else
                    {

                        // return RedirectToAction("Solicitud", "Rendiciones");
                        return RedirectToAction("Index", "Home");
                        //return RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Verifique usuario y contraseña.");
            }
        }
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual ActionResult Disassociate(string provider, string providerUserId)
    {
        string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
        ManageMessageId? message = null;

        // Desasociar la cuenta solo si el usuario que ha iniciado sesión es el propietario
        if (ownerAccount == User.Identity.Name)
        {
            //// Usar una transacción para evitar que el usuario elimine su última credencial de inicio de sesión
            //using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOption { IsolationLevel = IsolationLevel.Serializable }))
            //{
            //    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            //    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
            //    {
            //        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
            //        scope.Complete();
            //        message = ManageMessageId.RemoveLoginSuccess;
            //    }
            //}
        }

        return RedirectToAction("Manage", new { Message = message });
    }

    public enum ManageMessageId
    {
        ChangePasswordSuccess,
        SetPasswordSuccess,
        RemoveLoginSuccess,
    }
    ////
    //// GET: /Account/VerifyCode
    //[AllowAnonymous]
    //public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
    //{
    //    // Requerir que el usuario haya iniciado sesión con nombre de usuario y contraseña o inicio de sesión externo
    //    if (!await SignInManager.HasBeenVerifiedAsync())
    //    {
    //        return View("Error");
    //    }
    //    return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
    //}

    ////
    //// POST: /Account/VerifyCode
    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return View(model);
    //    }

    //    // El código siguiente protege de los ataques por fuerza bruta a los códigos de dos factores. 
    //    // Si un usuario introduce códigos incorrectos durante un intervalo especificado de tiempo, la cuenta del usuario 
    //    // se bloqueará durante un período de tiempo especificado. 
    //    // Puede configurar el bloqueo de la cuenta en IdentityConfig
    //    var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
    //    switch (result)
    //    {
    //        case SignInStatus.Success:
    //            return RedirectToLocal(model.ReturnUrl);
    //        case SignInStatus.LockedOut:
    //            return View("Lockout");
    //        case SignInStatus.Failure:
    //        default:
    //            ModelState.AddModelError("", "Código no válido.");
    //            return View(model);
    //    }
    //}

    //
    // GET: /Account/Register
    [AllowAnonymous]
    public virtual ActionResult Register()
    {
        return View();
    }

    //
    //// POST: /Account/Register
    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> Register(RegisterViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    //        var result = await UserManager.CreateAsync(user, model.Password);
    //        if (result.Succeeded)
    //        {
    //            await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

    //            // Para obtener más información sobre cómo habilitar la confirmación de cuenta y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
    //            // Enviar correo electrónico con este vínculo
    //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
    //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
    //            // await UserManager.SendEmailAsync(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

    //            return RedirectToAction("Index", "Home");
    //        }
    //        AddErrors(result);
    //    }

    //    // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
    //    return View(model);
    //}

    ////
    //// GET: /Account/ConfirmEmail
    //[AllowAnonymous]
    //public async Task<ActionResult> ConfirmEmail(string userId, string code)
    //{
    //    if (userId == null || code == null)
    //    {
    //        return View("Error");
    //    }
    //    var result = await UserManager.ConfirmEmailAsync(userId, code);
    //    return View(result.Succeeded ? "ConfirmEmail" : "Error");
    //}

    //
    // GET: /Account/ForgotPassword
    [AllowAnonymous]
    public virtual ActionResult ForgotPassword()
    {
        return View();
    }

    //
    // POST: /Account/ForgotPassword
    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var user = await UserManager.FindByNameAsync(model.Email);
    //        if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
    //        {
    //            // No revelar que el usuario no existe o que no está confirmado
    //            return View("ForgotPasswordConfirmation");
    //        }

    //        // Para obtener más información sobre cómo habilitar la confirmación de cuenta y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
    //        // Enviar correo electrónico con este vínculo
    //        // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
    //        // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
    //        // await UserManager.SendEmailAsync(user.Id, "Restablecer contraseña", "Para restablecer la contraseña, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");
    //        // return RedirectToAction("ForgotPasswordConfirmation", "Account");
    //    }

    //    // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
    //    return View(model);
    //}

    //
    // GET: /Account/ForgotPasswordConfirmation
    [AllowAnonymous]
    public virtual ActionResult ForgotPasswordConfirmation()
    {
        return View();
    }

    //
    // GET: /Account/ResetPassword
    [AllowAnonymous]
    public virtual ActionResult ResetPassword(string code)
    {
        return code == null ? View("Error") : View();
    }
    [Authorize]
    public virtual ActionResult CustomDropDownMenu()
    {
        //var idApplication = Int32.Parse(ConfigurationManager.AppSettings["AplicacionIdentificador"]);
        //var accessByUser = _accesoServices.GetListAccesosByUser(User.Identity.Name, idApplication);
        return PartialView();
    }

    //
    // POST: /Account/ResetPassword
    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return View(model);
    //    }
    //    var user = await UserManager.FindByNameAsync(model.Email);
    //    if (user == null)
    //    {
    //        // No revelar que el usuario no existe
    //        return RedirectToAction("ResetPasswordConfirmation", "Account");
    //    }
    //    var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
    //    if (result.Succeeded)
    //    {
    //        return RedirectToAction("ResetPasswordConfirmation", "Account");
    //    }
    //    AddErrors(result);
    //    return View();
    //}

    //
    // GET: /Account/ResetPasswordConfirmation
    [AllowAnonymous]
    public virtual ActionResult ResetPasswordConfirmation()
    {
        return View();
    }

    //
    // POST: /Account/ExternalLogin
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public virtual ActionResult ExternalLogin(string provider, string returnUrl)
    {
        // Solicitar redireccionamiento al proveedor de inicio de sesión externo
        return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
    }

    //
    // GET: /Account/SendCode
    //[AllowAnonymous]
    //public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
    //{
    //    var userId = await SignInManager.GetVerifiedUserIdAsync();
    //    if (userId == null)
    //    {
    //        return View("Error");
    //    }
    //    var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
    //    var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
    //    return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
    //}

    //
    //// POST: /Account/SendCode
    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> SendCode(SendCodeViewModel model)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return View();
    //    }

    //    // Generar el token y enviarlo
    //    if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
    //    {
    //        return View("Error");
    //    }
    //    return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
    //}

    //
    // GET: /Account/ExternalLoginCallback
    //[AllowAnonymous]
    //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
    //{
    //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
    //    if (loginInfo == null)
    //    {
    //        return RedirectToAction("Login");
    //    }

    //    // Si el usuario ya tiene un inicio de sesión, iniciar sesión del usuario con este proveedor de inicio de sesión externo
    //    var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
    //    switch (result)
    //    {
    //        case SignInStatus.Success:
    //            return RedirectToLocal(returnUrl);
    //        case SignInStatus.LockedOut:
    //            return View("Lockout");
    //        case SignInStatus.RequiresVerification:
    //            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
    //        case SignInStatus.Failure:
    //        default:
    //            // Si el usuario no tiene ninguna cuenta, solicitar que cree una
    //            ViewBag.ReturnUrl = returnUrl;
    //            ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
    //            return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
    //    }
    //}

    ////
    // POST: /Account/ExternalLoginConfirmation
    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
    //{
    //    if (User.Identity.IsAuthenticated)
    //    {
    //        return RedirectToAction("Index", "Manage");
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        // Obtener datos del usuario del proveedor de inicio de sesión externo
    //        var info = await AuthenticationManager.GetExternalLoginInfoAsync();
    //        if (info == null)
    //        {
    //            return View("ExternalLoginFailure");
    //        }
    //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    //        var result = await UserManager.CreateAsync(user);
    //        if (result.Succeeded)
    //        {
    //            result = await UserManager.AddLoginAsync(user.Id, info.Login);
    //            if (result.Succeeded)
    //            {
    //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //                return RedirectToLocal(returnUrl);
    //            }
    //        }
    //        AddErrors(result);
    //    }

    //    ViewBag.ReturnUrl = returnUrl;
    //    return View(model);
    //}

    //
    // POST: /Account/LogOff
    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual ActionResult LogOff()
    {
        FormsAuthentication.SignOut();
        HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
        return RedirectToAction("Login", "Account");
    }

    //
    // GET: /Account/ExternalLoginFailure
    [AllowAnonymous]
    public virtual ActionResult ExternalLoginFailure()
    {
        return View();
    }

    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        if (_userManager != null)
    //        {
    //            _userManager.Dispose();
    //            _userManager = null;
    //        }

    //        if (_signInManager != null)
    //        {
    //            _signInManager.Dispose();
    //            _signInManager = null;
    //        }
    //    }

    //    base.Dispose(disposing);
    //}

    #region Aplicaciones auxiliares
    // Se usa para la protección XSRF al agregar inicios de sesión externos
    private const string XsrfKey = "XsrfId";

    private IAuthenticationManager AuthenticationManager
    {
        get
        {
            return HttpContext.GetOwinContext().Authentication;
        }
    }

    //private void AddErrors(IdentityResult result)
    //{
    //    foreach (var error in result.Errors)
    //    {
    //        ModelState.AddModelError("", error);
    //    }
    //}

    private ActionResult RedirectToLocal(string returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        return RedirectToAction("Index", "Home");
    }

    internal class ChallengeResult : HttpUnauthorizedResult
    {
        public ChallengeResult(string provider, string redirectUri)
            : this(provider, redirectUri, null)
        {
        }

        public ChallengeResult(string provider, string redirectUri, string userId)
        {
            LoginProvider = provider;
            RedirectUri = redirectUri;
            UserId = userId;
        }

        public string LoginProvider { get; set; }
        public string RedirectUri { get; set; }
        public string UserId { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
            if (UserId != null)
            {
                properties.Dictionary[XsrfKey] = UserId;
            }
            context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        }
    }
    #endregion
}
}