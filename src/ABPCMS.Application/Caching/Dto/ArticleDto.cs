using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABPCMS.Articles;

namespace ABPCMS.Caching.Dto
{    
    [AutoMap(typeof(Article))]
    public class ArticleDto : IDoubleWayDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
