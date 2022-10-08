using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class WebApiHelper
    {
        /// <summary>
        /// Get Access token and Refresh token
        /// </summary>
        /// <param name="url"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ZoomAccessTokenResponse GetToken(string url, string clientId, string clientSecret, out string error)
        {
            var response = new ZoomAccessTokenResponse();
            error = null;
            try
            {
                var LegalHoldRequestObj = new LegalHoldRequest
                {
                    //title = string.Concat(legalHoldName, '_', dateRanges.StartDate.ToString("yyyy-MM-dd"), '_', dateRanges.EndDate.ToString("yyyy-MM-dd")),
                    //id = string.Concat(legalHoldName, '_', dateRanges.StartDate.ToString("yyyy-MM-dd"), '_', dateRanges.EndDate.ToString("yyyy-MM-dd")),
                    title = "",
                    id = "",
                    Type = "OnnaConstants.WORKSPACE",
                    legal_hold = new LegalHold
                    {
                        query = new Query
                        {
                            advanced = new Advanced
                            {
                                and = new List<And>()
                                        {
                                            new And
                                            {
                                                In = new List<object>() { new Var { var = "OnnaConstants.PARENT_DATASOURCE" }, new string[] { "Hi PD" } }
                                            }
                                        }
                            }
                        }
                    }
                };
                var EncodedAccessToken = Base64Encode(clientId + ':' + clientSecret);
                response = PostMethod(url, EncodedAccessToken, out error);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// To convert entered text into Base64 encoded format
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// To Read Data From Zoom API
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ZoomAccessTokenResponse PostMethod(string url, string accessToken, out string error)
        {
            var result = new ZoomAccessTokenResponse();
            error = null;
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic " + accessToken);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                    result = JsonDeserialize<ZoomAccessTokenResponse>(response.Content);
                else
                    error = response.Content;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public static T JsonDeserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
