using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.Models;

namespace WebApplication5.ViewModel
{
    public class EmpEidt
    {
        public int EmpId { get; set; }
        [Required, StringLength(50)]
        public string EmpName { get; set; }
        public IFormFile EmpImg { get; set; }
        [Required, ForeignKey("Dep")]
        public int DepId { get; set; }
        public virtual Dep Dep { get; set; }
    }
}
