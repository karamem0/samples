//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using SampleApplication.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication
{

    public class BearerClientMessageInspector : IClientMessageInspector
    {

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var property = new HttpRequestMessageProperty();
            property.Headers.Add("Authorization", "Bearer " + Settings.Default.AccessToken);
            request.Properties[HttpRequestMessageProperty.Name] = property;
            return null;
        }

    }

}
