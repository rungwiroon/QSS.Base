using System.Diagnostics;

namespace QSS.Base
{
    public interface IEventLog
    {
        void WriteEntry(string message);

        void WriteEntry(string message, EventLogEntryType type);
    }
}