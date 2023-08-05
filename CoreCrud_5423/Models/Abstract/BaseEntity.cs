using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Models.Abstract
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        public DateTime? UpdatedDate { get; set; }  // ? nullable yani boş bırakılabilir property 

        public DateTime? DeletedDate { get; set; }


        private bool _isActive=true;   // defaultta her nesne aktif olmuş olacak ama silinince false olarak pasife çekeceğiz.

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive=value; }
        }

    }
}
