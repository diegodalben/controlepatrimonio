using System;
using System.Data;
using System.Collections.Generic;
using Patrimonio.Business.Entities;
using Patrimonio.Business.Repositories;

namespace Patrimonio.DataAccess.AdoNet
{
    public class MarcaAdoDataAccess : IMarcaRepository
    {
        private readonly IDbConnection _connection;

        public MarcaAdoDataAccess
        (
            IDbConnection connection
        )
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public int Create(EMarca entity)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Marca_Insert;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@Nome", entity.Nome, ParameterDirection.Input);
                var paramMarcaId = AddParameter(command, "@MarcaId", entity.MarcaId, ParameterDirection.Output);

                try
                {
                    _connection.Open();
                    var affectedRows = command.ExecuteNonQuery();
                    entity.MarcaId = Convert.ToInt32(paramMarcaId.Value);

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
                command.CommandText = ProceduresConstants.Prc_Marca_Delete;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@MarcaId", id, ParameterDirection.Input);

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

        public IEnumerable<EMarca> GetAll()
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Marca_GetAll;
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new EMarca
                            {
                                MarcaId = Convert.ToInt32(reader["MarcaId"]),
                                Nome = reader["Nome"].ToString()
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

        public EMarca GetById(object id)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Marca_GetById;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@MarcaId", id, ParameterDirection.Input);

                try
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if(!reader.Read()) return null;
                        
                        return new EMarca
                        {
                            MarcaId = Convert.ToInt32(reader["MarcaId"]),
                            Nome = reader["Nome"].ToString()
                        };
                    }
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public EMarca GetByName(string nome)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Marca_GetByName;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@Nome", nome, ParameterDirection.Input);

                try
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if(!reader.Read()) return null;
                        
                        return new EMarca
                        {
                            MarcaId = Convert.ToInt32(reader["MarcaId"]),
                            Nome = reader["Nome"].ToString()
                        };
                    }
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public int Update(EMarca entity)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Marca_Update;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@MarcaId", entity.MarcaId, ParameterDirection.Input);
                AddParameter(command, "@Nome", entity.Nome, ParameterDirection.Input);

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

        private IDbDataParameter AddParameter
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

            return parameter;
        }
    }
}