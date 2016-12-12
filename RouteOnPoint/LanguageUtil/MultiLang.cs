using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOnPoint.LanguageUtil
{
    public class MultiLang
    {
        private Dictionary<string, string> _Englisch;
        private Dictionary<string, string> _Dutch;

        public enum LanguageEnum { Englisch, Dutch};

        public LanguageEnum Language;

        public MultiLang()
        {

        } 

        
    }
}
