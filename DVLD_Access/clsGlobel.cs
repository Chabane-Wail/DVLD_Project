using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLD_Access
{
    public class clsGlobel
    {
        public static void EventLogView(string Massage,EventLogEntryType LogType ,string sourceName = "DVLD_Project")
        {

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
               
            }
            EventLog.WriteEntry(sourceName,Massage,LogType);


        }


    }
}
