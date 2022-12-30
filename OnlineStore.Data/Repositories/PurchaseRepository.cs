using Dapper;
using OnlineStore.Data.Repositories.Core;
using OnlineStore.Domain.Contracts.Repositories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DbSession _session;

        public PurchaseRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<int> CreateAsync(PurchasedItem entity)
        {
            const string sql =
                "INSERT INTO purchase " +
                "(user_id, laptop_id, date, purchase_token)" +
                "VALUES" +
                "(@UserId, LaptopId, Date, PurchaseToken)" +
                "RETURNING id";

            return await _session.Connection.ExecuteScalarAsync<int>(sql, entity, _session.Transaction);
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM purchase WHERE id=@id";

            return await _session.Connection.ExecuteAsync(sql, new { id }, _session.Transaction);
        }

        public async Task<IEnumerable<PurchasedItem>> GetAllAsync()
        {
            const string sql = "SELECT * FROM purchase";

            return await _session.Connection.QueryAsync<PurchasedItem>(sql);
        }

        public async Task<PurchasedItem> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM purchase WHERE id=@id";

            return await _session.Connection.QuerySingleOrDefault(sql);
        }

        public async Task<int> UpdateAsync(PurchasedItem entity)
        {
            const string sql =
                "UPDATE purchase SET " +
                "user_id=@UserId," +
                "laptop_id=@LaptopId" +
                "date=@Date" +
                "purchase_token=@PurchaseToken" +
                "WHERE id=@Id";

            return await _session.Connection.ExecuteAsync(sql, entity, _session.Transaction);
        }

        public async Task<IEnumerable<PurchasedItem>> GetByToken(Guid token)
        {
            const string sql =
                "SELECT purchase_token, user_id, laptop_id, COUNT(*) FROM purchase p " +
                "GROUP BY p.purchase_token, p.laptop_id, p.user_id";

            return await _session.Connection.QueryAsync<PurchasedItem>(sql, new { token });
        }
    }
}
