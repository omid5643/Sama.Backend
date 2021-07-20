using Newtonsoft.Json;
using Omran.Sama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omran.Sama.Tests.GenericExample
{
    public class Serializer
    {
        

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T DeSerialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
