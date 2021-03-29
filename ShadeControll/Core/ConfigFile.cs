using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll
{
    abstract class ConfigFile
    {
        public static readonly string Default = 
        @"
        [info]
        version=1.9
        id=Home_PC
        first_run=true
        key=[telegram key]
        password=1234

        [directories]
        logs=Logs/
        ";
        
    }
}
