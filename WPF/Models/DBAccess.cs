using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.Models
{
    public class DBAccess
    {
        private void DBException()
        {
            MessageBox.Show("Ошибка подключения к базе, приложение будет закрыто", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            Environment.Exit(0);
        }

        public UserClass GetDoctor(string id)
        {
            BdContext DB = setDB();
            return new UserClass(DB.UserTable.Where(i => i.C__PK___Number_Of_Phone == id).FirstOrDefault());
        }

        private BdContext setDB()
        {
            BdContext db = new BdContext();
            try
            {
                if (db.Database.Exists())
                {
                    return db;
                }
                else
                {
                    DBException();
                    return null;
                }
            }
            catch (System.InvalidOperationException)
            {
                DBException();
                return null;
            }
        }

        public TarifClass GetTariffById(int tarifId)
        {
            BdContext DB = setDB();
            TarifTable tarif = DB.TarifTable.Where(i => i.C__PK___Kod_Tarifa == tarifId).FirstOrDefault();
            if (tarif != null)
            {
                return new TarifClass(tarif);
            }
            else
            {
                return null;
            }
        }

        public UserClass GetUserByLogin(string num)
        {
            BdContext DB = setDB();
            Debug.WriteLine($"Searching for user with phone number: {num}");

            UserTable user = DB.UserTable.Where(i => i.Loging == num).FirstOrDefault();
            if (user != null)
            {
                Debug.WriteLine("User found");
                return new UserClass(user);
            }
            else
            {
                Debug.WriteLine("User not found");
                return null;
            }
        }

        public List<TarifClass> GetAllTariffs()
        {
            BdContext DB = setDB();
            return DB.TarifTable.Select(t => new TarifClass
            {
                Id = t.C__PK___Kod_Tarifa,
                Name = t.Name,
                PricePerMonth = t.Cost_PerMonth,
                PriceGorod = t.Price_1minn_city,
                PriceMejGorod = t.Price_1minn_mejgorod,
                PriceMejNarod = t.Price_1minn_mejdunarod
            }).ToList();
        }

        public void UpdateUserTariff(string phoneNumber, int tarifId)
        {
            BdContext DB = setDB();
            UserTable user = DB.UserTable.FirstOrDefault(u => u.C__PK___Number_Of_Phone == phoneNumber);
            if (user != null)
            {
                user.C__FK___Kod_Tarifa = tarifId;
                DB.SaveChanges();
            }
        }

        public int Save(BdContext DB)
        {
            return DB.SaveChanges();
        }

        public void UpdateUserBalance(string phoneNumber, int amount)
        {
            BdContext DB = setDB();
            UserTable user = DB.UserTable.FirstOrDefault(u => u.C__PK___Number_Of_Phone == phoneNumber);
            if (user != null)
            {
                user.Money_On_Bank += amount;
                DB.SaveChanges();
            }
        }

        public void UpdateUserProfile(string oldPhoneNumber, string fullName, string newPhoneNumber)
        {
            BdContext DB = setDB();
            UserTable user = DB.UserTable.FirstOrDefault(u => u.C__PK___Number_Of_Phone == oldPhoneNumber);
            if (user != null)
            {
                // Присоединяем существующий объект к контексту данных
                DB.UserTable.Attach(user);

                if (!string.IsNullOrEmpty(fullName))
                {
                    user.FIO = fullName;
                }

                if (!string.IsNullOrEmpty(newPhoneNumber) && newPhoneNumber != oldPhoneNumber)
                {
                    user.C__PK___Number_Of_Phone = newPhoneNumber;
                }

                DB.SaveChanges();
            }
        }

        public void UpdateTariff(TarifClass tariff)
        {
            BdContext DB = setDB();
            TarifTable tarif = DB.TarifTable.FirstOrDefault(t => t.C__PK___Kod_Tarifa == tariff.Id);
            if (tarif != null)
            {
                tarif.Name = tariff.Name;
                tarif.Cost_PerMonth = tariff.PricePerMonth;
                tarif.Price_1minn_city = tariff.PriceGorod;
                tarif.Price_1minn_mejgorod = tariff.PriceMejGorod;
                tarif.Price_1minn_mejdunarod = tariff.PriceMejNarod;
                DB.SaveChanges();
            }
        }

        public void AddTariff(TarifClass tariff)
        {
            BdContext DB = setDB();
            int maxId = DB.TarifTable.Max(t => t.C__PK___Kod_Tarifa);
            TarifTable newTarif = new TarifTable
            {
                C__PK___Kod_Tarifa = maxId + 1,
                Name = tariff.Name,
                Cost_PerMonth = tariff.PricePerMonth,
                Price_1minn_city = tariff.PriceGorod,
                Price_1minn_mejgorod = tariff.PriceMejGorod,
                Price_1minn_mejdunarod = tariff.PriceMejNarod
            };
            DB.TarifTable.Add(newTarif);
            DB.SaveChanges();
            tariff.Id = newTarif.C__PK___Kod_Tarifa; // Обновляем ID в модели
        }

        public void DeleteTariff(int tariffId)
        {
            BdContext DB = setDB();
            TarifTable tarif = DB.TarifTable.FirstOrDefault(t => t.C__PK___Kod_Tarifa == tariffId);
            if (tarif != null)
            {
                DB.TarifTable.Remove(tarif);
                DB.SaveChanges();
            }
        }

        public bool IsPhoneNumberExists(string phoneNumber)
        {
            BdContext DB = setDB();
            return DB.UserTable.Any(u => u.C__PK___Number_Of_Phone == phoneNumber);
        }

        public List<UserClass> GetAllUsers()
        {
            BdContext DB = setDB();
            var users = DB.UserTable.Select(u => new UserClass
            {
                PhoneNumber = u.C__PK___Number_Of_Phone,
                Name = u.FIO,
                Balance = u.Money_On_Bank
            }).ToList();

            Debug.WriteLine($"Fetched {users.Count} users from the database.");
            return users;
        }

        public void AddUser(UserClass user)
        {
            BdContext DB = setDB();

            // Проверка на обязательные поля
            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                throw new ArgumentException("Phone number is required");
            }

            if (string.IsNullOrEmpty(user.Name))
            {
                throw new ArgumentException("Name is required");
            }

            UserTable newUser = new UserTable
            {
                C__PK___Number_Of_Phone = user.PhoneNumber,
                FIO = user.Name,
                Money_On_Bank = user.Balance
            };

            DB.UserTable.Add(newUser);
            DB.SaveChanges();
        }

        public void DeleteUser(string phoneNumber)
        {
            BdContext DB = setDB();
            UserTable user = DB.UserTable.FirstOrDefault(u => u.C__PK___Number_Of_Phone == phoneNumber);
            if (user != null)
            {
                DB.UserTable.Remove(user);
                DB.SaveChanges();
            }
        }

    }
}
