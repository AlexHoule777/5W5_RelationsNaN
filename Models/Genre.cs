﻿namespace RelationsNaN.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> games { get; set; }
    }
}
