using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class FixMessage
    {
        public static string Fix (string message)
        {
            message = message.Replace('<', ' ').Replace('>', ' ').Replace('&', ' ').Replace('*', ' ').Replace(':', ' ').Replace('?', ' ').Replace('%', ' ').Replace('?', ' ');
            return message;
        }
    }
}
