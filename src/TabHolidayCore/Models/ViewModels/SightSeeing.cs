using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class SightSeeingView
    {
        public int SightSeeingId { get; set; }
        public string Name { get; set; }
        public string TaggedLocation { get; set; }
        public string DetailedLocation { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public decimal TOAdult { get; set; }
        public decimal TOChild { get; set; }
        public decimal TOInfant { get; set; }
        public decimal PTAdult { get; set; }
        public decimal PTChild { get; set; }
        public decimal PTInfant { get; set; }
        public decimal SICAdult { get; set; }
        public decimal SICChild { get; set; }
        public decimal SICInfant { get; set; }
        public Int16 DurationHour { get; set; }
        public Int16 DurationMinute { get; set; }
        public bool FullDay { get; set; }


        public Int16 SightSeeingCategoryId { get; set; }
        public SightSeeingCategory SightSeeingCategory { get; set; }

        public int StarRatingId { get; set; }
        public StarRating StarRating { get; set; }

        public ICollection<InclusionView> Inclusions { get; set; }
        public ICollection<TimeSlotView> TimeSlots { get; set; }
        public ICollection<BlackOutView> BlackOuts { get; set; }
    }
}
