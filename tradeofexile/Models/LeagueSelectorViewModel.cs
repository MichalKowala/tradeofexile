using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.models.EntityItems;

namespace tradeofexile.models
{
    public class LeagueSelectorViewModel
    {
        public SelectListItem SelectedLeague { get; set; }
        public List<SelectListItem> LeagueSelectList { get; set; }
        public LeagueSelectorViewModel()
        {
            LeagueSelectList = PopulateLeagueSelectList();
        }
        private List<SelectListItem> PopulateLeagueSelectList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var x in Enum.GetValues(typeof(LeagueType)))
            {
                if (x.ToString() != "Other")
                {
                    var selectLi = new SelectListItem();
                    selectLi.Text = x.ToString();
                    selectLi.Value = ((int)x).ToString();
                    list.Add(selectLi);
                }
                
            }
            return list;
        }

    }
}
