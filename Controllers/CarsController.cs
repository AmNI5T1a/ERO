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

        // returning ViewResult
        //public ViewResult List()
        //{
        //    //ViewPage.Title = "WGTTM:Cars";

        //    // TODO: connect to db
        //    // TODO: get data 
        //    // TODO: set data to ViewModel
        //    // TODO: load page
        //    SqlConnection sql_Connection = new SqlConnection(_connectionPath);
        //    sql_Connection.Open();

        //    SqlCommand sql_command;
        //    SqlDataReader sql_DataReader;
        //    String sql, Output = null;

        //    sql = @"EXECUTE testProcedure";

        //    sql_command = new SqlCommand(sql, sql_Connection);

        //    sql_DataReader = sql_command.ExecuteReader();

        //    CarsListViewModel tempCLVM_Obj = new CarsListViewModel();

        //    while (sql_DataReader.Read())
        //    {
        //        //TODO Add to the list
        //        //Output = Output + sql_DataReader.GetValue(1) + " - " + sql_DataReader.GetValue(2) + " - " + sql_DataReader.GetValue(3) + " - " + sql_DataReader.GetValue(4) + "-" + sql_DataReader.GetValue(5);
        //        tempCLVM_Obj.allCars.AddFirst(new Car(sql_DataReader.GetValue(1).ToString(),
        //                                                sql_DataReader.GetValue(2).ToString(),
        //                                                sql_DataReader.GetValue(3).ToString(),
        //                                                (float)sql_DataReader.GetValue(4),
        //                                                sql_DataReader.GetValue(5).ToString()));
        //    }

        //    return View(tempCLVM_Obj);
        //}

        public async Task<ViewResult> List()
        {
            using (var dbConnection = new SqlConnection(_connectionPath))
            {
                await dbConnection.OpenAsync();

                using (var dbCommand = new SqlCommand())
                {
                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandTimeout = dbConnection.ConnectionTimeout;
                    dbCommand.CommandText = "testPrasdocedure";
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
                        return View("~/Views/Error.cshtml", e);
                    }
                }
            }
        }
    }
}
