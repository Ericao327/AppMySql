using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;

namespace AppMySql
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string celular { get; set; }
        public string serie { get; set; }

        MySqlConnection con = new MySqlConnection("server=127.0.0.1;port=3306;database=aula;user id=root;password=;charset=utf8");

        public List<Aluno> listaaluno()
        {
            List<Aluno> li = new List<Aluno>();
            string mysql = "SELECT * FROM turma";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(mysql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Aluno al = new Aluno();
                al.id = (int)dr["id"];
                al.nome = dr["nome"].ToString();
                al.celular = dr["celular"].ToString();
                al.serie = dr["serie"].ToString();
                li.Add(al);
            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Inserir(string nome, string celular, string serie)
        {
            string mysql = "INSERT INTO aluno(nome,celular,serie) VALUES('" + nome + "', '" + celular + "', '" + serie + "')";
            if (con.State == ConnectionState.Closed ) 
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand(mysql, con) ;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Atualizar(int id, string nome, string celular, string serie) 
        {
            string mysql = "UPDATE aluno SET nome ='" + nome + "',celular ='" + celular + "',serie ='" + serie + "' WHERE id ='" + id + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand( mysql, con) ;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int id)
        {
            string mysql = "DELETE FROM aluno WHERE id='"+id+"'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(mysql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int id)
        {
            string mysql = "SELECT * FROM aluno WHERE id='" + id + "' ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(mysql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                celular = dr["celular"].ToString(); 
                serie = dr["serie"].ToString();
            }
            dr.Close();
            con.Close();
        }

        public void Turma(int id)
        {
            string mysql = "SELECT * FROM aluno WHERE id='" + id + "' ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(mysql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                celular = dr["celular"].ToString();
                serie = dr["serie"].ToString();
            }
            dr.Close();
            con.Close();
        }

        public bool RegistroRepetido(string nome, string celular)
        {
            string mysql = "SELECT * FROM aluno WHERE nome='" + nome + "' AND celular='" + celular + "' ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(mysql, con);
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return true;
            }
            con.Close();
            return false;
        }
    }
}
