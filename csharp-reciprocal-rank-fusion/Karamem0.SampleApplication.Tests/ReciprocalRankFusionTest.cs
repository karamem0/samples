//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication;

[TestFixture()]
public class ReciprocalRankFusionTests
{

    [Test()]
    public void FuseTest()
    {
        // Arrange
        var rankings = new List<List<Tuple<string, double, string>>>
        {
            new()
            {
                Tuple.Create("A", 0.8, "A"),
                Tuple.Create("B", 0.6, "B"),
                Tuple.Create("C", 0.4, "C")
            },
            new()
            {
                Tuple.Create("B", 0.7, "B"),
                Tuple.Create("A", 0.5, "A"),
                Tuple.Create("C", 0.3, "C")
            },
            new()
            {
                Tuple.Create("C", 0.9, "C"),
                Tuple.Create("A", 0.2, "A"),
                Tuple.Create("B", 0.1, "B")
            }
        };
        var expected = new List<Tuple<string, double, string>>
        {
            Tuple.Create("A", (1.0 / 1) + (1.0 / 2) + (1.0 / 2), "A"),
            Tuple.Create("B", (1.0 / 2) + (1.0 / 1) + (1.0 / 3), "B"),
            Tuple.Create("C", (1.0 / 3) + (1.0 / 3) + (1.0 / 1), "C")
        };
        // Act
        var actual = ReciprocalRankFusion.Fuse(rankings, 0.0);
        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

}
