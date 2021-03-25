using System;

namespace VeterinariaEdiMvc2021.Datos
{
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;

        public UnitOfWork(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
