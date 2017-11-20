using System.Collections.Generic;
using ANW.ComposerModels;

namespace ANW.ComposerService
{
    public interface IComposerService
    {
        IEnumerable<ComposerModel> GetAllComposers();
        ComposerModel GetComposerById(int composerId);
    }
}
