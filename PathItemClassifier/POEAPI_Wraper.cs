using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PathItemClassifier
{
    class POEAPI_Wrapper
    {
        const string POEAPI_StashQuery = "http://api.pathofexile.com/public-stash-tabs/?id=$ID$";

        public static POEAPI_StashResponseJSON POEAPIStashQueryById(string id = "0")
        {
            string request = POEAPI_StashQuery.Replace("$ID$", id);
            string jsonResponse = CompressedHttpGet(request);
            return JsonConvert.DeserializeObject<POEAPI_StashResponseJSON>(jsonResponse);
        }
        public static POEAPI_StashResponseJSON[] POEAPIAllStashQuery()
        {
            List<POEAPI_StashResponseJSON> stashes = new List<POEAPI_StashResponseJSON>();
            stashes.Add(POEAPIStashQueryById());
            for (int i = 0; i < 100; i++)
            {
                stashes.Add(POEAPIStashQueryById(stashes[i].next_change_id));
                Console.WriteLine(stashes[i].next_change_id);
            }
                
            return stashes.ToArray();
        }
        private static string CompressedHttpGet(string URI)
        {
            System.Net.HttpWebRequest.DefaultWebProxy = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            //request.AutomaticDecompression = DecompressionMethods.GZip;
            string html = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream)) { html = reader.ReadToEnd(); }
            return html;
        }
    }
}
