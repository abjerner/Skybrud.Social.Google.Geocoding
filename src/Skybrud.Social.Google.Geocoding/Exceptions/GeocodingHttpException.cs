using System;
using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;

namespace Skybrud.Social.Google.Geocoding.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Google Geocoding API.
    /// </summary>
    public class GeocodingHttpException : Exception, IHttpException {

        #region Properties

        /// <inheritdoc />
        public IHttpResponse Response { get; }

        /// <inheritdoc />
        public HttpStatusCode StatusCode => Response.StatusCode;

        /// <summary>
        /// Gets the message of the exception.
        /// </summary>
        public new string Message { get; }

        /// <summary>
        /// Gets the status of the exception/response.
        /// </summary>
        public string Status { get; }

        #endregion

        #region Constructors

        internal GeocodingHttpException(IHttpResponse response, string message, string status) {
            Response = response;
            Message = message;
            Status = status;
        }

        #endregion

    }

}