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

    public partial class Url_Config_tabl
    {
        public int ID { get; set; }
        [Display(Name = "Endpoint Name",Prompt = "Endpoint Name is Required", Description = "Enter your Endpoint Name")]
        public string Endpoint_name { get; set; }
        [Display(Name = "URL")]
        public string url { get; set; }
        [Display(Name = "Calling Parameter")]
        public string url_param { get; set; }
        [Display(Name = "Interval(In Seconds)")]
        public Nullable<int> interval_number { get; set; }
        [Display(Name = "Report Name")]
        public string Report_Name { get; set; }
        [Display(Name = "Status")]
        public Nullable<bool> Status { get; set; }
        public System.DateTimeOffset CreateDate { get; set; } = DateTime.Now;
        public System.DateTimeOffset UpdateDate { get; set; } = DateTime.Now;
    }
}