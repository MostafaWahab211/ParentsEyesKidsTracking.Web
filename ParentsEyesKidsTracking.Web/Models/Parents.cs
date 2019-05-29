﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParentsEyesKidsTracking.Web.Models
{
    public class Parent:User
    {
        
        public Location Location { get; set; }

        public IEnumerable<Kid> Kids { get; set; }

    }
}