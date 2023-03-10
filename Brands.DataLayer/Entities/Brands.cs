using System;
using System.Collections.Generic;
using System.Text;

namespace Brands.DataLayer.Entities
{
    public class Brands
    {

        public int BrandId { get; set; }
        public int UserId { get; set; }
        public string PersianBrandName { get; set; }
        public string EnglishBrandName { get; set; }
        public string BrandPicture { get; set; }
        public bool IsDelete { get; set; }
        #region Relation
        public User Users { get; set; }
        #endregion
    }
}
