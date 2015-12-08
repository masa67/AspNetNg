using AspNetNg.DAL;
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
        private IDogRepository dogRepository;

        public DogsController()
        {
            this.dogRepository = new DogRepository(new DogContext());
        }

        [HttpPost]
        public IHttpActionResult Dog(DogDTO dogDto)
        {
            IEnumerable<Dog> dogs = dogRepository.GetDogs(); // getDogByID(dogDto.DogId);
            return Ok();
        }
    }
}