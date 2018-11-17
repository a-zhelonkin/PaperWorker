//using System.Collections.Generic;
//using Microsoft.Owin.Security.Jwt
//
//namespace Front.Global.Auth
// {
//     /// <summary>
//     /// Настройки для JWT Cookie авторизации
//     /// </summary>
//     public class JwtBearerCookieAuthenticationOptions : JwtBearerAuthenticationOptions
//     {
//         public JwtBearerCookieAuthenticationOptions()
//         {
//             AuthTokenCookieName = string.Empty;
//             UseRedirectToLogin = false;
//             LoginPage = "/";
//             RedirectExceptions = new string[] { };
//         }
//
//         /// <summary>
//         /// Имя куки, в которой содержится токен авторизации
//         /// </summary>
//         public string AuthTokenCookieName { get; set; }
//
//         /// <summary>
//         /// Редиректить ли на страницу логина, если пользователь не авторизован
//         /// </summary>
//         public bool UseRedirectToLogin { get; set; }
//
//         /// <summary>
//         /// Адрес страницы логина
//         /// </summary>
//         public string LoginPage { get; set; }
//
//         /// <summary>
//         /// Список частей адреса запроса, при обнаружении которых, редиректа на страницу логина не происходит (возврат 401)
//         /// </summary>
//         public IEnumerable<string> RedirectExceptions { get; set; }
//     }
//
// }