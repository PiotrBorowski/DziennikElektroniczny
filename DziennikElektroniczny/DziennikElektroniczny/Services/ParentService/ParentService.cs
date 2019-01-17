using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Repositories;

namespace DziennikElektroniczny.Services.ParentService
{
    public class ParentService : IParentService
    {
        private GenericRepository<DziennikElektronicznyContext, Usprawiedliwienie> _usprawiedliwienieRepo;
        private IMapper _mapper;

        public ParentService(GenericRepository<DziennikElektronicznyContext, Usprawiedliwienie> usprawiedliwienieRepo, IMapper mapper)
        {
            _usprawiedliwienieRepo = usprawiedliwienieRepo;
            _mapper = mapper;
        }

        public void AddExcuse(AddUsprawiedliwienieDTO addDto)
        {
            _usprawiedliwienieRepo.Add(_mapper.Map<Usprawiedliwienie>(addDto));
        }
    }
}
