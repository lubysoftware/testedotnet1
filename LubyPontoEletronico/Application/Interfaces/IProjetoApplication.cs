﻿using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IProjetoApplication : IApplicationBase<Projeto, ProjetoDTO>
    {
    }
}
