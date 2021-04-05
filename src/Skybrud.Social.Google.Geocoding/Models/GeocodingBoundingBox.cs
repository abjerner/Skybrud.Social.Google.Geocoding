using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Geocoding.Models {
    
    /// <summary>
    /// Class representing a bounding box of a <see cref="GeocodingResult"/>.
    /// </summary>
    public class GeocodingBoundingBox : GoogleApiObject {

        #region Properties

        /// <summary>
        /// Gets the north east point of the bounding box.
        /// </summary>
        public GeocodingLocation NorthEast { get; }

        /// <summary>
        /// Gets the south west point of the bounding box.
        /// </summary>
        public GeocodingLocation SouthWest { get; }

        #endregion

        #region Constructors

        private GeocodingBoundingBox(JObject obj) : base(obj) {
            NorthEast = obj.GetObject("northeast", GeocodingLocation.Parse);
            SouthWest = obj.GetObject("southwest", GeocodingLocation.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="GeocodingBoundingBox"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the address component.</param>
        /// <returns>An instance of <see cref="GeocodingBoundingBox"/>.</returns>
        public static GeocodingBoundingBox Parse(JObject obj) {
            return obj == null ? null : new GeocodingBoundingBox(obj);
        }

        #endregion

    }

}