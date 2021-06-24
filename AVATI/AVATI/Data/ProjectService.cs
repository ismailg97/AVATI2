using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using AVATI.Data.EmployeeDetailFiles;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AVATI.Data
{
    public class ProjectService : IProjektService
    {
        private readonly IConfiguration _configuration;
        public List<Project> Projects { get; set; }

        public ProjectService(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public DbConnection GetConnection()
        {
            return new SqlConnection
                (_configuration.GetConnectionString("AVATI-Database"));
        }

        public bool CreateProject(Project project)
        {
            if (project == null)
            {
                return false;
            }
            using DbConnection db = GetConnection();
            db.Open();
            db.Execute("INSERT INTO Project VALUES(@title, @description, @dateBeg , @dateEnd)",
                new
                {
                    title = project.Projecttitel, description = project.Projectdescription,
                    dateBeg = project.Projectbeginning.ToString("d", DateTimeFormatInfo.InvariantInfo),
                    dateEnd = project.Projectend.ToString("d", DateTimeFormatInfo.InvariantInfo)
                });
            foreach (var emp in project.Employees)
            {
                
            }

            return true;
        }

        public bool UpdateProject(Project project)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteProject(int projectID)
        {
            throw new System.NotImplementedException();
        }

        public Project GetProject(int projectID)
        {
            Project temp;
            IDbConnection db = GetConnection();
            db.Open();
            temp = new Project();
            temp.Projecttitel = temp.Projectdescription = db.QuerySingle<string>("SELECT Projecttitle from Project WHERE ProjectId = @proId",
                new {proId = projectID});
            temp.Projectdescription = db.QuerySingle<string>("SELECT Projectdescription from Project WHERE ProjectId = @proId",
                new {proId = projectID});
            temp.Projectbeginning = db.QuerySingle<DateTime>("SELECT Projectbegin from Project WHERE ProjectId = @proId",
                new {proId = projectID});
            temp.Projectend = db.QuerySingle<DateTime>("SELECT Projectend from Project WHERE ProjectId = @proId",
                new {proId = projectID});
            return temp;
        }

        public List<Project> GetAllProjects()
        {
            IDbConnection db = GetConnection();
            db.Open();
            Projects = new List<Project>(db.Query<Project>("SELECT * from Project"));
            foreach (var project in Projects)
            {
                project.Employees = new List<Employee>();
                project.Fields = new List<string>();

            }

            return Projects;

        }

        public List<Project> SearchProject(List<Project> projects, string input)
        {
            //Was soll das machen?

            return null;
        }

        public List<string> GetAllFieldsFromOneProject(int ProjectID)
        {
            //
            return null;
        }
    }
}