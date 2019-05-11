using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Mobile_AAPZ
{
#pragma warning disable // Disable all warnings

        [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
        public partial class APIClient
        {
            private string _baseUrl = "https://aapz-backend.conveyor.cloud";
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

            public APIClient()
            {
                _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() =>
                {
                    var settings = new Newtonsoft.Json.JsonSerializerSettings();
                    UpdateJsonSerializerSettings(settings);
                    return settings;
                });
            }

            public string BaseUrl
            {
                get { return _baseUrl; }
                set { _baseUrl = value; }
            }

            protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

            partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
            partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
            partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
            partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task PostAsync(RegistrationViewModel model)
            {
                return PostAsync(model, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task PostAsync(RegistrationViewModel model, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Account");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(model, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                return;
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<string> Post2Async(CredentialsViewModel credentials)
            {
                return Post2Async(credentials, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<string> Post2Async(CredentialsViewModel credentials, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Auth/login");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(credentials, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                string[] words = responseData_.Split(new char[] { '"' });

                                return words[7];
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                            //var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            //throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                                return "";
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
                return "";
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Building>> GetBuildingsListAsync()
            {
                return GetBuildingsListAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Building>> GetBuildingsListAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Building/GetBuildingsList");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<Building>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Building>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<Building>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Building> GetBuildingByIdAsync(int id)
            {
                return GetBuildingByIdAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Building> GetBuildingByIdAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Building/GetBuildingById/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Building);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Building>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Building);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Building> CreateBuildingAsync(Building building)
            {
                return CreateBuildingAsync(building, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Building> CreateBuildingAsync(Building building, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Building/CreateBuilding");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(building, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Building);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Building>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Building);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Building> UpdateBuildingAsync(Building building)
            {
                return UpdateBuildingAsync(building, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Building> UpdateBuildingAsync(Building building, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Building/UpdateBuilding");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(building, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Building);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Building>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Building);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Building> DeleteBuildingAsync(int id)
            {
                return DeleteBuildingAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Building> DeleteBuildingAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Building/DeleteBuilding/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Building);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Building>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Building);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Client>> GetClientsListAsync()
            {
                return GetClientsListAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Client>> GetClientsListAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Client/GetClientsList");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<Client>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Client>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<Client>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Client> GetClientByIdAsync(int? id)
            {
                return GetClientByIdAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Client> GetClientByIdAsync(int? id, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Client/GetClientById/{id}?");
                if (id != null)
                {
                    urlBuilder_.Append("id=").Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Client);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Client>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Client);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Client> CreateClientAsync(Client client)
            {
                return CreateClientAsync(client, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Client> CreateClientAsync(Client client, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Client/CreateClient");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(client, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Client);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Client>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Client);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Client> UpdateClientAsync(Client client)
            {
                return UpdateClientAsync(client, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Client> UpdateClientAsync(Client client, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Client");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(client, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Client);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Client>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Client);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Client> DeleteClientAsync(int? id)
            {
                return DeleteClientAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Client> DeleteClientAsync(int? id, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Client/DeleteClient/{id}?");
                if (id != null)
                {
                    urlBuilder_.Append("id=").Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Client);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Client>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Client);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Equipment>> GetEquipmentsListAsync()
            {
                return GetEquipmentsListAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Equipment>> GetEquipmentsListAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Equipment/GetEquipmentsList");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var
                                item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<Equipment>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Equipment>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<Equipment>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Equipment> GetEquipmentByIdAsync(int id)
            {
                return GetEquipmentByIdAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Equipment> GetEquipmentByIdAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Equipment/GetEquipmentById/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Equipment);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Equipment>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Equipment);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Equipment> CreateEquipmentAsync(Equipment equipment)
            {
                return CreateEquipmentAsync(equipment, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Equipment> CreateEquipmentAsync(Equipment equipment, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Equipment/CreateEquipment");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(equipment, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Equipment);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Equipment>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Equipment);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Equipment> UpdateEquipmentAsync(Equipment equipment)
            {
                return UpdateEquipmentAsync(equipment, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Equipment> UpdateEquipmentAsync(Equipment equipment, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Equipment/UpdateEquipment");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(equipment, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Equipment);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Equipment>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Equipment);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Equipment> DeleteEquipmentAsync(int id)
            {
                return DeleteEquipmentAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Equipment> DeleteEquipmentAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Equipment/DeleteEquipment/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Equipment);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Equipment>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Equipment);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Landlord>> GetLandlordsListAsync()
            {
                return GetLandlordsListAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Landlord>> GetLandlordsListAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Landlord/GetLandlordsList");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<Landlord>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Landlord>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<Landlord>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Landlord> GetLandlordByIdAsync(int id)
            {
                return GetLandlordByIdAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Landlord> GetLandlordByIdAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Landlord/GetLandlordById/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Landlord);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Landlord>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Landlord);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Landlord> CreateLandlordAsync(Landlord landlord)
            {
                return CreateLandlordAsync(landlord, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Landlord> CreateLandlordAsync(Landlord landlord, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Landlord/CreateLandlord");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(landlord, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Landlord);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Landlord>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Landlord);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Landlord> UpdateLandlordAsync(Landlord landlord)
            {
                return UpdateLandlordAsync(landlord, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Landlord> UpdateLandlordAsync(Landlord landlord, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Landlord/UpdateLandlord");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(landlord, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Landlord);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Landlord>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Landlord);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Landlord> DeleteLandlordAsync(int id)
            {
                return DeleteLandlordAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Landlord> DeleteLandlordAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Landlord/DeleteLandlord/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Landlord);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Landlord>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Landlord);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<double> CalculateRecommendedTableHeightAsync(int clientId)
            {
                return CalculateRecommendedTableHeightAsync(clientId, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<double> CalculateRecommendedTableHeightAsync(int clientId, System.Threading.CancellationToken cancellationToken)
            {
                if (clientId == null)
                    throw new System.ArgumentNullException("clientId");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Recommendation/CalculateRecommendedTableHeight/{clientId}");
                urlBuilder_.Replace("{clientId}", System.Uri.EscapeDataString(ConvertToString(clientId, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(double);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<double>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(double);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<double> CalculateRecommendedChairHeightAsync(int clientId)
            {
                return CalculateRecommendedChairHeightAsync(clientId, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<double> CalculateRecommendedChairHeightAsync(int clientId, System.Threading.CancellationToken cancellationToken)
            {
                if (clientId == null)
                    throw new System.ArgumentNullException("clientId");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Recommendation/CalculateRecommendedChairHeight/{clientId}");
                urlBuilder_.Replace("{clientId}", System.Uri.EscapeDataString(ConvertToString(clientId, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(double);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<double>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(double);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Scheduler>> GetScheduleAsync(int clientId)
            {
                return GetScheduleAsync(clientId, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Scheduler>> GetScheduleAsync(int clientId, System.Threading.CancellationToken cancellationToken)
            {
                if (clientId == null)
                    throw new System.ArgumentNullException("clientId");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Scheduler/GetSchedule/{clientId}");
                urlBuilder_.Replace("{clientId}", System.Uri.EscapeDataString(ConvertToString(clientId, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<Scheduler>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Scheduler>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<Scheduler>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<FindedWorkplace>> SearcForWorcplacesAsync(SearchingViewModel searchingViewModel)
            {
                return SearcForWorcplacesAsync(searchingViewModel, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<FindedWorkplace>> SearcForWorcplacesAsync(SearchingViewModel searchingViewModel, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Searching/SearhcForWorcplaces");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(searchingViewModel, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<FindedWorkplace>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<FindedWorkplace>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<FindedWorkplace>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetStatisticsByYearAsync(int year, int buildingId)
            {
                return GetStatisticsByYearAsync(year, buildingId, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetStatisticsByYearAsync(int year, int buildingId, System.Threading.CancellationToken cancellationToken)
            {
                if (year == null)
                    throw new System.ArgumentNullException("year");

                if (buildingId == null)
                    throw new System.ArgumentNullException("buildingId");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Statistics/GetStatisticsByYear/{year}, {buildingId}");
                urlBuilder_.Replace("{year}", System.Uri.EscapeDataString(ConvertToString(year, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Replace("{buildingId}", System.Uri.EscapeDataString(ConvertToString(buildingId, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.Generic.Dictionary<string, double>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, double>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.Generic.Dictionary<string, double>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetStatisticsByMonthAsync(int year, int month, int buildingId)
            {
                return GetStatisticsByMonthAsync(year, month, buildingId, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetStatisticsByMonthAsync(int year, int month, int buildingId, System.Threading.CancellationToken cancellationToken)
            {
                if (year == null)
                    throw new System.ArgumentNullException("year");

                if (month == null)
                    throw new System.ArgumentNullException("month");

                if (buildingId == null)
                    throw new System.ArgumentNullException("buildingId");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Statistics/GetStatisticsByMonth/{year}, {month}, {buildingId}");
                urlBuilder_.Replace("{year}", System.Uri.EscapeDataString(ConvertToString(year, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Replace("{month}", System.Uri.EscapeDataString(ConvertToString(month, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Replace("{buildingId}", System.Uri.EscapeDataString(ConvertToString(buildingId, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.Generic.Dictionary<string, double>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, double>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.Generic.Dictionary<string, double>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetAverageStatisticsByWeekAsync(int buildingId)
            {
                return GetAverageStatisticsByWeekAsync(buildingId, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetAverageStatisticsByWeekAsync(int buildingId, System.Threading.CancellationToken cancellationToken)
            {
                if (buildingId == null)
                    throw new System.ArgumentNullException("buildingId");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Statistics/GetAverageStatisticsByWeek/{buildingId}");
                urlBuilder_.Replace("{buildingId}", System.Uri.EscapeDataString(ConvertToString(buildingId, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.Generic.Dictionary<string, double>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, double>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.Generic.Dictionary<string, double>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetAllAsync()
            {
                return GetAllAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetAllAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Values");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<string>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<string>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<string>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task Post3Async(string value)
            {
                return Post3Async(value, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task Post3Async(string value, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Values");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(value, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                return;
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<string> GetAsync(int id)
            {
                return GetAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<string> GetAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Values/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(string);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(string);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task PutAsync(int id, string value)
            {
                return PutAsync(id, value, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task PutAsync(int id, string value, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Values/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(value, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                return;
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task DeleteAsync(int id)
            {
                return DeleteAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task DeleteAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Values/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                return;
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Workplace>> GetWorkplacesListAsync()
            {
                return GetWorkplacesListAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Workplace>> GetWorkplacesListAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Workplace/GetWorkplacesList");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<Workplace>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Workplace>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<Workplace>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Workplace> GetWorkplaceByIdAsync(int id)
            {
                return GetWorkplaceByIdAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Workplace> GetWorkplaceByIdAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Workplace/GetWorkplaceById/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Workplace);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Workplace>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Workplace);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Workplace> CreateWorkplaceAsync(Workplace workplace)
            {
                return CreateWorkplaceAsync(workplace, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Workplace> CreateWorkplaceAsync(Workplace workplace, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Workplace/CreateWorkplace");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(workplace, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Workplace);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Workplace>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Workplace);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Workplace> UpdateWorkplaceAsync(Workplace workplace)
            {
                return UpdateWorkplaceAsync(workplace, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Workplace> UpdateWorkplaceAsync(Workplace workplace, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Workplace/UpdateWorkplace");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(workplace, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Workplace);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Workplace>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Workplace);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<Workplace> DeleteWorkplaceAsync(int id)
            {
                return DeleteWorkplaceAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<Workplace> DeleteWorkplaceAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Workplace/DeleteWorkplace/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(Workplace);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Workplace>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(Workplace);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<WorkplaceEquipment>> GetWorkplaceEquipmentsListAsync()
            {
                return GetWorkplaceEquipmentsListAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<WorkplaceEquipment>> GetWorkplaceEquipmentsListAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceEquipment/GetWorkplaceEquipmentsList");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<WorkplaceEquipment>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<WorkplaceEquipment>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<WorkplaceEquipment>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<WorkplaceEquipment> GetWorkplaceEquipmentByIdAsync(int id)
            {
                return GetWorkplaceEquipmentByIdAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<WorkplaceEquipment> GetWorkplaceEquipmentByIdAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceEquipment/GetWorkplaceEquipmentById/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(WorkplaceEquipment);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceEquipment>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(WorkplaceEquipment);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<WorkplaceEquipment> CreateWorkplaceEquipmentAsync(WorkplaceEquipment workplaceEquipment)
            {
                return CreateWorkplaceEquipmentAsync(workplaceEquipment, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<WorkplaceEquipment> CreateWorkplaceEquipmentAsync(WorkplaceEquipment workplaceEquipment, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceEquipment/CreateWorkplaceEquipment");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(workplaceEquipment, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(WorkplaceEquipment);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceEquipment>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(WorkplaceEquipment);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<WorkplaceEquipment> UpdateWorkplaceEquipmentAsync(WorkplaceEquipment workplaceEquipment)
            {
                return UpdateWorkplaceEquipmentAsync(workplaceEquipment, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<WorkplaceEquipment> UpdateWorkplaceEquipmentAsync(WorkplaceEquipment workplaceEquipment, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceEquipment/UpdateWorkplaceEquipment");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(workplaceEquipment, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(WorkplaceEquipment);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceEquipment>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(WorkplaceEquipment);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<WorkplaceEquipment> DeleteWorkplaceEquipmentAsync(int id)
            {
                return DeleteWorkplaceEquipmentAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<WorkplaceEquipment> DeleteWorkplaceEquipmentAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceEquipment/DeleteWorkplaceEquipment/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(WorkplaceEquipment);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceEquipment>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(WorkplaceEquipment);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<WorkplaceOrder>> GetWorkplaceOrdersListAsync()
            {
                return GetWorkplaceOrdersListAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<WorkplaceOrder>> GetWorkplaceOrdersListAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceOrder/GetWorkplaceOrdersList");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.ObjectModel.ObservableCollection<WorkplaceOrder>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<WorkplaceOrder>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.ObjectModel.ObservableCollection<WorkplaceOrder>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<WorkplaceOrder> GetWorkplaceOrdersListByClientAsync(int? clientId, string id)
            {
                return GetWorkplaceOrdersListByClientAsync(clientId, id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<WorkplaceOrder> GetWorkplaceOrdersListByClientAsync(int? clientId, string id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceOrder/GetWorkplaceOrdersListByClient/{id}?");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
                if (clientId != null)
                {
                    urlBuilder_.Append("clientId=").Append(System.Uri.EscapeDataString(ConvertToString(clientId, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(WorkplaceOrder);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceOrder>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(WorkplaceOrder);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<WorkplaceOrder> GetWorkplaceOrderByIdAsync(int id)
            {
                return GetWorkplaceOrderByIdAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<WorkplaceOrder> GetWorkplaceOrderByIdAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceOrder/GetWorkplaceOrderById/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(WorkplaceOrder);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceOrder>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(WorkplaceOrder);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<WorkplaceOrder> CreateWorkplaceOrderAsync(WorkplaceOrder workplaceOrder)
            {
                return CreateWorkplaceOrderAsync(workplaceOrder, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<WorkplaceOrder> CreateWorkplaceOrderAsync(WorkplaceOrder workplaceOrder, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceOrder/CreateWorkplaceOrder");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(workplaceOrder, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                        string token = prefs.GetString("auth_token", "");
                        request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(WorkplaceOrder);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceOrder>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(WorkplaceOrder);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<WorkplaceOrder> UpdateWorkplaceOrderAsync(WorkplaceOrder workplaceOrder)
            {
                return UpdateWorkplaceOrderAsync(workplaceOrder, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<WorkplaceOrder> UpdateWorkplaceOrderAsync(WorkplaceOrder workplaceOrder, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceOrder/UpdateWorkplaceOrder");

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(workplaceOrder, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(WorkplaceOrder);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceOrder>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(WorkplaceOrder);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<WorkplaceOrder> DeleteWorkplaceOrderAsync(int id)
            {
                return DeleteWorkplaceOrderAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<WorkplaceOrder> DeleteWorkplaceOrderAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/WorkplaceOrder/DeleteWorkplaceOrder/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = new System.Net.Http.HttpClient();
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");
                        request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    string token = prefs.GetString("auth_token", "");
                    request_.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                   

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(WorkplaceOrder);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceOrder>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(WorkplaceOrder);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (client_ != null)
                        client_.Dispose();
                }
            }

            private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
            {
                if (value is System.Enum)
                {
                    string name = System.Enum.GetName(value.GetType(), value);
                    if (name != null)
                    {
                        var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                        if (field != null)
                        {
                            var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                                as System.Runtime.Serialization.EnumMemberAttribute;
                            if (attribute != null)
                            {
                                return attribute.Value;
                            }
                        }
                    }
                }
                else if (value is byte[])
                {
                    return System.Convert.ToBase64String((byte[])value);
                }
                else if (value != null && value.GetType().IsArray)
                {
                    var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                    return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
                }

                return System.Convert.ToString(value, cultureInfo);
            }
        }



        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class RegistrationViewModel : System.ComponentModel.INotifyPropertyChanged
        {
            private string _email;
            private string _password;
            private string _firstName;
            private string _lastName;
            private System.DateTime? _birthday;
            private long? _passportNumber;
            private long? _phone;
            private string _role;

            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email
            {
                get { return _email; }
                set
                {
                    if (_email != value)
                    {
                        _email = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Password
            {
                get { return _password; }
                set
                {
                    if (_password != value)
                    {
                        _password = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FirstName
            {
                get { return _firstName; }
                set
                {
                    if (_firstName != value)
                    {
                        _firstName = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LastName
            {
                get { return _lastName; }
                set
                {
                    if (_lastName != value)
                    {
                        _lastName = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("birthday", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTime? Birthday
            {
                get { return _birthday; }
                set
                {
                    if (_birthday != value)
                    {
                        _birthday = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("passportNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long? PassportNumber
            {
                get { return _passportNumber; }
                set
                {
                    if (_passportNumber != value)
                    {
                        _passportNumber = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("phone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long? Phone
            {
                get { return _phone; }
                set
                {
                    if (_phone != value)
                    {
                        _phone = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("role", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Role
            {
                get { return _role; }
                set
                {
                    if (_role != value)
                    {
                        _role = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static RegistrationViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<RegistrationViewModel>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class CredentialsViewModel : System.ComponentModel.INotifyPropertyChanged
        {
            private string _userName;
            private string _password;

            [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string UserName
            {
                get { return _userName; }
                set
                {
                    if (_userName != value)
                    {
                        _userName = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Password
            {
                get { return _password; }
                set
                {
                    if (_password != value)
                    {
                        _password = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static CredentialsViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<CredentialsViewModel>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class Building : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _id;
            private string _country;
            private string _city;
            private string _street;
            private string _house;
            private int? _flat;
            private int? _landlordId;
            private int? _x;
            private int? _y;
            private Landlord _landlord;
            private System.Collections.ObjectModel.ObservableCollection<Workplace> _workplace;

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id
            {
                get { return _id; }
                set
                {
                    if (_id != value)
                    {
                        _id = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Country
            {
                get { return _country; }
                set
                {
                    if (_country != value)
                    {
                        _country = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("city", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string City
            {
                get { return _city; }
                set
                {
                    if (_city != value)
                    {
                        _city = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("street", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Street
            {
                get { return _street; }
                set
                {
                    if (_street != value)
                    {
                        _street = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("house", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string House
            {
                get { return _house; }
                set
                {
                    if (_house != value)
                    {
                        _house = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("flat", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Flat
            {
                get { return _flat; }
                set
                {
                    if (_flat != value)
                    {
                        _flat = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("landlordId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? LandlordId
            {
                get { return _landlordId; }
                set
                {
                    if (_landlordId != value)
                    {
                        _landlordId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("x", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? X
            {
                get { return _x; }
                set
                {
                    if (_x != value)
                    {
                        _x = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("y", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Y
            {
                get { return _y; }
                set
                {
                    if (_y != value)
                    {
                        _y = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("landlord", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Landlord Landlord
            {
                get { return _landlord; }
                set
                {
                    if (_landlord != value)
                    {
                        _landlord = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("workplace", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.ObjectModel.ObservableCollection<Workplace> Workplace
            {
                get { return _workplace; }
                set
                {
                    if (_workplace != value)
                    {
                        _workplace = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static Building FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Building>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class Landlord : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _id;
            private string _firstName;
            private string _lastName;
            private long? _passportNumber;
            private long? _phone;
            private string _email;
            private int? _isInBlackList;
            private string _identityId;
            private User _identity;
            private System.Collections.ObjectModel.ObservableCollection<Building> _building;

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id
            {
                get { return _id; }
                set
                {
                    if (_id != value)
                    {
                        _id = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FirstName
            {
                get { return _firstName; }
                set
                {
                    if (_firstName != value)
                    {
                        _firstName = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LastName
            {
                get { return _lastName; }
                set
                {
                    if (_lastName != value)
                    {
                        _lastName = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("passportNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long? PassportNumber
            {
                get { return _passportNumber; }
                set
                {
                    if (_passportNumber != value)
                    {
                        _passportNumber = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("phone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long? Phone
            {
                get { return _phone; }
                set
                {
                    if (_phone != value)
                    {
                        _phone = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email
            {
                get { return _email; }
                set
                {
                    if (_email != value)
                    {
                        _email = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("isInBlackList", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? IsInBlackList
            {
                get { return _isInBlackList; }
                set
                {
                    if (_isInBlackList != value)
                    {
                        _isInBlackList = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("identityId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string IdentityId
            {
                get { return _identityId; }
                set
                {
                    if (_identityId != value)
                    {
                        _identityId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("identity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public User Identity
            {
                get { return _identity; }
                set
                {
                    if (_identity != value)
                    {
                        _identity = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("building", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.ObjectModel.ObservableCollection<Building> Building
            {
                get { return _building; }
                set
                {
                    if (_building != value)
                    {
                        _building = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static Landlord FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Landlord>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class Workplace : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _id;
            private int? _mark;
            private int? _cost;
            private int? _buildingId;
            private Building _building;
            private System.Collections.ObjectModel.ObservableCollection<WorkplaceOrder> _workplaceOrder;
            private System.Collections.ObjectModel.ObservableCollection<WorkplaceEquipment> _workplaceEquipment;

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id
            {
                get { return _id; }
                set
                {
                    if (_id != value)
                    {
                        _id = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("mark", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Mark
            {
                get { return _mark; }
                set
                {
                    if (_mark != value)
                    {
                        _mark = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("cost", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Cost
            {
                get { return _cost; }
                set
                {
                    if (_cost != value)
                    {
                        _cost = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("buildingId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? BuildingId
            {
                get { return _buildingId; }
                set
                {
                    if (_buildingId != value)
                    {
                        _buildingId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("building", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Building Building
            {
                get { return _building; }
                set
                {
                    if (_building != value)
                    {
                        _building = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("workplaceOrder", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.ObjectModel.ObservableCollection<WorkplaceOrder> WorkplaceOrder
            {
                get { return _workplaceOrder; }
                set
                {
                    if (_workplaceOrder != value)
                    {
                        _workplaceOrder = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("workplaceEquipment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.ObjectModel.ObservableCollection<WorkplaceEquipment> WorkplaceEquipment
            {
                get { return _workplaceEquipment; }
                set
                {
                    if (_workplaceEquipment != value)
                    {
                        _workplaceEquipment = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static Workplace FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Workplace>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class User : System.ComponentModel.INotifyPropertyChanged
        {
            private string _id;
            private string _userName;
            private string _normalizedUserName;
            private string _email;
            private string _normalizedEmail;
            private bool? _emailConfirmed;
            private string _passwordHash;
            private string _securityStamp;
            private string _concurrencyStamp;
            private string _phoneNumber;
            private bool? _phoneNumberConfirmed;
            private bool? _twoFactorEnabled;
            private System.DateTime? _lockoutEnd;
            private bool? _lockoutEnabled;
            private int? _accessFailedCount;

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Id
            {
                get { return _id; }
                set
                {
                    if (_id != value)
                    {
                        _id = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string UserName
            {
                get { return _userName; }
                set
                {
                    if (_userName != value)
                    {
                        _userName = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("normalizedUserName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NormalizedUserName
            {
                get { return _normalizedUserName; }
                set
                {
                    if (_normalizedUserName != value)
                    {
                        _normalizedUserName = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email
            {
                get { return _email; }
                set
                {
                    if (_email != value)
                    {
                        _email = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("normalizedEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NormalizedEmail
            {
                get { return _normalizedEmail; }
                set
                {
                    if (_normalizedEmail != value)
                    {
                        _normalizedEmail = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("emailConfirmed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool? EmailConfirmed
            {
                get { return _emailConfirmed; }
                set
                {
                    if (_emailConfirmed != value)
                    {
                        _emailConfirmed = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("passwordHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PasswordHash
            {
                get { return _passwordHash; }
                set
                {
                    if (_passwordHash != value)
                    {
                        _passwordHash = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("securityStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SecurityStamp
            {
                get { return _securityStamp; }
                set
                {
                    if (_securityStamp != value)
                    {
                        _securityStamp = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("concurrencyStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ConcurrencyStamp
            {
                get { return _concurrencyStamp; }
                set
                {
                    if (_concurrencyStamp != value)
                    {
                        _concurrencyStamp = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("phoneNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PhoneNumber
            {
                get { return _phoneNumber; }
                set
                {
                    if (_phoneNumber != value)
                    {
                        _phoneNumber = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("phoneNumberConfirmed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool? PhoneNumberConfirmed
            {
                get { return _phoneNumberConfirmed; }
                set
                {
                    if (_phoneNumberConfirmed != value)
                    {
                        _phoneNumberConfirmed = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("twoFactorEnabled", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool? TwoFactorEnabled
            {
                get { return _twoFactorEnabled; }
                set
                {
                    if (_twoFactorEnabled != value)
                    {
                        _twoFactorEnabled = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("lockoutEnd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTime? LockoutEnd
            {
                get { return _lockoutEnd; }
                set
                {
                    if (_lockoutEnd != value)
                    {
                        _lockoutEnd = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("lockoutEnabled", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool? LockoutEnabled
            {
                get { return _lockoutEnabled; }
                set
                {
                    if (_lockoutEnabled != value)
                    {
                        _lockoutEnabled = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("accessFailedCount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? AccessFailedCount
            {
                get { return _accessFailedCount; }
                set
                {
                    if (_accessFailedCount != value)
                    {
                        _accessFailedCount = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static User FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<User>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class WorkplaceOrder : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _id;
            private int? _clientId;
            private int? _workplaceId;
            private System.DateTime? _startTime;
            private System.DateTime? _finishTime;
            private int? _sumToPay;
            private Client _client;
            private Workplace _workplace;

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id
            {
                get { return _id; }
                set
                {
                    if (_id != value)
                    {
                        _id = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("clientId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? ClientId
            {
                get { return _clientId; }
                set
                {
                    if (_clientId != value)
                    {
                        _clientId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("workplaceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? WorkplaceId
            {
                get { return _workplaceId; }
                set
                {
                    if (_workplaceId != value)
                    {
                        _workplaceId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("startTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTime? StartTime
            {
                get { return _startTime; }
                set
                {
                    if (_startTime != value)
                    {
                        _startTime = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("finishTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTime? FinishTime
            {
                get { return _finishTime; }
                set
                {
                    if (_finishTime != value)
                    {
                        _finishTime = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("sumToPay", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? SumToPay
            {
                get { return _sumToPay; }
                set
                {
                    if (_sumToPay != value)
                    {
                        _sumToPay = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("client", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Client Client
            {
                get { return _client; }
                set
                {
                    if (_client != value)
                    {
                        _client = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("workplace", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Workplace Workplace
            {
                get { return _workplace; }
                set
                {
                    if (_workplace != value)
                    {
                        _workplace = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static WorkplaceOrder FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceOrder>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class WorkplaceEquipment : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _id;
            private int? _equipmentId;
            private int? _workplaceId;
            private Equipment _equipment;
            private Workplace _workplace;

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id
            {
                get { return _id; }
                set
                {
                    if (_id != value)
                    {
                        _id = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("equipmentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? EquipmentId
            {
                get { return _equipmentId; }
                set
                {
                    if (_equipmentId != value)
                    {
                        _equipmentId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("workplaceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? WorkplaceId
            {
                get { return _workplaceId; }
                set
                {
                    if (_workplaceId != value)
                    {
                        _workplaceId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("equipment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Equipment Equipment
            {
                get { return _equipment; }
                set
                {
                    if (_equipment != value)
                    {
                        _equipment = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("workplace", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Workplace Workplace
            {
                get { return _workplace; }
                set
                {
                    if (_workplace != value)
                    {
                        _workplace = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static WorkplaceEquipment FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<WorkplaceEquipment>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class Client : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _id;
            private string _firstName;
            private string _lastName;
            private System.DateTime? _birthday;
            private long? _passportNumber;
            private long? _phone;
            private string _email;
            private int? _hight;
            private int? _vision;
            private int? _tableHight;
            private int? _chairHight;
            private int? _light;
            private int? _temperature;
            private string _music;
            private string _drink;
            private int? _isInBlackList;
            private int? _sale;
            private string _identityId;
            private User _identity;
            private System.Collections.ObjectModel.ObservableCollection<WorkplaceOrder> _workplaceOrder;

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id
            {
                get { return _id; }
                set
                {
                    if (_id != value)
                    {
                        _id = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FirstName
            {
                get { return _firstName; }
                set
                {
                    if (_firstName != value)
                    {
                        _firstName = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LastName
            {
                get { return _lastName; }
                set
                {
                    if (_lastName != value)
                    {
                        _lastName = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("birthday", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTime? Birthday
            {
                get { return _birthday; }
                set
                {
                    if (_birthday != value)
                    {
                        _birthday = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("passportNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long? PassportNumber
            {
                get { return _passportNumber; }
                set
                {
                    if (_passportNumber != value)
                    {
                        _passportNumber = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("phone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long? Phone
            {
                get { return _phone; }
                set
                {
                    if (_phone != value)
                    {
                        _phone = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email
            {
                get { return _email; }
                set
                {
                    if (_email != value)
                    {
                        _email = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("hight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Hight
            {
                get { return _hight; }
                set
                {
                    if (_hight != value)
                    {
                        _hight = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("vision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Vision
            {
                get { return _vision; }
                set
                {
                    if (_vision != value)
                    {
                        _vision = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("tableHight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? TableHight
            {
                get { return _tableHight; }
                set
                {
                    if (_tableHight != value)
                    {
                        _tableHight = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("chairHight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? ChairHight
            {
                get { return _chairHight; }
                set
                {
                    if (_chairHight != value)
                    {
                        _chairHight = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("light", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Light
            {
                get { return _light; }
                set
                {
                    if (_light != value)
                    {
                        _light = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("temperature", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Temperature
            {
                get { return _temperature; }
                set
                {
                    if (_temperature != value)
                    {
                        _temperature = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("music", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Music
            {
                get { return _music; }
                set
                {
                    if (_music != value)
                    {
                        _music = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("drink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Drink
            {
                get { return _drink; }
                set
                {
                    if (_drink != value)
                    {
                        _drink = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("isInBlackList", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? IsInBlackList
            {
                get { return _isInBlackList; }
                set
                {
                    if (_isInBlackList != value)
                    {
                        _isInBlackList = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("sale", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Sale
            {
                get { return _sale; }
                set
                {
                    if (_sale != value)
                    {
                        _sale = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("identityId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string IdentityId
            {
                get { return _identityId; }
                set
                {
                    if (_identityId != value)
                    {
                        _identityId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("identity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public User Identity
            {
                get { return _identity; }
                set
                {
                    if (_identity != value)
                    {
                        _identity = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("workplaceOrder", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.ObjectModel.ObservableCollection<WorkplaceOrder> WorkplaceOrder
            {
                get { return _workplaceOrder; }
                set
                {
                    if (_workplaceOrder != value)
                    {
                        _workplaceOrder = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static Client FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Client>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class Equipment : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _id;
            private string _name;
            private string _description;
            private System.Collections.ObjectModel.ObservableCollection<WorkplaceEquipment> _workplaceEquipment;

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id
            {
                get { return _id; }
                set
                {
                    if (_id != value)
                    {
                        _id = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name
            {
                get { return _name; }
                set
                {
                    if (_name != value)
                    {
                        _name = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Description
            {
                get { return _description; }
                set
                {
                    if (_description != value)
                    {
                        _description = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("workplaceEquipment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.ObjectModel.ObservableCollection<WorkplaceEquipment> WorkplaceEquipment
            {
                get { return _workplaceEquipment; }
                set
                {
                    if (_workplaceEquipment != value)
                    {
                        _workplaceEquipment = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static Equipment FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Equipment>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class Scheduler : System.ComponentModel.INotifyPropertyChanged
        {
            private string _id;
            private string _start_date;
            private string _end_date;
            private string _text;
            private string _details;

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Id
            {
                get { return _id; }
                set
                {
                    if (_id != value)
                    {
                        _id = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("start_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Start_date
            {
                get { return _start_date; }
                set
                {
                    if (_start_date != value)
                    {
                        _start_date = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("end_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string End_date
            {
                get { return _end_date; }
                set
                {
                    if (_end_date != value)
                    {
                        _end_date = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("text", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Text
            {
                get { return _text; }
                set
                {
                    if (_text != value)
                    {
                        _text = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("details", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Details
            {
                get { return _details; }
                set
                {
                    if (_details != value)
                    {
                        _details = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static Scheduler FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Scheduler>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class SearchingViewModel : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _radius;
            private int? _wantedCost;
            private double? _x;
            private double? _y;
            private System.Collections.ObjectModel.ObservableCollection<SearchingModel> _searchingModel;

            [Newtonsoft.Json.JsonProperty("radius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Radius
            {
                get { return _radius; }
                set
                {
                    if (_radius != value)
                    {
                        _radius = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("wantedCost", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? WantedCost
            {
                get { return _wantedCost; }
                set
                {
                    if (_wantedCost != value)
                    {
                        _wantedCost = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("x", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double? X
            {
                get { return _x; }
                set
                {
                    if (_x != value)
                    {
                        _x = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("y", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double? Y
            {
                get { return _y; }
                set
                {
                    if (_y != value)
                    {
                        _y = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("searchingModel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.ObjectModel.ObservableCollection<SearchingModel> SearchingModel
            {
                get { return _searchingModel; }
                set
                {
                    if (_searchingModel != value)
                    {
                        _searchingModel = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static SearchingViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<SearchingViewModel>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class SearchingModel : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _equipmentId;
            private double? _importancy;

            [Newtonsoft.Json.JsonProperty("equipmentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? EquipmentId
            {
                get { return _equipmentId; }
                set
                {
                    if (_equipmentId != value)
                    {
                        _equipmentId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("importancy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double? Importancy
            {
                get { return _importancy; }
                set
                {
                    if (_importancy != value)
                    {
                        _importancy = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static SearchingModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<SearchingModel>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.11.0.0 (Newtonsoft.Json v9.0.0.0)")]
        public partial class FindedWorkplace : System.ComponentModel.INotifyPropertyChanged
        {
            private int? _workplaceId;
            private double? _appropriationPercentage;
            private string _appropriationColor;
            private string _costColor;

            [Newtonsoft.Json.JsonProperty("workplaceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? WorkplaceId
            {
                get { return _workplaceId; }
                set
                {
                    if (_workplaceId != value)
                    {
                        _workplaceId = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("appropriationPercentage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double? AppropriationPercentage
            {
                get { return _appropriationPercentage; }
                set
                {
                    if (_appropriationPercentage != value)
                    {
                        _appropriationPercentage = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("appropriationColor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string AppropriationColor
            {
                get { return _appropriationColor; }
                set
                {
                    if (_appropriationColor != value)
                    {
                        _appropriationColor = value;
                        RaisePropertyChanged();
                    }
                }
            }

            [Newtonsoft.Json.JsonProperty("costColor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string CostColor
            {
                get { return _costColor; }
                set
                {
                    if (_costColor != value)
                    {
                        _costColor = value;
                        RaisePropertyChanged();
                    }
                }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static FindedWorkplace FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<FindedWorkplace>(data);
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
        public partial class SwaggerException : System.Exception
        {
            public int StatusCode { get; private set; }

            public string Response { get; private set; }

            public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

            public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
                : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
            {
                StatusCode = statusCode;
                Response = response;
                Headers = headers;
            }

            public override string ToString()
            {
                return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
        public partial class SwaggerException<TResult> : SwaggerException
        {
            public TResult Result { get; private set; }

            public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
                : base(message, statusCode, response, headers, innerException)
            {
                Result = result;
            }
        }

    }