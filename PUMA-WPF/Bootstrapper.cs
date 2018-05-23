﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;
using Prism.Logging;
using Prism.DryIoc;
using DryIoc;
using Prism.Mvvm;
using PUMA_WPF.View_Models;
using PumaWpf.Modules.Survey;
using PumaWpf.Modules.Survey.ViewModels;
using PumaWpf.Modules.Survey.Views;

namespace PUMA_WPF
{
    class Bootstrapper : DryIocBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
        
        protected override void ConfigureViewModelLocator()
        {
            BindViewModelToView<MainWindowViewModel, MainWindow>();
            BindViewModelToView<SurveyActionViewModel, SurveyActionView>();
            BindViewModelToView<NewSurveyViewModel, NewSurveyView>();
        }

        public void BindViewModelToView<TViewModel, TView>()
        {
            ViewModelLocationProvider.Register(typeof(TView).ToString(), () => Container.Resolve<TViewModel>());
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (MainWindow)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            //moduleCatalog.AddModule(typeof(YOUR_MODULE));
            moduleCatalog.AddModule(typeof(SurveyModule));
        }
        
        protected override ILoggerFacade CreateLogger()
        {
            // CustomLogger is a custom logger implementation.            
            return new Nlogger();
        }   
    }
}
