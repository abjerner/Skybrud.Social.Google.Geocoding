using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Google.Geocoding.Options {

    /// <summary>
    /// Options class for getting information about a plkace from the Google Geocoding API.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#place-id</cref>
    /// </see>
    public class GeocodingGetPlaceOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the place to get information about.
        /// </summary>
        public string PlaceId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with empty options.
        /// </summary>
        public GeocodingGetPlaceOptions() { }

        /// <summary>
        /// Initializes a new instance for place with the specified <paramref name="placeId"/>.
        /// </summary>
        /// <param name="placeId">The ID of the place to get information for.</param>
        public GeocodingGetPlaceOptions(string placeId) {
            PlaceId = placeId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(PlaceId)) throw new PropertyNotSetException(nameof(PlaceId));

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString {
                { "place_id", PlaceId }
            };

            // Create the request
            return HttpRequest.Get("https://maps.googleapis.com/maps/api/geocode/json", query);

        }

        #endregion

    }

}