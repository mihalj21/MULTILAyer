using FootBall.Model;
using FootBall.Repository.Common;
using Npgsql;
using System.Text;
using FootBall.Common;

namespace FootBall.Repository
{
    public class FootBallRepository : IFootballRepository
    {


        string connectionString = "Host = localhost; Port=5433;Database=FootballClub;Username=postgres;Password=mono";


        public async Task  PostPlayer(FootBallPlayer player)
        {
           
                 await using var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();

                var commandText = "INSERT INTO \"FootballPlayer\"VALUES(@id,@FirstName,@LastName,@Nationality,@Age,@ClubId);";
                 await using var command = new NpgsqlCommand(commandText, connection);


                command.Parameters.AddWithValue("@id", NpgsqlTypes.NpgsqlDbType.Uuid, Guid.NewGuid());
                command.Parameters.AddWithValue("@FirstName", player.FirstName);
                command.Parameters.AddWithValue("@LastName", player.LastName);
                command.Parameters.AddWithValue("@Nationality", player.Nationality);
                command.Parameters.AddWithValue("@Age", player.Age);
                command.Parameters.AddWithValue("@ClubId", player.ClubId ?? (object)DBNull.Value);


               
                await command.ExecuteNonQueryAsync();
             
        }



        public async Task DeletePlayer(Guid id)
        {
           await  using var connection = new NpgsqlConnection(connectionString);
            var commandText = "DELETE FROM \"FootballPlayer\" WHERE \"Id\" = @Id;";
             await using var command = new NpgsqlCommand(commandText, connection);
            command.Parameters.AddWithValue("@Id", id);

             await connection.OpenAsync();
             await command.ExecuteNonQueryAsync();

            
        }

        public async Task<IEnumerable<FootBallPlayer>> GetPlayer()
        {
            var footballPlayers = new List<FootBallPlayer>();



            await using var connection = new NpgsqlConnection(connectionString);
            await using var command = new NpgsqlCommand(@"SELECT fp.*, c.""Name"" AS ""ClubName"", c.""Country"" 
                                                FROM ""FootballPlayer"" fp
                                                INNER JOIN ""Club"" c ON fp.""ClubId"" = c.""Id"";", connection);
               
                     await connection.OpenAsync();

                    await using var reader =  await command.ExecuteReaderAsync();
                    
                        while (await reader.ReadAsync())
                        {
                            var footballPlayer= new FootBallPlayer();
                            {
                                footballPlayer.Id = Guid.Parse(reader[0].ToString());
                                footballPlayer.FirstName = reader[1].ToString();
                                footballPlayer.LastName = reader[2].ToString();
                                footballPlayer.Nationality = reader[3].ToString();
                                footballPlayer.Age = reader[4] == DBNull.Value ? 0 : Convert.ToInt32(reader[4]);
                                footballPlayer.ClubId = Guid.Parse(reader["ClubId"].ToString());
                                
                            };

                            footballPlayers.Add(footballPlayer);
                        }
                    return footballPlayers;
                
                
              
        }

        public async Task<FootBallPlayer> GetPlayerById(Guid id)
        {
            var footballPlayer = new FootBallPlayer();
           
                
                 await using var connection = new NpgsqlConnection(connectionString);
                  var commandText = "SELECT * FROM \"FootballPlayer\" WHERE\"Id\" = @id;";
                await using var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@id", id);

               await  connection.OpenAsync();

                 await using var reader = await  command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();

                      return new FootBallPlayer
                    {
                        Id = Guid.Parse(reader[0].ToString()),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        Nationality = reader[3].ToString(),
                        Age = reader[4] == DBNull.Value ? 0 : Convert.ToInt32(reader[4]),
                        ClubId = reader[5] == DBNull.Value ? Guid.Empty : Guid.Parse(reader[5].ToString()),

                    };

                }

            return null;
            
           
           
        }
        public async Task<IList<FootBallPlayer>> GetAllAsync(GetPlayer getPlayer)
        {
            NpgsqlConnection _connection = new NpgsqlConnection(connectionString);
            IList<FootBallPlayer> players = new List<FootBallPlayer>();
            NpgsqlCommand command = new NpgsqlCommand("", _connection);
            command = MakeCommand(getPlayer, command);
            _connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (await reader.ReadAsync())
                {
                    FootBallPlayer footBallPlayer = new FootBallPlayer();
                    footBallPlayer.Id = reader.GetGuid(reader.GetOrdinal("Id"));
                    footBallPlayer.FirstName = reader.GetString(reader.GetOrdinal("firstName"));
                    footBallPlayer.LastName = reader.GetString(reader.GetOrdinal("lastName"));
                    
                    players.Add(footBallPlayer);
                }
            }
            _connection.Close();
            return players;
        }
        private NpgsqlCommand MakeCommand(GetPlayer getPlayer, NpgsqlCommand command)
        {
            StringBuilder builder = new StringBuilder();
         builder.Append("SELECT * FROM \"FootballPlayer\" WHERE 1=1");
            

            if (getPlayer.filter.FirstName != null) {

                builder.Append(" AND \"FirstName\" LIKE  @Firstname");
                command.Parameters.AddWithValue("@FirstName", $"%{getPlayer.filter.FirstName}%");
            }
            builder.Append($" ORDER BY \"{getPlayer.sort.SortBy}\" {getPlayer.sort.SortOrder}");
            command.CommandText = builder.ToString();
            return command;

        }

    }
}
