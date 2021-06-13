using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace pnut
{
    static class Data
    {
        private static string JSONFileInitial = Directory.GetCurrentDirectory() + @"\pnutData.json";
        public static List<Problem> Problems { get; set; }

        public static void InitializeData()
        {
            if (!File.Exists(JSONFileInitial))
            {
                Problems = new List<Problem>();
            }
            else
            {
                var InitialData = JsonConvert.DeserializeObject(JSONFileInitial);
                Problems = new List<Problem>((IEnumerable<Problem>)InitialData ?? Array.Empty<Problem>());
            }
        }

        public static void SaveData()
        {
            var dataToSave = JsonConvert.SerializeObject(Problems);
            if (!File.Exists(JSONFileInitial))
            {
                File.Create(JSONFileInitial);
            }
            File.WriteAllText(JSONFileInitial, dataToSave);
        }
    }
}
