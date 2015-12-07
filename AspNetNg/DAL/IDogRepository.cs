using AspNetNg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetNg.DAL
{
    public interface IDogRepository : IDisposable
    {
        IEnumerable<Dog> GetDogs();
        Dog GetDogByID(int dogId);
        void InsertDog(Dog dog);
        void DeleteDog(int dogID);
        void UpdateDog(Dog dog);
        void Save();
    }
}