//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace my_portfolio_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class TblAbout
    {
        public int Aboutid { get; set; }
        public string imageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CvUrl { get; set; }
        [NotMapped]
        public HttpPostedFileBase CV { get; set; }
        [NotMapped] 
        public HttpPostedFileBase ImageFile { get; set; }
    }
}