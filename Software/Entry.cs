using Software.Logger;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software
{
    /// <summary>
    /// Entry class using the Service
    /// This class has a dependency on the logger which cannot be null checked
    /// Logger is fine here but putting log into the service breaks it when the context changes and it is not initialised
    /// Typically into the tests.
    /// </summary>
    internal class Entry
    {
        BasicLogger _logger = new BasicLogger();
        Service service = new Service();

        public void DoEntryAction()
        {
            service.DoService();
            _logger.Log(LogLevels.Info, "Logging anything from Entry class");
        }
    }
}
