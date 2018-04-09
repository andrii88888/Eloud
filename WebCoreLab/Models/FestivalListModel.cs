using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebCoreLab.Domain;

namespace WebCoreLab.Models
{
    public class FestivalListModel
    {
        public List<int> Years { get; set; }
        public int SelectedYear { get; set; }

        public List<string> Months { get; set; }
        public string SelectedMonth { get; set; }

        public List<Festival> Festivals { get; set; }

        public FestivalListModel(List<Festival> list)
        {
            Festivals = list;

            Years = new List<int>();
            Months = new List<string>();

            for (int i = 2010; i < 2020; i++)
            {
                Years.Add(i);
            }

            for (int j = 1; j < 13; j++)
            {
                string strMonthName = new DateTimeFormatInfo().GetMonthName(j);

                Months.Add(strMonthName);
            }

            SelectedYear = DateTime.Now.Year;
            SelectedMonth = new DateTimeFormatInfo().GetMonthName(DateTime.Now.Month);
        }
    }
}
