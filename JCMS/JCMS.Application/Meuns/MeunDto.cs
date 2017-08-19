using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCms.Meuns
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Serializable]
    [AutoMapFrom(typeof(Meun))]
    public class MeunDto : EntityDto<int>
    {  /// <summary>
       /// id
       /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 父模块Id
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 是否是菜单
        /// </summary>
        public bool IsMenu { get; set; }
        /// <summary>
        /// 模块编号
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(100)]
        public string Description { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Enabled { get; set; }

        public DateTime UpdateDate { get; set; }

        //public virtual MeunDto ParentModule { get; set; }
        //public List<MeunDto> ChildModules { get; private set; }
        public List<MeunDto> children { get; set; }
    }
}
