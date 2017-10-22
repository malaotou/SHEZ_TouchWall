using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEZ_TouchWall.Helper
{

    public class MongoHelper
    {
        MongoClient mongo = new MongoClient("mongodb://localhost");
        MongoServer server;
        MongoDatabase database;
        //MongoCollection<info> _infos;


        public MongoHelper()
        {
            server = mongo.GetServer();
            server.Connect();
            database = server.GetDatabase("shezdb");
        }
        public MongoDatabase genClent()
        {
            return this.database;
        }

    }
}
