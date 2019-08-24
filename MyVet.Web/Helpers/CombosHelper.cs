using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet.Web.Data.Entities;

namespace MyVet.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboPetTypes()
        {
            var list = _dataContext.PetTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            }).OrderBy(pt => pt.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Select a pet type]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboServiceTypes()
        {
            var list = _dataContext.ServiceTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            }).OrderBy(pt => pt.Text)
          .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Service type]",
                Value = "0"
            });
            return list;
        }
    }
}
