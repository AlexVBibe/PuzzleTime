using DiskActivity.Interfaces;
using System;

namespace DiskActivity.Services
{
    class DiskContentQueryService : IQueryService
    {
        public bool GetCanFind(string item)
        {
            return false;
        }
    }
}
