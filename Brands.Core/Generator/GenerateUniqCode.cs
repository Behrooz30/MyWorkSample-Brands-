using System;
using System.Collections.Generic;
using System.Text;

namespace Brands.Core.Generator
{
    public class GenerateUniqCode
    {
        public static string GenerateTheUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

    }
}
