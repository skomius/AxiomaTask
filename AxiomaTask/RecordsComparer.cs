using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxiomaTask.Models;

namespace AxiomaTask
{
    public class RecordsComparer: IEqualityComparer<Record>
    {
        public bool Equals(Record? a, Record? b)
        {
            if (a == null && b == null)
                return true;

            if (a == null || b == null) 
                return false;

            if(a.smac == b.smac && a.start == b.start && a.shost == b.shost && 
                a.rt == b.rt && a.dmac == b.dmac)
                return true;
            else 
                return false;
        }

        public int GetHashCode(Record value)
        {
            if (value == null)
                return 0;

            else
                return value.GetHashCode();
        }
    }
}
