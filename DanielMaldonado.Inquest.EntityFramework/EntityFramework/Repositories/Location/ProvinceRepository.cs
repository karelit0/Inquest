﻿using Abp.Domain.Entities.Auditing;
using Abp.EntityFramework;
using DanielMaldonado.Inquest.Entity.Location;
using DanielMaldonado.Inquest.Entity.Survey;
using DanielMaldonado.Inquest.EntityFramework.Mapping;
using DanielMaldonado.Inquest.Repository.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Repositories
{
    public class ProvinceRepository : InquestRepositoryBase<Province, Guid>, IProvinceRepository
    {
        #region Builders
        public ProvinceRepository(IDbContextProvider<InquestDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        #endregion
    }
}
