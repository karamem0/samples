//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication;

public class ReciprocalRankFusion
{

    public static IEnumerable<Tuple<string, double, T>> Fuse<T>(IEnumerable<IEnumerable<Tuple<string, double, T>>> rankings, double k = 60)
    {
        var result = new List<Tuple<string, double, T>>();
        foreach (var ranking in rankings)
        {
            var ordered = ranking.OrderByDescending(x => x.Item2).Select((value, order) => Tuple.Create(value, order + 1.0));
            foreach (var (value, order) in ordered)
            {
                var index = result.FindIndex(x => x.Item1 == value.Item1);
                if (index < 0)
                {
                    result.Add(Tuple.Create(value.Item1, 1.0 / (order + k), value.Item3));
                }
                else
                {
                    result[index] = Tuple.Create(result[index].Item1, result[index].Item2 + 1.0 / (order + k), result[index].Item3);
                }
            }
        }
        return result.OrderByDescending(x => x.Item2);
    }

}
