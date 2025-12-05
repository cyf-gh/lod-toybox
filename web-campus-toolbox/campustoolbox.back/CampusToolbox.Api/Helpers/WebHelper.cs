using CampusToolbox.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;

namespace CampusToolbox.Api {
    public static class WebHelper {
        public static T GetObjectFromJsonInRequest<T>( HttpRequest request ) {
            MemoryStream stream = new MemoryStream();
            request.Body.CopyTo( stream );
            stream.Position = 0;
            using( StreamReader reader = new StreamReader( stream ) ) {
                string requestBody = reader.ReadToEnd();
                if( requestBody.Length > 0 ) {
                    return JsonConvert.DeserializeObject<T>( requestBody );
                }
            }
            throw new InvalidContentException( request );
        }

        public static T GetObjectFromJsonString<T>( string jsonStr ) {
            return JsonConvert.DeserializeObject<T>( jsonStr );
        }
    }
}
