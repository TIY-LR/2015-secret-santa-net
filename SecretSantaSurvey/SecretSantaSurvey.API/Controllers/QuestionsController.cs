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

namespace SecretSantaSurvey.API.Controllers
{
    public class QuestionsController : ApiController
    {
        private SecretSantaDB db = new SecretSantaDB();

        // GET: api/Questions
        public IQueryable<Question> GetQuestions()
        {
            return db.Questions;
        }

        // GET: api/Questions/5
        [ResponseType(typeof(Question))]
        public IHttpActionResult GetQuestion(int id)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/Questions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestion(int id, CreateQuestionVM question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var existingQuestionFromDB = db.Questions.Find(id);
            existingQuestionFromDB.Answer = question.Answer;
            existingQuestionFromDB.Text = question.Text;


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Questions
        // [ResponseType(typeof(Question))]
        public IHttpActionResult PostQuestion(CreateQuestionVM question)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //look up the survey based on the id that David passed to you.
            var survey = db.Surveys.Find(question.Survey);
            if (survey == null)
            {
                return BadRequest($"Couldn't find survey with id {question.Survey}");
            }

            var newquestion = new Question()
            {
                Answer = question.Answer,
                Text = question.Text,
                ParentSurvey = survey
            };

            db.Questions.Add(newquestion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newquestion.Id }, question);
        }

        // DELETE: api/Questions/5
        [ResponseType(typeof(Question))]
        public IHttpActionResult DeleteQuestion(int id)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            db.Questions.Remove(question);
            db.SaveChanges();

            return Ok(question);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionExists(int id)
        {
            return db.Questions.Count(e => e.Id == id) > 0;
        }
    }
}