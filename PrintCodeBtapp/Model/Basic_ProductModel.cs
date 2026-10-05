/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUKAMES.Entity.DomainModels
{
    [SugarTable("Basic_ProductModel")]
    public partial class Basic_ProductModel
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="ProductModel_Id")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public Guid ProductModel_Id { get; set; }

       /// <summary>
       ///工厂产品编号
       /// </summary>
       [Display(Name ="工厂产品编号")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProductCode { get; set; }

       /// <summary>
       ///生产型号
       /// </summary>
       [Display(Name ="生产型号")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProductModel { get; set; }

       /// <summary>
       ///生产车型
       /// </summary>
       [Display(Name ="生产车型")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string ProductCarModel { get; set; }

       /// <summary>
       ///产品描述
       /// </summary>
       [Display(Name ="产品描述")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string Product_Description { get; set; }

       /// <summary>
       ///指定首工序
       /// </summary>
       //[Display(Name ="指定首工序")]
       //[MaxLength(255)]
       //[Column(TypeName="varchar(255)")]
       //[Editable(true)]
       //public string FirstStation { get; set; }

       /// <summary>
       ///创建人编号
       /// </summary>
       [Display(Name ="创建人编号")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? CreateID { get; set; }

       /// <summary>
       ///型号描述
       /// </summary>
       [Display(Name ="型号描述")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string ProductParts { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       [Editable(true)]
       public string Creator { get; set; }

       /// <summary>
       ///创建人时间
       /// </summary>
       [Display(Name ="创建人时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///修改人编号
       /// </summary>
       [Display(Name ="修改人编号")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ModifyID { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       [Editable(true)]
       public string Modifier { get; set; }

       /// <summary>
       ///修改人时间
       /// </summary>
       [Display(Name ="修改人时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? ModifyDate { get; set; }

       
    }
}