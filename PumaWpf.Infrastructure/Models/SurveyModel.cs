using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumaWpf.Infrastructure.Models
{
    public class SurveyModel
    {
        public string Name { get; set; }
        public IList<Uri> MissionUris { get; set; }
        public Uri SelectedMissionUri { get; set; }
        public IList<TestPointModel> TestPoints { get; set; } 
        public Int32 NumberTestPoints { get; set; }
    }

    public class TestPointModel
    {
        public Int32 ID { get; set; }
        public Int32 Heading { get; set; }
        public Int32 Offset { get; set; }
        public Int32 Rotation { get; set; }
        public Int32 Allignment { get; set; }
    }
}
