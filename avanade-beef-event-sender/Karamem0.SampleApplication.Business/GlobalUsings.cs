//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

global using CoreEx;
global using CoreEx.Caching;
global using CoreEx.Configuration;
global using CoreEx.Database;
global using CoreEx.Database.SqlServer;
global using CoreEx.Entities;
global using CoreEx.Entities.Extended;
global using CoreEx.EntityFrameworkCore;
global using CoreEx.Events;
global using CoreEx.Http;
global using CoreEx.Http.Extended;
global using CoreEx.Invokers;
global using CoreEx.Json;
global using CoreEx.Mapping;
global using CoreEx.Mapping.Converters;
global using CoreEx.RefData;
global using CoreEx.RefData.Extended;
global using CoreEx.Validation;
global using CoreEx.Validation.Rules;
global using Microsoft.Data.SqlClient;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Logging;
global using System;
global using System.Collections.Generic;
global using System.Data.Common;
global using System.Diagnostics;
global using System.Linq;
global using System.Text.Json.Serialization;
global using System.Text.RegularExpressions;
global using System.Net.Http;
global using System.Threading;
global using System.Threading.Tasks;
global using Karamem0.SampleApplication.Business;
global using Karamem0.SampleApplication.Business.Entities;
global using Karamem0.SampleApplication.Business.Data;
global using Karamem0.SampleApplication.Business.DataSvc;
global using Karamem0.SampleApplication.Business.Validation;
global using RefDataNamespace = Karamem0.SampleApplication.Business.Entities;
