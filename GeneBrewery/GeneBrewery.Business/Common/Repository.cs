using System;

namespace GeneBrewery.Business.Common
{
    public class Repository<T> where T : Entity
    {
        //protected readonly UnitOfWork unitOfWork;

        //protected Repository(UnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        public T GetById(long id)
        {
            throw new NotImplementedException();
            //return unitOfWork.Get<T>(id);
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
            //unitOfWork.SaveOrUpdate(entity);
        }
    }
}
