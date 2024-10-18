
using caserandomuser.Models;
using Newtonsoft.Json;

namespace caserandomuser.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ApiResponse> ObterRespostaApiAsync(string id)
        {
            string url = $"https://randomuser.me/api/?results={id}";

            try
            {
                HttpResponseMessage responseApi = await _httpClient.GetAsync(url);

                if (responseApi.IsSuccessStatusCode)
                {
                    var responseApiContent = await responseApi.Content.ReadAsStringAsync();

                    ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseApiContent);

                    return apiResponse;
                }
                else
                {
                    throw new Exception("Erro no retorno da resposta: " + responseApi.StatusCode);
                }
            }

            catch (HttpRequestException httpEx)
            {
                throw new Exception($"Erro ao acessar a Api: {httpEx.Message}");
            }

            catch (JsonException jsonEx)
            {
                throw new Exception($"Erro ao Deserializar a resposta: {jsonEx.Message}");
            }

            catch (Exception ex)
            {
                throw new Exception($"Erro inexperado: {ex.Message}");
            }
        }
    }
}