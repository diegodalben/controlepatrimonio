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

        public void Create(EMarca entity)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Marca_Insert;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@Nome", entity.Nome, ParameterDirection.Input);
                AddParameter(command, "@MarcaId", entity.MarcaId, ParameterDirection.Output);

                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                    entity.MarcaId = (int) command.Parameters["@MarcaId"];
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public void Delete(object id)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = ProceduresConstants.Prc_Marca_Delete;
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@MarcaId", id, ParameterDirection.Input);

                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
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

        public void Update(EMarca entity)
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
                    command.ExecuteNonQuery();
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