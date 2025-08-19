//
// Copyright (c) 2011-2024 karamem0
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

    [ContentType(Name = "テスト", Id = "0x01")]
    public class Test : Item
    {

        public Test() { }

    }

}
