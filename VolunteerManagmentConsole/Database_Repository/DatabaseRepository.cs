using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerManagmentLibrary.Models;

namespace VolunteerManagmentConsole.Database_Repository
{
    public class DatabaseRepository: IDatabaseRepository
    {
        private readonly string _connectionString;
        public DatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

    public void AddCandidate(Candidate candidate, Details details, Documents documents, Volunteer volunteer)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"INSERT INTO Candidates (Name, Surname, PhoneNr, Email, DateOfBirth, Age) VALUES (@Name, @Surname, @PhoneNr, @Email, @DateOfBirth, @Age);";
                const string sql1 = @"INSERT INTO Details (Comments, Allergies, CommentsORG) VALUES (@Comments, @Allergies, @CommentsORG); SELECT CAST(SCOPE_IDENTITY() as int);";
                const string sql2 = @"INSERT INTO Documents (ParentAGRStatus, ParentAGRDate, AGRStatus, AGRDate) VALUES (@ParentAGRStatus, @ParentAGRDate, @AGRStatus, @AGRDate); SELECT CAST(SCOPE_IDENTITY() as int);";
                const string sql3 = @"INSERT INTO Volunteers (GetParentAGR, GetAGR, Availability) VALUES (@ParentAGR, @AGR, @Available); SELECT CAST(SCOPE_IDENTITY() as int);";
                db.Execute(sql, candidate);
                db.Execute(sql1, details);
                details.ID = db.ExecuteScalar<int>(sql1, details);
                db.Execute(sql2, documents);
                documents.ID = db.ExecuteScalar<int>(sql2, documents);
                db.Execute(sql3, volunteer);
                volunteer.ID = db.ExecuteScalar<int>(sql3, volunteer);
            }
        }

        public void AddVolunteerToTeam(Volunteer volunteer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCandidate(Candidate candidate, Details details, Documents documents, Volunteer volunteer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCandidate(Candidate candidate, Details details, Documents documents, Volunteer volunteer)
        {
            throw new NotImplementedException();
        }

        public void UpdateDocuments(Documents documents)
        {
            throw new NotImplementedException();
        }
    }
}
