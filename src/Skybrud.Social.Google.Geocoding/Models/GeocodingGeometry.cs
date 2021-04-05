using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.Geocoding.Models {

    /// <summary>
    /// Class representing the geometry of a <see cref="GeocodingResult"/>.
    /// </summary>
    public class GeocodingGeometry : GoogleApiObject {

        #region Properties

        /// <summary>
        /// Gets the bounding box which can fully contain the returned result. Note that these bounds may not match the
        /// recommended viewport. (For example, San Francisco includes the Farallon islands, which are technically part
        /// of the city, but probably should not be returned in the viewport).
        /// </summary>
        public GeocodingBoundingBox Bounds { get; }

        /// <summary>
        /// Gets whether the <see cref="Bounds"/> property is specified.
        /// </summary>
        public bool HasBounds => Bounds != null;

        /// <summary>
        /// Gets the geocoded latitude and longitude value. For normal address lookups, this field is typically the
        /// most important.
        /// </summary>
        public GeocodingLocation Location { get; }

        /// <summary>
        /// Gets additional data about the specified location.
        /// </summary>
        public GeocodingLocationType LocationType { get; }

        /// <summary>
        /// Gets the recommended viewport for displaying the returned result, specified as two latitude and longitude
        /// values defining the southwest and northeast corner of the viewport bounding box. Generally the viewport is
        /// used to frame a result when displaying it to a user.
        /// </summary>
        public GeocodingBoundingBox Viewport { get; }

        #endregion

        #region Constructors

        private GeocodingGeometry(JObject obj) : base(obj) {
            Bounds = obj.GetObject("bounds", GeocodingBoundingBox.Parse);
            Location = obj.GetObject("location", GeocodingLocation.Parse);
            LocationType = obj.GetEnum<GeocodingLocationType>("location_type");
            Viewport = obj.GetObject("viewport", GeocodingBoundingBox.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="GeocodingGeometry"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the address component.</param>
        /// <returns>An instance of <see cref="GeocodingGeometry"/>.</returns>
        public static GeocodingGeometry Parse(JObject obj) {
            return obj == null ? null : new GeocodingGeometry(obj);
        }

        #endregion

    }

}