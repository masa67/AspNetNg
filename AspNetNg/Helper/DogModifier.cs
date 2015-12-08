using AspNetNg.DAL;
using AspNetNg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetNg.Helper
{
    public class DogModifier
    {
        private IDogRepository dogRepository;

        public DogModifier()
        {
            this.dogRepository = new DogRepository(new DogContext());
        }

        public void modify(Dog dog)
        {
            dog.Breed = "Jack Russell Terrier";
            dogRepository.UpdateDog(dog);
        }
    }
}