using AspNetNg.DAL;
using AspNetNg.Helper;
using AspNetNg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace AspNetNg.api
{
    public class DogsController : ApiController
    {
        private readonly IDogRepository dogRepository;
        private readonly DogModifier dogModifier;

        public DogsController()
        {
            this.dogRepository = new DogRepository(new DogContext());
            this.dogModifier = new DogModifier();
        }

        [HttpPost]
        public IHttpActionResult Dog(DogDTO dogDto)
        {
            Dog dog = dogRepository.GetDogByID(dogDto.DogId);
            dogModifier.modify(dog);

            return Json(new { dog = dog });
        }
    }
}