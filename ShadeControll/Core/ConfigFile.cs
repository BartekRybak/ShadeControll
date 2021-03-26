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
        version=1.8
        id=Home_PC
        first_run=true
        key=1774037430:AAHnjjeOUNvn-ZpyCCo_6mIhztp_GkagsVg

        [directories]
        logs=Logs/
        ";
        
    }
}
