using Dapper;
using System;
using System.Text;

namespace GuiSamples.Data
{
    public class DbLog
    {
        public long Id { get; set; }
        public string Message { get; set; }
    }
}
