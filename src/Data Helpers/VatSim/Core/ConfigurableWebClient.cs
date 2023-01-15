// Decompiled with JetBrains decompiler
// Type: RossCarlson.VatSim.VatSpy.Core.ConfigurableWebClient
// Assembly: VATSpy, Version=1.3.3.19, Culture=neutral, PublicKeyToken=null
// MVID: 191BE92D-D460-48E2-AF38-70BEFDB1F90E
// Assembly location: D:\Flight Sim\VATSpy\VATSpy.exe

using System;
using System.Net;

namespace VatSim.Core
{
    public class ConfigurableWebClient : WebClient
    {
        private readonly int mTimeout;

        public ConfigurableWebClient(int timeout) => this.mTimeout = timeout;

        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest webRequest = base.GetWebRequest(uri);
            webRequest.Timeout = this.mTimeout;
            return webRequest;
        }
    }
}
