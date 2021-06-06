using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class DocumentClass
    {
        #region Declaration

        private DateTime? dateCreated = null;
        private Guid _Id = Guid.Empty;

        #endregion

        public DocumentClass()
        {
            _Id = Guid.NewGuid();
            dateCreated = DateTime.Now;
        }

        #region Properties

        [Required]
        public Guid Id
        {
            get
            {
                return _Id.Equals(Guid.Empty) ? Guid.NewGuid() : _Id;
            }
            set
            {
                _Id = value;
            }
        }

        [Required]
        public DateTime CreatedDateTime
        {
            get
            {
                return this.dateCreated.HasValue ? this.dateCreated.Value : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        #endregion
    }
}