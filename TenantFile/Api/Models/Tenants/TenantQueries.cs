﻿using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Data;
using System;

using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TenantFile.Api.DataLoader;
using TenantFile.Api.Extensions;
using TenantFile.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TenantFile.Api.Tenants
{
    [ExtendObjectType(Name = "Query")]
    public class TenantQueries
    {
        [UseTenantFileContext]
        [UsePaging]
        //[UseSelection]
        //[UseFiltering]
        //[UseSorting]
        public IQueryable<Tenant> GetTenants([ScopedService] TenantFileContext tenantContext) => tenantContext.Tenants.AsQueryable();

        public Task<Tenant> GetTenantAsync(int id, TenantByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}