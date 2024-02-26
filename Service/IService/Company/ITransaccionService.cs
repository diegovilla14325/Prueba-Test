﻿using Domain.Entities.Company.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService.Company
{
    public interface ITransaccionService
    {
        Task<List<ProductDTO>> GetProducts();

        
    }
}
