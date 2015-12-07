using AspNetNg.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetNg.DAL
{
    public class DogRepository : IDogRepository
    {
        private DogContext context;

        public DogRepository(DogContext context)
        {
            this.context = context;
        }

        public IEnumerable<Dog> GetDogs()
        {
            return context.Dogs.ToList();
        }

        public Dog GetDogByID(int id)
        {
            return context.Dogs.Find(id);
        }

        public void InsertDog(Dog dog)
        {
            context.Dogs.Add(dog);
        }

        public void DeleteDog(int dogID)
        {
            Dog dog = context.Dogs.Find(dogID);
            context.Dogs.Remove(dog);
        }

        public void UpdateDog(Dog dog)
        {
            context.Entry(dog).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}