using Software.Logger;
using Software.Service;

using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Software.Entry
{
    // TODO implémenter un médiateur et l'utiliser dans cette verison de l'Entry
    internal class EntryWithMediator
    {
        BasicLogger _logger = new BasicLogger();
        ILogMediator _logMediator;
        MediatedService _mediatedService;
        AnotherMediatedService _anotherMediatedService;

        public EntryWithMediator()
        {
            _logMediator = new LogMediator();
            _mediatedService = new MediatedService(_logMediator);
            _anotherMediatedService = new AnotherMediatedService(_logMediator);

            // Register loggers
            (_logMediator as LogMediator).RegisterLogger(_logger);

            // Register partners
            (_logMediator as LogMediator).RegisterPartner(_mediatedService);
            (_logMediator as LogMediator).RegisterPartner(_anotherMediatedService);
        }


        public void DoEntryAction()
        {
            _mediatedService.DoAnything();
        }

        public void DoAnotherAction(string val)
        {
            _anotherMediatedService.DoAnythingAnotherWay(val);
        }
    }

    public interface ILogMediator
    {
        void Notify(object sender, BasicEventArgs e);
    }

    public class LogMediator : ILogMediator
    {
        private List<MediatedParnter> _partners = new List<MediatedParnter>();
        private List<Software.Logger.ILogger> _loggers = new List<Software.Logger.ILogger>();

        public void RegisterLogger(Software.Logger.ILogger logger)
        {
            if (!_loggers.Contains(logger))
                _loggers.Add(logger);
        }

        public void UnregisterLogger(Software.Logger.ILogger logger)
        {
            if (_loggers.Contains(logger))
                _loggers.Remove(logger);
        }

        public void RegisterPartner(MediatedParnter partner)
        {
            if (!_partners.Contains(partner))
                _partners.Add(partner);
        }

        public void UnregisterParnter(MediatedParnter partner)
        {
            if(_partners.Contains(partner))
                _partners.Remove(partner);

        }

        void ILogMediator.Notify(object sender, BasicEventArgs e)
        {
            string logDate = DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss,fff");

            System.Diagnostics.Trace.WriteLine($"{logDate} | {e.Source}@{ sender.GetHashCode()} | {e.Message}");

            SendToRegisteredLoggers(sender, e);
        }

        public void SendToRegisteredLoggers(object sender, BasicEventArgs e) {
            var logLevelEnumValue = LogLevelsInfo.GetLogLevelEnumValueFromString(e.LogLevel);
            _loggers.ForEach(l => l.Log(logLevelEnumValue,e.Message));
        }
    }
}
