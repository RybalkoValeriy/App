using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using App.Domain.Abstract;
using Moq;
using App.Domain.Entites;
using App.Domain.Concrete;

namespace App.WebUI.infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        // Супер-фабрика, которая может создавать объекты всех видов, следуя намекам
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return
                controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepositiry>();
        }
    }
}