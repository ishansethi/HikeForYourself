//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hikeforyourselfver3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HikeRating
    {
        public int Id { get; set; }
        public string HikeComment { get; set; }
        public string Rating { get; set; }
        public int HikingId { get; set; }
        public string AspNetUserId { get; set; }
    
        public virtual Hiking Hiking { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}