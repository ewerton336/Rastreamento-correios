using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Correios.Pacotes.Models;

namespace Correios.Pacotes.DAO
{
    public class CrudPacotes : DaoConexao
    {

        public CrudPacotes(IDbConnection dbConnection) : base(dbConnection)
        {

        }


        public IEnumerable<Pacote> GetRastreios()
        {
            var sql = @"SELECT
                        ID
                        ,CODIGO_RASTREIO CODIGO
                        FROM T2S.RASTREAMENTO_CORREIOS
                        WHERE ENTREGUE != 1";

            var result = DbConnection.Query<Pacote>(sql);
            return result;
        }

        public IEnumerable<Models.Pacote> GetPacotes()
        {
            try
            {
                string SQL = @"   SELECT ID
                                 ,CODIGO_RASTREIO AS CODIGO
                                 , DESCRICAO_GERAL AS HISTORICO
                                 , ENTREGUE AS ENTREGUE
                                 FROM T2S.RASTREAMENTO_CORREIOS rc 
                                 WHERE ENTREGUE != 1";
                var result = DbConnection.Query<Models.Pacote>(SQL);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int InserirPacote(string codigoRastreio)
        {
            try
            {
                string SQL = @"   INSERT INTO T2S.RASTREAMENTO_CORREIOS
                                    ( CODIGO_RASTREIO, ENTREGUE)
                                    VALUES(:RASTREIO,  0)";

                var result = DbConnection.Execute(SQL, new {RASTREIO = codigoRastreio });
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EncerrarPacoteEntregue(int idPacote)
        {
            string sql = @"UPDATE T2S.RASTREAMENTO_CORREIOS
                            SET ENTREGUE = 1
                            WHERE ID = :ID";
            var result = DbConnection.Execute(sql, new { ID = idPacote });
        }






    }
}
