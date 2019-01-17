using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDogEF
{
    public class DataAccess
    {
        private readonly MyDogContext _context;

        public DataAccess()
        {
            _context = new MyDogContext();
        }

        internal void AddDogs()
        {
            Breed breed1 = new Breed { Name = "Finsk lapphund" };
            Breed breed2 = new Breed { Name = "Pudel" };
            Breed breed3 = new Breed { Name = "Fransk bulldog" };

            Dog dog1 = new Dog { Name = "Erke", Breed = breed1 };
            Dog dog2 = new Dog { Name = "Stella", Breed = breed3 };
            Dog dog3 = new Dog { Name = "Nixon", Breed = breed2 };

            _context.Dogs.Add(dog1);
            _context.Dogs.Add(dog2);
            _context.Dogs.Add(dog3);
            _context.SaveChanges();

        }

        internal void ClearDatabase()
        {
            foreach (var breed in _context.Breeds)
            {
                _context.Remove(breed);
            }

            foreach (var dog in _context.Dogs)
            {
                _context.Remove(dog);
            }

            _context.SaveChanges();
        }

        internal void AddOwners()
        {
            Breed breed1 = new Breed { Name = "Finsk lapphund" };
            Breed breed2 = new Breed { Name = "Pudel" };
            Breed breed3 = new Breed { Name = "Fransk bulldog" };

            Owner owner1 = new Owner
            {
                Name = "Rebecka",
                Dogs = new List<Dog>
                {
                    new Dog { Name = "Yoshi", Breed = breed1},
                    new Dog { Name = "Freja", Breed = breed2}
                }
            };

            Owner owner2 = new Owner
            {
                Name = "Anneli",
                Dogs = new List<Dog>
                {
                    new Dog { Name = "Stella", Breed = breed3},
                    new Dog { Name = "Sture", Breed = breed3}
                }
            };

            _context.AddRange(owner1, owner2);
            _context.SaveChanges();

        }

        internal List<Owner> GetOwners()
        {
            return _context.Owners.Include(x => x.Dogs).ThenInclude(x => x.Breed).ToList();
        }

        internal List<Dog> GetDogs()
        {
            return _context.Dogs.Include(x => x.Breed).ToList();
        }
    }
}
