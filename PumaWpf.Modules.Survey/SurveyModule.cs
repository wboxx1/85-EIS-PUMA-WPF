using PumaWpf.Modules.Survey.Views;
using Prism.Modularity;
using Prism.Regions;
using Prism.Events;
using System;
using DryIoc;
using Prism.DryIoc;
using PumaWpf.Modules.Survey.Events;
using PumaWpf.Infrastructure.Constants;
using System.Collections.Generic;

namespace PumaWpf.Modules.Survey
{
    public class SurveyModule : IModule
    {
        private IRegionManager _regionManager;
        private IContainer _container;
        private IEventAggregator _eventAggregator;

        public SurveyModule(IContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<LoadAllSurveyViewsEvent>().Subscribe(LoadViews);
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<SurveyActionView>();
        }

        private void LoadViews(object payload)
        {
            // Header Region
            var regionInstance = _regionManager.Regions[RegionNames.HeaderRegion];
            ClearRegion(regionInstance);

            // Action Region
            regionInstance = _regionManager.Regions[RegionNames.ActionRegion];
            ClearRegion(regionInstance);
            var surveyActionViewInstance = new SurveyActionView();
            regionInstance.Add(surveyActionViewInstance,"SurveyModule.SurveyActionView");
            regionInstance.Activate(regionInstance.GetView("SurveyModule.SurveyActionView"));

            // Plot Region
            regionInstance = _regionManager.Regions[RegionNames.PlotRegion];
            ClearRegion(regionInstance);

            // Equipment Region
            regionInstance = _regionManager.Regions[RegionNames.EquipmentRegion];
            ClearRegion(regionInstance);
        }
        
        public static void ClearRegion(IRegion region)
        {
            // Get existing view names
            var oldViewNames = new List<string>();
            foreach (var v in region.Views)
            {
                var s = v.ToString();
                oldViewNames.Add(s);
            }

            // Remove existing views
            foreach (var oldViewName in oldViewNames)
            {
                var oldView = region.GetView(oldViewName);
                region.Deactivate(oldView);
            }
        }
    }
}