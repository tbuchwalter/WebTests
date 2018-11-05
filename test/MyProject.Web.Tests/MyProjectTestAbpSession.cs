using System;
using System.Collections.Generic;
using System.Text;
using Abp.Configuration.Startup;
using Abp.MultiTenancy;
using Abp.Runtime;
using Abp.Runtime.Session;
using Abp.TestBase.Runtime.Session;

namespace AllPoints.Web.Tests
{
    public class AllPointsTestAbpSession: TestAbpSession
    {
        public ClaimsAbpSession ClaimsAbpSession { get; set; }

        public AllPointsTestAbpSession(IMultiTenancyConfig multiTenacy,
            IAmbientScopeProvider<SessionOverride> sessionOverrideScopeProvider, ITenantResolver tenantResolver) : base(
            multiTenacy, sessionOverrideScopeProvider, tenantResolver)
        {
            
        }

        public override long? UserId
        {
            get => base.UserId ?? ClaimsAbpSession.UserId; // Fallback
            set => base.UserId = value;
        }
    }
}
