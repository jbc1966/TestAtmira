using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Atmira.Models
{
    public class Episode
    {

        [Key]
        public int Id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string language { get; set; }
        public List<string> genres { get; set; }
        public string status { get; set; }
        public int runtime { get; set; }
        public int averageRuntime { get; set; }
        public string premiered { get; set; }
        public string ended { get; set; }
        public string officialSite { get; set; }

        [NotMapped]
        public Schedule schedule { get; set; }
        [NotMapped]
        public Rating rating { get; set; }
        public int weight { get; set; }
        [NotMapped]
        public Network network { get; set; }

        [NotMapped]
        public object webChannel { get; set; }

        [NotMapped]
        public object dvdCountry { get; set; }
        [NotMapped]
        public Externals externals { get; set; }
        [NotMapped]
        public Image image { get; set; }
        public string summary { get; set; }
        public int updated { get; set; }

        [NotMapped]
        public Links _links { get; set; }
    }

    [Keyless]
    public class Country
        {
            public string name { get; set; }
            public string code { get; set; }
            public string timezone { get; set; }
        }

    [Keyless]
    public class Externals
        {
            public int tvrage { get; set; }
            public int thetvdb { get; set; }
            public string imdb { get; set; }
        }

    [Keyless]
    public class Image
        {
            public string medium { get; set; }
            public string original { get; set; }
        }

    [Keyless]
    public class Links
        {
            public Self self { get; set; }
            public Previousepisode previousepisode { get; set; }
        }

    [Keyless]
    public class Network
        {
            public int id { get; set; }
            public string name { get; set; }

           [NotMapped]
            public Country country { get; set; }
            public string officialSite { get; set; }
        }

    [Keyless]
    public class Previousepisode
        {
            public string href { get; set; }
        }

    [Keyless]
    public class Rating
        {
            public double average { get; set; }
        }

    [Keyless]
    public class Schedule
        {
            public string time { get; set; }
            public List<string> days { get; set; }
        }

    [Keyless]
    public class Self
        {
            public string href { get; set; }
        }

}
