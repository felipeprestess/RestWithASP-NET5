﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET5.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
