using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Frontend.Models;

namespace Frontend.Utils
{
    public class Api
    {
        private readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        private readonly string ApiUrl = "https://localhost:7015/api";

        #region Cliente
        public async Task<Cliente> GetCliente(int id)
        {
            WebResponse response;
            string endPoint = $"{ApiUrl}/Cliente/{id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception)
            {
                throw;
            }

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                var end = await ProcessResponse<Cliente>(response);
                return end;
            }
            else
            {
                throw new Exception("Não foi possivel buscar o cliente.");
            }
        }

        public async Task<List<Cliente>> GetClientes()
        {
            WebResponse response;
            string endPoint = $"{ApiUrl}/Cliente";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception)
            {
                throw;
            }

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                var end = await ProcessResponse<List<Cliente>>(response);
                return end;
            }
            else
            {
                throw new Exception("Não foi possivel buscar o cliente.");
            }
        }
        public async Task<Cliente> PostCliente(Cliente data, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}/Cliente"))
            {
                await SetContent(data, requestMessage);

                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Cliente>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }

        public async Task<Cliente> PutCliente(int id, Cliente data, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}/Cliente/{id}"))
            {
                await SetContent(data, requestMessage);

                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Cliente>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }

        public async Task<Cliente> DeleteCliente(int id, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}/Cliente/{id}"))
            {
                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Cliente>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }

        #endregion

        #region Veiculo
        public async Task<Veiculo> GetVeiculo(int id)
        {
            WebResponse response;
            string endPoint = $"{ApiUrl}/Veiculo/{id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception)
            {
                throw;
            }

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                var end = await ProcessResponse<Veiculo>(response);
                return end;
            }
            else
            {
                throw new Exception("Não foi possivel buscar o veículo");
            }
        }

        public async Task<List<Veiculo>> GetVeiculo()
        {
            WebResponse response;
            string endPoint = $"{ApiUrl}/Veiculo";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception)
            {
                throw;
            }

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                var end = await ProcessResponse<List<Veiculo>>(response);
                return end;
            }
            else
            {
                throw new Exception("Não foi possivel buscar o veículo");
            }
        }
        public async Task<Veiculo> PostVeiculo(Veiculo data, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}/Veiculo"))
            {
                await SetContent(data, requestMessage);

                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Veiculo>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }

        public async Task<Veiculo> PutVeiculo(int id, Veiculo data, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}/Veiculo/{id}"))
            {
                await SetContent(data, requestMessage);

                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Veiculo>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }

        public async Task<Veiculo> DeleteVeiculo(int id, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}/Veiculo/{id}"))
            {
                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Veiculo>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }
        #endregion

        #region Locacao
        public async Task<Locacao> GetLocacao(int id)
        {
            WebResponse response;
            string endPoint = $"{ApiUrl}/Locacao/{id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception)
            {
                throw;
            }

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                var end = await ProcessResponse<Locacao>(response);
                return end;
            }
            else
            {
                throw new Exception("Não foi possivel buscar a locacão.");
            }
        }

        public async Task<List<Locacao>> GetLocacao()
        {
            WebResponse response;
            string endPoint = $"{ApiUrl}/Locacao";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception)
            {
                throw;
            }

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                var end = await ProcessResponse<List<Locacao>>(response);
                return end;
            }
            else
            {
                throw new Exception("Não foi possivel buscar a locação.");
            }
        }
        public async Task<Locacao> PostLocacao(Locacao data, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}/Locacao"))
            {
                await SetContent(data, requestMessage);

                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Locacao>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }
        

        public async Task<Locacao> DeleteLocacao(int id, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}/Locacao/{id}"))
            {
                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Locacao>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }
        #endregion


        private async Task SetContent(object data, HttpRequestMessage requestMessage)
        {
            if (data != null)
            {
                var content = await Task.FromResult(JsonConvert.SerializeObject(data, JsonSettings)).ConfigureAwait(false);
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }
        }

        private async Task<T> ProcessResponse<T>(WebResponse response)
        {
            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var data = readStream.ReadToEnd();
                receiveStream.Dispose();
                readStream.Dispose();
                return await Task.FromResult(JsonConvert.DeserializeObject<T>(data, JsonSettings)).ConfigureAwait(false);
            }
            throw new Exception("Não foi possível fazer a consulta. Tente novamente.");
        }
    }
}
