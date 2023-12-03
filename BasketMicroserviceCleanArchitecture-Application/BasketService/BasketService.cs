using BaketMicroservice_Domain.BasketEntities;
using BasketMicroserviceCleanArchitecture_Application.IBasketService;
using BasketMicroserviceCleanArchitecture_Infrastracture.IRepository;

namespace BasketMicroserviceCleanArchitecture_Application.BasketService
{
    public class BasketService : ICustomService<Basket>
    {
        private readonly IRepository<Basket> _studentRepository;
        public BasketService(IRepository<Basket> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void Delete(Basket entity)
        {
            try
            {
                if(entity != null)
                {
                    _studentRepository.Delete(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        public Basket Get(int Id)
        {
            try
            {
                var obj = _studentRepository.Get(Id);
                if(obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception)
            {

                throw;
            }
        }

        public IEnumerable<Basket> GetAll()
        {
            try
            {
                var obj = _studentRepository.GetAll();
                if(obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        public void Insert(Basket entity)
        {
            try
            {
                if(entity != null)
                {
                    _studentRepository.Insert(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        public void Remove(Basket entity)
        {
            try
            {
                if(entity != null)
                {
                    _studentRepository.Remove(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch(Exception)
            {

                throw;
            }
        }
        public void Update(Basket entity)
        {
            try
            {
                if(entity != null)
                {
                    _studentRepository.Update(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch(Exception)
            {

                throw;
            }
        }
    }
}
