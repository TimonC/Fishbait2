﻿using DAL.Models;
using Fishbait2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishbait2.Data
{
    public class LoginDBAccesLayer
    {
        public string connectionString = "Server=localhost;Database=fishbait;Uid=Tijmen;Pwd=Suckmycred123";
        public List<UserDto> GetUsers()
        {
            List<UserDto> users = new List<UserDto>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand query = new MySqlCommand("select * from user", conn))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        UserDto user = new UserDto();
                        user.id = reader.GetInt32(0);
                        user.username = reader.GetString(1);
                        user.password = reader.GetString(2);
                        user.mail = reader.GetString(3);

                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}
