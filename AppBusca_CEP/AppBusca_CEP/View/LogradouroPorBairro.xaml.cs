using AppBusca_CEP.Model;
using AppBusca_CEP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBusca_CEP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogradouroPorBairro : ContentPage
    {
        public LogradouroPorBairro()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            btnBuscar.IsEnabled = false;
            carregando.IsRunning = true;
            try
            {
                List<Cep> arr_ceps = await DataService.GetCepsByLogradouro(txt_bairro.Text);

                lst_logradouros.ItemsSource = arr_ceps;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops!", ex.Message, "OK");
            }
            finally
            {
                carregando.IsRunning = false;
                btnBuscar.IsEnabled = true;
            }
        }
    }
}