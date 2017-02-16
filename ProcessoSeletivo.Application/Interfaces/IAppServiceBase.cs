using ProcessoSeletivo.Application.ViewModel.Interface;
using System.Collections.Generic;

namespace ProcessoSeletivo.Application.Interfaces
{
    public interface IAppServiceBase<TViewModel>
        where TViewModel : IViewModel
    {
        void Add(TViewModel entity);

        TViewModel GetById(int id);

        IEnumerable<TViewModel> GetAll();

        void Update(TViewModel entity);

        void Remove(TViewModel entity);

        void Dispose();
    }
}
