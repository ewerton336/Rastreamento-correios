using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Correios.Pacotes.DAO
{
    public class CrudPacotes : DaoConexao
    {

        public CrudPacotes(IDbConnection dbConnection) : base(dbConnection)
        {
        }


        public IEnumerable<String> GetRastreios()
        {
            var sql = @"SELECT
                        CODIGO_RASTREIO
                        FROM T2S.RASTREAMENTO_CORREIOS
                        WHERE ENTREGUE != 1";

            var result = DbConnection.Query<string>(sql);
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






    }
}
