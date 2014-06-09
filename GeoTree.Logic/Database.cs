using Db4objects.Db4o;
using GeoTree.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTree.Logic
{
    public class Database
    {
        private readonly IObjectContainer db;
        public readonly PersonService personService;

        public Database()
        {
            db = Db4oEmbedded.OpenFile(@"D:/baza/db"); //kontrol kropka only - alt + enter! only resharper!!!!1111oneoneone

            this.personService = new PersonService(db);
        }

        public IObjectContainer GetDatabaseInstance()
        {
            return db;
        }
    }
}
