using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Dep
    {
        public Dep()
        {
            this.Emps = new List<Emp>();
        }
        [Key]
        public int DepId { get; set; }
        [Required,StringLength(50)]
        public string DepName { get; set; }
        public  virtual ICollection<Emp> Emps { get; set; }
    }
    public class Emp
    {
        public int EmpId { get; set; }
        [Required, StringLength(50)]
        public string EmpName { get; set; }
        [Required, StringLength(150)]
        public string EmpImg { get; set; }
        [Required,ForeignKey("Dep")]
        public int DepId { get; set; }
        public virtual Dep Dep { get; set; }

    }
    public class  EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) { }
        public DbSet<Emp> Emps { get; set; }
        public DbSet<Dep> Deps { get; set; }
    }


}
