using System;
using System.Globalization;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Maps.Geometry;

namespace Skybrud.Social.Google.Geocoding.Options {

    /// <summary>
    /// Options class for performing a reverse geocode lookup using the Google Geocoding API.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#ReverseGeocoding</cref>
    /// </see>
    public class GeocodingReverseGeocodeOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the latitude of the location do perform a reverse geocode lookup for.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the location do perform a reverse geocode lookup for.
        /// </summary>
        public double Longitude { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with empty options.
        /// </summary>
        public GeocodingReverseGeocodeOptions() { }

        /// <summary>
        /// Initializes a new instance for the location with the specified <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude">The latitude of the location.</param>
        /// <param name="longitude">The longitude of the location.</param>
        public GeocodingReverseGeocodeOptions(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Initializes a new instance for the specified <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location.</param>
        public GeocodingReverseGeocodeOptions(IPoint location) {
            if (location == null) throw new ArgumentNullException(nameof(location));
            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Make sure either Latitude or Longitude are specified ("0,0" is considered invalid) 
            if (Math.Abs(Latitude) < double.Epsilon && Math.Abs(Longitude) < double.Epsilon) throw new PropertyNotSetException(nameof(Latitude));

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString {
                {"latlng", string.Format(CultureInfo.InvariantCulture, "{0},{1}", Latitude, Longitude)}
            };

            // Create the request
            return HttpRequest.Get("https://maps.googleapis.com/maps/api/geocode/json", query);

        }

        #endregion

    }

}