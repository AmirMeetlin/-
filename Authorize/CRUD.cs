using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Authorize
{
    class CRUD
    {
        
        public static void Create(string login, string password)
        {
            using (StreamWriter SW= new StreamWriter(@"C:\Users\Пользователь\Desktop\УУУ ОАиП\Данные.txt"))
            {
                SW.WriteLine(login+" "+ password);
            }    
        }
        
    }
}
