using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TesteApi.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        public String Nome { get; set; }

    }
}