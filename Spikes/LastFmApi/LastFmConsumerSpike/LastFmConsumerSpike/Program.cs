using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotLastFm;
using DotLastFm.Models;

namespace LastFmConsumerSpike
{
    class Program
    {
        static void Main(string[] args)
        {
            const string keyword = "dire straits";
            var lastFmConfig = new LastFmConfig();
            var lastFmApi = new LastFmApi(lastFmConfig);
            var artistWithDetails = lastFmApi.Artist.GetInfo(keyword);
            var tracksForArtist = lastFmApi.Artist.GetTopTracks(artistWithDetails.Name);
            Console.WriteLine("==== Artist Details ==== ");
            Console.WriteLine(artistWithDetails.Name);
            Console.WriteLine();
            Console.WriteLine("==== Tracks by the Artist ==== ");
            foreach (var track in tracksForArtist)
                Console.WriteLine("{0} - {1} - {2}", track.Rank, track.Name, track.Url);
            Console.WriteLine();
            Console.WriteLine("==== Similar Artists ==== ");
            foreach (var artist in artistWithDetails.SimilarArtists)
                Console.WriteLine(artist.Name);
            Console.ReadKey();
        }
    }
}
