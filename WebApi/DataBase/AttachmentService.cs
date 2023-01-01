using WebApi.Exceptions;

namespace DefaultNamespace;
using WebApi.Entities;
using MySql.Data.MySqlClient;
public class AttachmentService
{
    private DBConnection _dbConnection;
    public AttachmentService()
    {
        _dbConnection = DBConnection.Instance();
        _dbConnection.Server = "127.0.0.1";
        _dbConnection.DatabaseName = "mydb";
        _dbConnection.UserName = "root";
        _dbConnection.Password = "S41494978s*";
    }
    
    public Task<IEnumerable<Attachment>> GetAllAsync()
    {
        var result = new List<Attachment>();
        if (_dbConnection.IsConnect())
        {
            string query = "SELECT * FROM mydb.attachment";
            using (var cmd = new MySqlCommand(query, _dbConnection.Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        result.Add(new Attachment()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Path = reader.GetString(2),
                            FileType = reader.GetString(3),
                            TaskId = reader.GetInt32(4)
                        });
                    }
                }
            }
            _dbConnection.Close();
        }

        return Task.FromResult<IEnumerable<Attachment>>(result);
    }
    
    public Task<Attachment> GetByIdAsync(int id)
    {
        Attachment result = null;
        if (id == null || id <= 0)
        {
            throw new CustomException("Invalid id");
        }

        if (_dbConnection.IsConnect())
        {
            var query = $"SELECT * FROM mydb.attachment WHERE id = {id}";
            using (var cmd = new MySqlCommand(query, _dbConnection.Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        result = new Attachment()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Path = reader.GetString(2),
                            FileType = reader.GetString(3),
                            TaskId = reader.GetInt32(4)
                        };
                    }
                }
            }
            _dbConnection.Close();
        }

        if (result == null)
        {
            throw new CustomException("There is no entity with such id.");
        }
        
        return Task.FromResult(result);
    }
    public Task AddAsync(Attachment entity)
    {
        if (string.IsNullOrEmpty(entity.Name)
            || string.IsNullOrEmpty(entity.Path)
            || string.IsNullOrEmpty(entity.FileType)
            || entity.TaskId == null || entity.TaskId <= 0)
        {
            throw new CustomException("Invalid Data");
        }
        if (_dbConnection.IsConnect())
        {
            var query = "INSERT INTO mydb.attachment (name, path, fileType, taskId) " +
                        $"VALUES ('{entity.Name}','{entity.Path}','{entity.FileType}','{entity.TaskId}')";
            using (var cmd = new MySqlCommand(query, _dbConnection.Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    }
                }
            }
            _dbConnection.Close();
        }
        return Task.CompletedTask;
        
    }
    public Task DeleteByIdAsync(int id)
    {
        if (id == null || id <= 0)
        {
            throw new CustomException("Invalid id");
        }
        
        if (_dbConnection.IsConnect())
        {
            var query = $"DELETE FROM mydb.attachment WHERE id = {id}";
            using (var cmd = new MySqlCommand(query, _dbConnection.Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                    }
                }
            }
            _dbConnection.Close();
        }
        
        return Task.CompletedTask;
    }
    
    public Task UpdateAsync(Attachment entity)
    {
        if (string.IsNullOrEmpty(entity.Name)
            || string.IsNullOrEmpty(entity.Path)
            || string.IsNullOrEmpty(entity.FileType)
            || entity.TaskId == null || entity.TaskId <= 0)
        {
            throw new CustomException("Invalid Data");
        }
        if (_dbConnection.IsConnect())
        {
            var query = "UPDATE mydb.attachment SET " +
                        $"name = '{entity.Name}', path = '{entity.Path}'," +
                        $"fileType = '{entity.FileType}', taskId = '{entity.TaskId}' WHERE id = {entity.Id}";
                        
            using (var cmd = new MySqlCommand(query, _dbConnection.Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    }
                }
            }
            _dbConnection.Close();
        }
        return Task.CompletedTask;
    }

}