using System.Transactions;
using Core.Contract.Data;
using Core.Contract.Services.Application;

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
