using SQLite;
using ReactAPIMobile.Models;


namespace ReactAPIMobile.DataAccess
{
    public class PersonData
    {
        SQLiteConnection database;

        public void Init()
        {
            if (database is not null)
            {
                return;
            }
            database = new SQLiteConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            database.CreateTable<Person>();
        }
        public List<Person> GetPeople()
        {
            Init();
            return database.Table<Person>().ToList();
        }
        public int SavePerson(ReactAPIMobile.Models.Person person)
        {
            Init();
            if (person.ID != 0)
            {
                // Update an existing person
                return database.Update(person);
            }
            else
            {
                // Save a new person
                return database.Insert(person);
            }
        }
    }
}