﻿using Exhibition.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Core
{
    public interface IOperate : IDisposable
    {
        void Play(Resource resource);

        void Stop();
    }
}
