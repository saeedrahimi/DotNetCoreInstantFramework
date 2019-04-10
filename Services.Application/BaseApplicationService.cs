using Core.Domain.Contract.Services;
using Core.Domain.Contract.Services.Application;
using Core.Domain._Shared.Data;
using Core.Domain._Shared.Services;

namespace Services.Application
{
    public class BaseApplicationService: IBaseApplicationServices
    {
        private readonly IUnitofWork _uow;

        public BaseApplicationService(IUnitofWork unitofWork)
        {

            _uow = unitofWork;
        }


        internal virtual void Commit()
        {
            _uow.SaveChange();
        }
    }
}
