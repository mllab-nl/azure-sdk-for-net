﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Options;

namespace Azure.Core.Extensions
{
    internal class ConfigureClientCredentials<TClient, TOptions> : IConfigureNamedOptions<AzureClientCredentialOptions<TClient>>
    {
        private readonly ClientRegistration<TClient, TOptions> _registration;
        private readonly Func<IServiceProvider, TokenCredential> _credentialFactory;

        public ConfigureClientCredentials(
            ClientRegistration<TClient, TOptions> registration,
            Func<IServiceProvider, TokenCredential> credentialFactory)
        {
            _registration = registration;
            _credentialFactory = credentialFactory;
        }

        public void Configure(AzureClientCredentialOptions<TClient> options)
        {
        }

        public void Configure(string name, AzureClientCredentialOptions<TClient> options)
        {
            if (name == _registration.Name)
            {
                options.CredentialFactory = _credentialFactory;
            }
        }
    }
}