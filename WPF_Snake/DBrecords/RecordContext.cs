using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Snake
{
    class RecordContext : DbContext
    {
        DbSet<Record> Records { get; set; }

    }
}
