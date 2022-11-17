//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SampleApplication.Models
{

    public class ApplicationConfiguration
    {

        private IConfiguration config;

        public ApplicationConfiguration()
        {
            this.config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
        }

        public string GraphBlobStorage => this.config.GetValue<string>(nameof(GraphBlobStorage));

        public string GraphBlobContainer => this.config.GetValue<string>(nameof(GraphBlobContainer));

        public string GraphTenantId => this.config.GetValue<string>(nameof(GraphTenantId));

        public string GraphClientId => this.config.GetValue<string>(nameof(GraphClientId));

        public string GraphClientSecret => this.config.GetValue<string>(nameof(GraphClientSecret));

        public string GraphAuthority => this.config.GetValue<string>(nameof(GraphAuthority));

        public string GraphRedirectUrl => this.config.GetValue<string>(nameof(GraphRedirectUrl));

        public string GraphScope => this.config.GetValue<string>(nameof(GraphScope));

        public string GraphSubscribeUrl => this.config.GetValue<string>(nameof(GraphSubscribeUrl));

    }

}
