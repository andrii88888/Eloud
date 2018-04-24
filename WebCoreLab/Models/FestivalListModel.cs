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

            Years = Enumerable.Range(DateTime.Now.Year - 1, 5).ToList();
            Months = Enumerable.Range(1, 12).Select(i => new DateTimeFormatInfo().GetMonthName(i)).ToList();

            SelectedYear = DateTime.Now.Year;
            SelectedMonth = new DateTimeFormatInfo().GetMonthName(DateTime.Now.Month);
        }
    }
}
