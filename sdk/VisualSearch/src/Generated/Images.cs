// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.VisualSearch
{
    using Microsoft.Rest;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Images operations.
    /// </summary>
    public partial class Images : IServiceOperations<VisualSearchClient>, IImages
    {
        /// <summary>
        /// Initializes a new instance of the Images class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public Images(VisualSearchClient client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException("client");
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the VisualSearchClient
        /// </summary>
        public VisualSearchClient Client { get; private set; }

        /// <summary>
        /// Visual Search API lets you discover insights about an image such as
        /// visually similar images, shopping sources, and related searches. The API
        /// can also perform text recognition, identify entities (people, places,
        /// things), return other topical content for the user to explore, and more.
        /// For more information, see [Visual Search
        /// Overview](https://docs.microsoft.com/en-us/bing/bing-visual-search/overview).
        /// </summary>
        /// <param name='acceptLanguage'>
        /// A comma-delimited list of one or more languages to use for user interface
        /// strings. The list is in decreasing order of preference. For additional
        /// information, including expected format, see
        /// [RFC2616](http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html). This
        /// header and the
        /// [setLang](https://docs.microsoft.com/en-us/bing/bing-visual-search/overview)
        /// query parameter are mutually exclusive; do not specify both. If you set
        /// this header, you must also specify the
        /// [cc](https://docs.microsoft.com/en-us/bing/bing-visual-search/overview)
        /// query parameter. To determine the market to return results for, Bing uses
        /// the first supported language it finds from the list and combines it with
        /// the cc parameter value. If the list does not include a supported language,
        /// Bing finds the closest language and market that supports the request or it
        /// uses an aggregated or default market for the results. To determine the
        /// market that Bing used, see the BingAPIs-Market header. Use this header and
        /// the cc query parameter only if you specify multiple languages. Otherwise,
        /// use the
        /// [mkt](https://docs.microsoft.com/en-us/bing/bing-visual-search/overview)
        /// and
        /// [setLang](https://docs.microsoft.com/en-us/bing/bing-visual-search/overview)
        /// query parameters. A user interface string is a string that's used as a
        /// label in a user interface. There are few user interface strings in the JSON
        /// response objects. Any links to Bing.com properties in the response objects
        /// apply the specified language.
        /// </param>
        /// <param name='contentType'>
        /// Must be set to multipart/form-data and include a boundary parameter (for
        /// example, multipart/form-data; boundary=&lt;boundary string&gt;). For more
        /// details, see [Content form
        /// types](https://docs.microsoft.com/en-us/bing/bing-visual-search/overview).
        /// </param>
        /// <param name='userAgent'>
        /// The user agent originating the request. Bing uses the user agent to provide
        /// mobile users with an optimized experience. Although optional, you are
        /// encouraged to always specify this header. The user-agent should be the same
        /// string that any commonly used browser sends. For information about user
        /// agents, see [RFC
        /// 2616](http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html). The
        /// following are examples of user-agent strings. Windows Phone: Mozilla/5.0
        /// (compatible; MSIE 10.0; Windows Phone 8.0; Trident/6.0; IEMobile/10.0; ARM;
        /// Touch; NOKIA; Lumia 822). Android: Mozilla / 5.0 (Linux; U; Android 2.3.5;
        /// en - us; SCH - I500 Build / GINGERBREAD) AppleWebKit / 533.1 (KHTML; like
        /// Gecko) Version / 4.0 Mobile Safari / 533.1. iPhone: Mozilla / 5.0 (iPhone;
        /// CPU iPhone OS 6_1 like Mac OS X) AppleWebKit / 536.26 (KHTML; like Gecko)
        /// Mobile / 10B142 iPhone4; 1 BingWeb / 3.03.1428.20120423. PC: Mozilla / 5.0
        /// (Windows NT 6.3; WOW64; Trident / 7.0; Touch; rv:11.0) like Gecko. iPad:
        /// Mozilla / 5.0 (iPad; CPU OS 7_0 like Mac OS X) AppleWebKit / 537.51.1
        /// (KHTML, like Gecko) Version / 7.0 Mobile / 11A465 Safari / 9537.53.
        /// </param>
        /// <param name='clientId'>
        /// Bing uses this header to provide users with consistent behavior across Bing
        /// API calls. Bing often flights new features and improvements, and it uses
        /// the client ID as a key for assigning traffic on different flights. If you
        /// do not use the same client ID for a user across multiple requests, then
        /// Bing may assign the user to multiple conflicting flights. Being assigned to
        /// multiple conflicting flights can lead to an inconsistent user experience.
        /// For example, if the second request has a different flight assignment than
        /// the first, the experience may be unexpected. Also, Bing can use the client
        /// ID to tailor web results to that client ID’s search history, providing a
        /// richer experience for the user. Bing also uses this header to help improve
        /// result rankings by analyzing the activity generated by a client ID. The
        /// relevance improvements help with better quality of results delivered by
        /// Bing APIs and in turn enables higher click-through rates for the API
        /// consumer. IMPORTANT: Although optional, you should consider this header
        /// required. Persisting the client ID across multiple requests for the same
        /// end user and device combination enables 1) the API consumer to receive a
        /// consistent user experience, and 2) higher click-through rates via better
        /// quality of results from the Bing APIs. Each user that uses your application
        /// on the device must have a unique, Bing generated client ID. If you do not
        /// include this header in the request, Bing generates an ID and returns it in
        /// the X-MSEdge-ClientID response header. The only time that you should NOT
        /// include this header in a request is the first time the user uses your app
        /// on that device. Use the client ID for each Bing API request that your app
        /// makes for this user on the device. Persist the client ID. To persist the ID
        /// in a browser app, use a persistent HTTP cookie to ensure the ID is used
        /// across all sessions. Do not use a session cookie. For other apps such as
        /// mobile apps, use the device's persistent storage to persist the ID. The
        /// next time the user uses your app on that device, get the client ID that you
        /// persisted. Bing responses may or may not include this header. If the
        /// response includes this header, capture the client ID and use it for all
        /// subsequent Bing requests for the user on that device. ATTENTION: You must
        /// ensure that this Client ID is not linkable to any authenticatable user
        /// account information. If you include the X-MSEdge-ClientID, you must not
        /// include cookies in the request.
        /// </param>
        /// <param name='clientIp'>
        /// The IPv4 or IPv6 address of the client device. The IP address is used to
        /// discover the user's location. Bing uses the location information to
        /// determine safe search behavior. Although optional, you are encouraged to
        /// always specify this header and the X-Search-Location header. Do not
        /// obfuscate the address (for example, by changing the last octet to 0).
        /// Obfuscating the address results in the location not being anywhere near the
        /// device's actual location, which may result in Bing serving erroneous
        /// results.
        /// </param>
        /// <param name='location'>
        /// A semicolon-delimited list of key/value pairs that describe the client's
        /// geographical location. Bing uses the location information to determine safe
        /// search behavior and to return relevant local content. Specify the key/value
        /// pair as &lt;key&gt;:&lt;value&gt;. The following are the keys that you use
        /// to specify the user's location. lat (required): The latitude of the
        /// client's location, in degrees. The latitude must be greater than or equal
        /// to -90.0 and less than or equal to +90.0. Negative values indicate southern
        /// latitudes and positive values indicate northern latitudes. long (required):
        /// The longitude of the client's location, in degrees. The longitude must be
        /// greater than or equal to -180.0 and less than or equal to +180.0. Negative
        /// values indicate western longitudes and positive values indicate eastern
        /// longitudes. re (required): The radius, in meters, which specifies the
        /// horizontal accuracy of the coordinates. Pass the value returned by the
        /// device's location service. Typical values might be 22m for GPS/Wi-Fi, 380m
        /// for cell tower triangulation, and 18,000m for reverse IP lookup. ts
        /// (optional): The UTC UNIX timestamp of when the client was at the location.
        /// (The UNIX timestamp is the number of seconds since January 1, 1970.) head
        /// (optional): The client's relative heading or direction of travel. Specify
        /// the direction of travel as degrees from 0 through 360, counting clockwise
        /// relative to true north. Specify this key only if the sp key is nonzero. sp
        /// (optional): The horizontal velocity (speed), in meters per second, that the
        /// client device is traveling. alt (optional): The altitude of the client
        /// device, in meters. are (optional): The radius, in meters, that specifies
        /// the vertical accuracy of the coordinates. Specify this key only if you
        /// specify the alt key. Although many of the keys are optional, the more
        /// information that you provide, the more accurate the location results are.
        /// Although optional, you are encouraged to always specify the user's
        /// geographical location. Providing the location is especially important if
        /// the client's IP address does not accurately reflect the user's physical
        /// location (for example, if the client uses VPN). For optimal results, you
        /// should include this header and the X-MSEdge-ClientIP header, but at a
        /// minimum, you should include this header.
        /// </param>
        /// <param name='market'>
        /// The market where the results come from. Typically, mkt is the country where
        /// the user is making the request from. However, it could be a different
        /// country if the user is not located in a country where Bing delivers
        /// results. The market must be in the form &lt;language code&gt;-&lt;country
        /// code&gt;. For example, en-US. The string is case insensitive. For a list of
        /// possible market values, see [Market
        /// Codes](https://docs.microsoft.com/en-us/bing/bing-visual-search/overview).
        /// NOTE: If known, you are encouraged to always specify the market. Specifying
        /// the market helps Bing route the request and return an appropriate and
        /// optimal response. If you specify a market that is not listed in [Market
        /// Codes](https://docs.microsoft.com/en-us/bing/bing-visual-search/overview),
        /// Bing uses a best fit market code based on an internal mapping that is
        /// subject to change.
        /// </param>
        /// <param name='safeSearch'>
        /// Filter the image results in actions with type 'VisualSearch' for adult
        /// content. The following are the possible filter values. Off: May return
        /// images with adult content. Moderate: Do not return images with adult
        /// content. Strict: Do not return images with adult content. The default is
        /// Moderate. If the request comes from a market that Bing's adult policy
        /// requires that safeSearch is set to Strict, Bing ignores the safeSearch
        /// value and uses Strict. If you use the site: filter in the knowledge
        /// request, there is the chance that the response may contain adult content
        /// regardless of what the safeSearch query parameter is set to. Use site: only
        /// if you are aware of the content on the site and your scenario supports the
        /// possibility of adult content. Possible values include: 'Off', 'Moderate',
        /// 'Strict'
        /// </param>
        /// <param name='setLang'>
        /// The language to use for user interface strings. Specify the language using
        /// the ISO 639-1 2-letter language code. For example, the language code for
        /// English is EN. The default is EN (English). Although optional, you should
        /// always specify the language. Typically, you set setLang to the same
        /// language specified by mkt unless the user wants the user interface strings
        /// displayed in a different language. A user interface string is a string
        /// that's used as a label in a user interface. There are few user interface
        /// strings in the JSON response objects. Also, any links to Bing.com
        /// properties in the response objects apply the specified language.
        /// </param>
        /// <param name='knowledgeRequest'>
        /// The form data is a JSON object that identifies the image using an insights
        /// token or URL to the image. The object may also include an optional crop
        /// area that identifies an area of interest in the image. The insights token
        /// and URL are mutually exclusive – do not specify both. You may specify
        /// knowledgeRequest form data and image form data in the same request only if
        /// knowledgeRequest form data specifies the cropArea field only (it must not
        /// include an insights token or URL).
        /// </param>
        /// <param name='image'>
        /// The form data is an image binary. The Content-Disposition header's name
        /// parameter must be set to "image". You must specify an image binary if you
        /// do not use knowledgeRequest form data to specify the image; you may not use
        /// both forms to specify an image. You may specify knowledgeRequest form data
        /// and image form data in the same request only if knowledgeRequest form data
        /// specifies the cropArea field only  (it must not include an insights token
        /// or URL).
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<ImageKnowledge>> VisualSearchMethodWithHttpMessagesAsync(string acceptLanguage = default(string), string contentType = default(string), string userAgent = default(string), string clientId = default(string), string clientIp = default(string), string location = default(string), string market = default(string), string safeSearch = default(string), string setLang = default(string), string knowledgeRequest = default(string), Stream image = default(Stream), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            string xBingApisSDK = "true";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("xBingApisSDK", xBingApisSDK);
                tracingParameters.Add("acceptLanguage", acceptLanguage);
                tracingParameters.Add("contentType", contentType);
                tracingParameters.Add("userAgent", userAgent);
                tracingParameters.Add("clientId", clientId);
                tracingParameters.Add("clientIp", clientIp);
                tracingParameters.Add("location", location);
                tracingParameters.Add("market", market);
                tracingParameters.Add("safeSearch", safeSearch);
                tracingParameters.Add("setLang", setLang);
                tracingParameters.Add("knowledgeRequest", knowledgeRequest);
                tracingParameters.Add("image", image);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "VisualSearchMethod", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "images/visualsearch").ToString();
            List<string> _queryParameters = new List<string>();
            if (market != null)
            {
                _queryParameters.Add(string.Format("mkt={0}", System.Uri.EscapeDataString(market)));
            }
            if (safeSearch != null)
            {
                _queryParameters.Add(string.Format("safeSearch={0}", System.Uri.EscapeDataString(safeSearch)));
            }
            if (setLang != null)
            {
                _queryParameters.Add(string.Format("setLang={0}", System.Uri.EscapeDataString(setLang)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (xBingApisSDK != null)
            {
                if (_httpRequest.Headers.Contains("X-BingApis-SDK"))
                {
                    _httpRequest.Headers.Remove("X-BingApis-SDK");
                }
                _httpRequest.Headers.TryAddWithoutValidation("X-BingApis-SDK", xBingApisSDK);
            }
            if (acceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("Accept-Language"))
                {
                    _httpRequest.Headers.Remove("Accept-Language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("Accept-Language", acceptLanguage);
            }
            if (userAgent != null)
            {
                if (_httpRequest.Headers.Contains("User-Agent"))
                {
                    _httpRequest.Headers.Remove("User-Agent");
                }
                _httpRequest.Headers.TryAddWithoutValidation("User-Agent", userAgent);
            }
            if (clientId != null)
            {
                if (_httpRequest.Headers.Contains("X-MSEdge-ClientID"))
                {
                    _httpRequest.Headers.Remove("X-MSEdge-ClientID");
                }
                _httpRequest.Headers.TryAddWithoutValidation("X-MSEdge-ClientID", clientId);
            }
            if (clientIp != null)
            {
                if (_httpRequest.Headers.Contains("X-MSEdge-ClientIP"))
                {
                    _httpRequest.Headers.Remove("X-MSEdge-ClientIP");
                }
                _httpRequest.Headers.TryAddWithoutValidation("X-MSEdge-ClientIP", clientIp);
            }
            if (location != null)
            {
                if (_httpRequest.Headers.Contains("X-Search-Location"))
                {
                    _httpRequest.Headers.Remove("X-Search-Location");
                }
                _httpRequest.Headers.TryAddWithoutValidation("X-Search-Location", location);
            }


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            MultipartFormDataContent _multiPartContent = new MultipartFormDataContent();
            if (knowledgeRequest != null)
            {
                StringContent _knowledgeRequest = new StringContent(knowledgeRequest, System.Text.Encoding.UTF8);
                _multiPartContent.Add(_knowledgeRequest, "knowledgeRequest");
            }
            if (image != null)
            {
                StreamContent _image = new StreamContent(image);
                _image.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                ContentDispositionHeaderValue _contentDispositionHeaderValue = new ContentDispositionHeaderValue("form-data");
                _contentDispositionHeaderValue.Name = "image";
                // get filename from stream if it's a file otherwise, just use  'unknown'
                var _fileStream = image as FileStream;
                var _fileName = (_fileStream != null ? _fileStream.Name : null) ?? "unknown";
                if(System.Linq.Enumerable.Any(_fileName, c => c > 127) )
                {
                    // non ASCII chars detected, need UTF encoding:
                    _contentDispositionHeaderValue.FileNameStar = _fileName;
                }
                else
                {
                    // ASCII only
                    _contentDispositionHeaderValue.FileName = _fileName;
                }
                _image.Headers.ContentDisposition = _contentDispositionHeaderValue;
                _multiPartContent.Add(_image, "image");
            }
            _httpRequest.Content = _multiPartContent;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new ErrorResponseException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    ErrorResponse _errorBody =  Rest.Serialization.SafeJsonConvert.DeserializeObject<ErrorResponse>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<ImageKnowledge>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = Rest.Serialization.SafeJsonConvert.DeserializeObject<ImageKnowledge>(_responseContent, Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

    }
}
