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
    public partial class CidadesPorUf : ContentPage
    {
        public CidadesPorUf()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            btnBuscar.IsEnabled = false;
            carregando.IsRunning = true;
            try
            {
                List<Cidade> arr_cidades = await DataService.GetCidadesByEstado(txt_uf.Text);

                lst_cidades.ItemsSource = arr_cidades;
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