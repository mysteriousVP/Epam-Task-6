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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.Get(id);

            if (category == null)
            {
                return false;
            }

            return _unitOfWork.CategoryRepository.Remove(category);
        }

        public async Task<CategoryToReturnDTO> Get(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.Get(id);

            return _mapper.Map<CategoryToReturnDTO>(category);
        }

        public async Task<IEnumerable<CategoryToReturnDTO>> Get()
        {
            IEnumerable<Category> categories = await _unitOfWork.CategoryRepository.GetAll();

            return _mapper.Map<IEnumerable<CategoryToReturnDTO>>(categories);
        }

        public CategoryToReturnDTO Post(CategoryToCreateDTO categoryTocreate)
        {
            Category category = _mapper.Map<Category>(categoryTocreate);

            if (_unitOfWork.CategoryRepository.Add(category) == true)
            {
                return _mapper.Map<CategoryToReturnDTO>(category);
            }

            throw new ArgumentException("Fail on creation");
        }

        public bool Put(CategoryToCreateDTO categoryToCreate, int id)
        {
            Category category = _mapper.Map<Category>(categoryToCreate);
            category.CategoryId = id;
            return _unitOfWork.CategoryRepository.Update(category);
        }
    }
}
