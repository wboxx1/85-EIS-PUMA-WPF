using PumaWpf.Modules.Survey.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using DryIoc;
using Prism.DryIoc;

namespace PumaWpf.Modules.Survey
{
    public class SurveyModule : IModule
    {
        private IRegionManager _regionManager;
        private IContainer _container;

        public SurveyModule(IContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewA>();
        }
    }
}