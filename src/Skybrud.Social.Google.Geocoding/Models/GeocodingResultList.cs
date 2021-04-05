using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Geocoding.Models {

    /// <summary>
    /// Class representing a list of geocoding results received from the Google Geocoding API.
    /// </summary>
    public class GeocodingResultList : GoogleApiObject {

        #region Properties

        /// <summary>
        /// Gets an array of places that matched your query.
        /// </summary>
        public GeocodingResult[] Results { get; }

        /// <summary>
        /// Gets the status of the response from the Geocoding API. At this point, <see cref="Status"/> will most
        /// likely always be <c>OK</c>.
        /// </summary>
        public string Status { get; }

        #endregion

        #region Constructors

        private GeocodingResultList(JObject obj) : base(obj) {
            Results = obj.GetArrayItems("results", GeocodingResult.Parse);
            Status = obj.GetString("status");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="GeocodingResultList"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the collection.</param>
        /// <returns>An instance of <see cref="GeocodingResultList"/>.</returns>
        public static GeocodingResultList Parse(JObject obj) {
            return obj == null ? null : new GeocodingResultList(obj);
        }

        #endregion

    }

}