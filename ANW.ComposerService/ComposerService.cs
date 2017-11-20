using System.Collections.Generic;
using System.Linq;
using ANW.ComposerModels;
using ANW.ComposerRepository;

namespace ANW.ComposerService
{
    public class ComposerService : IComposerService
    {
        public IEnumerable<ComposerModel> GetAllComposers()
        {
            return ComposerRepo.Composers;
        }

        public ComposerModel GetComposerById(int composerId)
        {
            return ComposerRepo.Composers.FirstOrDefault(x => x.Id == composerId);
        }
    }
}
