﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        private readonly DBLibrosBootcampContext context;

        public LibroController(DBLibrosBootcampContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Libros.Add(libro);

            context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> GetById(int id)
        {
            Libro libro = (from lib in context.Libros where lib.Id == id select lib).SingleOrDefault();

            return libro;
        }

        [HttpGet("listado/{idAutor}")]
        public ActionResult<IEnumerable<Libro>> GetByAutor(int idAutor)
        {
            List<Libro> libros = (from lib in context.Libros where lib.IdAutor == idAutor select lib).ToList();

            return libros;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Libro libro)
        {
            if(id != libro.Id)
            {
                return BadRequest();
            }

            context.Entry(libro).State = EntityState.Modified;

            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = (from lib in context.Libros where lib.Id == id select lib).SingleOrDefault();

            if (libro == null)
            {
                return NotFound();
            }

            context.Libros.Remove(libro);

            context.SaveChanges();

            return libro;
        }

    }
}
