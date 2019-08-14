﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mollie.Extensions
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content) =>
            client.PatchAsync(CreateUri(requestUri), content);

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content) =>
            client.PatchAsync(requestUri, content, CancellationToken.None);

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content, CancellationToken cancellationToken) =>
            client.PatchAsync(CreateUri(requestUri), content, cancellationToken);

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content, CancellationToken cancellationToken) =>
            client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = content }, cancellationToken);

        private static Uri CreateUri(string uri) =>
            string.IsNullOrEmpty(uri) ? null : new Uri(uri, UriKind.RelativeOrAbsolute);
    }
}
