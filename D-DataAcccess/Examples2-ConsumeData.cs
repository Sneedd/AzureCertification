using System;
using System.Data.Common;
using System.Linq;
using System.IO;
using System.Transactions;

namespace Example
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsumeData
    {
        #region ADO.NET Examples

        public void RunAdoNetExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - ADO.NET https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/
            //
            // - SqlConnection class https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection
            //

            // Creating the abstract base classes
            string path = Path.Combine(Environment.CurrentDirectory, "database.mdf");
            DbConnection connection = new System.Data.SqlClient.SqlConnection(
                string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True", path));
            connection.Open();
            DbProviderFactory factory = DbProviderFactories.GetFactory(connection);

            // --------------------------------------------------------------------------------------------
            // ExecuteNonQuery            
            using (DbCommand createCommand = factory.CreateCommand())
            {
                createCommand.Connection = connection;
                createCommand.CommandText = "CREATE TABLE [Words] ([Id] INT NOT NULL PRIMARY KEY, [Word] NVARCHAR(50) NOT NULL, [Count] INT NOT NULL)";
                createCommand.ExecuteNonQuery();
            }

            // --------------------------------------------------------------------------------------------
            // ExecuteNonQuery with parameters
            using (DbCommand insertCommand = factory.CreateCommand())
            {
                DateTime current = DateTime.UtcNow;
                insertCommand.Connection = connection;
                insertCommand.CommandText = "INSERT INTO [Words] ([Id], [Word], [Count]) VALUES (@id, @word, @count)";

                DbParameter idParameter = factory.CreateParameter();
                idParameter.DbType = System.Data.DbType.Int32;
                idParameter.ParameterName = "@id";
                idParameter.Size = 4;
                idParameter.Value = 0;
                insertCommand.Parameters.Add(idParameter);

                DbParameter wordParameter = factory.CreateParameter();
                wordParameter.DbType = System.Data.DbType.String;
                wordParameter.ParameterName = "@word";
                wordParameter.Size = 100;
                wordParameter.Value = 0;
                insertCommand.Parameters.Add(wordParameter);

                DbParameter countParameter = factory.CreateParameter();
                countParameter.DbType = System.Data.DbType.Int32;
                countParameter.Size = 4;
                countParameter.ParameterName = "@count";
                countParameter.Value = 0;
                insertCommand.Parameters.Add(countParameter);

                insertCommand.Prepare();

                int id = 0;
                string text = StringData.CreateMediumString();
                string[] words = text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words.Distinct())
                {
                    idParameter.Value = id++;
                    wordParameter.Value = word;
                    countParameter.Value = words.Count(a => a == word);
                    insertCommand.ExecuteNonQuery();
                }
                Console.WriteLine("[DbCommand.Parameters] Inserted {0} rows in {1:0.000}s", id+1, (DateTime.UtcNow - current).TotalSeconds);
            }

            // --------------------------------------------------------------------------------------------
            // ExecuteScalar
            //   TODO
            using (DbCommand countCommand = factory.CreateCommand())
            {
                DateTime current = DateTime.UtcNow;
                countCommand.Connection = connection;
                countCommand.CommandText = "SELECT COUNT(*) FROM [Words]";
                int count = (int)countCommand.ExecuteScalar();
                Console.WriteLine("[DbCommand.ExecuteScalar] Result Count = {0} in {1:0.000}s", count, (DateTime.UtcNow - current).TotalSeconds);
            }


        }

        #endregion

        #region Transaction Examples

        public void RunTransactionsExamples()
        {
            // - IEnlistmentNotification interface https://docs.microsoft.com/en-us/dotnet/api/system.transactions.ienlistmentnotification
                       

            // Thread.GetMutableExecutionContext() allows the communication between TransactionScope and the inner Transactions.
            // IEnlistmentNotification can be used to implement integrate TransactionScope/Transcations in your an own API.

            // -----------------------------------------
            Console.Write("[Transaction] ");
            using (TransactionScope scope = new TransactionScope())
            {
                Transaction.Current.EnlistVolatile(new TestEnlistmentClass(), EnlistmentOptions.None);
                scope.Complete();
            }
            Console.WriteLine();


            // -----------------------------------------
            Console.Write("[Transaction.Exception] ");
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    Transaction.Current.EnlistVolatile(new TestEnlistmentClass(), EnlistmentOptions.None);
                    throw (new Exception());
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                Console.Write("Exception ");
            }
            Console.WriteLine();

            // -----------------------------------------
            Console.Write("[Transaction.WithoutComplete] ");
            using (TransactionScope scope = new TransactionScope())
            {
                Transaction.Current.EnlistVolatile(new TestEnlistmentClass(), EnlistmentOptions.None);
                //scope.Complete();
            }
            Console.WriteLine();

        }

        public class TestEnlistmentClass : IEnlistmentNotification
        {
            public void Prepare(PreparingEnlistment enlistment)
            {
                Console.Write("Prepare ");
                enlistment.Prepared();
            }

            public void Commit(Enlistment enlistment)
            {
                Console.Write("Commit ");
                enlistment.Done();
            }

            public void Rollback(Enlistment enlistment)
            {
                Console.Write("Rollback ");
                enlistment.Done();
            }

            public void InDoubt(Enlistment enlistment)
            {
                Console.Write("InDoubt ");
                enlistment.Done();
            }
        }

        #endregion

        #region Using WebServices Examples

        public void RunUsingWebServicesExamples()
        {

        }

        #endregion

        #region Consume JSON or XML Data Examples

        public void RunConsumeJsonXmlDataExamples()
        {
        }

        #endregion
    }
}