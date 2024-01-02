using ApiPagamentos.Entities;
using ApiPagamentos.Repositories;
using ApiPagamentos.ValueObjects;
using AutoMapper;

namespace ApiPagamentos.Business.Impl;

public class VendaBusiness : IVendaBusiness
{
    readonly IVendaRepository _repository;

    readonly IMapper _mapper;

    public VendaBusiness(IVendaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public VendaVO Create(VendaVO vo)
    {
       var entity = _mapper.Map<Venda>(vo);
       entity.Id = default;
       _repository.Create(entity);
       return _mapper.Map<VendaVO>(entity);
    }

    public IEnumerable<VendaVO> FindAll()
    {
        return _mapper.Map<IEnumerable<VendaVO>>(_repository.FindAll());
    }

    public VendaVO Update(string id, VendaVO vo)
    {
        if (_repository.Exists(id))
        {
            var entity = _repository.FindById(id);
            _mapper.Map(vo, entity);
            entity.Id = id;
            _repository.Update(entity);
            return _mapper.Map<VendaVO>(entity);
        }
       
       throw new ApplicationException($"Venda com ID {id} não foi encontrada.");
    }
}