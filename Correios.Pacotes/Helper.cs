﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correios.Pacotes
{
    public class Helper
    {
        public static string _ambiente { get; set; }

        public Helper(string  ambiente)
        {
            ambiente = _ambiente;
        }
        public static System.Data.IDbConnection DBConnectionOracle
        {
            get
            {
                return new Oracle.ManagedDataAccess.Client.OracleConnection(_ambiente);
            }
        }
    }
}
