﻿using Mlm.Domain.DataBase;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;


namespace Mlm.Web.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            }
            catch(Exception e)
            {

            }
            
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<DataBaseContext>(null);

                try
                {
                    using (var context = new DataBaseContext())
                    {
                        if (!context.Database.Exists())
                        {
                            
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Users", "Id", "Login", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized.", ex);
                }
            }
        }
    }
}