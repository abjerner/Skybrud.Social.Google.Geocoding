using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Geocoding.Exceptions;

namespace Skybrud.Social.Google.Geocoding.Responses {

    /// <summary>
    /// Class representing a response from the Google Geocoding API.
    /// </summary>
    public class GeocodingResponse : HttpResponseBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected GeocodingResponse(IHttpResponse response) : base(response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            JObject obj = ParseJsonObject(response.Body);

            string message = obj.GetString("error_message");
            string status = obj.GetString("status");

            throw new GeocodingHttpException(response, message, status);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Google Geocoding API.
    /// </summary>
    public class GeocodingResponse<T> : GeocodingResponse {

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected GeocodingResponse(IHttpResponse response) : base(response) { }

    }

}