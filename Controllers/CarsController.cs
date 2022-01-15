using System;
using System.Data.SqlClient;
using Data.Models;

using ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Data.Interfaces;

using ERO;
using System.Threading.Tasks;

namespace Controllers
{
    public class CarsController : Controller, IGetAllCars
    {
        private static readonly string _connectionPath = ApplicationConfiguration.Get().GetConnectionString("DB");

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
                    catch
                    {
                        Console.WriteLine("Error");
                        return View("~/Views/Error.cshtml");
                    }
                }
            }
        }
    }
}
