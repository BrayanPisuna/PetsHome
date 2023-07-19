using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        string url;
        string secret;

        public Login(string url, string secret)
        {
            InitializeComponent();
            this.url = url;
            this.secret = secret;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {



            try
            {
                WebClient cliente = new WebClient();
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                Usuario user = new Usuario(lblUser.Text, lblPass.Text);

                string json = JsonConvert.SerializeObject(user);

                App.token = cliente.UploadString(this.url + "login", "POST", json).Replace("Bearer ", String.Empty);

                //var token = new  JwtSecurityToken(App.token);
                //new JwtSecurityToken(token);


                //var mensaje = "Dato ingresado con exito";
                //var tokenHandler = new JwtSecurityTokenHandler();
                //SecurityToken securityToken;
                //var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(this.secret));
                //var expiration = DateTime.UtcNow.AddHours(1);
                //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //var validationParameters = new TokenValidationParameters()
                //{
                //    ValidateLifetime = true,
                //    //ValidateIssuerSigningKey = true,
                //    ValidAudience = "mvc.manual",
                //    IssuerSigningKey = securityKey
                //};


                //var parametros = tokenHandler.ValidateToken(App.token, validationParameters, out securityToken);

                //var a=parametros;
                //DisplayAlert("ALERTA",parametros, "OK");

                //DependencyService.Get<Mensaje>().longAlert(mensaje);

                Navigation.PushAsync(new Validacion());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ok", ex.Message, "OK");
                //DependencyService.Get<Mensaje>().longAlert(ex.Message);
            }



        }
        private void ButtonCrear_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}