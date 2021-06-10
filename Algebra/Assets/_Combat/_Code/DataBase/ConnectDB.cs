using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;



public class ConnectDB : MonoBehaviour
{
    private DataBase dataBase = new DataBase();

    public string stringConnection; 
    void Start()
    {
            stringConnection = "URI=file:" + Application.persistentDataPath + "/" + "CombatDB";
        // Iniciar la base de datos
        dataBase.StartDB(stringConnection);
        
        // IF no se ha iniciado el juego nunca (creación de tablas):
        dataBase.CreateTable("CREATE TABLE IF NOT EXISTS Player (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, HighScore INTEGER, LastScore INTEGER)");
        Debug.Log(dataBase.DataBaseStatus);
        
        // Detenemos la base de datos
        dataBase.StopDB();

        InitialProcess();
        consultaResultados();
    }


    public void InitialProcess()
    {
        if (!PlayerPrefs.HasKey("First"))
        {
            dataBase.StartDB(stringConnection);
            // Se inserta un valor dummy para validar la tabla
            dataBase.InsertRow("INSERT INTO Player (HighScore, LastScore)VALUES (0, 0)");
            dataBase.InsertRow("INSERT INTO Player (HighScore, LastScore)VALUES (0, 0)");
            // Se detiene la base de datos
            dataBase.StopDB();
            PlayerPrefs.SetInt("First",0);
        }      
                                                    
    }

    public void updateData(int OneHS, int OneScore, int TwoHS, int TwoScore)
    {
        dataBase.StartDB(stringConnection);
        // Se inserta un valor dummy para validar la tabla
        dataBase.InsertRow("UPDATE Player SET HighScore = " + OneHS + " WHERE ID = 1");
        dataBase.InsertRow("UPDATE Player SET LastScore = " + OneScore + " WHERE ID = 1");
        dataBase.InsertRow("UPDATE Player SET HighScore = " + TwoHS + " WHERE ID = 2");
        dataBase.InsertRow("UPDATE Player SET LastScore = " + TwoScore + " WHERE ID = 2");
        // Se detiene la base de datos
        dataBase.StopDB();
    }



    public string[,] consultaResultados()
    {
        // Inicializar base de datos
        dataBase.StartDB(stringConnection);

        // Se identifican cuantas filas hay en la tabla
        int numberRows = dataBase.CountQuery("SELECT COUNT(*) FROM Player");
        int numberColumns = 3;

        // Se realiza query de la tabla playerID
        string[,] player_ID = new string[numberRows,numberColumns];
            
        player_ID = dataBase.ArrayQuery("SELECT * FROM Player", numberRows, numberColumns);        
        Debug.Log(dataBase.DataBaseStatus);
                  
        dataBase.StopDB();
        return player_ID;
    }




    public void databaseTest()
    {

        Debug.Log(Application.persistentDataPath);

        string connection = "URI=file:" + Application.persistentDataPath + "/" + "unityDB";
        IDbConnection dbcon = new SqliteConnection(connection);
        
        try
        {
            // Ejecuta todo lo que hay en esta sección hasta que te de error.
            dbcon.Open();
            Debug.Log("Conexión exitosa!");
                
            // Se crea una nueva tabla
            IDbCommand cmnd = dbcon.CreateCommand();
            cmnd.CommandText = "CREATE TABLE IF NOT EXISTS " +
            "game_stats ( player_name VARCHAR(50), time_played INT, number_medals INT," +
            "number_Pokedex INT)";
            cmnd.ExecuteNonQuery();
            Debug.Log("Se creo la tabla game_stats");

            // Crear otro comando para insertar
            IDbCommand cmnd2 = dbcon.CreateCommand();
            cmnd2.CommandText = "INSERT INTO game_stats " +
            "(player_name, time_played, number_medals, number_Pokedex) " + 
            "VALUES ('Diana',  0, 0, 1)" ;
            //cmnd2.ExecuteNonQuery();
            Debug.Log("Se inserto un registro a la tabla");
            
            // Crear un comando Query para consulta
            IDbCommand cmd_read = dbcon.CreateCommand();
            cmd_read.CommandText = "SELECT * FROM game_stats";
            IDataReader reader = cmd_read.ExecuteReader();

            int conteo = 0;
            while (reader.Read())
            {
                Debug.Log("player_name: " + reader[0].ToString());
                Debug.Log("number_Pokedex: " + reader[3].ToString());
                conteo++;
            }

            Debug.Log("Hay " + conteo + " registros en la tabla game_stats");

                  
            // Se cierra la conexion a la BD
            dbcon.Close();
        }
        catch
        {
            // Cuando te de error ejecuta esto:
            Debug.Log("ocurrió un error");   
        }
        
                
    }

}
