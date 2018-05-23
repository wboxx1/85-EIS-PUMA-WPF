using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumaWpf.Infrastructure
{
    public static class PumaWpfCommands
    {
        public static CompositeCommand RunSurveyCommand { get; set; } = new CompositeCommand(true);
        public static CompositeCommand StopSurveyCommand { get; set; } = new CompositeCommand(true);
        public static CompositeCommand PauseSurveyCommand { get; set; } = new CompositeCommand(true);
    }
}
