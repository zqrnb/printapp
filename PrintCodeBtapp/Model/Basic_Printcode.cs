using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintForms.Model
{
    [SugarTable("Basic_Printcode")]
    public class Basic_Printcode
    {
        /// <summary>
        ///
        /// </summary>
        [Key]
        [Display(Name = "Princode_Id")]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Princode_Id { get; set; }
        
        /// <summary>
        ///工位编号
        /// </summary>
        [Display(Name = "工位编号")]
        public string StationCode { get; set; }

        /// <summary>
        ///供应商
        /// </summary>
        [Display(Name = "供应商")]
        public string FactoryCode { get; set; }

        /// <summary>
        ///零件号
        /// </summary>
        [Display(Name = "零件号")]
        public string ProdModel { get; set; }



        /// <summary>
        ///年月日
        /// </summary>
        [Display(Name = "年月日")]
        public string yearmonth { get; set; }

        /// <summary>
        ///产线
        /// </summary>
        [Display(Name = "产线")]
        public string linecode { get; set; }

        /// <summary>
        ///打印流水
        /// </summary>
        [Display(Name = "打印流水")]
        public string princode { get; set; }

        /// <summary>
        ///执行流水
        /// </summary>
        [Display(Name = "执行流水")]
        public int code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "SN")]
        public string Ext {  get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "是否打印")]
        public bool isPrint {  get; set; }

        /// <summary>
        ///创建人编号
        /// </summary>
        [Display(Name = "创建人编号")]
        public int? CreateID { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "创建人")]
        public string Creator { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///修改人编号
        /// </summary>
        [Display(Name = "修改人编号")]
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        public DateTime? ModifyDate { get; set; }
    }
}
