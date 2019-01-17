using System;
using System.Collections.Generic;
using System.Text;

namespace MyDogEF
{
    public class App
    {
        static readonly DataAccess _dataAccess = new DataAccess();

        internal void Run()
        {
            //ClearAndInitDatabase(); Behövs egentligen inte eftersom man använder Drop-Database i Package manager console?
            //AddDogs();
            //AddOwner();

            //DisplayAllDogs();
            DisplayDogsWithOwners();
        }

        private void ClearAndInitDatabase()
        {
            _dataAccess.ClearDatabase();
        }

        private void DisplayDogsWithOwners()
        {
            List<Owner> owners = _dataAccess.GetOwners();

            Console.WriteLine("OWNERS AND DOGS\n");

            foreach (var owner in owners)
            {
                Console.WriteLine(owner.Name);

                foreach (var dog in owner.Dogs)
                {
                    Console.WriteLine(dog.Name.PadRight(10) + dog.Breed.Name);
                }

                Console.WriteLine();
            }
        }

        private void DisplayAllDogs()
        {
            List<Dog> dogs = _dataAccess.GetDogs();

            Console.WriteLine("DOGS\n");
            foreach (var dog in dogs)
            {
                Console.WriteLine(dog.Name.PadRight(10) + dog.Breed.Name);
            }

            Console.WriteLine();
        }

        private void AddOwner()
        {
            _dataAccess.AddOwners();
        }

        private void AddDogs()
        {
            _dataAccess.AddDogs();
        }
    }
}
