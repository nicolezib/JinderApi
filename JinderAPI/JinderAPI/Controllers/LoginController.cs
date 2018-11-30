using JinderAPI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace JinderAPI.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("PostNewSeekerUser")]
        public HttpResponseMessage PostNewSeekerUser(SeekerUserModel jinderSeekerUser)
        {
            JinderDBEntities dbContext = new JinderDBEntities();
            var usersTable = dbContext.JinderUsers;
            var SeekersTable = dbContext.SeekerProfiles;

            HttpResponseMessage message = new HttpResponseMessage();

            //if(usersTable.Find(infoUser.JinderUserId) != null)
            //{
            //    message.StatusCode = HttpStatusCode.Conflict;
            //    message.Content = new StringContent("Username: " + infoUser.JinderUserId + " is already registered");
            //    return message;
            //}

            JinderUser user = new JinderUser();
            
            user.FullName = jinderSeekerUser.FullName;
            user.DateOfBirth = jinderSeekerUser.DateOfBirth;
            user.Gender = jinderSeekerUser.Gender;
            user.Address = jinderSeekerUser.Address;
            user.UserType = jinderSeekerUser.UserType;
            user.username = jinderSeekerUser.username;
            user.password = jinderSeekerUser.password;

           


            usersTable.Add(user);
            dbContext.SaveChanges();

            SeekerProfile seekerUser = new SeekerProfile();

            seekerUser.JinderUserId = user.JinderUserId;
            seekerUser.Certification = jinderSeekerUser.Certification;
            seekerUser.Education = jinderSeekerUser.Education;
            seekerUser.Experience = jinderSeekerUser.Experience;
            seekerUser.Skills = jinderSeekerUser.Skills;

            SeekersTable.Add(seekerUser);
            dbContext.SaveChanges();

            //message.Content = new StringContent("name " + name);
            //message.Content = new StringContent("user saved");


            return message;
        }
        [HttpPost]
        [Route("PostNewPosterUser")]
        public HttpResponseMessage PostNewPosterUser(PosterUserModel jinderPosterUser)
        {
            JinderDBEntities dbContext = new JinderDBEntities();
            var usersTable = dbContext.JinderUsers;
            var PostersTable = dbContext.JobPosts;

            HttpResponseMessage message = new HttpResponseMessage();

            //if(usersTable.Find(infoUser.JinderUserId) != null)
            //{
            //    message.StatusCode = HttpStatusCode.Conflict;
            //    message.Content = new StringContent("Username: " + infoUser.JinderUserId + " is already registered");
            //    return message;
            //}

            JinderUser user = new JinderUser();

            user.FullName = jinderPosterUser.FullName;
            user.DateOfBirth = jinderPosterUser.DateOfBirth;
            user.Gender = jinderPosterUser.Gender;
            user.Address = jinderPosterUser.Address;
            user.UserType = jinderPosterUser.UserType;
            user.username = jinderPosterUser.username;
            user.password = jinderPosterUser.password;




            usersTable.Add(user);
            dbContext.SaveChanges();

            JobPost posterUser = new JobPost();

            posterUser.JobPostId = user.JinderUserId;
            posterUser.JobDescription = jinderPosterUser.JobDescription;
            posterUser.RequiredSkills = jinderPosterUser.RequiredSkills;
            posterUser.SalaryRange = jinderPosterUser.SalaryRange;
            posterUser.OperationHours = jinderPosterUser.OperationHours;
            posterUser.Location = jinderPosterUser.Location;

            PostersTable.Add(posterUser);
            dbContext.SaveChanges();

            //message.Content = new StringContent("name " + name);
            //message.Content = new StringContent("user saved");


            return message;
        }
    }
}
