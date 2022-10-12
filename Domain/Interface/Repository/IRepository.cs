using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        T Update(T item);

        Task<bool> DeleteAsync(Guid id);
        bool Delete(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        IEnumerable<T> Select();
        //Task<bool> ExistAsync(Guid id);
        IDbConnection CreateConnection(string connectionStringName);
        void ExecuteScript(string script, IDbConnection connection, IDbTransaction transaction);
        Task ExecuteScriptAsync(string script, IDbConnection connection, IDbTransaction transaction);

        IEnumerable<T> ExecuteScript<T>(string script, IDbConnection connection, IDbTransaction transaction);
        Task<IEnumerable<T>> ExecuteScriptAsync<T>(string script, IDbConnection connection, IDbTransaction transaction);

        IEnumerable<T> ExecuteScript<T>(string script, string connectionStringName);
        Task<IEnumerable<T>> ExecuteScriptAsync<T>(string script, string connectionStringName);

        List<T> LoadData<T>(string storedProcedure, string connectionStringName);
        Task<IEnumerable<T>> LoadDataAsync<T>(string storedProcedure, string connectionStringName);

        List<T1> LoadData<T1, T2>(string storedProcedure, T2 parameters, string connectionStringName);
        Task<IEnumerable<T1>> LoadDataAsync<T1, T2>(string storedProcedure, T2 parameters, string connectionStringName);

        void SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionStringName);

        void SaveData<T>(string storedProcedure, T parameters, IDbConnection connection, IDbTransaction transaction);
        Task SaveDataAsync<T>(string storedProcedure, T parameters, IDbConnection connection, IDbTransaction transaction);
    }
}
