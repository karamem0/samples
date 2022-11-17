//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

global using Beef.Database;
global using Beef.Database.SqlServer;
global using CoreEx;
global using CoreEx.Entities;
global using CoreEx.Http;
global using CoreEx.RefData;
global using CoreEx.Validation;
global using DbEx;
global using Microsoft.Extensions.DependencyInjection;
global using Moq;
global using NUnit.Framework;
global using System;
global using System.Net;
global using System.Reflection;
global using System.Threading;
global using System.Threading.Tasks;
global using UnitTestEx;
global using UnitTestEx.Expectations;
global using UnitTestEx.NUnit;
global using Karamem0.SampleApplication.Api;
global using Karamem0.SampleApplication.Business;
global using Karamem0.SampleApplication.Business.Data;
global using Karamem0.SampleApplication.Business.DataSvc;
global using Karamem0.SampleApplication.Business.Validation;
global using Karamem0.SampleApplication.Common.Agents;
global using HttpRequestOptions = CoreEx.Http.HttpRequestOptions;
