using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploSonar.API.Entities
{
    public class Entity
    {
        public int Id { get; private set; }

        [Column("data_criacao")]
        public DateTime DataCriacao { get; private set; }

        protected Entity()
        {
            DataCriacao = DateTime.UtcNow; 
        }
    }
}
