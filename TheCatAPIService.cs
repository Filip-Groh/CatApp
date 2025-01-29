using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CatApp {
    public class Weight {
        public string? imperial { get; set; }
        public string? metric { get; set; } 
    }

    public class Breed {
        public Weight? weight { get; set; }
        public string? id { get; set; }
        public string? name { get; set; }
        public string? temperament {  get; set; }
        public string? origin { get; set; }
        public string? country_codes { get; set; }
        public string? country_code { get; set; }
        public string? life_span { get; set; }
        public string? wikipedia_url { get; set; }
    }

    public class Cat {
        public string? id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string? url { get; set; }
        public List<Breed>? breeds { get; set; }
    }

    public enum Size {
        Thumb,
        Small,
        Medium,
        Full
    }

    public class TheCatAPIService {
        HttpClient client;
        JsonSerializerOptions options;

        public static TheCatAPIService Current = new TheCatAPIService();

        public TheCatAPIService() {
            client = new HttpClient();
            options = new JsonSerializerOptions() {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Current = this;
        }

        public string Deserialize<T>(T obj) {
            return JsonSerializer.Serialize(obj, options);
        }

        public async Task<List<Cat>?> GetCatsAsync(int limit, bool include_breeds, Size size) {
            string sizeParam = size switch {
                Size.Thumb => "thumb",
                Size.Small => "small",
                Size.Medium => "med",
                Size.Full => "full",
                _ => ""
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://api.thecatapi.com/v1/images/search?limit={limit}&size={sizeParam}&has_breeds={(include_breeds ? 1 : 0)}");
            request.Headers.Add("x-api-key", "live_7F0IMZgDBdauHzOTSc22KQQbIiYqN12v3OYJgPd1HMkdU8VtMn4rvQtrIiwXrGSE");

            StringContent content = new StringContent(string.Empty);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Content = content;

            try {
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode) {
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Cat>>(data, options);
                }
            } catch (Exception ex) {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }
    }
}
