using System;
using System.Data.SqlClient;
using Data.Models;

using ViewModels;

using Microsoft.AspNetCore.Mvc;

using Data.Interfaces;

namespace Controllers
{
    public class CarsController : Controller, IGetAllCars
    {
        private static readonly string _connectionString = @"Server=localhost;Database=AUTOSHOP;Trusted_Connection=True;MultipleActiveResultSets=true";

        // returning ViewResult
        public ViewResult List()
        {
            //ViewPage.Title = "WGTTM:Cars";

            // TODO: connect to db
            // TODO: get data 
            // TODO: set data to ViewModel
            // TODO: load page
            SqlConnection sql_Connection = new SqlConnection(_connectionString);
            sql_Connection.Open();

            SqlCommand sql_command;
            SqlDataReader sql_DataReader;
            String sql, Output = null;

            sql = @"EXECUTE testProcedure1 @CarName = 'Honda Accord'";

            sql_command = new SqlCommand(sql, sql_Connection);

            sql_DataReader = sql_command.ExecuteReader();

            CarsListViewModel tempCLVM_Obj = new CarsListViewModel();

            while (sql_DataReader.Read())
            {
                //TODO Add to the list
                //Output = Output + sql_DataReader.GetValue(1) + " - " + sql_DataReader.GetValue(2) + " - " + sql_DataReader.GetValue(3) + " - " + sql_DataReader.GetValue(4) + "-" + sql_DataReader.GetValue(5);
                tempCLVM_Obj.allCars.AddFirst(new Car(sql_DataReader.GetValue(1).ToString(),
                                                        sql_DataReader.GetValue(2).ToString(),
                                                        sql_DataReader.GetValue(3).ToString(),
                                                        (float)sql_DataReader.GetValue(4),
                                                        sql_DataReader.GetValue(5).ToString()));
            }

            return View(tempCLVM_Obj);
        }
    }
}
