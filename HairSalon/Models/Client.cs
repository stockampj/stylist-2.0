using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;



namespace HairSalon.Models
{

    public class Client
    {
        public int ClientId { get; set; }
        public string Name_First { get; set; }
        public string Name_Last { get ; set; }
        public string Phone { get; set; }
        public int StylistId { get; set; }
        public virtual Stylist Stylist { get; set; }
    }
}