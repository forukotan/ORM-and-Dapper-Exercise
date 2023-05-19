﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
       private readonly IDbConnection _connection;
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartment()
        {
           var depos = _connection.Query<Department>("SELECT * FROM departments");
            return depos;

        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }
    }
}
