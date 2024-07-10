﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Produtos.DeleteProduto
{
    public class DeleteProdutoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteProdutoCommand(Guid _id)
        {
            Id = _id;
        }
    }
}
