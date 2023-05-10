using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL
{
    public enum MapMethod
    {
        Value, EntityId
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MapAttribute : Attribute
    {
        public string MapName { get; set; }
        public MapMethod Method { get; set; } = MapMethod.Value;
        public MapAttribute(string mapName)
        {
            MapName = mapName;
        }
    }
}
