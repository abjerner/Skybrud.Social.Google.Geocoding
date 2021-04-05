using System;
using Skybrud.Social.Google.Geocoding.Http;
using Skybrud.Social.Google.OAuth;

#pragma warning disable 1591

namespace Skybrud.Social.Google.Geocoding {

    public static class GeocodingExtensions {

        /// <summary>
        /// Returns the <see cref="GeocodingHttpClient"/> of the specified Google OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The Google OAuth client.</param>
        /// <returns>An instance of <see cref="GeocodingHttpClient"/>.</returns>
        /// <remarks>
        /// The <see cref="GeocodingHttpClient"/> instance keeps an internal registry ensuring that calling this method
        /// multiple times for the same <paramref name="client"/> will result in the same instance of
        /// <see cref="GeocodingHttpClient"/>.
        ///
        /// Specifically the <see cref="GeocodingHttpClient"/> instance will be created the first time this method is
        /// called, while any subsequent calls to this method will result in the instance saved registry being
        /// returned.
        /// </remarks>
        public static GeocodingHttpClient Geocoding(this GoogleOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return client.GetApiClient(() => new GeocodingHttpClient(client));
        }

        /// <summary>
        /// Returns the <see cref="GeocodingService"/> instance of the specified Google <paramref name="service"/>.
        /// </summary>
        /// <param name="service">The Google service.</param>
        /// <returns>An instance of <see cref="GeocodingService"/>.</returns>
        /// <remarks>
        /// The <see cref="GoogleService"/> instance keeps an internal registry ensuring that calling this method
        /// multiple times for the same <paramref name="service"/> will result in the same instance of
        /// <see cref="GeocodingService"/>.
        ///
        /// Specifically the <see cref="GeocodingService"/> instance will be created the first time this method is
        /// called, while any subsequent calls to this method will result in the instance saved registry being
        /// returned.
        /// </remarks>
        public static GeocodingService Geocoding(this GoogleService service) {
            if (service == null) throw new ArgumentNullException(nameof(service));
            return service.GetApiService(() => new GeocodingService(service));
        }

    }

}