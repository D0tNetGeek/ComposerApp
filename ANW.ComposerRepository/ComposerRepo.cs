using System.Collections.Generic;
using ANW.ComposerModels;

namespace ANW.ComposerRepository
{
    public static class ComposerRepo
    {
        public static IEnumerable<ComposerModel> Composers = new List<ComposerModel>
        {
            new ComposerModel
            {
                Id = 1,
                FirstName = "Terry",
                LastName = "Devine King",
                Title = "Mr",
                Awards = "Grammy 2006"
            },
            new ComposerModel
            {
                Id = 2,
                FirstName = "Tim",
                LastName = "Garland",
                Title = "Mr",
                Awards = "MTV Best New Artist 2001"
            },
            new ComposerModel
            {
                Id = 3,
                FirstName = "David",
                LastName = "Tobin",
                Title = "Mr",
                Awards = "Teen Choice Awards Best song 2010"
            },
            new ComposerModel
            {
                Id = 4,
                FirstName = "Max",
                LastName = "Bradley",
                Title = "Mr",
                Awards = "Brit Awards Best composition 2011"
            },
            new ComposerModel
            {
                Id = 5,
                FirstName = "Hannah",
                LastName = "Jones",
                Title = "Ms",
                Awards = "Brit Awards Best act 2007"
            },
            new ComposerModel
            {
                Id = 6,
                FirstName = "Evelyn",
                LastName = "Glennie",
                Title = "Mrs",
                Awards = "Brit Awards Best Percussion album 2013"
            }
        };
    }
}
