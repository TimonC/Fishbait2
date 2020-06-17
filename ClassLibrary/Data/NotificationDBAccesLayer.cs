﻿using DAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Data
{
    public class NotificationDBAccesLayer : INotificationDBAccesLayer
    {
        MySqlConnection con = new MySqlConnection(ConnectionString.GetConnection());
        public bool AddFollow(INotificationDto notification)
        {
            try
            {
                con.Open();
                string sql = "INSERT INTO notification (accountID, postID) VALUES (@accountID,@postID);";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@accountID", notification.accountID);
                    cmd.Parameters.AddWithValue("@postID", notification.postID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<INotificationDto> GetNotifications()
        {
            List<INotificationDto> follows = new List<INotificationDto>();

            using (MySqlCommand query = new MySqlCommand("select * from notification", con))
            {
                con.Open();
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    NotificationDto follow = new NotificationDto();
                    follow.id = reader.GetInt32(0);
                    follow.accountID = reader.GetInt32(1);
                    follow.postID = reader.GetInt32(2);
                    follows.Add(follow);
                }
                con.Close();
            }

            return follows;
        }
        public void DeleteNotification(int id)
        {
            using (MySqlCommand query = new MySqlCommand("DELETE FROM notification WHERE id=@id", con))
            {
                MySqlParameter param = new MySqlParameter("@id", id);
                query.Parameters.Add(param);
                con.Open();
                var reader = query.ExecuteReader();
            }
            con.Close();
        }
    }
}
