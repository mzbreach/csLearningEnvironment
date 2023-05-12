using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csLearningEnvironment
{
    internal class user
    {
        public uint userID { set; get; }
        public string firstName { set; get; }
        public string lastName { set; get; }
        public string description { set; get; }
        public string role { set; get; }
        public string username { set; get; }
        private string password;

        public user()
        {
            userID = 0;
            firstName = string.Empty;
            lastName = string.Empty;
            description = string.Empty;
            role = string.Empty;
            username = string.Empty;
            password = string.Empty;

        }

        public user(uint id, string first, string last, string des, string rle, string user, string pass)
        {
            userID = id;
            firstName = first;
            lastName = last;
            description = des;
            role = rle;
            username = user;
            password = pass;
        }
    }
}
