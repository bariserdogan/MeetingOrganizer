using MeetingOrganizer.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DataAccess
{
    public class Initializer : CreateDatabaseIfNotExists<MeetingContext>
    {
        protected override void Seed(MeetingContext context)
        {         
            //Fake meetings...
            Meeting meet = new Meeting()
            {
                meetingTopic = FakeData.NameData.GetCompanyName(),
                meetingDate = FakeData.DateTimeData.GetDatetime(DateTime.Now, DateTime.Now.AddYears(1)),
                startTime = FakeData.DateTimeData.GetDatetime(DateTime.Now, DateTime.Now.AddYears(1)),
                finishTime = FakeData.DateTimeData.GetDatetime(DateTime.Now, DateTime.Now.AddYears(1)),
            };
            Meeting meet1 = new Meeting()
            {
                meetingTopic = FakeData.NameData.GetCompanyName(),
                meetingDate = FakeData.DateTimeData.GetDatetime(DateTime.Now, DateTime.Now.AddYears(1)),
                startTime = FakeData.DateTimeData.GetDatetime(DateTime.Now, DateTime.Now.AddYears(1)),
                finishTime = FakeData.DateTimeData.GetDatetime(DateTime.Now, DateTime.Now.AddYears(1)),
            };
           
            context.Meeting.Add(meet);
            context.Meeting.Add(meet1);
            context.SaveChanges();
            


        }
    }
}
