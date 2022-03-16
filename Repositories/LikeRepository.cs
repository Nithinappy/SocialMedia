using Dapper;
using OnlineShopping.Repositories;
using SocialMedia.Models;
using SocialMedia.Utilities;

namespace SocialMedia.Repositories;
public interface ILikeRepository
{
    
    
    Task<Like> CreateLike(Like item);
    Task<Like> GetLikeById(long LikeId);
    Task<bool> DeleteLike(long LikeId);
    Task<List<Like>> GetLikesById(long PostId);
    Task<List<Like>> GetUserLikesById(long User_id);

    

}

public class LikeRepository :BaseRepository, ILikeRepository
{

    public LikeRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Like> CreateLike(Like item)
    {
        var query = $@"INSERT INTO ""{TableNames.likes}"" 
        (post_id,user_id) 
        VALUES (@PostId, @UserId)  RETURNING *";
          using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Like>(query, item);
            return res;
        }
    }

    public async Task<bool> DeleteLike(long LikeId)
    {
        var query = $@"Delete  FROM ""{TableNames.likes}"" 
        WHERE like_id = @LikeId";

        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { LikeId });
            return res > 0;
        }

    }
     public async Task<Like> GetLikeById(long LikeId)
    {
        var query = $@"SELECT * FROM ""{TableNames.likes}"" 
        WHERE like_id = @LikeId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Like>(query, new { LikeId });
            
    }

    public async Task<List<Like>> GetLikesById(long PostId)
    {
          var query = $@"SELECT * FROM ""{TableNames.likes}"" WHERE post_id = @PostId";

        List<Like> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Like>(query,new{PostId})).AsList(); // Execute the query
       
        return res;
    }

    public async Task<List<Like>> GetUserLikesById(long User_id)
    {
       var query = $@"SELECT * FROM ""{TableNames.likes}"" WHERE user_id = @User_id";

        List<Like> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Like>(query,new{User_id})).AsList(); // Execute the query
       
        return res;
    }

 
}