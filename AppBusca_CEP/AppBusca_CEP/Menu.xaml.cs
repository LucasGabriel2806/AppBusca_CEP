using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBusca_CEP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Cep por logradouro
            Navigation.PushAsync(
                new View.BuscaCepPorLogradouro());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //Cidades por uf
            Navigation.PushAsync(
                new View.CidadesPorUf());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            //Ruas de bairro por cidade
            Navigation.PushAsync(
                new View.BairrosPorCidade());

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            //Logradouros por bairro
            Navigation.PushAsync(
                new View.LogradouroPorBairro());
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            //Endereço por cep
            Navigation.PushAsync(
                new View.EnderecoPorCep());

        }
    }
}