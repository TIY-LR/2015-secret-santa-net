using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SecretSantaSurvey.API.Models;
using SecretSantaSurvey.Api.Models;

namespace SecretSantaSurvey.API.Controllers
{
    public class UsersController : ApiController
    {

        private List<string> StartingQuestions = new List<string>()
        {
            "1. Are you a Boy/Girl/Undecided?",
            "2. Where's your favorite place / brand to buy clothes?",
            "3.Do you collect anything? If so, what is it?",
            "4. Do you have any food allergies? If so, what are they?",
            "5. What is something you can't live without?",
            "6. What's one thing you always seem to be running out of?",
            "7. You love the smell of _____ ?",
            "8. Do you have a favorite hobby? What is it?",
            "9. If you have a favorite sports team, who are they?",
            "10. Bonus: What was the worst Christmas gift you can think of?"

        };

        private SecretSantaDB db = new SecretSantaDB();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TODO We have a user...add a survey, with the questions 
            //(populated from the startingquestions above)
            //and then add that survey to the user.
            //I.e. 
            var s = new Survey();
            foreach (var str in StartingQuestions)
            {
                var q = new Question() { ParentSurvey = s, Text = str };

                s.Questions.Add(q);
            }
            user.Survey.Add(s);

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}