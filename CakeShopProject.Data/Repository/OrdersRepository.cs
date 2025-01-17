﻿using CakeShopProject.Data.Repository.Base;
using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace CakeShopProject.Data.Repository;

public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
{
    public OrdersRepository(DbContext context) : base(context)
    {
    }
}
