using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MapAttribute : Attribute
    {
        public string MapName { get; set; }
        public MapAttribute(string mapName)
        {
            MapName = mapName;
        }
    }
}
