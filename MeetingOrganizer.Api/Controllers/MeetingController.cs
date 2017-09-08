using MeetingOrganizer.DataAccess;
using MeetingOrganizer.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeetingOrganizer.Api.Controllers
{
    public class MeetingController : ApiController
    {
        public List<Meeting> Get()
        {
            using (MeetingContext db = new MeetingContext())
            {
                return db.Meeting.ToList();
            }
        }
        // GET: api/Meeting
        public IHttpActionResult Get(int id)
        {
            Meeting meeting = null;
            using (var db = new MeetingContext())
            {
                meeting = db.Meeting.Where(m => m.meetingID == id).FirstOrDefault();
            }
            if (meeting == null)            
                return NotFound();

            return Ok(meeting);
        }

        // POST: api/Meeting
        public IHttpActionResult Post(Meeting meeting)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model Geçersiz");

            using (var db = new MeetingContext())
            {
                db.Meeting.Add(new Meeting()
                {
                    meetingTopic = meeting.meetingTopic,
                    meetingDate = meeting.meetingDate,
                    startTime= meeting.startTime,
                    finishTime= meeting.finishTime,
                });
                db.SaveChanges();
            }
            return Ok();
        }
        // PUT: api/Meeting/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        public IHttpActionResult Put(Meeting model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Geçersiz model");
            using (MeetingContext db = new MeetingContext())
            {
                var meeting = db.Meeting.Where(m => m.meetingID == model.meetingID).FirstOrDefault<Meeting>();
                if (meeting != null)
                {
                    meeting.meetingTopic = model.meetingTopic;
                    meeting.meetingDate = model.meetingDate;
                    meeting.startTime = model.startTime;
                    meeting.finishTime = model.finishTime;
                    db.SaveChanges();
                }
                else
                    return NotFound();
            }
            return Ok();
        }

        // DELETE: api/Meeting/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Geçersiz ID değeri");

            using (var db = new MeetingContext())
            {
                var meeting = db.Meeting
                    .Where(m=>m.meetingID == id)
                    .FirstOrDefault();
                db.Entry(meeting).State= System.Data.Entity.EntityState.Deleted;              
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
