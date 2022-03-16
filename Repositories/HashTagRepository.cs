using Dapper;
using OnlineShopping.Repositories;
using SocialMedia.Models;
using SocialMedia.Utilities;

namespace SocialMedia.Repositories;
public interface IHashTagRepository
{


    Task<HashTag> CreateHashTag(HashTag item);
    Task<HashTag> GetHashTagById(long HashTagId);
    Task<List<HashTag>> GetAllHashTag();
    Task<List<HashTag>> GetPostHashTagById(long PostId);

    Task<bool> DeleteHashTag(long HashTagId);

}

public class HashTagRepository : BaseRepository, IHashTagRepository
{

    public HashTagRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<HashTag> CreateHashTag(HashTag item)
    {
        var query = $@"INSERT INTO ""{TableNames.hash_tags}"" 
        (hash_name) 
        VALUES (@HashName)  RETURNING *";
        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<HashTag>(query, item);
            return res;
        }
    }

    public async Task<bool> DeleteHashTag(long HashTagId)
    {
        var query = $@"Delete  FROM ""{TableNames.hash_tags}"" 
        WHERE hash_tag_id = @HashTagId";

        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { HashTagId });
            return res > 0;
        }

    }

    public async Task<List<HashTag>> GetAllHashTag()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.hash_tags}""";

        List<HashTag> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<HashTag>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }

    public async Task<HashTag> GetHashTagById(long HashTagId)
    {
        var query = $@"SELECT * FROM ""{TableNames.hash_tags}"" 
        WHERE hash_tag_id = @HashTagId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<HashTag>(query, new { HashTagId });

    }

    public async Task<List<HashTag>> GetPostHashTagById(long PostId)
    {
        var query = $@"SELECT ht.* FROM {TableNames.hash_post}  hp LEFT JOIN {TableNames.hash_tags} ht 
			  on hp.hash_tag_id = ht.hash_tag_id  WHERE post_id = @PostId ORDER BY ht.hash_tag_id ASC";
        List<HashTag> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<HashTag>(query, new { PostId })).AsList(); // Execute the query

        return res;
    }


}