//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CookingPlanWithUI.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Curry
    {
        public int id { get; set; }
        public int curryCategory_id { get; set; }
        public string name { get; set; }
        public string taste { get; set; }
        public string description { get; set; }
        public System.DateTime created_at { get; set; }
    
        public virtual CurryCategory CurryCategory { get; set; }
    }
}
