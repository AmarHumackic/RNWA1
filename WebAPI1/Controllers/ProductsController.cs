using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI1.Models;
using WebAPI1.ViewModels;

namespace WebAPI1.Controllers
{
    public class ProductsController : ApiController
    {
        private classicmodelsEntities db = new classicmodelsEntities();

        [HttpGet]
        [Route("api/products")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                List<Product> products = db.Products.ToList();

                return Ok(products);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Route("api/products/{productCode}")]
        public IHttpActionResult GetProductByCode(string productCode)
        {
            try
            {
                Product product = db.Products.FirstOrDefault(x => x.productCode == productCode);

                return Ok(product);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost]
        [Route("api/products")]
        [ResponseType(typeof(Object))]
        public IHttpActionResult PostProduct(ProductPostVM productVM)
        {
            Product product = new Product()
            {
                productCode = productVM.productCode,
                productName = productVM.productName,
                productLine = productVM.productLine,
                buyPrice = productVM.buyPrice,
                MSRP =productVM.MSRP,
                productDescription = productVM.productDescription,
                productScale = productVM.productScale,
                productVendor = productVM.productVendor,
                quantityInStock = productVM.quantityInStock
            };

            db.Products.Add(product);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("api/products")]
        [ResponseType(typeof(Object))]
        public IHttpActionResult PutProduct(Product product)
        {
            Product existingProduct = db.Products.FirstOrDefault(x => x.productCode == product.productCode);

            if (existingProduct != null)
            {
                existingProduct.productName = product.productName;
                existingProduct.productLine = product.productLine;
                existingProduct.buyPrice = product.buyPrice;
                existingProduct.MSRP = product.MSRP;
                existingProduct.productDescription = product.productDescription;
                existingProduct.productScale = product.productScale;
                existingProduct.productVendor = product.productVendor;
                existingProduct.quantityInStock = product.quantityInStock;

                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/products/{productCode}")]
        [ResponseType(typeof(Object))]
        public IHttpActionResult DeleteProduct(string productCode)
        {
            Product deleteProduct = db.Products.FirstOrDefault(x => x.productCode == productCode);

            if (deleteProduct != null)
            {
                db.Entry(deleteProduct).State = EntityState.Deleted;
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
