using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Google.Geocoding.Options {

    /// <summary>
    /// Options class for performing a geocode lookup using the Google Geocoding API.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/maps/documentation/geocoding/overview#geocoding</cref>
    /// </see>
    public class GeocodingGeocodeOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the address the search should be based on.
        /// </summary>
        public string Address { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with empty options.
        /// </summary>
        public GeocodingGeocodeOptions() { }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="address"/>.
        /// </summary>
        /// <param name="address">The address to be used for the geocode lookup.</param>
        public GeocodingGeocodeOptions(string address) {
            Address = address;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Address)) throw new PropertyNotSetException(nameof(Address));

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString {
                { "address", Address }
            };

            // Create the request
            return HttpRequest.Get("https://maps.googleapis.com/maps/api/geocode/json", query);

        }

        #endregion

    }

}