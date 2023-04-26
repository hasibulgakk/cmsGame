using cmsGame.Models.Upload;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cmsGame.Service
{
    public interface IOwnerService
    {
        public Task<List<OwnerModel>> SelectListOwnerServiceAndriod();
        public Task<List<OwnerModel>> SelectListOwnerServiceJava();

    }
}
