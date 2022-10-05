using BookingWebApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebApp.DataAccess.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var dbcontext = new BookingDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookingDBContext>>()))
            {
                if (!dbcontext.Clients.Any())
                {
                    dbcontext.Clients.AddRange(
                        new Client
                        {
                            FirstName = "Кирилл",
                            LastName = "Валетко",
                            EMail = "kirya_valet@mail.ru",
                            PasswordHash = "12345678"
                        },
                        new Client
                        {
                            FirstName = "Анатолий",
                            LastName = "Касабуцкий",
                            EMail = "kasaba_all_cash@mail.ru",
                            PasswordHash = "87654321"
                        },
                        new Client
                        {
                            FirstName = "Ван",
                            LastName = "Даркхолм",
                            EMail = "300bucks@mail.ru",
                            PasswordHash = "fucking_slave"
                        },
                        new Client 
                        {
                            FirstName = "Михаил",
                            LastName = "Зубенко",
                            EMail = "vor_v_zakone@mail.ru",
                            PasswordHash = "77777777"
                        }
                        );
                    dbcontext.SaveChanges();
                }
                if (!dbcontext.Hotels.Any())
                {
                    dbcontext.Hotels.AddRange(
                        new Hotel
                        {
                            HotelName = "Минск",
                            NumberOfRooms = 15,
                            NumberOfFloors = 3,
                            Parking = true,
                            Addr = "Беларусь, Минск, пр. Независимости, 11",
                            PhoneNumber = "80172099062",
                            EMail = "hotelminsk@gmail.com",
                            PasswordHash = "13572468"
                        },
                        new Hotel
                        {
                            HotelName = "Гачилэнд",
                            NumberOfRooms = 20,
                            NumberOfFloors = 4,
                            Parking = true,
                            Addr = "Беларусь, Минск, ул. П. Бровки, 10",
                            PhoneNumber = "80173003003",
                            EMail = "gachiland@gmail.com",
                            PasswordHash = "24681357"
                        },
                        new Hotel
                        {
                            HotelName = "Бгуир",
                            NumberOfRooms = 25,
                            NumberOfFloors = 5,
                            Parking = false,
                            Addr = "Беларусь, Минск, ул. Платонова, 39",
                            PhoneNumber = "80172938432",
                            EMail = "bsuir@gmail.com",
                            PasswordHash = "11111118"
                        }
                        );
                    dbcontext.SaveChanges();
                }
                if (!dbcontext.Rooms.Any())
                {
                    Random rnd = new Random();
                    for (int i = 0; i < 15; i++)
                    {
                        dbcontext.Rooms.Add(
                            new Room
                            {
                                HotelId = dbcontext.Hotels.Where(hotel => hotel.HotelName == "Минск").First().HotelId,
                                FloorNumber = (byte)rnd.Next(1, 4),
                                NumberOfBedrooms = (byte)rnd.Next(1, 3),
                                NumberOfBeds = (byte)rnd.Next(1, 3),
                                IsLuxe = rnd.Next(0, 2) == 0 ? false : true,
                                PricePerDay = rnd.Next(200, 250)
                            }
                            );
                        dbcontext.SaveChanges();
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        dbcontext.Rooms.Add(
                            new Room
                            {
                                HotelId = dbcontext.Hotels.Where(hotel => hotel.HotelName == "Гачилэнд").First().HotelId,
                                FloorNumber = (byte)rnd.Next(1, 5),
                                NumberOfBedrooms = (byte)rnd.Next(1, 4),
                                NumberOfBeds = (byte)rnd.Next(2, 4),
                                IsLuxe = rnd.Next(0, 2) == 0 ? false : true,
                                PricePerDay = rnd.Next(270, 300)
                            }
                            );
                        dbcontext.SaveChanges();
                    }
                    for (int i = 0; i < 25; i++)
                    {
                        dbcontext.Rooms.Add(
                            new Room
                            {
                                HotelId = dbcontext.Hotels.Where(hotel => hotel.HotelName == "Бгуир").First().HotelId,
                                FloorNumber = (byte)rnd.Next(1, 6),
                                NumberOfBedrooms = (byte)rnd.Next(1, 4),
                                NumberOfBeds = (byte)rnd.Next(2, 4),
                                IsLuxe = rnd.Next(0, 2) == 0 ? false : true,
                                PricePerDay = rnd.Next(350, 400)
                            }
                            );
                        dbcontext.SaveChanges();
                    }
                }
            }
        }
    }
}
