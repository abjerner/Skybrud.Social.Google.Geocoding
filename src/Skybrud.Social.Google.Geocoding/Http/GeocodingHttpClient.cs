using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Google.Geocoding.Options;
using Skybrud.Social.Google.Http;
using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google.Geocoding.Http {

    /// <summary>
    /// HTTP client used for communicationg with the Google Geocoding API.
    /// </summary>
    public class GeocodingHttpClient : GoogleApiHttpClientBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified Google OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The Google OAuth client to be used.</param>
        public GeocodingHttpClient(GoogleOAuthClient client) : base(client) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Performs a geocode lookup based on the specified <paramref name="address"/>.
        /// </summary>
        /// <param name="address">The address to look up.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#geocoding</cref>
        /// </see>
        public IHttpResponse Geocode(string address) {
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));
            return GetResponse(new GeocodingGeocodeOptions(address));
        }

        /// <summary>
        /// Performs a geocode lookup based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#geocoding</cref>
        /// </see>
        public IHttpResponse Geocode(GeocodingGeocodeOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetResponse(options);
        }

        /// <summary>
        /// Performs a reverse geocode lookup based on the location with the specified <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude">The latitude of the location.</param>
        /// <param name="longitude">The longitude of the location.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#ReverseGeocoding</cref>
        /// </see>
        public IHttpResponse ReverseGeocode(double latitude, double longitude) {
            return Client.GetResponse(new GeocodingReverseGeocodeOptions(latitude, longitude));
        }

        /// <summary>
        /// Performs a reverse geocode lookup based on the specified <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location the lookup should be based on.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#ReverseGeocoding</cref>
        /// </see>
        public IHttpResponse ReverseGeocode(IPoint location) {
            return Client.GetResponse(new GeocodingReverseGeocodeOptions(location));
        }

        /// <summary>
        /// Performs a reverse geocode lookup based on the location with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#ReverseGeocoding</cref>
        /// </see>
        public IHttpResponse ReverseGeocode(GeocodingReverseGeocodeOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets information about the place with the specified <paramref name="placeId"/>.
        /// </summary>
        /// <param name="placeId">The ID of the place.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#place-id</cref>
        /// </see>
        public IHttpResponse GetPlace(string placeId) {
            if (string.IsNullOrWhiteSpace(placeId)) throw new ArgumentNullException(nameof(placeId));
            return GetResponse(new GeocodingGetPlaceOptions(placeId));
        }

        /// <summary>
        /// Gets information about the place matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns></returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#place-id</cref>
        /// </see>
        public IHttpResponse GetPlace(GeocodingGetPlaceOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetResponse(options);
        }

        #endregion

    }

}