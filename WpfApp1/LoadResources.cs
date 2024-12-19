using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Receipt
{
    public class LoadResources
    {
        List<Components> components = new();
        public LoadResources(string filePath) 
        {
            string document = String.Empty;
            using (StreamReader sr = new StreamReader(filePath))
            {
                document += sr.ReadToEnd();
            }
            var positions = JsonArray.Parse(document);
            if(positions?["Компоненты"] !=null)
            components = JsonSerializer.Deserialize<List<Components>>(positions["Компоненты"])??new List<Components>();
        }
        public List<Components> GetComponents()
        {
            return components;
        }
        
    }
}
