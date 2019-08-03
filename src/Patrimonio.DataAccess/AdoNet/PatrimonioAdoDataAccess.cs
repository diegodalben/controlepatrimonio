using System;
using System.Collections.Generic;
using System.Data;
using Patrimonio.Business.Entities;
using Patrimonio.Business.Repositories;

namespace Patrimonio.DataAccess.AdoNet
{
    public class PatrimonioAdoDataAccess : IPatrimonioRepository
    {
        private readonly IDbConnection _connection;

        public PatrimonioAdoDataAccess
        (
            IDbConnection connection
        )
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public int Create(EPatrimonio entity)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Patrimonio_Insert;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@Nome", entity.Nome, ParameterDirection.Input);
                AddParameter(command, "@MarcaId", entity.Marca.MarcaId, ParameterDirection.Input);
                AddParameter(command, "@Descricao", entity.Descricao, ParameterDirection.Input);
                AddParameter(command, "@NumTombo", entity.NumTombo, ParameterDirection.Input);
                AddParameter(command, "@PatrimonioId", entity.PatrimonioId, ParameterDirection.Output);

                try
                {
                    _connection.Open();
                    var affectedRows = command.ExecuteNonQuery();
                    entity.PatrimonioId = (int) command.Parameters["@PatrimonioId"];

                    return affectedRows;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public int Delete(object id)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Patrimonio_Delete;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@PatrimonioId", id, ParameterDirection.Input);

                try
                {
                    _connection.Open();
                    return command.ExecuteNonQuery();
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public IEnumerable<EPatrimonio> GetAll()
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Patrimonio_GetAll;
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new EPatrimonio
                            {
                                PatrimonioId = Convert.ToInt64(reader["PatrimonioId"]),
                                Nome = reader["Nome"].ToString(),
                                Marca = new EMarca
                                {
                                    MarcaId = Convert.ToInt32(reader["MarcaId"]),
                                    Nome = reader["MarcaNome"].ToString()
                                },
                                Descricao = reader["Descricao"].ToString(),
                                NumTombo = Convert.ToInt32(reader["NumTombo"])
                            };
                        }
                    }
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public EPatrimonio GetById(object id)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Patrimonio_GetById;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@PatrimonioId", id, ParameterDirection.Input);

                try
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if(!reader.Read()) return null;
                        
                        return new EPatrimonio
                        {
                            PatrimonioId = Convert.ToInt64(reader["PatrimonioId"]),
                            Nome = reader["Nome"].ToString(),
                            Marca = new EMarca
                            {
                                MarcaId = Convert.ToInt32(reader["MarcaId"]),
                                Nome = reader["MarcaNome"].ToString()
                            },
                            Descricao = reader["Descricao"].ToString(),
                            NumTombo = Convert.ToInt32(reader["NumTombo"])
                        };
                    }
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public IEnumerable<EPatrimonio> GetByMarca(int marcaId)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Patrimonio_GetByMarca;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@MarcaId", marcaId, ParameterDirection.Input);

                try
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new EPatrimonio
                            {
                                PatrimonioId = Convert.ToInt64(reader["PatrimonioId"]),
                                Nome = reader["Nome"].ToString(),
                                Marca = new EMarca
                                {
                                    MarcaId = Convert.ToInt32(reader["MarcaId"]),
                                    Nome = reader["MarcaNome"].ToString()
                                },
                                Descricao = reader["Descricao"].ToString(),
                                NumTombo = Convert.ToInt32(reader["NumTombo"])
                            };
                        }
                    }
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public int Update(EPatrimonio entity)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Patrimonio_Update;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@PatrimonioId", entity.PatrimonioId, ParameterDirection.Input);
                AddParameter(command, "@Nome", entity.Nome, ParameterDirection.Input);
                AddParameter(command, "@MarcaId", entity.Marca.MarcaId, ParameterDirection.Input);
                AddParameter(command, "@Descricao", entity.Descricao, ParameterDirection.Input);

                try
                {
                    _connection.Open();
                    return command.ExecuteNonQuery();
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        private void AddParameter
        (
            IDbCommand command,
            string paramName,
            object paramValue, 
            ParameterDirection paramDirect
        )
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.Value = paramValue;
            parameter.Direction = paramDirect;
            command.Parameters.Add(parameter);
        }
    }
}