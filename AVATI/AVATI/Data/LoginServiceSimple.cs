﻿namespace AVATI.Data
{
    public class LoginServiceSimple : ILoginService
    {
        public bool LogIn(string username, string password)
        {
            if (username == "Max Mustermann" && password == "123456")
            {
                return true;
            }
            else return false;
        }
         
    }
}