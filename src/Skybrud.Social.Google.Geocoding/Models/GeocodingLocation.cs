using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Geocoding.Models {

    /// <summary>
    /// Class representing a point within a <see cref="GeocodingResult"/>.
    /// </summary>
    public class GeocodingLocation : GoogleApiObject, IPoint {

        #region Properties

        /// <summary>
        /// Gets the latitude of the point.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// gets the longitude of the point.
        /// </summary>
        public double Longitude { get; }

        #endregion

        #region Constructors

        private GeocodingLocation(JObject obj) : base(obj) {
            Latitude = obj.GetDouble("lat");
            Longitude = obj.GetDouble("lng");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="GeocodingLocation"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the location.</param>
        /// <returns>An instance of <see cref="GeocodingLocation"/>.</returns>
        public static GeocodingLocation Parse(JObject obj) {
            return obj == null ? null : new GeocodingLocation(obj);
        }

        #endregion

    }

}