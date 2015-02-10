using Mlm.Domain.Abstract.Database;
using Mlm.Domain.DataBase;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Syntax;

namespace Mlm.Web.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                                    ? null :
                                    (IController)kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            kernel.Bind<IRepository>().To<DataBaseContext>();
        }
    }
}