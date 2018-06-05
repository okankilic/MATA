using MATA.BL;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Helpers
{
    public static class SelectHelper
    {
        public static SelectList GetRoleTypeList(string selectedRoleType = null)
        {
            var selectList = new SelectList(new List<SelectListItem>()
            {
                new SelectListItem(){ Value = null, Text = "" },
                new SelectListItem(){ Value = RoleTypes.Admin, Text = "Admin" },
                new SelectListItem(){ Value = RoleTypes.Staff, Text = "Çalışan" },
                new SelectListItem(){ Value = RoleTypes.Customer, Text = "Müşteri" }
            }, "Value", "Text", selectedRoleType);

            return selectList;
        }

        public static SelectList GetProjectList(int selectedProjectID = 0)
        {
            IEnumerable<ProjectDTO> projects;

            using (var db = new MataDBEntities())
            {
                projects = ProjectBL.GetProjects(0, 0, db);
            }

            var selectItemList = new List<SelectListItem>();

            selectItemList.Add(new SelectListItem() { Value = null, Text = "" });

            selectItemList.AddRange(projects.Select(q => new SelectListItem
            {
                Value = q.ID.ToString(),
                Text = q.ProjectName
            }));

            var selectList = new SelectList(selectItemList, "Value", "Text", selectedProjectID);

            return selectList;
        }

        public static SelectList GetCityList(int selectedCityID = 0)
        {
            IEnumerable<CityDTO> cities;

            using (var db = new MataDBEntities())
            {
                cities = CityBL.GetCities(db);
            }

            var selectItemList = new List<SelectListItem>();

            selectItemList.Add(new SelectListItem() { Value = null, Text = "" });

            selectItemList.AddRange(cities.Select(q => new SelectListItem
            {
                Value = q.ID.ToString(),
                Text = q.CityName,
                Group = new SelectListGroup
                {
                    Name = q.CountryName
                }
            }));

            var selectList = new SelectList(selectItemList, "Value", "Text", selectedCityID);

            return selectList;
        }
    }
}