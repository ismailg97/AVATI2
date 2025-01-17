﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using AVATI.Data.ValidationAttributes;

namespace AVATI.Data
{
    [DateTimeValidationAttribute]
    public class Project
    
    { /// <summary>
      /// Diese Klasse benutzt einer <see cref="List{T}"/>
      /// </summary>
      
        public int ProjectID { get; set; }
        
        [StringLength(70, ErrorMessage = "Projekttitel ist zu lang (70 Zeichen)")] [Required(ErrorMessage = "Titel ist erforderlich")]
        public string Projecttitel { get; set; } //yes
        
        [StringLength(150, ErrorMessage = "Projektbeschreibung ist zu lang (150 Zeichen)")]
        public string Projectdescription { get; set; } //yes
        [NotNull]
        public Dictionary<string, string> Projectpurpose { get; set; } = new Dictionary<string, string>();
        public List<string> ProjectActivities { get; set; } = new List<string>();
        public DateTime Projectbeginning { get; set; } //yes
        public DateTime Projectend { get; set; } //yes
        public List<string> Fields { get; set; } = new List<string>(); //yes
        public List<Employee> Employees { get; set; } = new List<Employee>(); //yes
    }
}