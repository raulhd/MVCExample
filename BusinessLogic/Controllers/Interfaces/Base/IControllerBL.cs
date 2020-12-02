using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers.Interfaces.Base
{
    public interface IControllerBL <T>
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T dto);
        Task<T> Update(T dto, int id);
        Task<bool> Delete(int id);
    }
}
