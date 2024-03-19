using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Isaac_Rivera.Modelos;
using System.Net.Http;
using System.Net;

namespace Isaac_Rivera
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Login log = new Login
            {
                Usuario= txtUsuario.Text,
                Contraseña=txtContraseña.Text,

            };
            Uri RequestUri = new Uri("https://www.test.com/api/Login_21");

            
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "aplication/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await Navigation.PushAsync(new Principal());
            }
            else
            {
                await DisplayAlert("Mensaje", "Datos invalidos", "OK");
            }

        }
    }
}
