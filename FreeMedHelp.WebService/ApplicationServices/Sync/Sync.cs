using System;
using System.Collections.Generic;
using System.Net;
using FreeMedHelp.DomainObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace FreeMedHelp.ApplicationServices.Synchronization
{
    public class MedPoint_Cell
    {
        public int global_id { get; set; }
        public int Number { get; set; }
        public MedPoint_inf Cells { get; set; }
    }

    public class MedPoint_inf
    {
        public long global_id { get; set; }
        public string FullName { get; set; }
        public string IsOMSProvider { get; set; }

    }

    public class UseCaseMedPoints
    {
        static string remoteUri = "https://apidata.mos.ru/v1/datasets/1465/rows?api_key=80a756e69ebdbb37f01f159f6325baac&$top=1000";

        List<MedPoint_Cell> medpoint_cells;

        public List<MedPoint> medpoints = new List<MedPoint>();

        public UseCaseMedPoints()
        {
            //---Запрос---
            WebRequest request = WebRequest.Create(remoteUri);
            WebResponse response = request.GetResponse();

            //читаем ответ
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string line = stream.ReadToEnd();

            //вытащили весь массив данных из json
            JArray jsonArray = JArray.Parse(line);

            //заполним класс, который вытащит нам только нужные поля и выведем списком все парки
            medpoint_cells = JsonConvert.DeserializeObject<List<MedPoint_Cell>>(jsonArray.ToString());
            //Console.WriteLine(medpoints[0].Cells.CommonName);

            for (int i = 0; i < medpoint_cells.Count; i++)
            {
                medpoints.Add(new MedPoint()
                {
                    FullName = medpoint_cells[i].Cells.FullName,
                    Id = medpoint_cells[i].Cells.global_id,
                    IsMedHelpFree = medpoint_cells[i].Cells.IsOMSProvider,

                });
            }
        }

    }
}

