﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Snake
{
    class Record
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int Result { get; set; }

        public int Rank { get; set; }
        public Record(string name, int result, int rank)
        {
            this.Result = result;
            this.Name = name;
            this.Rank = rank;
        }
        
        
        
        
    }
}
