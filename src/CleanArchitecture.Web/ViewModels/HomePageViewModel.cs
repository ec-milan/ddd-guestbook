using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string GuestbookName { get; set; }

        public GuestbookEntry NewEntry { get; set; }

        public List<GuestbookEntry> PreviousEntries { get; set; } = new List<GuestbookEntry>();
    }
}
