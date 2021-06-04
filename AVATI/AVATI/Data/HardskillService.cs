﻿using System.Collections.Generic;

namespace AVATI.Data
{
    public class HardskillServiceSimple: IHardskillService
    {
        private readonly List<Hardskill> _allHardskills;
        
        private readonly List<Hardskill> _allHardskillCat;

        public HardskillServiceSimple()
        {
            Hardskill javascript = 
                new Hardskill {Description = "JavaScript", Subcat = null, Uppercat = null, Height = 0};
            Hardskill css = 
                new Hardskill {Description = "CSS", Subcat = null, Uppercat = null, Height = 0};
            Hardskill html = 
                new Hardskill {Description = "HTML", Subcat = null, Uppercat = null, Height = 0};

            Hardskill aussp = 
                new Hardskill {Description = "Auszeichnungssprachen", Subcat = new List<Hardskill>(){ html, css },
                    Uppercat = null, Height = 1};
            Hardskill objWeb = 
                new Hardskill {Description = "objektorientierte Web-Programmierung", Subcat = new List<Hardskill>(){ javascript }, 
                    Uppercat = null, Height = 1};
            Hardskill fronEnd = 
                new Hardskill {Description = "Front-End", Subcat = new List<Hardskill>(){ aussp, objWeb }, 
                    Uppercat = null, Height = 2};
            Hardskill webent = 
                new Hardskill {Description = "Webentwicklung", Subcat = new List<Hardskill>(){ fronEnd },
                    Uppercat = null, Height = 3};
            javascript.Uppercat = objWeb;
            css.Uppercat = aussp;
            html.Uppercat = aussp;
            aussp.Uppercat = fronEnd;
            objWeb.Uppercat = fronEnd;
            fronEnd.Uppercat = webent;

            _allHardskills = new List<Hardskill>() { javascript, css, html };
            _allHardskillCat = new List<Hardskill>() { aussp, objWeb, fronEnd, webent};
        }

        public bool CreateHardskill(Hardskill hardskill)
        {
            _allHardskills.Add(hardskill);
            return true;
        }

        public bool UpdateHardskill(Hardskill newHardskill, Hardskill oldHardskill)
        {
            int index = _allHardskills.IndexOf(oldHardskill);
            if (index == -1) return false;
            _allHardskills[index] = newHardskill;
            return true;
        }

        public bool DeleteHardskill(string description)
        {
            int output = _allHardskills.RemoveAll(x => x.Description == description);
            return output == 1;
        }

        public Hardskill GetHardskill(string description)
        {
            return _allHardskills.Find(x => x.Description == description);
        }

        public List<Hardskill> GetAllHardskills()
        {
            return _allHardskills;
        }

        public bool CreateHardskillCategory(Hardskill hardskillcat)
        {
            _allHardskillCat.Add(hardskillcat);
            return true;
        }

        public bool UpdateHardskillCategory(Hardskill newHardskillcat, Hardskill oldHardskillcat)
        {
            int index = _allHardskills.IndexOf(oldHardskillcat);
            if (index == -1) return false;
            _allHardskillCat[index] = newHardskillcat;
            return true;
        }

        public bool DeleteHardskillCategory(string description)
        {
            int output = _allHardskillCat.RemoveAll(x => x.Description == description);
            return output == 1;
        }

        public Hardskill GetHardskillCategory(string description)
        {
            return _allHardskillCat.Find(x => x.Description == description);
        }

        public List<Hardskill> GetAllHardskillCategorys()
        {
            return _allHardskillCat;
        }
    }
}