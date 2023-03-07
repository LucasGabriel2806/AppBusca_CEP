using AppBusca_CEP.Model;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;


namespace AppBusca_CEP.Service
{
    public class DataService
    {
        // Método GetEnderecoByCep            
        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco end;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/endereco/by-cep?cep=" + cep);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return end;
        }

        public static async Task<List<Cidade>> GetCidadesByEstado(string uf)
        {
            List<Cidade> arr_cidades = new List<Cidade>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(
                    "https://cep.metoda.com.br/cidade/by-uf?uf=" + uf);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_cidades = JsonConvert.DeserializeObject<List<Cidade>>(json);

                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return arr_cidades;
        }

        /*
         Obtem a lista de logradouros (ruas) de um bairro.
        */
        public static async Task<List<Logradouro>> GetLogradourosByBairroAndIdCidade(string bairro, int id_cidade)
        {
            List<Logradouro> arr_logradouros = new List<Logradouro>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/logradouro/by-bairro?id_cidade=" + id_cidade + "&bairro=" + bairro);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_logradouros = JsonConvert.DeserializeObject<List<Logradouro>>(json);

                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return arr_logradouros;
        }

        /*
        Obtem o CEP de um logradouro
        */
        public static async Task<List<Cep>> GetCepsByLogradouro(string logradouro)
        {
            List<Cep> arr_ceps = new List<Cep>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(
                    "https://cep.metoda.com.br/cep/by-logradouro?logradouro=" + logradouro);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_ceps = JsonConvert.DeserializeObject<List<Cep>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return arr_ceps;
        }


        /*
         Obtem as cidades da uf
         */
        public static async Task<List<Cidade>> GetCidadesByUF(int uf)
        {
            List<Cidade> arr_cidades = new List<Cidade>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/cidade/by-uf?uf=" + uf);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_cidades = JsonConvert.DeserializeObject<List<Cidade>>(json);

                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return arr_cidades;
        }




        // Método GetBairrosByIdCidade                   
        public static async Task<List<Bairro>> GetBairrosByIdCidade(int id_cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/bairro/by-cidade?id_cidade=" + id_cidade);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);

                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return arr_bairros;
        }




        /*
            https://cep.metoda.com.br/endereco/by-cep?cep=17210580
            https://cep.metoda.com.br/logradouro/by-bairro?id_cidade=4874&bairro=Jardim
            https://cep.metoda.com.br/cep/by-logradouro?logradouro=Rua Raphael de Almeida Leite
            https://cep.metoda.com.br/cidade/by-uf?uf=SP
            https://cep.metoda.com.br/bairro/by-cidade?id=4874
         */

    }
}
