using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gleac.Anand.Levenshtein.Distance;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Gleac.Anand.Web.App.Levenshtein.Distance.Client
{
    public class LevenshteinDistanceApiClient : IDisposable
    {
        private readonly IConfiguration configuration;
        private static readonly Uri _tokenSettingUri = new Uri("api/Login", UriKind.RelativeOrAbsolute); // https://localhost:44309/api/Login
        private static readonly Uri _levenshteinDistanceUri = new Uri("api/ComputeLevenshteinDistance", UriKind.RelativeOrAbsolute); // https://localhost:44309/api/ComputeLevenshteinDistance

        public LevenshteinDistanceApiClient(IConfiguration iConfigParam)
        {
            configuration = iConfigParam;
        }    

        /// <summary>
        ///  Generating and getting JWT Token for accessing authorized tagged WEB API
        /// </summary>
        /// <param name="userModel">The object containing user name and password.</param>
        /// <returns></returns>
        public async Task<StringToken> SetJwtToken(UserModel userModel)
        {
            StringToken JWTToken = null;
            HttpResponseMessage httpResponseMessage = null;
            Uri resourcePath = null;
            string requestUri = null;
            string baseAddress = null;
            StringBuilder stringBuilder = null;

            try
            {
                baseAddress = configuration.GetValue<string>("MySettings:ApiBaseAddress");
                resourcePath = _tokenSettingUri;
                stringBuilder = new StringBuilder();
                stringBuilder.Append(baseAddress);
                stringBuilder.Append(resourcePath.ToString());
                requestUri = stringBuilder.ToString();
                //                
                using (var httpclient = new HttpClient())
                {
                    httpResponseMessage = await httpclient.PostAsJsonAsync(requestUri, userModel);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        JWTToken = httpResponseMessage.Content.ReadAsAsync<StringToken>().Result;
                    }
                }
            }
            catch (Exception exception)
            {
                throw (exception);
            }
            finally
            {
                httpResponseMessage = null;
                resourcePath = null;
                baseAddress = null;
                requestUri = null;
                stringBuilder = null;
            }
            return JWTToken;
        }

        /// <summary>
        /// Getting the cost and array containing compute values as matrix.
        /// </summary>
        /// <param name="stringsModel">The object containing first and second strings whose distance to be calculated.</param>
        /// <returns></returns>
        public async Task<LevenshteinDistanceMatrixAndCostResult> GetLevenshteinDistanceMatrixAndCostResult(StringsModel stringsModel, string JWTToken)
        {
            LevenshteinDistanceMatrixAndCostResult levenshteinDistanceMatrixAndCostResult = null;            
            HttpResponseMessage httpResponseMessage = null;
            Uri resourcePath = null;
            string requestUri = null;
            string baseAddress = null;
            StringBuilder stringBuilder = null;

            try
            {               
                baseAddress = configuration.GetValue<string>("MySettings:ApiBaseAddress");
                resourcePath = _levenshteinDistanceUri;
                stringBuilder = new StringBuilder();
                stringBuilder.Append(baseAddress);
                stringBuilder.Append(resourcePath.ToString());
                requestUri = stringBuilder.ToString();
                //                
                using (var httpclient = new HttpClient())
                {                                  
                    httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWTToken);
                    httpResponseMessage = await httpclient.PostAsJsonAsync(requestUri, stringsModel);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        levenshteinDistanceMatrixAndCostResult = httpResponseMessage.Content.ReadAsAsync<LevenshteinDistanceMatrixAndCostResult>().Result;
                    }
                }
            }
            catch (Exception exception)
            {
                throw (exception);
            }
            finally
            {                
                httpResponseMessage = null;
                resourcePath = null;
                baseAddress = null;
                requestUri = null;
                stringBuilder = null;
            }
            return levenshteinDistanceMatrixAndCostResult;
        }

        public void Dispose()
        {
            ; // Null Statement
        }
    }
}
