﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewerFinal.Models
{
    public class GameReview
    {
        [Key]
        public int ReviewID { get; set; }

        public string Content { get; set; }

        public int RefID { get; set; }

        [ForeignKey("RefID")]
        public virtual Game GameID { get; set; }
    }
}