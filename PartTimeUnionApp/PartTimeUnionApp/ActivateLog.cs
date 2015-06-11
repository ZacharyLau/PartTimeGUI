using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class ActivityLog
    {
        ActivityLogDataAdapter log; //= new ActivityLogDataAdapter();
        String id;

        public ActivityLog(String id, String pass)
        {
            this.id = id;
            log = new ActivityLogDataAdapter(id, pass);
        }

        public ADTArray<String[]> GetRecord()
        {
            //for each taple:
            //0:date
            //1:id
            //2:message
            return log.GetRecord(id);
        }

        public void InsertRecord(String message)
        {
            log.InsertRecord(id, message);
        }



        
    }
}
