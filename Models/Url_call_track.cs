//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrueDynamicWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Url_call_track
    {
        public int ID { get; set; }
        [Display(Name = "Url Config ID")]
        public int url_config_fk { get; set; }
        [Display(Name = "Response Data")]
        public string response_data { get; set; }
        [Display(Name = "Status")]
        public Nullable<bool> Status { get; set; }
        public System.DateTimeOffset CreateDate { get; set; } = DateTime.Now;
        public System.DateTimeOffset UpdateDate { get; set; } = DateTime.Now;
    }
}