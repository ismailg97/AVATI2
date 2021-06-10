﻿using System.Collections.Generic;

namespace AVATI.Data
{
    public class Proposal
    {
        public string ProposalTitle { get; set; }
        
        public int ProposalId { get; set; }
        public List<string> Softskills { get; set; } = new List<string>();
        public List<string> Fields { get; set; } = new List<string>();
        public List<Hardskill> Hardskills { get; set; } = new List<Hardskill>();
        public string AdditionalInfo { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Dictionary<int, int> AltRc = new Dictionary<int, int>();
    }
}