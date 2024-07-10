using Application.DTOs.Fornecedores;
using Application.DTOs.Produtos;
using AutoMapper;
using Domain.Models.Fornecedores;
using Domain.Models.Produtos;

namespace Infrastructure.Data
{
    public class Mappings
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<FornecedorDTO, Fornecedor>().ReverseMap();
                config.CreateMap<FornecedorEditDTO, Fornecedor>().ReverseMap();
                config.CreateMap<EnderecoDTO, Endereco>().ReverseMap();
                config.CreateMap<EnderecoEditDTO, Endereco>().ReverseMap();
                config.CreateMap<ProdutoDTO, Produto>().ReverseMap();
                config.CreateMap<ProdutoEditDTO, Produto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
