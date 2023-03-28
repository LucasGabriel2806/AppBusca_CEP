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
    public partial class EnderecoPorCep : ContentPage
    {
        public EnderecoPorCep()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            btnBuscar.IsEnabled = false;
            carregando.IsRunning = true;
            try
            {
                //end = await DataService.GetEnderecoByCep(txt_endereco.Text);
                lst_endereco.ItemsSource = new List<Endereco>();
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

        private void btnBuscar_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}