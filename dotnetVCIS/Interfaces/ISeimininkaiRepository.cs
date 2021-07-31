﻿using dotnetVCIS.Models;
using System;
using System.Collections.Generic;

namespace dotnetVCIS.Repositories
{
    public interface ISeimininkaiRepository
    {
        IEnumerable<Seimininkas> GetSeimininkas();
        Seimininkas GetSeimininkas(Guid id_seimininkas);
        void CreateSeimininkas(Seimininkas seimininkas);
        void UpdateSeimininkas(Seimininkas seimininkas);
        void DeleteSeimininkas(Guid id_seimininkas);
    }
}