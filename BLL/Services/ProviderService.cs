using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProviderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            Provider provider = await _unitOfWork.ProviderRepository.Get(id);

            if (provider == null)
            {
                return false;
            }

            return _unitOfWork.ProviderRepository.Remove(provider);
        }

        public async Task<ProviderToReturnDTO> Get(int id)
        {
            Provider provider = await _unitOfWork.ProviderRepository.Get(id);

            return _mapper.Map<ProviderToReturnDTO>(provider);
        }

        public async Task<IEnumerable<ProviderToReturnDTO>> Get()
        {
            IEnumerable<Provider> providers = await _unitOfWork.ProviderRepository.GetAll();

            return _mapper.Map<IEnumerable<ProviderToReturnDTO>>(providers);
        }

        public ProviderToReturnDTO Post(ProviderToCreateDTO providerToCreate)
        {
            Provider provider = _mapper.Map<Provider>(providerToCreate);

            if (_unitOfWork.ProviderRepository.Add(provider) == true)
            {
                return _mapper.Map<ProviderToReturnDTO>(provider);
            }

            throw new ArgumentException("Fail on creation");
        }

        public bool Put(ProviderToCreateDTO providerToCreate, int id)
        {
            Provider provider = _mapper.Map<Provider>(providerToCreate);
            provider.ProviderId = id;

            return _unitOfWork.ProviderRepository.Update(provider);
        }
    }
}
