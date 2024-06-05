using FootBall.Model;
using FootBall.Repository.Common;
using Npgsql;

namespace FootBall.Repository
{
    public class FootBallRepository : IFootballRepository
    {


        string connectionString = "Host = localhost; Port=5433;Database=FootballClub;Username=postgres;Password=mono";


        public string PostPlayer(FootBallPlayer player)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                var commandText = "INSERT INTO \"FootballPlayer\"VALUES(@id,@FirstName,@LastName,@Nationality,@Age,@ClubId);";
                using var command = new NpgsqlCommand(commandText, connection);


                command.Parameters.AddWithValue("@id", NpgsqlTypes.NpgsqlDbType.Uuid, Guid.NewGuid());
                command.Parameters.AddWithValue("@FirstName", player.FirstName);
                command.Parameters.AddWithValue("@LastName", player.LastName);
                command.Parameters.AddWithValue("@Nationality", player.Nationality);
                command.Parameters.AddWithValue("@Age", player.Age);
                command.Parameters.AddWithValue("@ClubId", player.ClubId ?? (object)DBNull.Value);


                connection.Open();

                var numberOfCommits = command.ExecuteNonQuery();

                if (numberOfCommits == 0)
                {
                    return "Not Found";
                       
                }
                return "Successfully added";

            }

            catch (Exception ex) {
                return (ex.Message);
            }
        }



        public string DeletePlayer(Guid id)
        {
            using var connection = new NpgsqlConnection(connectionString);
            var commandText = "DELETE FROM \"FootballPlayer\" WHERE \"Id\" = @Id;";
            using var command = new NpgsqlCommand(commandText, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return "Player deleted successfully";
            }
            else
            {
                return "Not Found"; 
            }
        }

        public List<FootBallPlayer> GetPlayer()
        {
            var footballPlayers = new List<FootBallPlayer>();
            try
            {
                

                using (var connection = new NpgsqlConnection(connectionString))
                using (var command = new NpgsqlCommand(@"SELECT fp.*, c.""Name"" AS ""ClubName"", c.""Country"" 
                                                FROM ""FootballPlayer"" fp
                                                INNER JOIN ""Club"" c ON fp.""ClubId"" = c.""Id"";", connection))
                {
                    connection.Open();
                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
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
                    }
                }
                return footballPlayers;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return footballPlayers;
        }

        public FootBallPlayer GetPlayerById(Guid id)
        {
            var footballPlayer = new FootBallPlayer();
            try
            {
                
                using var connection = new NpgsqlConnection(connectionString);
                var commandText = "SELECT * FROM \"FootballPlayer\" WHERE\"Id\" = @id;";
                using var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    
                    {
                        footballPlayer.Id = Guid.Parse(reader[0].ToString());
                        footballPlayer.FirstName = reader[1].ToString();
                        footballPlayer.LastName = reader[2].ToString();
                        footballPlayer.Nationality = reader[3].ToString();
                        footballPlayer.Age = reader[4] == DBNull.Value ? 0 : Convert.ToInt32(reader[4]);
                        footballPlayer.ClubId = reader[5] == DBNull.Value ? Guid.Empty : Guid.Parse(reader[5].ToString());

                    };

                }
                if (footballPlayer == null)
                {
                    Console.WriteLine("Player Not Found");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return footballPlayer;
        }

        public string DeletePlayer(FootBallPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
