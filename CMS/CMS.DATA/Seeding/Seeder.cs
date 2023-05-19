using CMS.DATA.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CMS.DATA.Seeding
{
    public class Seeder
    {
        public static async Task SeedData(IApplicationBuilder app)
        {
            //Get db context
            var dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CMSDbContext>();

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
            if (dbContext.Users.Any())
            {
                return;
            }
            else
            {
                var baseDir = Directory.GetCurrentDirectory();

                await dbContext.Database.EnsureCreatedAsync();
                //Get Usermanager and rolemanager from IoC container
                var userManager = app.ApplicationServices.CreateScope()
                                              .ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var roleManager = app.ApplicationServices.CreateScope()
                                                .ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //Creating list of roles

                List<string> roles = new() { "Facilitator", "Admin", "Student" };

                //Creating roles
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }
                //Instantiating i User and it properties
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Francis",
                    LastName = "Facilitator",
                    UserName = "cdSpark",
                    Email = "cmssq014@gmail.com",
                    PhoneNumber = "08162292349",
                    PhoneNumberConfirmed = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EmailConfirmed = true

                };
                await userManager.CreateAsync(user, "Password@123");
                await userManager.AddToRoleAsync(user, roles[0]);


                //Creating file path for each model class
                var path = File.ReadAllText(FilePath(baseDir, "JsonFiles/Users.json"));
                var invitePath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Invite.json"));
                var coursePath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Course.json"));
                var lessonPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Lesson.json"));
                var quizPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Quiz.json"));
                var stackPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Stack.json"));
                var userCoursePath = File.ReadAllText(FilePath(baseDir, "JsonFiles/UserCourse.json"));
                var userQuizTakenPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/UserQuizTaken.json"));
                var userStackPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/UserStack.json"));
                var userQuizOptionPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/UserQuizOption.json"));

                //Converting the JSON objects to their respective class objects
                var cmsUsers = JsonConvert.DeserializeObject<List<ApplicationUser>>(path);
                var cmsInvite = JsonConvert.DeserializeObject<List<Invite>>(invitePath);
                var cmsCourse = JsonConvert.DeserializeObject<List<Course>>(coursePath);
                var cmsLesson = JsonConvert.DeserializeObject<List<Lesson>>(lessonPath);
                var cmsQuiz = JsonConvert.DeserializeObject<List<Quiz>>(quizPath);
                var cmsStack = JsonConvert.DeserializeObject<List<Stack>>(stackPath);
                var cmsUserCourse = JsonConvert.DeserializeObject<List<UserCourse>>(userCoursePath);
                var cmsUserQuizTaken = JsonConvert.DeserializeObject<List<UserQuizTaken>>(userQuizTakenPath);
                var cmsUserStack = JsonConvert.DeserializeObject<List<UserStack>>(userStackPath);
                var cmsQuizOption = JsonConvert.DeserializeObject<List<QuizOption>>(userQuizOptionPath);


                //Seeding Users
                for (int i = 0; i < cmsUsers.Count; i++)
                {
                    cmsUsers[i].EmailConfirmed = true;
                    await userManager.CreateAsync(cmsUsers[i], "Password@123");

                    //Making the first five users to be Admins
                    if (i < 5)
                    {
                        await userManager.AddToRoleAsync(cmsUsers[i], roles[1]);
                        continue;
                    }
                    await userManager.AddToRoleAsync(cmsUsers[i], roles[3]);
                }

                //Seeding Invites
                for (int i = 0; i < cmsInvite.Count; i++)
                {
                    
                    
                }
                await dbContext.Invites.AddRangeAsync(cmsInvite);

                //Seeding Courses
                for (int i = 0; i < cmsCourse.Count; i++)
                {
                   
                }
                await dbContext.Courses.AddRangeAsync(cmsCourse);

                //Seeding Lesson
                for (int i = 0; i < cmsLesson.Count; i++)
                {
                    
                }
                await dbContext.Lessons.AddRangeAsync(cmsLesson);
                //Seeding Quizs
                for (int i = 0; i < cmsQuiz.Count; i++)
                {
                    
                }
                await dbContext.Quizs.AddRangeAsync(cmsQuiz);

                //Seeding Stacks
                for (int i = 0; i < cmsStack.Count; i++)
                {
                    
                }
                await dbContext.Stacks.AddRangeAsync(cmsStack);

                //Seeding UserCourse
                for (int i = 0; i < cmsUserCourse.Count; i++)
                {
                    
                }
                await dbContext.UserCourses.AddRangeAsync(cmsUserCourse);

                //Seeding UserQuizTaken
                for (int i = 0; i < cmsUserQuizTaken.Count; i++)
                {

                }
                await dbContext.UserQuizTaken.AddRangeAsync(cmsUserQuizTaken);

                //Seeding UserStack
                for (int i = 0; i < cmsUserStack.Count; i++)
                {

                }
                await dbContext.UserStack.AddRangeAsync(cmsUserStack);

                //Seeding UserStack
                for (int i = 0; i < cmsQuizOption.Count; i++)
                {

                }
                await dbContext.QuizOptions.AddRangeAsync(cmsQuizOption);
            }
            //Saving everything into the database
            await dbContext.SaveChangesAsync();
        }

        //Defining method to get file paths
        static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}
