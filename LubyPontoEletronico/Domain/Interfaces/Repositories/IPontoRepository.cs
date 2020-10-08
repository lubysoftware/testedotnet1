﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IPontoRepository : IRepositoryBase<Ponto>
    {
        List<Pessoa> GetMediaPonto(List<DateTime> dataSemana);
    }
}
