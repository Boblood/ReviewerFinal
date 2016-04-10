namespace ReviewerFinal.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReviewerFinal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ReviewerFinal.Models.ApplicationDbContext context)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Debugger.Launch();
            }

            context.Games.AddOrUpdate(x => x.GameID,
                new Game
                {
                    GameID = 1,
                    Name = "Super Mario Brothers",
                    Publisher = "Nintendo",
                    ReleaseDate = new DateTime(1985, 9, 13),
                    GameConsoles = GameSystem.NES,
                    Description = "The first Console Mario",
                    ReasonForGreatness = "OG status"
                },
                new Game
                {
                    GameID = 2,
                    Name = "The Legend of Zelda",
                    Publisher = "Nintendo",
                    ReleaseDate = new DateTime(1986, 2, 21),
                    GameConsoles = GameSystem.NES,
                    Description = "The first Console Zelda",
                    ReasonForGreatness = "OG status"
                },
                new Game
                {
                    GameID = 3,
                    Name = "Halo: Combat Evolved",
                    Publisher = "Microsoft Game Studios",
                    ReleaseDate = new DateTime(2001, 11, 15),
                    GameConsoles = GameSystem.Xbox,
                    Description = "The first Console Halo",
                    ReasonForGreatness = "OG status and impact on Game community"
                });
            context.GameReviews.AddOrUpdate(x => x.ReviewID,
                new GameReview
                {
                    ReviewID = 1,
                    DateCreated = DateTime.Now,
                    Content = "Best Game Ever",
                    GameID = context.Games.First(x => x.GameID == 1)
                },
                new GameReview
                {
                    ReviewID = 2,
                    DateCreated = DateTime.Now,
                    Content = "Best Game Ever Ever",
                    GameID = context.Games.First(x => x.GameID == 4)
                });
        }
    }
}
