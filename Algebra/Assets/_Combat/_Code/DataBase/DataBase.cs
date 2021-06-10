using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class DataBase
{

    // Attributes
    private string stringConnection;
    private IDbConnection dbcon;
    private int dataBaseStatus = 0;

    // Properties
    public int DataBaseStatus
    {
        get{ return dataBaseStatus;}
    }
    

    // Connection Method
    public void StartDB(string connection)
    {
        try{
            this.dbcon = new SqliteConnection(connection);
            this.dbcon.Open();
            this.dataBaseStatus = 1;            
        }catch
        {
            this.dataBaseStatus = -1;
        }
    }

    public void StopDB()
    {
        this.dbcon.Close();
        this.dataBaseStatus = 0;
    }

    // Create table method
    public void CreateTable(string sqlcommand)
    {
        try{
            IDbCommand cmnd = this.dbcon.CreateCommand();
            cmnd.CommandText = sqlcommand;
            cmnd.ExecuteNonQuery();
            this.dataBaseStatus = 2;
        } catch
        {
            this.dataBaseStatus = -2;
        }
        
    }

    // Insert row to table
    public void InsertRow(string sqlcommand)
    {
        try
        {
            IDbCommand cmnd = this.dbcon.CreateCommand();
            cmnd.CommandText = sqlcommand;
            cmnd.ExecuteNonQuery();
            this.dataBaseStatus = 3;
        }
        catch
        {
            this.dataBaseStatus = -3;
        }
    }

    // COUNT QUERY
    public int CountQuery(string sqlcommand)
    {
        IDbCommand cmd_read = this.dbcon.CreateCommand();
        cmd_read.CommandText = sqlcommand;
        IDataReader reader = cmd_read.ExecuteReader();
        this.dataBaseStatus  = 5;
        int count = Int32.Parse(reader[0].ToString());
        return count;
    }


    // Query limited table method
    public string[,] ArrayQuery(string sqlcommand, int row, int column)
    {
        string[,] resultQuery = new string[row,column];
        IDbCommand cmd_read = this.dbcon.CreateCommand();
        cmd_read.CommandText = sqlcommand;
        IDataReader reader = cmd_read.ExecuteReader();

        int count = 0;
            while (reader.Read())
            {
                for(int i = 0; i < column; i++)
                {                    
                    resultQuery[count, i] = reader[i].ToString();
                }
                count++;
            }
        this.dataBaseStatus = 4;
        return resultQuery;
    }



}
