using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTstReportViewer.Model
{
    public class ActivityLog
    {
        public string JSONString { get; set; }

        public int durationMs { get; set; }
        public string name { get; set; }
        public string operationname { get; set; }
        public string resultSignature { get; set; }
        public DateTime time { get; set; }
    }
}
