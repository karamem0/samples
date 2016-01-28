using Karamem0.Samples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.Samples
{

    public class Program
    {

        private static void Main(string[] args)
        {
            using (var context = new SharePointDataContext("http://localhost/"))
            {
                var item1 = new Test() { Title = "タイトル 1" };
                var item2 = new Test() { Title = "タイトル 2" };
                var item3 = new Test() { Title = "タイトル 3" };
                context.Tests.InsertOnSubmit(item1);
                context.Tests.InsertOnSubmit(item2);
                context.Tests.InsertOnSubmit(item3);
                context.SubmitChanges();
                foreach (var item in context.Tests)
                {
                    Console.WriteLine("{0}:{1}", item.ID, item.Title);
                }
                Console.ReadLine();
            }
        }

    }

}
