using System;
using System.Collections.Generic;
using System.Text;

namespace Brands.Core.Convertors
{
    public class FixedText
    {
        public static string FixText(string text)
        {
            return text.Trim().ToLower();
        }

    }
}
