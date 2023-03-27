﻿using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly IComment db;
        public CommentController(IComment _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetComments()
        {
            IQueryable<Comment> data = db.GetComments;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetComment(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
               // return Ok(new List<object>());
            }
        }
        [HttpPost]
        public IActionResult AddComment([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
                //return Ok(new List<object>());
            }
            else
            {
                db.Save(comment);
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Comment comment)
        {
            if (comment == null || comment.Id == 0)
            {
                return BadRequest();
               // return Ok(new List<object>());
            }
            else
            {
                db.Update(comment);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            db.Delete(id);
            return Ok();
        }
    }
}
