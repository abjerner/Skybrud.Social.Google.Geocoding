using Skybrud.Essentials.Http;
using Skybrud.Social.Google.Geocoding.Models;

namespace Skybrud.Social.Google.Geocoding.Responses {
    
    /// <summary>
    /// Class representing a response holding a list of Geocode results.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview</cref>
    /// </see>
    public class GeocodingResultListResponse : GeocodingResponse<GeocodingResultList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public GeocodingResultListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GeocodingResultList.Parse);
        }

    }

}