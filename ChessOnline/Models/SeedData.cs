using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChessOnline.Data;
using System;
using System.Linq;

namespace ChessOnline.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ChessOnlineContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ChessOnlineContext>>()))
            {
                // Look for any movies.
                if (context.Players.Any())
                {
                    return;   // DB has been seeded
                }

                context.Players.AddRange(
                    new Players
                    {
                        Name = "Magnus Carlsen",
                        GamesPlayed = 3946,
                        GamesWon = 740,
                        GamesLost = 275,
                        GamesTied = 811,
                        WinPercentage = 63, 
                        Ranking = 2863,
                        CountryOfOrigin = "Norwegia"
                    },
                    new Players
                    {
                        Name = "Garry Kasparov",
                        GamesPlayed = 2423,
                        GamesWon = 718,
                        GamesLost = 107,
                        GamesTied = 727,
                        WinPercentage = 70,
                        Ranking = 2812,
                        CountryOfOrigin = "Russia"
                    },
                    new Players
                    {
                        Name = "Fabiano Caruana",
                        GamesPlayed = 2348,
                        GamesWon = 474,
                        GamesLost = 190,
                        GamesTied = 675,
                        WinPercentage = 61,
                        Ranking = 2835,
                        CountryOfOrigin = "United-States"
                    },
                    new Players
                    {
                        Name = "Vasyl Ivanchuk",
                        GamesPlayed = 3883,
                        GamesWon = 856,
                        GamesLost = 295,
                        GamesTied = 1306,
                        WinPercentage = 61,
                        Ranking = 2678,
                        CountryOfOrigin = "Russia"
                    },
                    new Players
                    {
                        Name = "Anatoly Karpov",
                        GamesPlayed = 3631,
                        GamesWon = 946,
                        GamesLost = 215,
                        GamesTied = 1270,
                        WinPercentage = 65,
                        Ranking = 2617,
                        CountryOfOrigin = "Russia"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}