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
        private static Dictionary<string, string> _English;
        private static Dictionary<string, string> _Dutch;

        public enum LanguageEnum { Englisch, Dutch};

        public static LanguageEnum Language { get; set; }

        private bool load = false;

        public MultiLang()
        {
            _Dutch = new Dictionary<string, string>();
            LoadHistorischeKilometerDutch();
            LoadBlindWallsDutch();
            _English = new Dictionary<string, string>();
            LoadHistorischeKilometerEnglish();
        }

        public static string GetContent(string key)
        {

            string value = "";

            if (Language == LanguageEnum.Dutch)
            {
                bool hh = _Dutch.ContainsKey(key);
                _Dutch.TryGetValue(key, out value);
            }

            if (Language == LanguageEnum.Englisch)
            {
                _English.TryGetValue(key, out value);
            }

            return value;
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

            names[0] = "P_ANTONIUSKERKINFO_INFO";
            names[1] = "P_BIBLIOTHEEKINFO_INFO";
            names[2] = "P_KASTEELINFO_INFO";
            names[3] = "P_KLOOSTERKAZERNEINFO_INFO";
            names[4] = "P_NASSAUMONUMENTINFO_INFO";
            names[5] = "P_STADHUISINFO_INFO";
            names[6] = "P_TORENSTRAATINFO_INFO";
            names[7] = "P_VALKENBERGINFO_INFO";
            names[8] = "P_VISHALINFO_INFO";

            int position = 0;
            foreach (string path in paths)
            {
                string text = "";
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///"+path));
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


        private void LoadBlindWallsDutch()
        {
            _Dutch.Add("P_ZENKONEGODEVAERT_NAME", "Zenk One Godevaert");
            _Dutch.Add("P_ZENKONEGODEVAERT_INFO", "Robin Nas aka Zenkone groeit op in creatieve familie en start op jonge leeftijd met graffiti. Hij raakt bekend om zijn realistische portretten die hij later mixt met een meer grafische stijl. Inmiddels reist hij de wereld over om metershoge muurschilderingen te maken in zijn kenmerkte stijl. Vanuit zijn studio in Breda werkt hij als illustrator voor internationale opdrachtgevers.\r\n\r\nDe muurschildering is een ode aan Godevaart Montens, burgemeester van Breda van 1580-1581 en 1596-1602. Hij staat bekend vanwege zijn vermeend heldhaftig gedrag op 28 juni 1581. Tijdens de furie van Houtepen voerde hij een groep Bredase burgersoldaten aan in de strijd tegen de Spaanse troepen. Deze troepen hebben hevig huisgehouden, geplunderd, gemoord en gebrandschat. Vrijwilligers moesten de stoffelijke overschotten van 400 à 500 dode burgers opruimen.");
            _Dutch.Add("P_STAYNICELUNETTUNNEL_NAME", "Staynice Lunettunnel");
            _Dutch.Add("P_STAYNICELUNETTUNNEL_INFO", "De broers Rob (1973) en Barry (1977) van Dijck vormen samen de grafisch ontwerp studio Staynice. Vanuit hun interesse voor graffiti startten ze de opleiding Graphic Design aan AKV|St.Joost. In 2006 gaf de nominatie voor de St.Joost-penning toegang tot een gastatelier. Hier smeedden ze plannen om een eigen studio te starten.\r\n\r\nIn tien jaar tijd groeiden ze uit tot een gerenommeerde studio. Hun werk kenmerkt zich door het op speelse wijze combineren van informatie, illustratie en typografie. Experimenten op hun eigen Riso printer dienen vaak als inspiratie voor commerciële projecten voor internationale klanten. Toch blijven ze trouw aan hun roots en nemen regelmatig de spuitbus ter hand voor muurschilderingen.\r\n\r\nVoor de Blind Walls Gallery maakten ze de langste muurschildering tot nu toe. De ruim 130m zoete vormen zijn geïnspireerd op de (deels verdwenen) suikerwaren industrie in Breda. Als de wind de juiste kant op waait, voegt de Perfetti Van Melle fabriek een geurige dimensie aan de schildering toe.");
            _Dutch.Add("P_JUKKAHAKANEN_NAME", "Jukka Hakanen");
            _Dutch.Add("P_JUKKAHAKANEN_INFO", "Al sinds jonge leeftijd zijn tekenen en schilderen natuurlijke expressievormen voor Jukka Hakanen. Opgroeiend in Turku (FI) raakte hij geïnteresseerd in graffiti. Sinds 2000 maakte hij vele muurschilderingen in Finland en het buitenland.\r\n\r\nDeze muurschildering is een hedendaagse versie van het klassieke stilleven. De inspiratie kwam uit de omliggende restaurants, de lange geschiedenis van het pand en de beroemde moerbeiboom (geplant in 1780) in de tuin van de Nieuwe Veste.");
            _Dutch.Add("P_MAIKKIRANTALA_NAME", "Maikki Rantala");
            _Dutch.Add("P_MAIKKIRANTALA_INFO", "Maikki Rantala mixt sinds 2012 ‘community art’ en street art tot participatie projecten op grote schaal. Zij ziet street art als een vorm van stedelijk activisme, waarmee uitdagingen rondom verstedelijking aangepakt kunnen worden. Met haar muurschilderingen richt ze zich vaak op kinderen, omdat ze veel beter hun omgeving observeren dan volwassenen.\r\n\r\nDit historische miniatuur huisje met bakstenen gevels en vele hoeken is een echte uitdaging om te beschilderen. Het verhaal van deze muurschildering gaat terug tot de 19e eeuwse horeca school gevestigd op dit terrein. Ze refereert hieraan met een verscheidenheid aan picturaal serviesgoed in traditioneel Nederlandse, Spaanse, Italiaanse, Chinese, Arabische en zelfs de Finse stijl.");
            _Dutch.Add("P_DZIA_NAME", "DZIA");
            _Dutch.Add("P_DZIA_INFO", "De Liniestraat vormt de buitengrens van het Liniekwartier. Op het verzoek van de bewoners is de wijk niet gesloopt, maar herontwikkeld door AlleeWonen in samenwerking met de bewoners. Er zijn klushuizen, een wijksalon en diverse culturele evenementen in samenwerking met Electron.\r\n\r\nBelgische kunstenaar DZIA is uitgenodigd om het creatieve karakter van de wijk te visualiseren. Zijn echte naam blijft onbekend, ook is hij niet herkenbaar op foto's. Hij kiest ervoor zijn werk te laten spreken. Al jaren schildert hij dieren in zijn karakteristieke stijl op muren over de hele wereld.\r\n\r\nDe flamingo verbeeldt het kleurrijke karakter van de wijk. Vroeger was dit gebied een ​​polder waar veel vogels broedden. Tijdens het aanbrengen van de witte onderschildering kreeg DZIA al veel reacties uit de buurt. Men vond zijn 'zwaan' te gek! Na de toekan was de inspiratie voor de laatste vogel snel gevonden. Samen verbeelden de drie vogels het creatieve, kleurrijke en diverse karakter van de wijk, met een kleine knipoog naar het verleden.");
            _Dutch.Add("P_DAMIENPOULAINVANCOOTHPLEIN_NAME", "Damien Poulain Van Coothplein");
            _Dutch.Add("P_DAMIENPOULAINVANCOOTHPLEIN_INFO", "Damien Poulain is een grafisch ontwerper en illustrator met een specifieke focus op kunst, mode en muziek. Hij publiceert ook fotoboeken onder de naam oodee. Na het beschilderen van rolluiken in Tokyo, Parijs en Londen nodigde de Blind Walls Gallery Damien uit Breda te bezoeken. Ondanks dat het de warmste dag van het jaar was, schilderde Damien vier prachtige 'happy shutters'.");
            _Dutch.Add("P_DAMIENPOULAINBOSCHSTRAAT_NAME", "Damien Poulain Boschstraat");
            _Dutch.Add("P_DAMIENPOULAINBOSCHSTRAAT_INFO", "Damien Poulain is een grafisch ontwerper en illustrator met een specifieke focus op kunst, mode en muziek. Hij publiceert ook fotoboeken onder de naam oodee. Na het beschilderen van rolluiken in Tokyo, Parijs en Londen nodigde de Blind Walls Gallery Damien uit Breda te bezoeken. Ondanks dat het de warmste dag van het jaar was, schilderde Damien vier prachtige 'happy shutters'.");
            _Dutch.Add("P_HELL'O_NAME", "Hell'O");
            _Dutch.Add("P_HELL'O_INFO", "Het Brusselse duo Hell’O beheerst de grafische lijn als een 21-ste eeuwse Jherimus Bosch. Hun universum lijkt een surrealistisch bestiarium met mysterieuze dieren, hybride personages, architectuur en badass geometrie. Hun schilderingen en sculpturen verwijzen naar middeleeuwse folklore, esoterie, techno muziek, de Memphis Design Group, 17e-eeuwse gravure, oude mythologie, surrealisme, ... In verhalende scènes, die soms betekenisrijk, dan weer gewoon absurd zijn, geven humor en spot ruimte voor eigen interpretatie door de kijker.\r\n\r\nVoor de muurschildering in de Bleekstraat lieten ze zich inspireren door het uitzicht op winkelend publiek vanuit de Bleekstraat op de Ginnekenstraat. De straatnaam is letterlijk geïnterpreteerd en laat de hybride personages langzaam aan vervagen.");
            _Dutch.Add("P_KRATJEBEELD_NAME", "Kratje Beeld");
            _Dutch.Add("P_KRATJEBEELD_INFO", "Studio Kratje Beeld is een tijdelijke ontwerpstudio gevormd door tien derdejaarsstudenten Illustratie van AKV|St.Joost. In hun stageperiode werken ze aan opdrachten voor verschillende opdrachtgevers waaronder de 3sec.gallery. Voor de meeste studenten is het de eerste keer dat ze op deze schaal werken. De muurschildering is dan ook grondig voorbereid met schetsen, kleurstudies en research in het Stadsarchief Breda.");
            _Dutch.Add("P_NOL_NAME", "NOL");
            _Dutch.Add("P_NOL_INFO", "Vermoedelijk heeft vroeger, in het witte vlak, op de gevel van dit monument een reclame schildering gestaan. Onderzoek in het stadsarchief leverde geen aanwijzingen op over welke reclame hier wanneer heeft gestaan. Ook navraag bij de buren Meeuwsen Aquaria -al meer dan 35 jaar hier gevestigd- leverde geen informatie op. Het pand heeft de afgelopen decennia gefunctioneerd als bakkerij, sigarenwinkel en smartshop. Vanaf eind jaren ’90 is het een woonhuis. Recentelijk is het volledig gerestaureerd. Tot die tijd woonde kunstenaar Michael Nolta in het pand. In de ruimte op de begane grond was zijn studio gevestigd. De huidige raamdecoratie is een overblijfsel uit die tijd. Onder het pseudoniem NOL maakt hij wereldwijd muurschilderingen waarin blauwe wezens de hoofdrol spelen. Het lag dan ook voor de hand om NOL te vragen deze muurschildering te maken.");
            _Dutch.Add("P_THUNDER&BOLD_NAME", "Thunder & Bold");
            _Dutch.Add("P_THUNDER&BOLD_INFO", "De nieuwe eigenaar en gebruiker van de oude kleuterschool in het Burgemeester van Sonsbeek Park vroegen ons een muurschildering te realiseren op dit fraaie paviljoen. Sinds kort wordt het doordeweeks gebruikt als crèche en is het in het weekend een koffiehuis.\r\n\r\nHet Burgemeester van Sonsbeek Park wordt door betrokken buurtbewoners onderhouden. Ze houden het park schoon, planten bloembollen en maakten zelfs speeltoestellen voor de kinderen van afvalmateriaal. We vroegen ontwerpers Thunder&amp;Bold het bijzondere karakter van dit park weer te geven in de muurschildering.\r\n\r\nThunder&amp;Bold (aka Martijn van der Meeren en Emiel Jonkers) gingen op bezoek in het park en vonden inspiratie. Terwijl ze in het park waren fluisterde Jimmy Hendrix in hun oor....\r\n\r\n Rainy day, dream away\r\nAh let the sun take a holiday\r\nFlowers bathe an' ah see the children play\r\nLay back and groove on a rainy day.");
            _Dutch.Add("P_BENEINE_NAME", "Ben Eine");
            _Dutch.Add("P_BENEINE_INFO", "Deze spooronderdoorgang verbindt het centrum van de stad en de wijk Belcrum, bekend om zijn woonwijk en voormalige industrie. De rivier de Mark loopt onder de onderdoorgang en laat kleine boten toe tot de passantenhaven in de binnenstad. Aan de zijde van de Belcrumweg zijn er doorgangen voor auto’s, fietsers en voetgangers. Hier passeren elke dag duizenden mensen op hun weg naar de stad. Aan de andere zijde ligt de Markkade. Deze kade is tegenwoordig veel minder druk, de fabrieken de hier aan lagen zijn inmiddels verdwenen. In 1776 was dit nog poldergebied en de thuisbasis voor tal van vogels. In 1855 werd het eerste treinstation gebouwd in de buurt van de Markkade. De spoorweg en de rivier maakten het gebied een hotspot tijdens de industriële revolutie. Vanaf toen tot aan de late jaren ’90 stonden hier veel roemruchte fabrieken, zoals Kwatta, MOMO, Centrale Suiker Maatschappij, Etna, Electron, Backer & Rueb en Hollandse Kunstzijde Industrie. Toen de spoorlijn in 1862 naar Tilburg werd uitgebreid, werd een brug over de rivier de Mark aangelegd.In de jaren ’20 is de polder naast de spoorlijn omgebouwd to woonwijk waar arbeiders dichtbij hun fabrieken konden wonen.De straten werden vernoemd naar de vogels die weggejaagd werden door deze expansie.In de jaren daarna bleven zowel de stad als het spoorgebruik groeien.In 1972 werd de huidige brug gebouwd. In de twintigste eeuw vormde het spoor een scheiding tussen het ‘rijke’ centrum en de ‘arbeidersklasse’ in het noorden. De afgelopen jaren transformeerde Belcrum in een hotspot. Jonge gezinnen wonen nu naast de theaters, tentoonstellingsruimten, ateliers, skatehal en zelfs een strand. Het nieuwe station (opening september 2016) heeft twee ingangen; stads- en noordzijde zijn gelijk geworden. Om dit te vieren is de beroemde kunstenaar Ben Eine(Londen, 1970) uitgenodigd om te werken aan aan de onderdoorgang.Eine ziet een duidelijk onderscheid tussen graffiti en street art.Naar zijn mening maakt graffiti de stad lelijk, terwijl street art zorgt voor verfraaiing.Hij spreekt uit ervaring, want in zijn jonge jaren tagde hij op treinen en muren. Op een gegeven moment zag Eine dat graffiti te veel op elkaar ging lijken en daardoor relevantie miste.Hij wilde iets anders te doen en besloot zich te verdiepen in zijn passie voor letters. De typografische werken van Eine zijn te zien in wereldsteden als Tokyo, New York, Los Angeles en Berlijn. Voor zijn muurschildering in Breda haalde hij inspiratie uit de verdwenen industrie. Niet door te verwijzen naar de geschiedenis, de woorden “meaningful”, “imagineer”, “mesmerising”, “storytelling” vieren de huidige en toekomstige industrie van Breda. De stad staat bekend als ‘City of Imagineers’ een thuisbasis voor vele educatieve, culturele en commerciële instellingen in de creatieve industrie.");
            _Dutch.Add("P_NOODLEINC_NAME", "Noodle Inc.");
            _Dutch.Add("P_NOODLEINC_INFO", "Het duo Noodle inc bestaat uit de vrienden Michael Nolta en Edo Rath. Hun doorgaans kleurige en altijd vrolijke werk kenmerkt zich door strakke lijnen en steeds terugkerende figuren.\r\n\r\nOp uitnodiging van Koffie bij Teun maakten ze in twee nachten tijd een zwart witte muurschildering met de titel \"Koffie verkeerd\". Je ziet het verhaal van twee betoverde koffielepeltjes die een reis maken door een fluffy landschap met opgeblazen muffins, blije koffiekopjes, dansende donuts, euforische theezakjes, stralende suikerstrooiers en zichzelf regulerende koffiemalers.");
            _Dutch.Add("P_LUCAFONT_NAME", "Luca Font");
            _Dutch.Add("P_LUCAFONT_INFO", "De dag voor Luca Font aakwam in Breda overleed rockster David Bowie. Dit schilderij herdenkt de iconische kunstenaar.");
            _Dutch.Add("P_COMBATSUPERMURAL_NAME", "Combat Super Mural");
            _Dutch.Add("P_HEDOFOASE_NAME", "Hedof Oase");
            _Dutch.Add("P_ZENKONE2012_NAME", "Zenk One 2012");
            _Dutch.Add("P_STAYNICEKOP_NAME", "Staynice KOP");
            _Dutch.Add("P_STAYNICEBLOOS_NAME", "Staynice Bloos");
            _Dutch.Add("P_ZENKONEVEILINGKADE_NAME", "Zenk One Veilingkade");
            _Dutch.Add("P_SUPERA_NAME", "Super A");
            _Dutch.Add("P_FINDAC_NAME", "Fin Dac");
            _Dutch.Add("P_FINDAC_INFO", "Samen met Nol Art en Edo Rath maakte Fin DAC deze Geisha muurschildering ‘Kokesh’ op de muur van een (eveneens Japans) sushi restaurant. DAC maakte deze als toevoeging op zijn ‘Hidden Beauty’ serie. Het kleurpalet, met veel rood en wit, sluit aan bij de Bredase stadsvlag. Fin DAC (Londen) werd ondanks zijn relatief jonge street art carrière bekend door zijn opvallende en dramatische XXL portretten (vooral van Geishas). Aan zijn stencilwerk voegt hij uit de losse hand details toe.");
            _Dutch.Add("P_JEFFCANHAM_NAME", "Jeff Canham");
            _Dutch.Add("P_JEFFCANHAM_INFO", "In zijn schildering nam Canham de eerste negen woorden van het NATO fonetische alfabet op. Het gebruik ervan tijdens o.a. WWII verwijst naar het militaire verleden van Achter de Lange Stallen. Vanaf 1765 tot 1980 was het terrein onderdeel van de Chassékazerne, waar tijdens WWII Kriegs­marine-opleidingseenheden gevestigd waren. Jeff Canham is een sign painter uit San Francisco, bekend om zijn handgeschilderde typografische reclameborden en winkelruiten. Zijn unieke werkwijze krijgt aandacht in de documentaire ‘Sign Painters’.");
            _Dutch.Add("P_RUTGERTERMOHLEN_NAME", "RUTGER TERMOHLEN, COLLIN VAN DER SLUIJS & SUPER A");
            _Dutch.Add("P_RUTGERTERMOHLEN_INFO", "Deze muurschildering is geinspireerd op het duistere verleden van deze plek. De Mols Parking was ooit (rond 1514) een begraafplaats voor mensen die stierven aan de pest. De rat ­ de ziekteverspreider ­ symboliseert dit. Bredase kunstenaar Rutger Termohlen schildert mensen, dieren en een combinatie ervan. Altijd dynamisch en contrastrijk in kleur en thema: van liefde tot dood, van licht totduisternis. Van der Sluijs voegde dromerige details toe, Super A maakt veelal portretten van dier en mens.");
            _Dutch.Add("P_JOBWOUTERS_NAME", "JOB WOUTERS");
            _Dutch.Add("P_JOBWOUTERS_INFO", "De veelkleurigheid en grillige vormen van deze muurschildering verwijzen naar het roerige verleden van de plek waar Wouters het werk maakte. Van kapel in de vijftiende eeuw tot begraafplaats in de zestiende eeuw, groentetuin in de negentiende eeuw en kazerne in de twintigste eeuw. Job Wouters (Letman) is een Amsterdamse letterontwerper. Als ‘lettergek’ schuwt hij traditionele technieken als kalligrafie zeker niet! Gewapend met zijn ‘spuitbusmachine’ maakt hij unieke letterkunstwerken.");
            _Dutch.Add("P_MIKEPERRY_NAME", "Mike Perry");
            _Dutch.Add("P_MIKEPERRY_INFO", "Dat de muurschildering van Perry is opgebouwd uit diverse lagen zie je als toeschouwer niet direct. Het verwijst naar het verborgen ontwerpproces én de gelaagdheid van de Bredase geschiedenis. In zijn werk is een Bredaas palindroom gedicht verwerkt, bestaande uit woorden die je vanaf beide kanten hetzelfde leest. Mike Perry is een kunstenaar en ontwerper die tekent, schil- dert, illustreert, animeert, knipt, plakt en bouwt. Hij werkt met verschillende media en woont en werkt in New York City.");
            _Dutch.Add("P_STEPHENPOWERS_NAME", "Stephen Powers");
            _Dutch.Add("P_STEPHENPOWERS_INFO", "Gesprekken met bewoners en passanten verwerkte Powers in zijn muurschildering, als liefdesbrief aan de stad. Dit deed hij tijdens de eerste Koningsdag, met Oranjegekte ten top. Koninginnedag mag dan geschiedenis zijn, volgens Powers is het elke dag ‘Queensday’ met een dagelijkse ode aan alle vrouwen. New Yorkse kunstenaar Steve ‘ESPO’ Powers begeeft zich met zijn graffiti vaak op de grens tussen legaal en illegaal. Zijn schilderingen zijn vaak een liefdesverklaring in lokale context.");
            _Dutch.Add("P_HEDOF_NAME", "Hedof");
            _Dutch.Add("P_HEDOF_INFO", "Deze schildering verwijst naar zowel het heden als verleden van de locatie. Opnieuw ‘groeit’ er groenten en fruit op de plek waar begin negentiende eeuw een grote groentetuin was. De winkelende figuren in de schildering zijn op doortocht naar de nabij­ gelegen winkelstraat. Hedof is Rick Berkelmans, een illustrator uit Breda. Een mix van sterke vormen, cartooneske figuren en een uitgesproken kleurpalet typeert zijn werk.");
            _Dutch.Add("P_JOHANMOORMAN_NAME", "Johan Moorman");
            _Dutch.Add("P_JOHANMOORMAN_INFO", "De muurschildering is geïnspireerd op een gebeurtenis uit 1988 toen twee rivaliserende circussen gelijktijdig Breda aandeden. Ter promotie liet een van de circussen olifanten uit op de Mols Parking. Naar aanleiding van de actie kregen beiden gedurende 5 jaar een verbod tot op treden in de stad. Johan Moorman uit Eindhoven is bekend als grafisch ontwerper onder de naam Spielerei. Naast werk in opdracht maakt hij grote muurschilderingen in de openbare ruimte.");
            _Dutch.Add("P_BRUCETMC_NAME", "Bruce TMC");
            _Dutch.Add("P_BRUCETMC_INFO", "“If wishes were horses, beggars would ride” is een Engels gezegde dat suggereert dat het nutteloos is om te wensen en dat verbetering bereikt wordt door actie. In dit werk is “beggars” (bedelaars) vervangen voor “refugees” (vluchtelingen), mogelijk een verwijzing naar de huidige vluchtelingenproblematiek. Het vers­ je verwijst ook naar de paardenstal die hier ooit stond. Bruce Tsai-Meu-Chong (TMC) is een Rotterdamse illustrator en signpainter. Zijn werk varieert van menu’s en winkelruiten tot grote muurschilderingen. Soms met een boodschap, altijd handgemaakt.");
            _Dutch.Add("P_THOMAS&JURGEN_NAME", "Thomas & Jurgen");
            _Dutch.Add("P_THOMAS&JURGEN_INFO", "Op de zolder van een verhuisbedrijf in de Stallings­traat lag ooit een kist bomvol werken van Van Gogh. Zijn moeder had ze daar opgeslagen, maar nadat ze verhuisde verkocht de eigenaar ze voor een dubbel­ tje per stuk. Pas later ontdekte hij hoe waardevol ze waren. De tekst “Trash to Treasure” illustreert deze gebeurtenis. Thomas&Jurgen is een Bredase designstudio. De studio ontwerpt boeken, copyzines en is onder andere verantwoordelijk voor de visuele identiteit van de 3sec.gallery (Chassé Parking)");
            _Dutch.Add("P_ILSEWEISFELT_NAME", "Ilse Weisfelt");
            _Dutch.Add("P_ILSEWEISFELT_INFO", "Op de plek van de fietsenstalling waarop Weisfelt haar muurschildering maakte stond vroeger een paardenstal. Vandaar een ludieke mix van heden en verleden, met een ruiter op een fiets en een fietser op een paard. Illustrator Ilse Weisfelt (Den Bosch) maakt kleurrijke en cartooneske werken waarin grappige scenes met dieren en mensen centraal staan.");
            _Dutch.Add("P_FRM_NAME", "FRM");
            _Dutch.Add("P_FRM_INFO", "Deze muurschildering verwijst naar de legende van St. Joris, een heilige die nauw is verbonden met de geschiedenis van Breda. Het werk verbeeldt de tekst “Overcome the Wind” en roept op tot dapperheid. FRM (Wroclaw, Polen) is grafisch ontwerper en maakt muurschilderingen in de openbare ruimte. Samen met Joanna Jopkiewicz runt hij ontwerpcollectief Grupa Projektor, ze bieden simpele oplossingen voor allerlei grafische uitdagingen.");
            _Dutch.Add("P_ARONVELLEKOOPLÉON_NAME", "Aron Vellekoop Léon");
            _Dutch.Add("P_ARONVELLEKOOPLÉON_INFO", "Illustrator en graficus Aron Vellekoop León werd geboren op Fuerteventura, groeide op op de Veluwe, studeerde aan AKV|St.Joost in Breda en werkt tegenwoordig vanuit Amsterdam. Zijn strakke geometrische vormen zijn vast beïnvloed door Nederland, terwijl zijn Spaanse roots terugkomen in zijn kleurenpalet. Aron maakt zowel vrij werk als redactionele illustraties en doet dit veelal volgens traditionele technieken zoals zeefdruk. Hij is een ware ambachtsman in het digitale tijdperk, maar moest voor deze print toch echt de computer hanteren. Een bestand van 8 gb verbeeldt het thema mobiliteit op de gevel van de oudste parkeergarage van de stad (1968). De print aan de gevel van de parkeergarage komt tot stand in samenwerking met het parkeerbedrijf van de Gemeente Breda. \r\nDe print wordt iedere 4 jaar gewisseld.");
            _Dutch.Add("P_AKACORLEONE_NAME", "AKAcorleone");
            _Dutch.Add("P_AKACORLEONE_INFO", "This mural is a visual interpretation of the busy location and to the chaos that surrounds us daily. Inspired by the adjacent lively shopping street, AKACorleone made a work that shows his own vision on chaos. AKACorleone (Pedro Campiche) is a Portuguese artist who started out as a notorious graffiti writer. In his work colours, typography, characters and forms blend together to eye-cat- ching compositions.");
            _Dutch.Add("P_ZENKONE_NAME", "Zenk ONE");
            _Dutch.Add("P_ZENKONE_INFO", "Deze schildering op een tijdelijke bouwmuur toont een vlucht van eenden waarbij fotorealisme en illustratie zijn gecombineerd. Het ontwerp ver­wijst naar het groene karakter van de nieuwbouw. Hierbij wordt het casco grotendeels hergebruikt, is er ruimte voor duurzame ondernemers en worden de daken groen om de migratie van fauna in de stad te bevorderen. De Bredase Zenk One (Robin Nas) maakt illustraties en (muur) schilderingen. In zijn werk combineert hij realistische tekeningen met grafische elementen.");
            _Dutch.Add("P_CRANIO_NAME", "Cranio");
            _Dutch.Add("P_CRANIO_INFO", "Met een kritische en grappige ondertoon verwijst het werk Cranio naar hedendaagse maatschappij. Net als het Bredase straatbeeld kan deze wel wat kleur gebruiken: zijn indianen voeren de opdracht voor een muur­schildering uit. Als passant zie je hoe de kleurrijke groep het woord ‘Amazonia’ op de tijdelijke bouw­schutting spuit terwijl ze hun speren als selfiestick gebruiken. Cranio (Fabio Oliveira) besloot in 1998 dat de grauwe muren uit ‘zijn’ Sao Paolo een boost konden gebruiken. Sindsdien doet hij hetzelfde voor andere steden. Zijn handelsmerk én hoofdrolspeler is een blauwe indiaan.");
            _Dutch.Add("P_MCITY_NAME", "M-City");
            _Dutch.Add("P_MCITY_INFO", "Met een futuristisch uitziende ‘Robo Dino’ verwijst M­City naar het industriële verleden van de stad. In dit stadsdeel stond o.a. de vermaarde Etna fabriek. De ijzergieterij en stoommachines zijn ingeruild voor een robot met schaar. Een verwijzing naar de kapsalon die in het pand gevestigd is.");
            _Dutch.Add("P_ANTIHELD_NAME", "anti-held");
            _Dutch.Add("P_ANTIHELD_INFO", "Illustrator Sjoerd Jansen aka Anti-held geniet van het maken van semi-realistische expressieve illustraties geïnspireerd op de wereld waarin we leven. Hij gebruikt hierbij zijn eigen metaforen en symboliek. Hij heeft een fascinatie voor analoge technieken als tekenen, schilderen, zeefdruk, houtsnede en etsen.\r\n\r\nMet deze muurschildering reflecteert hij op het nachtleven dat zich afspeelt in deze smalle steeg.");
            _Dutch.Add("P_JORENJOSHUA_NAME", "Joren Joshua");
            _Dutch.Add("P_JORENJOSHUA_INFO", "Dit werk werd speciaal gemaakt om de Potkanstraat visueel te verbeteren (zoals 4, 5 & 7). Qua kleur verwijst de schildering naar water van de haven. Het feestende duo, met een drankje en bitterbal in de hand, brengt een ode aan het Bredase uitgaans­ leven. De speelse illustraties van Joren Joshua (Rotterdam) zijn beïnvloed door graffiti en grafiek. Met zijn slungelige figuren reflecteert hij op alledaagse gebeurtenissen, altijd met humor.");
            _Dutch.Add("P_RUTGERTERMOHLEN2_NAME", "Rutger Termohlen");
            _Dutch.Add("P_RUTGERTERMOHLEN2_INFO", "Net als Antiheld, Joren Joshua en Daniel van de Haterd nam Termohlen een muur in de Potkanstraat onder­ handen. Zijn schildering is een ode aan de haven en het uitgaansleven om de hoek, te zien in zijn mooie dame die wordt omgeven door waterplanten en een octopus. Bredase kunstenaar, illustrator en tattoo artist Rutger Termohlen tekent mensen, dieren en vaak een combinatie ervan. Dynamisch en contrastrijk in kleur en thema: van liefde tot dood, van licht tot duisternis.");
            _Dutch.Add("P_IWANSMIT_NAME", "Iwan Smit");
            _Dutch.Add("P_IWANSMIT_INFO", "Het op de muur achtergebleven logo van studenten dispuut Phileas Fogg, tevens gevestigd in de School­ straat, was het startpunt voor deze schildering. Smit reageert met zijn vraag “Who’s got the power?” op de traditie van de verschillende logo’s op deze muur. Hij stelt de vraag aan passanten en nodigt andere disputen uit tot reactie. Iwan Smit (Rotterdam) illustreert, ontwerpt, schildert en maakt. Zijn werken zijn energiek, soms donker en vaak speelt mythologie een belangrijke rol.");
            _Dutch.Add("P_HEDOF2_NAME", "Hedof");
            _Dutch.Add("P_HEDOF2_INFO", "Op de muren van het sanitairhuisje in de nieuwe Passantenhaven toont Hedof de ‘hoofd­ rolspelers’ uit de buurt: zeelieden, recreanten en passerende gezinnen. Het decor van zijn schildering verwijst naar de gebouwen in de stad. Hedof is Rick Berkelmans, een illustrator uit Breda. Een mix van sterke vormen, cartooneske figuren en een uitgesproken kleurpalet typeert zijn werk.");
            _Dutch.Add("P_STAYNICE_NAME", "Staynice");
            _Dutch.Add("P_STAYNICE_INFO", "De bouwschutting naast Station Breda leent zich goed voor een beeldverhaal. Een steeds terug­ kerende serie van tien illustraties visualiseert een dynamische dag in het leven van de treinreiziger.");
            _Dutch.Add("P_TECKELKMA_NAME", "Teckel KMA");
            _Dutch.Add("P_STAYNICESCOUTING_NAME", "Staynice scouting");
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

            names[0] = "P_ANTONIUSKERKINFO_INFO";
            names[1] = "P_BIBLIOTHEEKINFO_INFO";
            names[2] = "P_KASTEELINFO_INFO";
            names[3] = "P_KLOOSTERKAZERNEINFO_INFO";
            names[4] = "P_NASSAUMONUMENTINFO_INFO";
            names[5] = "P_STADHUISINFO_INFO";
            names[6] = "P_TORENSTRAATINFO_INFO";
            names[7] = "P_VALKENBERGINFO_INFO";
            names[8] = "P_VISHALINFO_INFO";

            int position = 0;
            foreach (string path in paths)
            {
                string text = "";
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///"+path));
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
                    _English.Add(names[position], text);
                }

                position++;
            }

            _English.Add("R_HISTORISCHEKILOMTER_NAME", "Historic kilometer");

            _English.Add("P_VVV_NAME", "VVV");
            _English.Add("P_LIEFDESZUSTER_NAME", "Liefdeszuster");
            _English.Add("P_NASSABARONIEMONUMENT_NAME", "Nassau Baronie Monument");
            _English.Add("P_THELIGHTHOUSE_NAME", "The Light House");
            _English.Add("P_KASTEELVANBREDA_NAME", "Kasteel van Breda");
            _English.Add("P_STADHOUDERSPOORT_NAME", "Stadhouderspoort");
            _English.Add("P_HUISVANBRECHT_NAME", "Huis van Brecht");
            _English.Add("P_SPANJAARDSGAT_NAME", "Spanjaardsgat");
            _English.Add("P_BEGINVISMARKT_NAME", "Begin Vismarkt");
            _English.Add("P_BEGINHAVERMARKT_NAME", "Begin Havermarkt");
            _English.Add("P_GROTEKERK_NAME", "Grote Kerk");
            _English.Add("P_HETPOORTJE_NAME", "Het Poortje");
            _English.Add("P_RIDDERSTRAAT_NAME", "Ridderstraat");
            _English.Add("P_GROTEMARKT_NAME", "Grote Markt");
            _English.Add("P_BEVRIJDINGSMONUMENT_NAME", "Bevrijdingsmonument");
            _English.Add("P_STADHUIS_NAME", "Stadhuis");
            _English.Add("P_ANTONIUSVANPADUAKERK_NAME", "Antonius van Paduakerk");
            _English.Add("P_BIBLIOTHEEK_NAME", "Bibliotheek");
            _English.Add("P_KLOOSTERKAZERNE_NAME", "Kloosterkazerne");
            _English.Add("P_CHASSETHEATER_NAME", "Chasse theater");
            _English.Add("P_BINDINGVANISAAC_NAME", "Binding van Isaac");
            _English.Add("P_BEYERD_NAME", "Beyerd");
            _English.Add("P_GASTHUISPOORT_NAME", "Gasthuispoort");
            _English.Add("P_WILLEMMERKXTUIN_NAME", "Willem Merkxtuin");
            _English.Add("P_BEGIJNENHOF_NAME", "Begijnenhof");

            //Pagetext
            _English.Add("ROUTESELECTIONVIEWMODEL_SELECTROUTE_TEXT", "Select Route");

        }


    }
}
