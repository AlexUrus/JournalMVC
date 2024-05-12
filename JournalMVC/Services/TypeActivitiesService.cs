using AutoMapper;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services.Interfaces;

namespace JournalMVC.Services
{
    public class TypeActivitiesService : ITypeActivitiesService
    {
        private readonly IMapper _mapper;
        private readonly ITypeActivitiesRepository _repository;

        public TypeActivitiesService(IMapper mapper, ITypeActivitiesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task AddAsync(TypeActivityDTO dTO)
        {
            var obj = _mapper.Map<TypeActivity>(dTO);
            await _repository.AddAsync(obj);
        }

        public async Task<ICollection<TypeActivityDTO>> GetAsync()
        {
            var obj = await _repository.GetAsync();
            return _mapper.Map<ICollection<TypeActivityDTO>>(obj);
        }

        public async Task<TypeActivityDTO> GetAsync(int id)
        {
            var obj = await _repository.GetAsync(id);
            return _mapper.Map<TypeActivityDTO>(obj);
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await _repository.GetAsync(id);
            await _repository.DeleteAsync(obj);
        }

        public async Task UpdateAsync(TypeActivityDTO dTO)
        {
            var obj = _mapper.Map<TypeActivity>(dTO);
            await _repository.UpdateAsync(obj);
        }

        public void Add(TypeActivityDTO dTO)
        {
            var obj = _mapper.Map<TypeActivity>(dTO);
            _repository.Add(obj);
        }

        public ICollection<TypeActivityDTO> Get()
        {
            var obj = _repository.Get();
            return _mapper.Map<ICollection<TypeActivityDTO>>(obj);
        }

        public TypeActivityDTO Get(int id)
        {
            var obj = _repository.Get(id);
            return _mapper.Map<TypeActivityDTO>(obj);
        }

        public void Delete(int id)
        {
            var obj = _repository.Get(id);
            _repository.Delete(obj);
        }

        public void Update(TypeActivityDTO dTO)
        {
            var obj = _mapper.Map<TypeActivity>(dTO);
            _repository.Update(obj);
        }
    }
}
