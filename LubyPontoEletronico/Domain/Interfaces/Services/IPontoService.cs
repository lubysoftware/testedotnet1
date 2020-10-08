﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPontoService : IServiceBase<Ponto>
    {
        List<Pessoa> GetMediaPonto();
    }
}
