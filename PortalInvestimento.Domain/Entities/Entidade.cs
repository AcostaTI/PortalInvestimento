using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalInvestimento.Domain.Entities
{
    public abstract class Entidade
    {
        //public Entidade(int id, bool deleted, DateTime publishDate, DateTime lastChanged, byte status)
        //{
        //    Id = id;
        //    Deleted = deleted;
        //    PublishDate = publishDate;
        //    LastChanged = lastChanged;
        //    Status = status;
        //}

        //public Entidade()
        //{
            
        //}


        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime LastChanged { get; set; }
        public byte Status { get; set; }

        public abstract void ValidateEntity();
    }

    public enum EntityStatus { Deactivated, Active }

    
}
