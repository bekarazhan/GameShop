using AutoMapper;
using GameShop.Interfaces;
using GameShop.Models.Entities;
using GameShop.Models.ViewModels;
using GameShop.Repositories;

namespace GameShop.Services
{
    public class GenresService : IGenresService
    {
        private readonly IGenresRepository _genresRepository;
        private readonly IMapper _mapper;

        public GenresService(
            IGenresRepository genresRepository,
            IMapper mapper)
        {
            _genresRepository = genresRepository;
            _mapper = mapper;
        }
        public async Task<GenreVm> CreateGenre(GenreVm genreVm)
        {
           var genre = _mapper.Map<Genre>(genreVm);
            await _genresRepository.AddAsync(genre);
            return genreVm;
        }

        public async Task DeleteGenre(int id)
        {
            await _genresRepository.DeleteAsync(id);
        }

        public async Task<List<GenreVm>> GetAllGenres()
        {
            var genres = await _genresRepository.ListAllAsync();
            return _mapper.Map<List<GenreVm>>(genres);
        }

        public async Task<GenreVm> GetGenreById(int id)
        {
            var genre = await _genresRepository.GetByIdAsync(id);
            return _mapper.Map<GenreVm>(genre);
        }

        public async Task UpdateGenre(GenreVm genreVm)
        {
            if (genreVm.Id == null) {
                throw new ArgumentNullException(nameof(genreVm));
            }
            var genre = await _genresRepository.GetByIdAsync((int)genreVm.Id);
            if (genre==null) {
                throw new ArgumentException(nameof(genreVm));
            }
            //genre =  _mapper.Map<Genre>(genreVm);
            _mapper.Map(genreVm, genre);
            await _genresRepository.UpdateAsync(genre);

            return;
        }
    }
}
