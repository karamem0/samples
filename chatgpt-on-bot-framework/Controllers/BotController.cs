//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Controllers
{

    [Route("api/messages")]
    [ApiController()]
    public class BotController : ControllerBase
    {

        private readonly IBotFrameworkHttpAdapter adapter;
        private readonly IBot bot;

        public BotController(IBotFrameworkHttpAdapter adapter, IBot bot)
        {
            this.adapter = adapter;
            this.bot = bot;
        }

        [HttpPost()]
        public async Task PostAsync()
        {
            await this.adapter.ProcessAsync(this.Request, this.Response, this.bot);
        }

    }

}
