using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGetAllCars
    {
        public Task<ViewResult> List();
    }
}
