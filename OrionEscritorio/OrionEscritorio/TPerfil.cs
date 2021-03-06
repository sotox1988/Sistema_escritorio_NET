﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace OrionEscritorio
{
    class TPerfil
    {
        public static List<Perfil> listarPerfil()
        {
            List<Perfil> lista = new List<Perfil>();
            OracleConnection conexion = Conexion.abrirConexion();//Singleton
            OracleCommand orden = new OracleCommand(string.Format("SELECT * FROM PERFIL"), conexion);
            OracleDataReader lector = orden.ExecuteReader();
            while (lector.Read())
            {
                Perfil perfil = new Perfil();

                perfil.idPerfil = lector.GetInt32(0);
                perfil.nombre = lector.GetString(1);
                perfil.descripcion = lector.GetString(2);
                //motivo.permiso_id = lector.GetInt32(3);

                lista.Add(perfil);
            }
            return lista;
        }

        public int modBuscar(Perfil perf)
        {
            int resp = 0;


            OracleConnection conexion = Conexion.abrirConexion();
            OracleCommand orden = new OracleCommand("select * from perfil where ID_PERFIL = '"+perf.idPerfil+"'", conexion);
            OracleDataReader lector = orden.ExecuteReader();
            if (lector.Read())
            {
                perf.idPerfil = lector.GetInt32(0);
                perf.nombre = lector.GetString(1);
                perf.descripcion = lector.GetString(2);
               
            }


            return resp;

        }

        public int ingresarPerfil(Perfil perfil)
        {

            OracleConnection conexion = Conexion.abrirConexion();
            OracleCommand orden = new OracleCommand(String.Format("select max(id_perfil) from perfil"), conexion);
            OracleDataReader lector = orden.ExecuteReader();
            if (lector.Read())
            {
                perfil.idPerfil = 1 + lector.GetInt32(0);
            }

            int resp = 0;
            
            OracleCommand orden2 = new OracleCommand(string.Format("INSERT INTO PERFIL(ID_PERFIL, NOMBRE_PERFIL, DESCRIPCION_PERFIL) VALUES('{0}', '{1}', '{2}')", perfil.idPerfil, perfil.nombre, perfil.descripcion), conexion);
            resp = orden2.ExecuteNonQuery();
            conexion.Close();
            return resp;
        }

        public int modificarPerfil(Perfil perfil)
        {
            int resp = 0;
            OracleConnection conexion = Conexion.abrirConexion();//Singleton  
            OracleCommand orden = new OracleCommand(string.Format("UPDATE PERFIL SET NOMBRE_PERFIL='{0}',DESCRIPCION_PERFIL={1} WHERE ID_PERFIL={3}", perfil.nombre, perfil.descripcion, perfil.idPerfil), conexion);
            resp = orden.ExecuteNonQuery();
            conexion.Close();
            return resp;
        }

        public int eliminarPerfil(int idPerfil)
        {
            int resp = 0;
            OracleConnection conexion = Conexion.abrirConexion();//Singleton
            OracleCommand orden = new OracleCommand(string.Format("DELETE FROM PERFIL WHERE ID_PERFIL='{0}'", idPerfil), conexion);
            resp = orden.ExecuteNonQuery();
            conexion.Close();
            return resp;
        }


        //Queries
        public Perfil buscarPerfil(int idPerfil)
        {
            Perfil perfil = new Perfil();
            OracleConnection conexion = Conexion.abrirConexion();
            OracleCommand orden = new OracleCommand(String.Format("SELECT * FROM PERFIL WHERE ID_PERFIL=@idPerfil"), conexion);
            orden.Parameters.Add("@ID_PERFIL", idPerfil);
            OracleDataReader lector = orden.ExecuteReader();
            if (lector.Read())
            {
                perfil.idPerfil = lector.GetInt32(0);
                perfil.nombre = lector.GetString(1);
                perfil.descripcion = lector.GetString(2);
                //motivo.permiso_id = lector.GetInt32(3);

            }
            conexion.Close();
            return perfil;
        }
    }
}
