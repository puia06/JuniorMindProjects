﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public interface IMatch
    {
        bool Success();
        StringView RemainingText();
    }
}

