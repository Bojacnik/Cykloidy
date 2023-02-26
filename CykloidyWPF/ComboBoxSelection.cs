using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CykloidyWPF
{
    public static class ComboBoxSelection
    {
        private static readonly KeyValuePair<int, string>[] tripLengthList = {
            new KeyValuePair<int, string>(0, "0"),
            new KeyValuePair<int, string>(30, "30"),
            new KeyValuePair<int, string>(50, "50"),
            new KeyValuePair<int, string>(100, "100"),
        };

        public static KeyValuePair<int, string>[] TripLengthList
        {
            get
            {
                return tripLengthList;
            }
        }
    }
}
