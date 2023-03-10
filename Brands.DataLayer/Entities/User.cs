using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Brands.DataLayer.Entities
{
    public class User
    {
        public User()
        {

        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        #region
        public virtual List<Brands> Brands { get; set; }
        #endregion

    }
}
