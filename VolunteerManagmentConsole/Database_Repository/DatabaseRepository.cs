using Dapper;
using System.Data;
using System.Data.SqlClient;
using VolunteerManagmentConsole.Models;
using VolunteerManagmentLibrary.Models;

namespace VolunteerManagmentConsole.Database_Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;
        public DatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCandidate(VolunteerData volunteerData)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                // neveikia ID scalar lentelems (Id foreign keys null)
                //Candidate(name, surname, phoneNr, email, DOB)
                const string sql = @"INSERT INTO Candidates (Name, Surname, PhoneNr, Email, DateOfBirth, Age) VALUES (@Name, @Surname, @PhoneNr, @Email, @DateOfBirth, @Age); SELECT CAST(SCOPE_IDENTITY() as int);";
                const string sql1 = @"INSERT INTO Details (Comments, Allergies, CommentsORG) VALUES (@Comments, @Allergies, @CommentsORG);";
                const string sql2 = @"INSERT INTO Documents (ParentAGRStatus, ParentAGRDate, AGRStatus, AGRDate) VALUES (@ParentAGRStatus, @ParentAGRDate, @AGRStatus, @AGRDate);";
                const string sql3 = @"INSERT INTO Volunteers (GetParentAGR, GetAGR, Availability) VALUES (@ParentAGR, @AGR, @Available);";

                volunteerData.CandidateObj.ID = db.ExecuteScalar<int>(sql, volunteerData.CandidateObj);
                db.Execute(sql1, volunteerData.DetailsObj);
                db.Execute(sql2, volunteerData.DocumentsObj);
                db.Execute(sql3, volunteerData.VolunteerObj);
            }
        }

        public void AddVolunteerToTeam(VolunteerData volunteerData)
        {
            throw new NotImplementedException();
        }



        public void UpdateCandidate(VolunteerData volunteerData)
        {
            //System.Data.SqlClient.SqlException: 'Incorrect syntax near ')'.'
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"UPDATE Candidate SET Name = @Name, Surname = @Surname, PhoneNr = @PhoneNr, Email = @Email, DateOfBirth = @DateOfBirth WHERE ID = @ID);";
                db.Execute(sql, volunteerData.CandidateObj);
            }
        }
        public void UpdateDocuments(VolunteerData volunteerData)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"UPDATE Documents SET ParentAGRStatus = @ParentAGRStatus, AGRStatus = @AGRStatus WHERE ID = @ID)";
                db.Execute(sql, volunteerData.DocumentsObj);
            }
        }
        public void DeleteCandidate(VolunteerData volunteerData)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"DELETE FROM Volunteers WHERE ID = @ID;)";
                const string sql1 = @"DELETE FROM Documents WHERE ID = @ID)";
                const string sql2 = @"DELETE FROM Details WHERE ID = @ID)";
                const string sql3 = @"DELETE FROM Candidates WHERE ID = @ID)";
                db.Execute(sql, volunteerData.ID);
                db.Execute(sql1, volunteerData.ID);
                db.Execute(sql2, volunteerData.ID);
                db.Execute(sql3, volunteerData.ID);
            }
        }
    }
}
