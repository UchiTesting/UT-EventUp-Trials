using Software.Entry;

using System.Net.Http;

namespace Software.Service
{
    public abstract class MediatedParnter
    {
        protected readonly ILogMediator _logMediator;

        public MediatedParnter(ILogMediator logMediator)
        {
            _logMediator = logMediator;
        }
    }
}
