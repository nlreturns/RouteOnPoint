using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace RouteOnPoint.LanguageUtil
{
    public class MultiLang
    {
        private Dictionary<string, string> _Englisch;
        private Dictionary<string, string> _Dutch;

        public enum LanguageEnum { Englisch, Dutch};

        public LanguageEnum Language { get; set; }

        public MultiLang()
        {
            _Dutch = new Dictionary<string, string>();
            LoadHistorischeKilometerDutch();
        }

        //DUTCH
        private async void LoadHistorischeKilometerDutch()
        {
            string[] paths = new string[9];

            paths[0] = "Assets/Text/Dutch/AntoniusKerkInfo.txt";
            paths[1] = "Assets/Text/Dutch/bibliotheekInfo.txt";
            paths[2] = "Assets/Text/Dutch/kasteelInfo.txt";
            paths[3] = "Assets/Text/Dutch/kloosterKazerneInfo.txt";
            paths[4] = "Assets/Text/Dutch/NassauMonumentInfo.txt";
            paths[5] = "Assets/Text/Dutch/stadhuisInfo.txt";
            paths[6] = "Assets/Text/Dutch/TorenstraatInfo.txt";
            paths[7] = "Assets/Text/Dutch/valkenbergInfo.txt";
            paths[8] = "Assets/Text/Dutch/vishalInfo.txt";

            string[] names = new string[9];

            paths[0] = "P_ANTONIUSKERKINFO_INFO";
            paths[1] = "P_BIBLIOTHEEKINFO_INFO";
            paths[2] = "P_KASTEELINFO_INFO";
            paths[3] = "P_KLOOSTERKAZERNEINFO_INFO";
            paths[4] = "P_NASSAUMONUMENTINFO_INFO";
            paths[5] = "P_STADHUISINFO_INFO";
            paths[6] = "P_TORENSTRAATINFO_INFO";
            paths[7] = "P_VALKENBERGINFO_INFO";
            paths[8] = "P_VISHALINFO_INFO";
            _Dutch.Add("P_VISHALINFO_INFO", null);

            int position = 0;
            foreach (string path in paths)
            {
                string text = "";
                StorageFile file = await StorageFile.GetFileFromPathAsync(path);
                using (var inputStream = await file.OpenReadAsync())
                using (var classicStream = inputStream.AsStreamForRead())
                using (var streamReader = new StreamReader(classicStream))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        text = streamReader.ReadToEnd();
                    }
                }

                if (text != "")
                {
                    _Dutch.Add(names[position], text);
                }

                position++;
            }

            _Dutch.Add("R_HISTORISCHEKILOMTER_NAME", "Historische Kilometer");

            _Dutch.Add("P_VVV_NAME", "VVV");
            _Dutch.Add("P_LIEFDESZUSTER_NAME", "Liefdeszuster");
            _Dutch.Add("P_NASSABARONIEMONUMENT_NAME", "Nassau Baronie Monument");
            _Dutch.Add("P_THELIGHTHOUSE_NAME", "The Light House");
            _Dutch.Add("P_KASTEELVANBREDA_NAME", "Kasteel van Breda");
            _Dutch.Add("P_STADHOUDERSPOORT_NAME", "Stadhouderspoort");
            _Dutch.Add("P_HUISVANBRECHT_NAME", "Huis van Brecht");
            _Dutch.Add("P_SPANJAARDSGAT_NAME", "Spanjaardsgat");
            _Dutch.Add("P_BEGINVISMARKT_NAME", "Begin Vismarkt");
            _Dutch.Add("P_BEGINHAVERMARKT_NAME", "Begin Havermarkt");
            _Dutch.Add("P_GROTEKERK_NAME", "Grote Kerk");
            _Dutch.Add("P_HETPOORTJE_NAME", "Het Poortje");
            _Dutch.Add("P_RIDDERSTRAAT_NAME", "Ridderstraat");
            _Dutch.Add("P_GROTEMARKT_NAME", "Grote Markt");
            _Dutch.Add("P_BEVRIJDINGSMONUMENT_NAME", "Bevrijdingsmonument");
            _Dutch.Add("P_STADHUIS_NAME", "Stadhuis");
            _Dutch.Add("P_ANTONIUSVANPADUAKERK_NAME", "Antonius van Paduakerk");
            _Dutch.Add("P_BIBLIOTHEEK_NAME", "Bibliotheek");
            _Dutch.Add("P_KLOOSTERKAZERNE_NAME", "Kloosterkazerne");
            _Dutch.Add("P_CHASSETHEATER_NAME", "Chasse theater");
            _Dutch.Add("P_BINDINGVANISAAC_NAME", "Binding van Isaac");
            _Dutch.Add("P_BEYERD_NAME", "Beyerd");
            _Dutch.Add("P_GASTHUISPOORT_NAME", "Gasthuispoort");
            _Dutch.Add("P_WILLEMMERKXTUIN_NAME", "Willem Merkxtuin");
            _Dutch.Add("P_BEGIJNENHOF_NAME", "Begijnenhof");

            //Pagetext
            _Dutch.Add("ROUTESELECTIONVIEWMODEL_SELECTROUTE_TEXT", "Selecteer Route");

        }

        //ENGLISH
        private async void LoadHistorischeKilometerEnglish()
        {
            string[] paths = new string[9];

            paths[0] = "Assets/Text/English/AntoniusKerkInfo.txt";
            paths[1] = "Assets/Text/English/bibliotheekInfo.txt";
            paths[2] = "Assets/Text/English/kasteelInfo.txt";
            paths[3] = "Assets/Text/English/kloosterKazerneInfo.txt";
            paths[4] = "Assets/Text/English/NassauMonumentInfo.txt";
            paths[5] = "Assets/Text/English/stadhuisInfo.txt";
            paths[6] = "Assets/Text/English/TorenstraatInfo.txt";
            paths[7] = "Assets/Text/English/valkenbergInfo.txt";
            paths[8] = "Assets/Text/English/vishalInfo.txt";

            string[] names = new string[9];

            paths[0] = "P_ANTONIUSKERKINFO_INFO";
            paths[1] = "P_BIBLIOTHEEKINFO_INFO";
            paths[2] = "P_KASTEELINFO_INFO";
            paths[3] = "P_KLOOSTERKAZERNEINFO_INFO";
            paths[4] = "P_NASSAUMONUMENTINFO_INFO";
            paths[5] = "P_STADHUISINFO_INFO";
            paths[6] = "P_TORENSTRAATINFO_INFO";
            paths[7] = "P_VALKENBERGINFO_INFO";
            paths[8] = "P_VISHALINFO_INFO";
            _Dutch.Add("P_VISHALINFO_INFO", null);

            int position = 0;
            foreach (string path in paths)
            {
                string text = "";
                StorageFile file = await StorageFile.GetFileFromPathAsync(path);
                using (var inputStream = await file.OpenReadAsync())
                using (var classicStream = inputStream.AsStreamForRead())
                using (var streamReader = new StreamReader(classicStream))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        text = streamReader.ReadToEnd();
                    }
                }

                if (text != "")
                {
                    _Dutch.Add(names[position], text);
                }

                position++;
            }

            _Dutch.Add("R_HISTORISCHEKILOMTER_NAME", "Historic kilometer");

            _Dutch.Add("P_VVV_NAME", "VVV");
            _Dutch.Add("P_LIEFDESZUSTER_NAME", "Liefdeszuster");
            _Dutch.Add("P_NASSABARONIEMONUMENT_NAME", "Nassau Baronie Monument");
            _Dutch.Add("P_THELIGHTHOUSE_NAME", "The Light House");
            _Dutch.Add("P_KASTEELVANBREDA_NAME", "Kasteel van Breda");
            _Dutch.Add("P_STADHOUDERSPOORT_NAME", "Stadhouderspoort");
            _Dutch.Add("P_HUISVANBRECHT_NAME", "Huis van Brecht");
            _Dutch.Add("P_SPANJAARDSGAT_NAME", "Spanjaardsgat");
            _Dutch.Add("P_BEGINVISMARKT_NAME", "Begin Vismarkt");
            _Dutch.Add("P_BEGINHAVERMARKT_NAME", "Begin Havermarkt");
            _Dutch.Add("P_GROTEKERK_NAME", "Grote Kerk");
            _Dutch.Add("P_HETPOORTJE_NAME", "Het Poortje");
            _Dutch.Add("P_RIDDERSTRAAT_NAME", "Ridderstraat");
            _Dutch.Add("P_GROTEMARKT_NAME", "Grote Markt");
            _Dutch.Add("P_BEVRIJDINGSMONUMENT_NAME", "Bevrijdingsmonument");
            _Dutch.Add("P_STADHUIS_NAME", "Stadhuis");
            _Dutch.Add("P_ANTONIUSVANPADUAKERK_NAME", "Antonius van Paduakerk");
            _Dutch.Add("P_BIBLIOTHEEK_NAME", "Bibliotheek");
            _Dutch.Add("P_KLOOSTERKAZERNE_NAME", "Kloosterkazerne");
            _Dutch.Add("P_CHASSETHEATER_NAME", "Chasse theater");
            _Dutch.Add("P_BINDINGVANISAAC_NAME", "Binding van Isaac");
            _Dutch.Add("P_BEYERD_NAME", "Beyerd");
            _Dutch.Add("P_GASTHUISPOORT_NAME", "Gasthuispoort");
            _Dutch.Add("P_WILLEMMERKXTUIN_NAME", "Willem Merkxtuin");
            _Dutch.Add("P_BEGIJNENHOF_NAME", "Begijnenhof");


        }


    }
}
