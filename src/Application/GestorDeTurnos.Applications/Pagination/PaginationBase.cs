﻿using GestorDeTurnos.Application.Interfaces;

namespace GestorDeTurnos.Application.Pagination
{
    public abstract class PaginationBase : IPaginationBase
    {
        public string? OrderBy { get; set; }
        public bool Descending { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; } = 10;
    }
}