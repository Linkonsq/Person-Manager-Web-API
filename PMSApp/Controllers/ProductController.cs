using PMSEntity;
using PMSInterface;
using PMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMSApp.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        [Route("{id}", Name = "GetProduct")]
        public IHttpActionResult Get(int id)
        {
            Product p = repo.Get(id);

            //return cat == null ? StatusCode(HttpStatusCode.NoContent) : Ok(cat);

            if (p == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(p);
            }

        }
        [Route("")]
        public IHttpActionResult Post(Product product)
        {
            repo.Insert(product);
            string url = Url.Link("GetProduct", new { id = product.Id });
            return Created(url, product);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Product product, [FromUri]int id)
        {
            product.Id = id;
            repo.Update(product);
            return Ok(product);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(repo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
// Cross Origin Resource Sharing (CORS)