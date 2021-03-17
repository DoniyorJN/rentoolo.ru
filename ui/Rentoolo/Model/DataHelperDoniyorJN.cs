using System.Collections.Generic;
using System.Linq;

namespace Rentoolo.Model
{
    public static class DataHelperDoniyorJN
    {
        public static List<NewsDoniyorJN> GetActiveNews()
        {
            using (var ctx = new RentooloEntities())
            {
                List<NewsDoniyorJN> list = ctx.NewsDoniyorJN.Where(x => x.Active).OrderByDescending(x => x.Date).ToList();

                return list;
            }
        }
    }
}