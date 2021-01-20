using HotelProject.DataAccess.Abstract;
using HotelProject.Entities.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelProject.DataAccess.Concrete.Adonet
{
    public class AdoHotelDal:IHotelDal
    {
      

        public void Add(Hotel entity)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO Hotels (HotelName,Stars,FeePerNight) VALUES (@HotelName,@Stars,@FeePerNight)"))
            {
                command.Parameters.AddWithValue("HotelName", entity.HotelName);
                command.Parameters.AddWithValue("Stars", entity.Stars);
                command.Parameters.AddWithValue("FeePerNight", entity.FeePerNight);
                
                DBMS.ExecuteNonQuery(command);
            }
        }

        public void Delete(Hotel entity)
        {
            using (SqlCommand command = new SqlCommand("DELETE FROM Hotels WHERE HotelId = @HotelId"))
            {
                command.Parameters.AddWithValue("HotelId", entity.HotelId);
                DBMS.ExecuteNonQuery(command);
            }

        }

        public Hotel Get(Expression<Func<Hotel, bool>> filter)
        {
            var hotelList = new List<Hotel>();
            SqlConnection connection = new SqlConnection(DBMS.Connection);
            SqlCommand command = new SqlCommand("SELECT * FROM Hotels", connection);
            command.Connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var hotel = new Hotel();
                hotel.HotelId = Convert.ToInt32(reader[0]);
                hotel.HotelName = reader[2].ToString();
                hotel.Stars = Convert.ToInt32(reader[1]);
                hotel.FeePerNight = Convert.ToDecimal(reader[3].ToString());
                
                hotelList.Add(hotel);
            }

            var list = hotelList.Where(filter.Compile()).ToList();
            command.Connection.Close();
            return list[0];

        }

        public List<Hotel> GetAll(Expression<Func<Hotel, bool>> filter = null)
        {
            var hotelList = new List<Hotel>();
            SqlConnection connection = new SqlConnection(DBMS.Connection);
            SqlCommand command = new SqlCommand("SELECT * FROM Hotels", connection);
            command.Connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var hotel = new Hotel();
                hotel.HotelId = Convert.ToInt32(reader[0]);
                hotel.HotelName = reader[2].ToString();
                hotel.Stars = Convert.ToInt32(reader[1]);
                hotel.FeePerNight = Convert.ToDecimal(reader[3].ToString());

                hotelList.Add(hotel);
            }

            var list = hotelList.Where(filter.Compile()).ToList();
            command.Connection.Close();
            return filter == null ? hotelList : hotelList.Where(filter.Compile()).ToList();
        }

        public void Update(Hotel entity)
        {
            using (SqlCommand command = new SqlCommand("UPDATE Hotels SET HotelName = @HotelName, Stars=@Stars, FeePerNight=@FeePerNight WHERE HotelId = @HotelId"))
            {
                command.Parameters.AddWithValue("HotelId", entity.HotelId);
                command.Parameters.AddWithValue("Stars", entity.Stars);
                command.Parameters.AddWithValue("HotelName", entity.HotelName);
                command.Parameters.AddWithValue("FeePerNight", entity.FeePerNight);
                DBMS.ExecuteNonQuery(command);
            }

        }
    }
}
