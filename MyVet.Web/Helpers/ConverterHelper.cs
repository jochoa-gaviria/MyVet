﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyVet.Web.Data.Entities;
using MyVet.Web.Models;

namespace MyVet.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;
        public ConverterHelper(ICombosHelper combosHelper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        public EditUserViewModel ToEditUserViewModel(Owner owner)
        {
            return new EditUserViewModel
            {
                Address = owner.User.Address,
                Document = owner.User.Document,
                FirstName = owner.User.FirstName,
                Id = owner.Id,
                LastName = owner.User.LastName,
                PhoneNumber = owner.User.PhoneNumber
            };
        }

        public async Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew)
        {
            return new History
            {
                Date = model.Date.ToUniversalTime(),
                Description = model.Description,
                Id = isNew ? 0: model.Id,
                Pet = await _dataContext.Pets.FindAsync(model.PetId),
                Remarks = model.Remarks,
                ServiceType = await _dataContext.ServiceTypes.FindAsync(model.ServiceTypeId)
            };
        }

        public HistoryViewModel ToHistoryViewModel(History history)
        {
            return new HistoryViewModel
            {
                Date = history.Date,
                Description = history.Description,
                PetId = history.Pet.Id,
                Id = history.Id,
                Remarks = history.Remarks,
                ServiceTypeId = history.ServiceType.Id,
                ServiceTypes = _combosHelper.GetComboServiceTypes()
            };
        }

        public async Task<Owner> ToOwnerAsync(EditUserViewModel model, bool isNew)
        {
            var owner = await _dataContext.Owners
                               .Include(o => o.User)
                               .FirstOrDefaultAsync(o => o.Id == model.Id);

            owner.User.Document = model.Document;
            owner.User.FirstName = model.FirstName;
            owner.User.LastName = model.LastName;
            owner.User.Address = model.Address;
            owner.User.PhoneNumber = model.PhoneNumber;

            return owner;
        }

        public async Task<Pet> ToPetAsync(PetViewModel model, string path, bool isNew)
        {
            return new Pet
            {
                Agendas = model.Agendas,
                Born = model.Born.ToUniversalTime(),
                Histories = model.Histories,
                Id = isNew ? 0 : model.Id,
                ImageUrl = path,
                Name = model.Name,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                PetType = await _dataContext.PetTypes.FindAsync(model.PetTypeId),
                Race = model.Race,
                Remarks = model.Remarks
            };
        }

        public PetViewModel ToPetViewModel(Pet pet)
        {
            return new PetViewModel
            {
                Agendas = pet.Agendas,
                Born = pet.BornLocal,
                Histories = pet.Histories,
                ImageUrl = pet.ImageUrl,
                Name = pet.Name,
                Owner = pet.Owner,
                PetType = pet.PetType,
                Race = pet.Race,
                Remarks = pet.Remarks,
                Id = pet.Id,
                OwnerId = pet.Owner.Id,
                PetTypeId = pet.PetType.Id,
                PetTypes = _combosHelper.GetComboPetTypes()
            };
        }
    }
}
