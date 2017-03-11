using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Core.Interfaces;

namespace Test.Core.Model
{
    public class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        object IBaseEntity.Id
        {
            get
            {
                return this.Id;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private DateTime? createdDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsDeleted
        {
            get; set;
        }
    }
}
