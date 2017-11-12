#region Copyright Notice
/* Copyright (c) 2017, Deb'jyoti Das - debjyoti@debjyoti.com
 All rights reserved.

 Redistribution and use in source and binary forms, with or without
 modification, are not permitted.Neither the name of the 
 'Deb'jyoti Das' nor the names of its contributors may be used 
 to endorse or promote products derived from this software without 
 specific prior written permission.

 THIS SOFTWARE IS PROVIDED BY Deb'jyoti Das 'AS IS' AND ANY
 EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 DISCLAIMED. IN NO EVENT SHALL Synechron Holdings Inc BE LIABLE FOR ANY
 DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
#region Developer Information
/*
Author  - Debjyoti Das (debjyoti@debjyoti.com)
Created - 11/12/2017 3:31:31 PM
Description  - 
Modified By - 
Description  - 
*/
#endregion Developer Information

#endregion Copyright Notice
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eyedia.Aarbac.Framework;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Configuration;
using GenericParsing;

namespace Eyedia.Aarbac.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            new DisclaimerWriter(@"C:\Deb\Workspace\GitHub\Aarbac\aarbac").Write();
            return;

            SetDataDirectory();
            CommandLineCommands.Do(args);
            
        }

        private static void SetDataDirectory()
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Eyedia.Aarbac.Framework\Databases");
            var fullPath = System.IO.Path.GetFullPath(path);
            AppDomain.CurrentDomain.SetData("DataDirectory", fullPath);
        }


        #region GetCityId
        private static void GetCityId(string connStr)
        {
            DataTable t = new GenericParserAdapter("c:\\temp\\sc.csv").GetDataTable();

            DataTable newT = new DataTable();        
            newT.Columns.Add("ZipCode");
            newT.Columns.Add("CityId");

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                foreach (DataRow r in t.Rows)
                {
                    DataRow newr = newT.NewRow();                    
                    SqlCommand tCommand = new SqlCommand(string.Format("select CityId from City where Name = '{0}' and StateId = 41", r["City"]), connection);
                    SqlDataReader tReader = tCommand.ExecuteReader();
                    tReader.Read();
                    newr[0] = r[0];
                    newr[1] = tReader[0];
                    tReader.Close();
                    newT.Rows.Add(newr);
                }
                connection.Close();
            }

            //newT.ToCsv("c:\\temp\\zipcode.csv");
        }
        #endregion GetCityId

    }
}
