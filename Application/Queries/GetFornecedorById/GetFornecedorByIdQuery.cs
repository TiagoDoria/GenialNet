﻿using Application.DTOs.Fornecedores;
using MediatR;

namespace Application.Queries.GetFornecedorById
{
    public class GetFornecedorByIdQuery : IRequest<FornecedorDTO>
    {
        public Guid Id { get; set; }

        public GetFornecedorByIdQuery(Guid _id)
        {
            Id = _id;
        }
    }
}