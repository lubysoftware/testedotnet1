﻿using System;

namespace LTS.Domain.Base
{
    public interface IEntity
    {
        Guid Id { get; }
        void SetId(Guid id);
    }
}
