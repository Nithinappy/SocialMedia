using Dapper;
using OnlineShopping.Repositories;
using SocialMedia.Models;
using SocialMedia.Utilities;

namespace SocialMedia.Repositories;
public interface IPostRepository
{
    Task<List<Post>> GetAllPosts();
    Task<Post> GetPostById(long PostId);
    Task<Post> CreatePost(Post item);
    // Task<bool> UpdatePost(Post item);
    Task<bool> DeletePost(long PostId);
    Task<List<Post>> GetUserPostById(long UserId);
    Task<List<Post>> GetHashTagPostById(long HashTagId);


}

public class PostRepository :BaseRepository, IPostRepository
{

    public PostRepository(IConfiguration config) : base(config)
    {

    }
    public async Task<Post> CreatePost(Post item)
    {
       var query = $@"INSERT INTO ""{TableNames.posts}"" 
        (post_type,user_id) 
        VALUES (@PostType, @UserId)  RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Post>(query, item);
            return res;
        }
    }

    public async Task<bool> DeletePost(long PostId)
    {
         var query = $@"Delete  FROM ""{TableNames.posts}"" 
        WHERE post_id=@PostId";

        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { PostId });
            return res > 0;
        }
    }

    public async Task<List<Post>> GetAllPosts()
    {
     
        // Query
        var query = $@"SELECT * FROM ""{TableNames.posts}""";

        List<Post> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Post>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }

    public async Task<List<Post>> GetHashTagPostById(long HashTagId)
    {
         var query = $@"SELECT p.* FROM {TableNames.hash_post}  hp LEFT JOIN {TableNames.posts} p 
			  on hp.post_id = p.post_id  WHERE hash_tag_id=@HashTagId ORDER BY p.post_id ASC";
        List<Post> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Post>(query,new{HashTagId})).AsList(); // Execute the query
       
        return res;
    }

    public async Task<Post> GetPostById(long PostId)
    {
        var query = $@"SELECT * FROM ""{TableNames.posts}"" 
        WHERE post_id = @PostId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Post>(query, new { PostId });
            
    }

    public async Task<List<Post>> GetUserPostById(long UserId)
    {
         var query = $@"SELECT * FROM ""{TableNames.posts}"" WHERE user_id=@UserId";

        List<Post> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Post>(query,new{UserId})).AsList(); // Execute the query
       
        return res;
    }

    public async Task<bool> UpdatePost(Post item)
    {
          var query = $@"UPDATE ""{TableNames.posts}"" SET Post_name = @PostName, 
        email = @Email,bio = @Bio,address = @Address WHERE Post_id = @PostId";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, item);
            return rowCount == 1;
    }

   
}
}