using Dapper;
using OnlineShopping.Repositories;
using SocialMedia.Models;
using SocialMedia.Utilities;

namespace SocialMedia.Repositories;
public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(long UserId);
    Task<User> CreateUser(User item);
    Task<bool> UpdateUser(User item);
    Task<User> DeleteUser(long UserId);

}

public class UserRepository :BaseRepository, IUserRepository
{

    public UserRepository(IConfiguration config) : base(config)
    {

    }
    public async Task<User> CreateUser(User item)
    {
       var query = $@"INSERT INTO ""{TableNames.users}"" 
        (first_name,last_name,user_name,email,mobile,bio,address,passcode) 
        VALUES (@FirstName, @LastName, @UserName ,@Email, @Mobile,@Bio, @Address, @Passcode) 
        RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<User>(query, item);
            return res;
        }
    }

    public  Task<User> DeleteUser(long UserId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllUsers()
    {
     
        // Query
        var query = $@"SELECT * FROM ""{TableNames.users}""";

        List<User> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<User>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }

    public async Task<User> GetUserById(long UserId)
    {
        var query = $@"SELECT * FROM ""{TableNames.users}"" 
        WHERE user_id = @UserId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<User>(query, new { UserId });
            
    }

    public async Task<bool> UpdateUser(User item)
    {
          var query = $@"UPDATE ""{TableNames.users}"" SET user_name = @UserName, 
        email = @Email,bio = @Bio,address = @Address WHERE user_id = @UserId";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, item);
            return rowCount == 1;
    }

   
}
}