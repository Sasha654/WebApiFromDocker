using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace WebApiFromDocker
{
    public class RedisRepository
    {
        private string _connectionString = "redis1:6379";
        private TimeSpan _expiry = TimeSpan.FromHours(1);

        public async Task SetValue(string key, string value)
        {
            using var connection = await ConnectionMultiplexer.ConnectAsync(_connectionString);
            var db = connection.GetDatabase();
            await db.StringSetAsync(key.ToUpper(), value, _expiry);
        }

        public async Task<string> GetValue(string key)
        {
            using var connection = await ConnectionMultiplexer.ConnectAsync(_connectionString);
            var db = connection.GetDatabase();
            var redisValue = await db.StringGetAsync(key.ToUpper());
            return redisValue;
        }
    }
}
