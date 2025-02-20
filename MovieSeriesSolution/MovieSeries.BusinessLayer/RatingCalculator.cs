using MovieSeries.CoreLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieSeries.BusinessLayer
{
    public static class RatingCalculator
    {
        public static decimal CalculateAverageRating(IEnumerable<Ratings> ratings)
        {
            if (ratings == null || !ratings.Any())
                return 0;

            return ratings.Average(r => r.rating);
        }
    }
}