﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll
{
    abstract class ConfigFile
    {
        public static readonly string Default = @"
        [info]
        version=1.7
        id=Home_PC
        first_run=true";
    }
}