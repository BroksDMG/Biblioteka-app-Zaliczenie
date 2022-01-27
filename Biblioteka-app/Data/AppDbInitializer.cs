using Biblioteka_app.Data.Static;
using Biblioteka_app.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryManagerContext>();
                context.Database.EnsureCreated();

                //Author
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<AuthorModel>()
                    {
                        new AuthorModel()
                        {
                            Name="Artur",
                            Surname="Morgan",
                            Address="Miodowa",
                            Phone="111333222"
                        },
                        new AuthorModel()
                        {
                            Name="Zbigniew",
                            Surname="Morgan",
                            Address="Błotna",
                            Phone="111335622"
                        },
                        new AuthorModel()
                        {
                            Name="Arkadiusz",
                            Surname="Kowalski",
                            Address="Miodowa",
                            Phone="114233237"
                        },
                        new AuthorModel()
                        {
                            Name="Bogusław",
                            Surname="Ważny",
                            Address="Szermierzy 12",
                            Phone="114236622"
                        },
                        new AuthorModel()
                        {
                            Name="Ludwik",
                            Surname="Malutki",
                            Address="Św.filipa 5",
                            Phone="114233155"
                        }
                    });
                    context.SaveChanges();
                }
                //Publisher
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<PublisherModel>()
                    {
                        new PublisherModel()
                        {
                            Name="Mateusz",
                            Surname="Wróbel",
                            Address="Żelazna 19",
                            Phone="111336252"
                        },
                        new PublisherModel()
                        {
                            Name="Wojciech",
                            Surname="Szyszkowski",
                            Address="Mała 20",
                            Phone="111733222"
                        },new PublisherModel()
                        {
                            Name="Marcin",
                            Surname="Szczęsny",
                            Address="Fiołkowa 24/4",
                            Phone="111333999"
                        },new PublisherModel()
                        {
                            Name="Jerzy",
                            Surname="Kowalski",
                            Address="Krakowska 33",
                            Phone="113443222"
                        },new PublisherModel()
                        {
                            Name="Dominik",
                            Surname="Szlufik",
                            Address="Witosa 44",
                            Phone="11133551"
                        }
                    });
                    context.SaveChanges();

                }
                //Category
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<CategoryModel>()
                    {
                        new CategoryModel()
                        {
                            Catname="It",
                            Status="Yes"
                        },
                        new CategoryModel()
                        {
                            Catname="Marketing",
                            Status="Yes"
                        },new CategoryModel()
                        {
                            Catname="Horror",
                            Status="Yes"
                        },new CategoryModel()
                        {
                            Catname="Drama",
                            Status="Yes"
                        },new CategoryModel()
                        {
                            Catname="Comedy",
                            Status="Yes"
                        }
                    });
                    context.SaveChanges();

                }
                //Book
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<BookModel>()
                    {
                        new BookModel()
                        {
                            ProfilePictureURL="https://ecsmedia.pl/c/java-to-takie-proste-praktyczne-wprowadzenie-do-programowania-b-iext53230067.jpg",
                            BookName="Java.To takie proste",
                            Pages=490,
                            Edition="II",
                            Cat_id=1,
                            A_id=1,
                            P_id=1,
                        },
                        new BookModel()
                        {
                            ProfilePictureURL="https://static01.helion.com.pl/global/okladki/326x466/marby5.png",
                            BookName="Marketing dla bystrzaków",
                            Pages=500,
                            Edition="I",
                            Cat_id=2,
                            A_id=2,
                            P_id=2,
                        },new BookModel()
                        {
                            ProfilePictureURL="https://www.swiatksiazki.pl/media/catalog/product/cache/eaf55611dc9c3a2fa4224fad2468d647/7/1/7199906619571.jpg",
                            BookName="TO",
                            Pages=400,
                            Edition="II",
                            Cat_id=3,
                            A_id=3,
                            P_id=3,
                        },new BookModel()
                        {
                            ProfilePictureURL="https://fwcdn.pl/fpo/01/36/420136/7347382.3.jpg",
                            BookName="Chłopiec w pasiastej piżamie",
                            Pages=600,
                            Edition="I",
                            Cat_id=4,
                            A_id=4,
                            P_id=4,
                        },
                        new BookModel()
                        {
                            ProfilePictureURL="https://ecsmedia.pl/c/randka-z-hugo-bosym-b-iext102674412.jpg",
                            BookName="Randka z hugo bosym",
                            Pages=350,
                            Edition="I",
                            Cat_id=5,
                            A_id=5,
                            P_id=5,
                        },
                    });
                    context.SaveChanges();

                }





            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }

}