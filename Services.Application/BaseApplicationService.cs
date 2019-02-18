using Core.Domain.Contract.Data;
using Core.Domain.Contract.Services.Application;

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
