//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.SharePoint.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Models
{

    public class SharePointDataContext : DataContext
    {

        public SharePointDataContext(string url)
            : base(url)
        {
        }

        public EntityList<Test> Tests { get { return this.GetList<Test>("テスト"); } }

    }

}
