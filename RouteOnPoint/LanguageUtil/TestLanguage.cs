using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOnPoint.LanguageUtil
{
    public class TestLanguage
    {
        public TestLanguage()
        {
            MultiLang ml = new MultiLang();
            MultiLang.Language = MultiLang.LanguageEnum.Dutch;
            string antwoord = MultiLang.GetContent("P_BEGIJNENHOF_NAME");
        }
    }
}
