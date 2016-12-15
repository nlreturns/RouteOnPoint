using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOnPoint.LanguageUtil
{
    public class TestMultiLang
    {
        public TestMultiLang()
        {
            setUP();
        }

        private async void setUP()
        {
            await MultiLang.setLanguage(MultiLang.LanguageEnum.English);
            string name = MultiLang.GetContent("P_ANTONIUSVANPADUAKERK_NAME");
            string name2 = MultiLang.GetContent("P_BEGINHAVERMARKT_NAME");
            string name3 = MultiLang.GetContent("P_BEGIJNENHOF_NAME");
            string name4 = MultiLang.GetContent("P_KASTEELVANBREDA_INFO");
            string name5 = MultiLang.GetContent("ROUTESELECTIONVIEWMODEL_SELECTROUTE_TEXT");
            string name6 = MultiLang.GetContent("R_BLINDWALLS_NAME");
            string name7 = MultiLang.GetContent("P_DZIA_NAME");
            string name8 = MultiLang.GetContent("P_BENEINE_NAME");
        }

    }
}
