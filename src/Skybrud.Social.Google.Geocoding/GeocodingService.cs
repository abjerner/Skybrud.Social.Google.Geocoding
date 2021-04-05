using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Google.Geocoding.Http;
using Skybrud.Social.Google.Geocoding.Options;
using Skybrud.Social.Google.Geocoding.Responses;

namespace Skybrud.Social.Google.Geocoding {

    /// <summary>
    /// Service implementation for the Google Geocoding API.
    /// </summary>
    public class GeocodingService : GoogleApiServiceBase {

        #region Properties

        /// <summary>
        /// Gets a reference to the Geocoding HTTP client.
        /// </summary>
        public GeocodingHttpClient Client => Service.Client.Geocoding();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified Google <paramref name="service"/>.
        /// </summary>
        /// <param name="service">The Google service to be used.</param>
        public GeocodingService(GoogleService service) : base(service) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Performs a geocode lookup based on the specified <paramref name="address"/>.
        /// </summary>
        /// <param name="address">The address to look up.</param>
        /// <returns>An instance of <see cref="GeocodingResultListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#geocoding</cref>
        /// </see>
        public GeocodingResultListResponse Geocode(string address) {
            return new GeocodingResultListResponse(Client.Geocode(address));
        }

        /// <summary>
        /// Performs a geocode lookup based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GeocodingResultListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#geocoding</cref>
        /// </see>
        public GeocodingResultListResponse Geocode(GeocodingGeocodeOptions options) {
            return new GeocodingResultListResponse(Client.Geocode(options));
        }

        /// <summary>
        /// Performs a reverse geocode lookup based on the location with the specified <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude">The latitude of the location.</param>
        /// <param name="longitude">The longitude of the location.</param>
        /// <returns>An instance of <see cref="GeocodingResultListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#ReverseGeocoding</cref>
        /// </see>
        public GeocodingResultListResponse ReverseGeocode(double latitude, double longitude) {
            return new GeocodingResultListResponse(Client.ReverseGeocode(latitude, longitude));
        }

        /// <summary>
        /// Performs a reverse geocode lookup based on the specified <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location the lookup should be based on.</param>
        /// <returns>An instance of <see cref="GeocodingResultListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#ReverseGeocoding</cref>
        /// </see>
        public GeocodingResultListResponse ReverseGeocode(IPoint location) {
            return new GeocodingResultListResponse(Client.ReverseGeocode(location));
        }

        /// <summary>
        /// Performs a reverse geocode lookup based on the location with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GeocodingResultListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#ReverseGeocoding</cref>
        /// </see>
        public GeocodingResultListResponse ReverseGeocode(GeocodingReverseGeocodeOptions options) {
            return new GeocodingResultListResponse(Client.ReverseGeocode(options));
        }

        /// <summary>
        /// Gets information about the place with the specified <paramref name="placeId"/>.
        /// </summary>
        /// <param name="placeId">The ID of the place.</param>
        /// <returns>An instance of <see cref="GeocodingResultListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#place-id</cref>
        /// </see>
        public GeocodingResultListResponse GetPlace(string placeId) {
            return new GeocodingResultListResponse(Client.GetPlace(placeId));
        }

        /// <summary>
        /// Gets information about the place matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns></returns>
        /// <see>
        ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#place-id</cref>
        /// </see>
        public GeocodingResultListResponse GetPlace(GeocodingGetPlaceOptions options) {
            return new GeocodingResultListResponse(Client.GetPlace(options));
        }

        #endregion

    }

}