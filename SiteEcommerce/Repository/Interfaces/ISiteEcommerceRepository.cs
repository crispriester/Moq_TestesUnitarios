﻿using Repository.Entidades;
using System;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface ISiteEcommerceRepository
    {
        List<SiteEcommerceEntity> GetCollection();
    }
}
