using System;

namespace Test.Core.Interfaces
{
    public interface IBaseEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        bool IsDeleted { get; set; }
    }

    public interface IBaseEntity<T> : IBaseEntity
    {
        new T Id { get; set; }
    }
}
