using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.CoreLayer.Entities
{
    public class MoviesSeries
    {
        [Key]
        public int movie_series_id { get; set; }
        public string title { get; set; } 
        public string genre { get; set; }
        public DateTime release_date { get; set; }
        public string description { get; set; }
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }

}
