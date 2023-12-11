using System;
using System.Collections.Generic;
using System.Text;

namespace MiniSuperPF_YustinA.Services
{
    public static class Connection
    {
        // definimos prefijo de consumo de las rutas
        public static string ProductionURLPrefix = "http://192.168.0.3:45455/api/";
        public static string TestingURLPrefix = "http://192.168.0.3:45455/api/";


        public static string KeyName = "MiniSuperPF_ApiKey";
        public static string KeyValue = "SKATER08JUS*";
    }
}
  