using System;
using System.Collections.Generic;
using System.Text;

namespace Virtum.Utils
{
    class Utilitarios
    {
        public static bool VerificarEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress endereco = new System.Net.Mail.MailAddress(email);
                return endereco.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
