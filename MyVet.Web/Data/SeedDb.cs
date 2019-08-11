using MyVet.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context) { _context = context; }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPetTypesAsync();
            await CheckServiceTypesAsync();
            await CheckOwnersAsync();
            await CheckPetsAsync();
            await CheckAgendasAsync();

        }

        private async Task CheckAgendasAsync()
        {
            if (!_context.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                var finalDate = initialDate.AddMonths(6);
                while (initialDate<finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate<finalDate2)
                        {
                            _context.Agendas.Add(new Agenda
                            {
                                Date = initialDate.ToUniversalTime(),
                                IsAvailable = true
                            });
                            initialDate = initialDate.AddMinutes(30);
                        }
                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPetsAsync()
        {
            var owner = _context.Owners.FirstOrDefault();
            var petType = _context.PetTypes.FirstOrDefault();
            if (!_context.Pets.Any())
            {
                AddPet("Zeus", owner, petType, "Pastor Aleman");
                AddPet("Tayson", owner, petType, "Doberman");
                await _context.SaveChangesAsync();
            }
        }

        private void AddPet(string name, Owner owner, PetType petType, string race)
        {
            _context.Pets.Add(new Pet
            {
                Born = DateTime.Now.AddYears(-2),
                Name = name,
                Owner =  owner,
                PetType = petType,
                Race = race
            });
        }

        private async Task CheckOwnersAsync()
        {
            if (!_context.Owners.Any())
            {
                AddOwner("8989898", "Juan", "Ochoa", "234 5221", "311 743 70 28", "Calle 70b");
                AddOwner("7655544", "Nereida", "Gaviria", "343 3226", "300 332 3281", "Carrera 66 #55 21");
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string document, string firstName, string lastName, string fixedPhone, string cellPhone, string address)
        {
            _context.Owners.Add(new Owner
            {
                Address = address,
                CellPhone = cellPhone,
                Document = document,
                FirstName = firstName,
                FixedPhone = fixedPhone,
                LastName = lastName
            });
        }

        private async Task CheckServiceTypesAsync()
        {
            if (!_context.ServiceTypes.Any())
            {
                _context.ServiceTypes.Add(new ServiceType { Name = "Consult" });
                _context.ServiceTypes.Add(new ServiceType { Name = "Urgency" });
                _context.ServiceTypes.Add(new ServiceType { Name = "Vacunation" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPetTypesAsync()
        {
            if (!_context.PetTypes.Any())
            {
                _context.PetTypes.Add(new PetType {Name = "Dog"});
                _context.PetTypes.Add(new PetType {Name = "Cat"});
                _context.PetTypes.Add(new PetType {Name = "Bird"});
                await _context.SaveChangesAsync();
            }
        }
    }
}
