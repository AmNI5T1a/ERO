using System;
using System.Data.SqlClient;
using Data.Models;

using ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Data.Interfaces;

using ERO;
using System.Threading.Tasks;
using System.Data;

namespace Controllers
{
    public class CarsController : Controller, IGetAllCars
    {
        private static readonly string _connectionPath = ApplicationConfiguration.Get().GetConnectionString("DB");

        /// <summary>
        /// Show new View with all cars stored in database
        /// </summary>
        /// <returns> View with all cars in database </returns>
        [HttpGet("Cars/List")]
        public async Task<ViewResult> List()
        {
            using (var dbConnection = new SqlConnection(_connectionPath))
            {
                await dbConnection.OpenAsync();

                using (var dbCommand = new SqlCommand())
                {
                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandTimeout = dbConnection.ConnectionTimeout;
                    dbCommand.CommandText = "testProcedure";
                    dbCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        SqlDataReader sqlDataReader = dbCommand.ExecuteReader();
                        CarsListViewModel tempCLVM_Obj = new CarsListViewModel();

                        while (sqlDataReader.Read())
                        {
                            tempCLVM_Obj.allCars.AddFirst(new Car(sqlDataReader.GetValue(1).ToString(),
                                                            sqlDataReader.GetValue(2).ToString(),
                                                            sqlDataReader.GetValue(3).ToString(),
                                                            (float)sqlDataReader.GetValue(4),
                                                            sqlDataReader.GetValue(5).ToString()));
                        }

                        return View(tempCLVM_Obj);
                    }
                    catch(Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Catched exception: " + e.ToString());
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        return View("~/Views/Error.cshtml");
                    }
                }
            }
        }
        /// <summary>
        /// Searching in database all cars that are in the interval of the price
        /// </summary>
        /// <param name="inputElement"> Contains price from and price to elements for input parameters to database procedure </param>
        /// <returns> List of cars in the price interval</returns>
        [HttpGet("get")]
        public async Task<CarsListViewModel> ShowCarsWithPriceInterval(FromToPrice inputElement)
        {
            using(var connection = new SqlConnection(_connectionPath))
            {
                await connection.OpenAsync();

                using(var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "GetCarsWithPriceInterval";
                    sqlCommand.CommandTimeout = 1;

                    sqlCommand.Parameters.AddWithValue("@PriceFrom", inputElement.PriceFrom);
                    sqlCommand.Parameters.AddWithValue("@PriceTo", inputElement.PriceTo);

                    try
                    {
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        CarsListViewModel tempCLVM_Obj = new CarsListViewModel();

                        while (sqlDataReader.Read())
                        {
                            tempCLVM_Obj.allCars.AddFirst(new Car(sqlDataReader.GetValue(1).ToString(),
                                                            sqlDataReader.GetValue(2).ToString(),
                                                            sqlDataReader.GetValue(3).ToString(),
                                                            (float)sqlDataReader.GetValue(4),
                                                            sqlDataReader.GetValue(5).ToString()));
                        }

                        return tempCLVM_Obj;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Catched exception: " + e.ToString());
                        Console.ForegroundColor = ConsoleColor.White;

                        return null;
                    }
                }
            }
        }
    }
}
