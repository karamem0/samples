//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using AdaptiveCards.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

var template = new AdaptiveCardTemplate(File.ReadAllText("Template.json"));

// JSON 文字列から Adaptive Cards を生成する場合
var json = """
    {
        "title": "Please confirm your order:",
        "customer": [
            {
                "firstName": "John",
                "lastName": "Smith",
                "phone": "(555) 555-5555"
            }
        ]
    }
""";
Console.WriteLine(template.Expand(json));

// オブジェクトから Adaptive Cards を生成する場合
var data = new
{
    Title = "Please confirm your order:",
    Customer = new[]
    {
        new
        {
            FirstName = "John",
            LastName = "Smith",
            Phone = "(555) 555-5555"
        }
    }
};
Console.WriteLine(template.Expand(data));
