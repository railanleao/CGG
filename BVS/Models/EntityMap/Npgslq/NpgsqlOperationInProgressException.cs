using Npgsql;

namespace BVS.Models.EntityMap.Npgslq
{
    public sealed class NpgsqlOperationInProgressException : NpgsqlException
    {
        public NpgsqlCommand CommandInProgress { get; }
        public NpgsqlOperationInProgressException(NpgsqlCommand command)
        {
            CommandInProgress = command;
        }
    }
}
