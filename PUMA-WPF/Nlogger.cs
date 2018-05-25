using Prism.Logging;
using NLog;

namespace PumaWpf
{
    class Nlogger : ILoggerFacade
    {
        //Private ReadOnly _log As Logger = LogManager.GetCurrentClassLogger()
        private static Logger _log = LogManager.GetCurrentClassLogger();

        #region ILoggerFacade Members

        public void Log(string message, Category category, Priority priority)
        {
            var nLogCategory = string.Empty;

            switch (category)
            {
                case Category.Debug:
                    _log.Debug(message);
                    break;
                case Category.Info:
                    break;
                case Category.Warn:
                    break;
                case Category.Exception:
                    break;
            }                
        }

        #endregion
    }
}
