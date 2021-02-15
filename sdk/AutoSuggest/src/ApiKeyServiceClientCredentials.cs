using System;
using System.Collections.Generic;
using System.Text;


namespace Microsoft.Bing.AutoSuggest
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApiKeyServiceClientCredentials : ServiceClientCredentials
    {

        private readonly string subscriptionKey;

        /// <summary>
        /// Creates a new instance of the ClientCredentials class
        /// </summary>
        /// <param name="subscriptionKey">The subscription key to authenticate and authorize as</param>
        public ApiKeyServiceClientCredentials(string subscriptionKey)
        {
            this.subscriptionKey = subscriptionKey;
        }

        /// <summary>
        /// Add the Basic Authentication Header to each outgoing request
        /// </summary>
        /// <param name="request">The outgoing request</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            request.Headers.Add("Ocp-Apim-Subscription-Key", this.subscriptionKey);

            return Task.FromResult<object>(null);

        }
    }
}
