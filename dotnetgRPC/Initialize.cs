using System.Collections.Generic;

namespace dotnetgRPC
{
    public static class Initialize
    {

        public static Dictionary<string,string> GetInfo()
        {
            var informations = new Dictionary<string, string>();
            informations.Add("10000", "90");
            informations.Add("10001", "80");
            informations.Add("10002", "70");
            informations.Add("10003", "60");
            return informations;
        }

    }
}
