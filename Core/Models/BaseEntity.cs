using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public abstract class BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column(TypeName = "INTEGER")]
        public long Id { get; set; }    
        public int TenantId { get; set; }
        public bool IsDeleted { get; set; }
        public bool Cancelled { get { return IsDeleted; } set { IsDeleted = value; } }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set;}
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set;} = DateTime.UtcNow;


        public static implicit operator JsonContainer<BaseEntity>(BaseEntity obj)
        {
            var jsonContainer = new JsonContainer<BaseEntity>();
            jsonContainer.Data = obj != null ? JsonConvert.SerializeObject(obj) : null;
            return jsonContainer;
        }

        public static implicit operator BaseEntity(JsonContainer<BaseEntity> jsonContainer)
        {
            return jsonContainer != null ? JsonConvert.DeserializeObject<BaseEntity>(jsonContainer.Data.ToString()) : null;
        }
    }
    public class JsonContainer<T>
    {
        public object Data { get; set; }

        public static implicit operator T(JsonContainer<T> jsonContainer)
        {
            return jsonContainer != null ? JsonConvert.DeserializeObject<T>(jsonContainer.Data.ToString()) : default(T);
        }

        public static implicit operator JsonContainer<T>(T obj)
        {
            var jsonContainer = new JsonContainer<T>();
            jsonContainer.Data = obj != null ? JsonConvert.SerializeObject(obj) : null;
            return jsonContainer;
        }
    }
}
