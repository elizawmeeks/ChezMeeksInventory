using Common.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public partial class Repository
    {
        public Repository(Context context, ILogger<Repository> logger)
        {
            _context = context;
            _logger = logger;
        }
        private readonly Context _context;
        private ILogger<Repository> _logger;


        public void SaveChanges() => 
            _context.SaveChanges();
    }
}