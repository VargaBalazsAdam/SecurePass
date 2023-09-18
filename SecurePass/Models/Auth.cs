using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Models
{
  public class Auth
  {
    public int id { get; set; }
    public string name { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    public string email { get; set; }

    //these are lists, but i was lazy to create a database with 2 table and relations,
    //so i decided to separate the items with ";"
    public string accessableWithService { get; set; }
    public string accessableWithDataType { get; set; }
    public string accessableWithDataValue { get; set; }
    ///////////////////////////////////////////////////
    
    public string link { get; set; }
  }
}
