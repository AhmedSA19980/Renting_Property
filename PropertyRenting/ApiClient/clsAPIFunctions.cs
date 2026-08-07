using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using Models;

using PropertyRenting.ClassGlobal;



namespace ApiClient
{
    public  class  clsAPIFunctions<T>
    {

        private static string GetMimeType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                default:
                    return "application/octet-stream";
            }
        }


        private static readonly HttpClient _httpClient = new HttpClient();
        private const string ApiUrl = "https://localhost:7042/api/";

        static clsAPIFunctions() {
            _httpClient.BaseAddress = new Uri(ApiUrl);
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void  setAuthorizationToken( string token) {
        
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" , token);  
        
        }

        public static async Task<T> getUserData()
        {
            if (string.IsNullOrEmpty(clsGlobal.CurrentUser.AccessToken))
            {
                throw new InvalidOperationException("Access token not found. User must log in first.");
            }

         
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", clsGlobal.CurrentUser.AccessToken);
                var response = await _httpClient.GetAsync("UserData/data");


                if (response.IsSuccessStatusCode)
                {
                    // Read the JSON string from the response
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON string into a UserData object
                    return JsonConvert.DeserializeObject<T>(jsonResponse);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);
                }
                else
                {
                    return default(T);
                }
            
        }
        // Call this method on logout.
        public static void ClearAuthorizationToken()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }



        public static async Task<T> GetAsync(string subUrl , int ID)
        {
            
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            clsAPIFunctions<T>.EnsureAuthorization();
            HttpResponseMessage Response = await _httpClient.GetAsync($"{subUrl}{ID}");

                if (Response.IsSuccessStatusCode)
                {
                    string json =  await Response.Content.ReadAsStringAsync();
                   
                    if(typeof(T) == typeof(int))
                    {
                        return (T)Convert.ChangeType(Convert.ToString(json), typeof(T));
                    }else  return JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    Console.WriteLine($"Error: {Response.StatusCode}");
                    return default(T);
                }
        }
        public static async Task<T> GetAsync(string subUrl, string ID= "")
        {
          
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           
                string IsIDProvidedToUrl = string.IsNullOrEmpty(ID) ? $"{subUrl}" : $"{subUrl}{ID}";
            clsAPIFunctions<T>.EnsureAuthorization();
            HttpResponseMessage Response = await _httpClient.GetAsync($"{IsIDProvidedToUrl}");

                if (Response.IsSuccessStatusCode)
                {
                    string json = await Response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);

                }
                else
                {
                    string ErrorContent = await Response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {Response.StatusCode};  Content{ErrorContent}");
                return default(T);


                }

          
           
        }

        public class Result<T>
        {

            public T Value { get; }
            public string Error { get; }
            public bool IsSuccess => Error == null;

            private Result(T value, string error)
            {

                this.Value = value;
                this.Error = error;
            }

            public static Result<T> Success(T value) => new Result<T>(value , null);
            public static Result<T> Failed(string error) => new Result<T>(default, error);

        }
        public static async Task<Result<T>> GetAsync2(string subUrl)
        {

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            clsAPIFunctions<T>.EnsureAuthorization();

            HttpResponseMessage Response = await _httpClient.GetAsync($"{subUrl}");

            if (Response.IsSuccessStatusCode)
            {
                string json = await Response.Content.ReadAsStringAsync();
                return Result<T>.Success( JsonConvert.DeserializeObject<T>(json));
            }
            else
            {
                string ErrorContent = await Response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {Response.StatusCode}");
                return Result<T>.Failed($"Error: {Response.StatusCode} - {ErrorContent}");
            }
        }

        public static async Task<T> PostAsync(string subUrl, object Data)
        {

             _httpClient.DefaultRequestHeaders.Accept.Clear();
             _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

          
            string json = JsonConvert.SerializeObject(Data);  
                
                var content = new StringContent(json , System.Text.Encoding.UTF8 , "application/json");

           clsAPIFunctions<T>.EnsureAuthorization();

             var Response = await _httpClient.PostAsync($"{subUrl}" , content);

                     
                if (Response.IsSuccessStatusCode)
                {
                    string responseJson = await Response.Content.ReadAsStringAsync();
                Console.WriteLine($"DEBUG RAW RESPONSE for {subUrl}: {responseJson}");
                return JsonConvert.DeserializeObject<T>(responseJson);

                }
                else
                {
                    //Console.WriteLine($"Error: {Response.StatusCode}");
                    string ErrorContent = await Response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {Response.StatusCode};  Content{ErrorContent}");
                    return default(T);
                }


        }
        
        public static void EnsureAuthorization()
        {
            if (clsGlobal.CurrentUser != null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", clsGlobal.CurrentUser.AccessToken);
            else return;
        }




        public static async Task<T> PutAsync(string subUrl ,  object Data)
        {
          

            try
            {

                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = null;

                if (Data != null)// addedd
                {
                    string json = JsonConvert.SerializeObject(Data);
                     content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                }

                //  UriBuilder url = new UriBuilder(ApiUrl);
                //url.Path += $"{subUrl}";
                // string RequestUrl = url.ToString();
                    EnsureAuthorization();
                    var Response = await _httpClient.PutAsync($"{subUrl}", content);

                    if (!Response.IsSuccessStatusCode)
                    {
                        

                        string ErrorContent = await Response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error: {Response.StatusCode};  Content{ErrorContent}");

                        throw new HttpRequestException($"HTTP request failed with status code {Response.StatusCode}: {ErrorContent}");
                    }
                    else
                    {
                    string responseJson = await Response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(responseJson);

                    }

                
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request exception: {ex.Message}");
                return default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General exception: {ex.Message}");
                return default(T);
            }
        }


        public static async Task<T> PutMediaAsync(string subUrl ,int ID, Models.Container Data)
        {
            
            try
            {
                  //  object formData = Data;
                   using (var formData = new MultipartFormDataContent())
                    {                                               
                        formData.Add(new StringContent(Data.ToString()), "containerID");

                        async Task AddImageFromPath(string imagePath, string fieldName)
                        {
                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                try
                                {
                                    byte[] fileBytes = await File.ReadAllBytesAsync(imagePath);
                                var memoryStream = new MemoryStream(fileBytes);
                                //var fileStream = File.OpenRead(imagePath);
                                var streamContent = new StreamContent(memoryStream);
                                    string mimeType = GetMimeType(imagePath);
                                    streamContent.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
                                    formData.Add(streamContent, fieldName, Path.GetFileName(imagePath));
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine($"Error reading image file at {imagePath}: {ex.Message}");
                                    // Optionally handle this error (e.g., skip the file or throw an exception)
                                }
                            }
                        }

                        // Add each image from the Container object's paths
                        await AddImageFromPath(Data.ImageOnePath, "ImageOne");
                        await AddImageFromPath(Data.ImageTwoPath, "ImageTwo");
                        await AddImageFromPath(Data.ImageThreePath, "ImageThree");
                        await AddImageFromPath(Data.ImageFourPath, "ImageFour");
                        await AddImageFromPath(Data.ImageFivePath, "ImageFive");
                        await AddImageFromPath(Data.ImageSixPath, "ImageSix");
                        await AddImageFromPath(Data.ImageSevenPath, "ImageSeven");
                        await AddImageFromPath(Data.ImageEightPath, "ImageEight");
                        await AddImageFromPath(Data.ImageNinePath, "ImageNine");

                    clsAPIFunctions<T>.EnsureAuthorization();
                    HttpResponseMessage Response = await _httpClient.PutAsync($"{subUrl}{ID}", formData);



                        if (Response.IsSuccessStatusCode)
                        {
                            string responseJson = await Response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<T>(responseJson);

                        }
                        else
                        {
                            string ErrorContent = await Response.Content.ReadAsStringAsync();
                            Console.WriteLine($"Error: {Response.StatusCode};  Content{ErrorContent}");

                            throw new HttpRequestException($"HTTP request failed with status code {Response.StatusCode}: {ErrorContent}");

                           
                        }

                    }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request exception: {ex.Message}");
                return default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General exception: {ex.Message}");
                return default(T);
            }
        }

        public static async Task<T> AddMediaAsync(string subUrl,  Models.Container Data)
        {
           
            try
            {
               
                    //  object formData = Data;
                    using (var formData = new MultipartFormDataContent())
                    {

                        formData.Add(new StringContent(Data.ToString()), "containerID");



                        async Task AddImageFromPath(string imagePath, string fieldName)
                        {
                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                try
                                {
                                    var fileStream = File.OpenRead(imagePath);
                                    var streamContent = new StreamContent(fileStream);
                                    string mimeType = GetMimeType(imagePath);
                                    streamContent.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
                                    formData.Add(streamContent, fieldName, Path.GetFileName(imagePath));
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine($"Error reading image file at {imagePath}: {ex.Message}");
                                    // Optionally handle this error (e.g., skip the file or throw an exception)
                                }
                            }
                        }

                        // Add each image from the Container object's paths
                        await AddImageFromPath(Data.ImageOnePath, "ImageOne");
                        await AddImageFromPath(Data.ImageTwoPath, "ImageTwo");
                        await AddImageFromPath(Data.ImageThreePath, "ImageThree");
                        await AddImageFromPath(Data.ImageFourPath, "ImageFour");
                        await AddImageFromPath(Data.ImageFivePath, "ImageFive");
                        await AddImageFromPath(Data.ImageSixPath, "ImageSix");
                        await AddImageFromPath(Data.ImageSevenPath, "ImageSeven");
                        await AddImageFromPath(Data.ImageEightPath, "ImageEight");
                        await AddImageFromPath(Data.ImageNinePath, "ImageNine");

                    clsAPIFunctions<T>.EnsureAuthorization();

                    HttpResponseMessage Response = await _httpClient.PostAsync($"{subUrl}", formData);



                        if (Response.IsSuccessStatusCode)
                        {
                            string responseJson = await Response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<T>(responseJson);

                        }
                        else
                        {
                            string ErrorContent = await Response.Content.ReadAsStringAsync();
                            Console.WriteLine($"Error: {Response.StatusCode};  Content{ErrorContent}");

                            throw new HttpRequestException($"HTTP request failed with status code {Response.StatusCode}: {ErrorContent}");

                            //return default(T);
                        }

                    }
                
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request exception: {ex.Message}");
                return default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General exception: {ex.Message}");
                return default(T);
            }
        }


        public static async Task<T> DeleteAsync(string subUrl, int Data)
        {




            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            // _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            clsAPIFunctions<T>.EnsureAuthorization();
            HttpResponseMessage Response = await _httpClient.DeleteAsync($"{subUrl}{Data}");

                if (Response.IsSuccessStatusCode)
                {
                    string responseJson = await Response.Content.ReadAsStringAsync();

                    if(typeof(T) == typeof(string))
                    {
                        return (T)Convert.ChangeType(Convert.ToString(responseJson), typeof(T));
                    }
                    return JsonConvert.DeserializeObject<T>(responseJson);

                }
                else
                {
                    Console.WriteLine($"Error: {Response.StatusCode}");
                    return default(T);
                }


            
        }
    }
}
