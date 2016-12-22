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

        public enum LanguageEnum { English, Dutch};

        public static LanguageEnum Language;

        //set language and load the dictionary for the given language
        public static async Task setLanguage(LanguageEnum lang)
        {
            Language = lang;

            if (Language == LanguageEnum.Dutch)
            {
                _Dutch = new Dictionary<string, string>();
                LoadPageTextDutch();
                await LoadHistorischeKilometerDutch();
                LoadAssistPageDutch();
                LoadBlindWallsDutch();
            }

            if (Language == LanguageEnum.English)
            {
                _English = new Dictionary<string, string>();
                LoadPageTextEnglish();
                await LoadHistorischeKilometerEnglish();
                LoadAssistPageEnglish();
                LoadBlindWallsEnglish();
            }

        }

        //return string in the current language for given key
        public static string GetContent(string key)
        {

            string value = "";
            if (key != null)
            {
                if (Language == LanguageEnum.Dutch)
                {
                    _Dutch.TryGetValue(key, out value);
                }

                if (Language == LanguageEnum.English)
                {
                    _English.TryGetValue(key, out value);
                }
            }

            return value;
        }

        //DUTCH
        #region

        //Historic kilometer text Dutch
        private static async Task LoadHistorischeKilometerDutch()
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

            names[0] = "P_ANTONIUSVANPADUAKERK_INFO";
            names[1] = "P_BIBLIOTHEEK_INFO";
            names[2] = "P_KASTEELVANBREDA_INFO";
            names[3] = "P_KLOOSTERKAZERNE_INFO";
            names[4] = "P_NASSAUBARONIEMONUMENT_INFO";
            names[5] = "P_STADHUIS_INFO";
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

            _Dutch.Add("R_HISTORISCHEKILOMETER_NAME", "Historische Kilometer");

            _Dutch.Add("P_VVV_NAME", "VVV");
            _Dutch.Add("P_LIEFDESZUSTER_NAME", "Liefdeszuster");
            _Dutch.Add("P_NASSAUBARONIEMONUMENT_NAME", "Nassau Baronie Monument");
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

        //All pages text Dutch
        private static void LoadPageTextDutch()
        {
            _Dutch.Add("ROUTESELECTIONVIEWMODEL_SELECTROUTE_TEXT", "Selecteer Route");
            _Dutch.Add("ROUTESELECTIONVIEWMODEL_RESUMEROUTE_TEXT", "Hervat route");
            _Dutch.Add("NOTITLEERROR", "De naam is onbekend");
            _Dutch.Add("NOINFOERROR", "Er is geen informatie beschikbaar");
            _Dutch.Add("NOIMAGEERROR", "Er is geen foto beschikbaar");
            _Dutch.Add("GPSREADER_LOCATION_TEXT", "Mijn Locatie");
            _Dutch.Add("GPSREADER_GPSAVAILABLE_TITLE", "GPS signal niet gevonden");
            _Dutch.Add("GPSREADER_GPSAVAILABLE_TEXT", "Route on point kan je locatie niet bepalen, omdat er geen GPS signaal beschikbaar is");
        }

        //Assistpage text Dutch
        private static void LoadAssistPageDutch()
        {
            _Dutch.Add("ASSISTVIEWMODEL_HEADER_TEXT", "Hulp pagina");
            _Dutch.Add("ASSISTVIEWMODEL_LOCATIONBUTTONINFO_TEXT", "Deze knop brengt u naar uw huidige locatie wanneer hier op gedrukt wordt.");
            _Dutch.Add("ASSISTVIEWMODEL_PAUSEBUTTONINFO_TEXT", "Deze knop zorgt ervoor dat u de route op pauze kunt zetten. Wanneer de route is gepauzeerd ontvangt u geen meldingen totdat u het pauzeren eindigt door nogmaals op deze knop te drukken.");
            _Dutch.Add("ASSISTVIEWMODEL_HELPBUTTONINFO_TEXT", "Deze knop brengt u naar het scherm waar u zich nu in bevind. Dit scherm geeft u uitleg over de functionaliteiten en mogenlijkheden van deze applicatie.");
            _Dutch.Add("ASSISTVIEWMODEL_MYLOCATIONINFO_TEXT", "Dit geeft uw huidige locatie aan op de kaart. Als u dit niet ziet druk dan op de knop om u naar uw locatie te brengen.");
            _Dutch.Add("ASSISTVIEWMODEL_MYLOACTIONINFO_IMAGE", "ms-appx:///Assets/HelpPage/MijnLocatie.png");
            _Dutch.Add("ASSISTVIEWMODEL_GREENPOI_TEXT", "Dit icoon geeft aan dat dit specifieke Point of Interest nog niet is bezocht.");
            _Dutch.Add("ASSISTVIEWMODEL_BLUEPOI_TEXT", "Dit icoon geeft aan dat dit specifieke Point of Interest is bezocht.");
            _Dutch.Add("ASSISTVIEWMODEL_ORANGELINE_TEXT", "Deze kleur lijn geeft aan wat de route is. Dit is de geadviseerde wandelroute.");
            _Dutch.Add("ASSISTVIEWMODEL_GRAYLINE_TEXT","Deze kleur lijn geeft aan wat je gelopen hebt. Dit onderdeel van de route is dus al bewandeld.");
        }

        //Blindwalls text Dutch
        private static void LoadBlindWallsDutch()
        {
            _Dutch.Add("R_BLINDWALLS_NAME", "Blind Walls");
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

        #endregion

        //ENGLISCH
        #region 

        //Historic kilometer text Englisch
        private static async Task LoadHistorischeKilometerEnglish()
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

            names[0] = "P_ANTONIUSVANPADUAKERK_INFO";
            names[1] = "P_BIBLIOTHEEK_INFO";
            names[2] = "P_KASTEELVANBREDA_INFO";
            names[3] = "P_KLOOSTERKAZERNE_INFO";
            names[4] = "P_NASSAUBARONIEMONUMENT_INFO";
            names[5] = "P_STADHUIS_INFO";
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

            _English.Add("R_HISTORISCHEKILOMETER_NAME", "Historic kilometer");

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

        }

        //All pages text Englisch
        private static void LoadPageTextEnglish()
        {
            _English.Add("ROUTESELECTIONVIEWMODEL_SELECTROUTE_TEXT", "Select Route");
            _English.Add("ROUTESELECTIONVIEWMODEL_RESUMEROUTE_TEXT", "Resume route");
            _English.Add("NOTITLEERROR", "The name is unknown");
            _English.Add("NOINFOERROR", "There is no information available for this point");
            _English.Add("NOIMAGEERROR", "No image availeble");
            _English.Add("GPSREADER_LOCATION_TEXT", "My Location");
            _English.Add("GPSREADER_GPSAVAILABLE_TITLE", "GPS signal not found");
            _English.Add("GPSREADER_GPSAVAILABLE_TEXT", "Route on point can't find your location due to there's no GPS signal");
            //_English.Add()
        }

        //AssistPage text Englisch
        private static void LoadAssistPageEnglish()
        {
            _English.Add("ASSISTVIEWMODEL_HEADER_TEXT", "Help page");
            _English.Add("ASSISTVIEWMODEL_LOCATIONBUTTONINFO_TEXT", "This button takes you to your current location when pressed.");
            _English.Add("ASSISTVIEWMODEL_PAUSEBUTTONINFO_TEXT", "This button provides you to pause the route. When the route is paused you won't get any notifications untill you unpause the route by pressing the button again.");
            _English.Add("ASSISTVIEWMODEL_HELPBUTTONINFO_TEXT", "This button takes you to the page where you are right now. This page provides you with information and possibilities about and with this application.");
            _English.Add("ASSISTVIEWMODEL_MYLOCATIONINFO_TEXT", "This displays your current location on the map. If you can't see this you should press the button that takes you there.");
            _English.Add("ASSISTVIEWMODEL_MYLOACTIONINFO_IMAGE", "ms-appx:///Assets/HelpPage/MyLocation.png");
            _English.Add("ASSISTVIEWMODEL_GREENPOI_TEXT", "This icon shows a Point of Interest that isn't visited yet.");
            _English.Add("ASSISTVIEWMODEL_BLUEPOI_TEXT", "This icon shows a Point of Interest that is visited already.");
            _English.Add("ASSISTVIEWMODEL_ORANGELINE_TEXT", "This color line shows you the route. This is the advised walk.");
            _English.Add("ASSISTVIEWMODEL_GRAYLINE_TEXT", "This color line shows you the route you have already walked.");
        }

        //BlindWalls text Englisch
        private static void LoadBlindWallsEnglish()
        {
            _English.Add("R_BLINDWALLS_NAME", "Blind Walls");
            _English.Add("P_ZENKONEGODEVAERT_NAME", "Zenk One Godevaert");
            _English.Add("P_ZENKONEGODEVAERT_INFO", "Robin Nas aka Zenkone grew up in creative family and started with graffiti at a young age. He became well-known for his realistic portraits that he later started mixing with a more graphic style. He now travels the world to make tall wall paintings in his characteristic style. From his studio in Breda, he works as an illustrator for international clients. The mural is a tribute to Godevaart Montens, mayor of Breda from 1580 - 1581 and 1596 - 1602.He is known for his supposed heroic conduct on June 28, 1581.During the fury of Houtepen he led a group of Breda citizen soldiers into battle against the Spanish troops.These troops have violently havoc, pillaged, killed and looted.Volunteers were needed to clean up the remains of 400 - 500 dead civilians.");
            _English.Add("P_STAYNICELUNETTUNNEL_NAME", "Staynice Lunettunnel");
            _English.Add("P_STAYNICELUNETTUNNEL_INFO", "Brothers Rob (1973) and Barry (1977) van Dijck together form the graphic design studio Staynice. From their interest in graffiti they studied graphic design at AKV | St. Joost. In 2006 the nomination for the St.Joost medal gave access to a guest studio. Here they made plans to start their own studio. In ten years they developed into a renowned studio.Their work is characterized by the playful combination of information, illustration and typography.Experiments on their own RISO printer often serve as inspiration for commercial projects for international clients. Yet they remain true to their roots and regular take up spray cans for murals. They created the longest mural so far.The over 130m sweet shapes are inspired by the(partly disappeared) confectionery industry in Breda.When the wind blows in the right direction, the factory down the street adds a fragrant dimension to the painting.");
            _English.Add("P_JUKKAHAKANEN_NAME", "Jukka Hakanen");
            _English.Add("P_JUKKAHAKANEN_INFO", "Drawing and painting have been natural forms of expression for Jukka Hakanen since an early age. Growing up in Turku (FI) he became interested in graffiti. Since 2000 he has made many murals in Finland and abroad. This mural is an updated version of the still life painting.The inspiration came from surrounding restaurants, the building’s long history, and the famous nearby growing mulberry tree(planted in 1780).");
            _English.Add("P_MAIKKIRANTALA_NAME", "Maikki Rantala");
            _English.Add("P_MAIKKIRANTALA_INFO", "Maikki Rantala is a community artist working on large scale participatory street art programs since 2012. To her street art is a form of urban activism, a way to tackle many of the challenges which urbanization presents us. She often aims her murals at children, as they often are more observant to their surroundings. The historical miniature house with brick facades and many corners is a real challenge to paint.The story of this mural goes back to the 19th century catering school located at the site with a variety of pictorial plates in traditional Dutch, Spanish, Italian, Chinese, Arabic and even Finnish styles.");
            _English.Add("P_DZIA_NAME", "DZIA");
            _English.Add("P_DZIA_INFO", "The Liniestraat forms the outer limit of the Linie Quarter. By the request of residents this area was not demolished, but redeveloped by Alleewonen in close cooperation with its residents. There is DIY-housing, a neighborhood salon and various cultural events in partnership with Electron. Belgian artist DZIA was invited to visualize the creative character of the neighborhood.His real name remains unknown, like he is not recognizable in photographs and chooses to let his work speak out for itself.For years he’s been painting animals in his characteristic style on walls all over the world. The flamingo depicts the colorful character of the neighborhood.As this area used to be a polder frequented by many birds.While putting the white paint up DZIA already got many reactions from the neighborhood.They really liked his ‘swan’. After the toucan the inspiration for the final bird was easily found.Together the three birds represent the creative, colorful and diverse character of the neighborhood, with a small nod to the past.");
            _English.Add("P_DAMIENPOULAINVANCOOTHPLEIN_NAME", "Damien Poulain Van Coothplein");
            _English.Add("P_DAMIENPOULAINVANCOOTHPLEIN_INFO", "Damien Poulain is a graphic designer and illustrator with a specific focus on art, fashion and music. He also publishes photography books under the name oodee. After painting shutters in Tokyo, Paris and London the Blind Walls Gallery invited Damien to visit Breda and work his magic. Besides it being the hottest day of the year Damien delivered four beautiful ‘happy’ shutters.");
            _English.Add("P_DAMIENPOULAINBOSCHSTRAAT_NAME", "Damien Poulain Boschstraat");
            _English.Add("P_DAMIENPOULAINBOSCHSTRAAT_INFO", "Damien Poulain is a graphic designer and illustrator with a specific focus on art, fashion and music. He also publishes photography books under the name oodee. After painting shutters in Tokyo, Paris and London the Blind Walls Gallery invited Damien to visit Breda and work his magic. Besides it being the hottest day of the year Damien delivered four beautiful ‘happy’ shutters.");
            _English.Add("P_HELL'O_NAME", "Hell'O");
            _English.Add("P_HELL'O_INFO", "Brussels duo Hell’O masters the graphic line like a 21st century Jherimus Bosch. Their universe looks like a surrealistic bestiary of mysterious animals, hybrid characters, architecture and badass geometry. Their paintings and sculptures refer to medieval folklore, esotericism, techno music, the Memphis Design Group, 17th-century engraving, ancient mythology, surrealism … In narrative scenes, meaningful and absurd, humor and mockery provide room for interpretation by the viewer. For the mural in the Bleekstraat Hell’O were inspired by the view on shoppers from Bleekstraat.The street name is interpreted literally and allows the hybrid characters slowly fade.");
            _English.Add("P_KRATJEBEELD_NAME", "Kratje Beeld");
            _English.Add("P_KRATJEBEELD_INFO", "Studio Kratje Beeld is a temporary design studio formed by ten third-year AKV|St. Joost Illustration students. In their training period they work on assignments for various clients. For most students it is the first time they work on this scale. The mural is therefore thoroughly prepared with sketches, color studies and research at the City Archives Breda.");
            _English.Add("P_NOL_NAME", "NOL");
            _English.Add("P_NOL_INFO", "Presumably in earlier times the white space on the facade of this monument contained an advertisement. Research in the city archives yielded no evidence about what the ad or period in which it was visible. Also the neighbors Meeuwsen Aquariums -looking at this wall for more than 35 years- had no clue about the content of the mysterious white space. In recent decades the building has functioned as a bakery, tobacconist and smart shop. From the late 90s, it’s a residence. Recently it has been completely restored. Until then artist Michael Nolta lived in the property. His studio was located on the ground floor. The current window decoration is a relic from that time. Under the NOL pseudonym he creates murals. After having painted his blue creatures in many cities round the globe it was obvious to have NOL paint this mural.");
            _English.Add("P_THUNDER&BOLD_NAME", "Thunder & Bold");
            _English.Add("P_THUNDER&BOLD_INFO", "We invited Thunder & Bold (aka Martijn van der Meeren and Emiel Jonkers) to take on the old nursery school in the Burgemeester van Sonsbeeckpark in Breda. Nowadays the building is used as a day-care during the week and a coffeehouse during the weekends. After some research we found out that once a year all the surrounding neighbours of the park get together and do maintenance on the park.They clean up the public gardens, plant flower bulbs and even have created playing equipment for the kids from leftover wood and other materials.This makes the Sonsbeeckpark a place of the people and this should be reflected in the mural. Rainy day, dream away, Ah let the sun take a holiday, Flowers bathe an’ ah see the children play, Lay back and groove on a rainy day, Inspiration sometimes finds you and this was the case for Thunder & Bold this time.While working in their studio, listening to Rainy day, dream away from Jimi Hendrix it all came together.This is the place where the flowers bathe and the children play!");
            _English.Add("P_BENEINE_NAME", "Ben Eine");
            _English.Add("P_BENEINE_INFO", "This triple railway underpass connects the city center and the Belcrum district, known for it’s residential area and former industrial side. The river Mark runs through the center underpass giving way to small boats heading for the city marina. On the Belcrumweg there are underpasses for cars, cyclists and pedestrians. Here every day thousands of people pass on their way to the city. The other site is called Markkade. This quay is far less busy nowadays, as factories it led to have all closed. Back in 1776 -when the city was still small- this entire area was still a polder and home to lots of birds. In 1855 the first Breda Railway station was build near the Markkade. The railway and river made the site a hotspot in the rise of the industrial revolution. From this period up to the late 1990’s many notorious factories, like Kwatta (chocolate) MOMO (limonade), Centrale Suiker Maatschappij (sugar refinery), Etna (stoves), Electron (mechanics), Backer & Rueb (steam engines), Hollandsche Kunstzijde Industrie (silk), were located in this area. When the railway was extended to Tilburg in 1862 a bridge over the river Mark was build.In the 1920’s the polder next to the railway was turned into a residential area allowing workers to live close to factories.The streets were named after the birds chased away by the expansion.As both the city and railway use grew the current bridge was build in 1972. In the twentieth century the railway marked the division between the ‘rich’ center of town and the ‘working class’ north. In recent years Belcrum turned into a hotspot. Young families live there next to theaters, exhibitions spaces, studios, skate hall, and even a beach in the old docks. The new station (opening September 2016) has two entrances; city and north have become equal. To celebrate the new station renowned street artist Ben Eine(London, 1970) was invited to work on the underpass.Eine claims there is a clear distinction between graffiti and street art.To his opinion graffiti makes the streets ugly,while street art beautifies it.He knows from experience as he had been tagging trains and walls since the age of 14. At some point Eine felt existing graffiti artists were creating designs that were entirely similar and therefore lacked interest. He wanted to do something different. He was always interested in letters and how they could change shape when combined into words, so this is the direction he took. Eine’s typographical works appear in Tokyo, New York, Los Angeles, Berlin and other metropolitan cities. For his mural in Breda he got inspiration from the old and vanished industry at the site. Instead of referring to history the words “Meaningful”, “Imagineer”, “Mesmerising”, “Storytelling” celebrate the present and future industry of Breda. The city is known as ‘City of Imagineers’ a home for many educational, cultural and commercial institutions in the creative industry.");
            _English.Add("P_NOODLEINC_NAME", "Noodle Inc.");
            _English.Add("P_NOODLEINC_INFO", "The duo Noodle Inc. consists of friends Michael Nolta and Edo Rath. Their typically colorful and always cheerful work is characterized by clean lines and recurring characters. Invited by the owner they created a black and white mural titled “Cafe au Lait” in two nights.It depicts the story of two enchanted spoons making a journey through a fluffy landscape with puffy muffins, happy coffee cups, dancing donuts, euphoric tea bags, radiant sugar casters and self - regulating coffee grinders.");
            _English.Add("P_LUCAFONT_NAME", "Luca Font");
            _English.Add("P_LUCAFONT_INFO", "The day before Luca Font arrived in Breda rock star David Bowie had passed away. This painting commemorates the iconic artist. Luca Font grew up writing graffiti, skateboarding and visiting art museums with his mom. These days he spends his time tattooing, painting, drawing and traveling along the way.");
            _English.Add("P_COMBATSUPERMURAL_NAME", "Combat Super Mural");
            _English.Add("P_HEDOFOASE_NAME", "Hedof Oase");
            _English.Add("P_ZENKONE2012_NAME", "Zenk One 2012");
            _English.Add("P_STAYNICEKOP_NAME", "Staynice KOP");
            _English.Add("P_STAYNICEBLOOS_NAME", "Staynice Bloos");
            _English.Add("P_ZENKONEVEILINGKADE_NAME", "Zenk One Veilingkade");
            _English.Add("P_SUPERA_NAME", "Super A");
            _English.Add("P_FINDAC_NAME", "Fin Dac");
            _English.Add("P_FINDAC_INFO", "Together with Nol Art and Edo Rath, Fin DAC made this Geisha mural named ‘Kokesh’ on the wall of an (also Japanese) sushi restaurant. DAC made this mural in addition to his ‘Hidden Beauty’ series. The colour palette refers to Breda, since the City colours are red and white. Despite his relatively short street art career, Fin DAC (London) is well known for his striking and dramatic large-scale (mostly female) portraits. He applies the stencil technique and adds hand painted details.");
            _English.Add("P_JEFFCANHAM_NAME", "Jeff Canham");
            _English.Add("P_JEFFCANHAM_INFO", "In his painting Canham depicts the first nine words of the NATO phonetic alphabet. Their use during WWII refers to the military past of this place. From 1765 to 1980 the site was part of the Chassékazerne (barracks), where during WWII Kriegsmarine training units were established. Jeff Canham is a sign painter from San Francisco, known for his hand painted typographical advertising signs and shopping windows. His unique methods are highlighted in documentary ‘Sign Painters’.");
            _English.Add("P_RUTGERTERMOHLEN_NAME", "RUTGER TERMOHLEN, COLLIN VAN DER SLUIJS & SUPER A");
            _English.Add("P_RUTGERTERMOHLEN_INFO", "This wall is inspired by the sinister history of the location, which used to be a graveyard for people that died from the plague (around 1514). Because of this the graveyard became unpopular, therefore the cemetery was used to bury the poor, children, soldiers and suicides. The children dancing around the rat, the spreader of the plague is a link to the children song ‘Ring around the Rosie’ which refers to the black sores that would appear on your body as part of the plague. The artists also added elements that refer to the city Breda. Breda artist Rutger Termohlen depicts people, animals and a combination of both. His work is dynamic and with rich contrasts in colour and theme: from love to death, from light to dark. Van der Sluijs added dreamy details, Super A mostly makes both animal and human portraits.");
            _English.Add("P_JOBWOUTERS_NAME", "JOB WOUTERS");
            _English.Add("P_JOBWOUTERS_INFO", "The diversity in colours and whimsical shapes of this mural refer to the turbulent past of the place where Wouters made the work. A chapel was built in the fifteenth century, it was used as a cemetery in the sixteenth century, a vegetable garden in the nineteenth century and as barracks in the twentieth century. Job Wouters (Letman) is an Amsterdam based typedesigner. As “letter loony” he doesn’t shun traditional techniques like calligraphy. Armed with his ‘spray can-machine’ he makes unique letter art.");
            _English.Add("P_MIKEPERRY_NAME", "Mike Perry");
            _English.Add("P_MIKEPERRY_INFO", "That Perry’s mural is made up of several layers is not directly noticeable. It’s a reference to the hidden design process and the richness of the Breda history (forgotten by some). Interwoven in his work is a Palindrome poem, consisting of words you read the same from both sides. Mike Perry is an artist and designer that draws, paints, illustrates, animates, cuts, pastes, and builds. He’s working in numerous media and is living and working in New York City.");
            _English.Add("P_STEPHENPOWERS_NAME", "Stephen Powers");
            _English.Add("P_STEPHENPOWERS_INFO", "Powers processed his conversations with residents and passers­by in his mural, as a love letter to the city. He did this during the first Koningsdag (Kings­ day) with ‘orange fever’ at its best. Koninginnedag (Queen’s day) is history, but according to Powers every day is ‘Queensday’ with a daily ode to all women. Steve ‘ESPO’ Powers is an artist from New York City who’s work often blurred the lines between illegal and legal and which are often declarations of love in a local context.");
            _English.Add("P_HEDOF_NAME", "Hedof");
            _English.Add("P_HEDOF_INFO", "This painting refers to both the present and past of the location. Again fruits and vegetables ‘grow’ at the same location as the large vegetable garden in the early nineteenth century.The shopping figures in the painting are on their way to the nearby shopping street. Hedof is Rick Berkelmans, an illustrator from Breda. A mix of strong shapes, weird characters and bold colours typifies his work.");
            _English.Add("P_JOHANMOORMAN_NAME", "Johan Moorman");
            _English.Add("P_JOHANMOORMAN_INFO", "The mural depicts a circus with elephant, inspired by a troubled event that took place in 1988. Elephants walked the Akkerstraat when two circuses were performing only 500 meters apart. Both received a Breda ban for five years afterwards. With graphic design agency Spielerei (Eindhoven) Johan Moorman designs for analogue and digital media. ‘Extraordinary’ is the starting point and ‘playful’ the key word to get there.");
            _English.Add("P_BRUCETMC_NAME", "Bruce TMC");
            _English.Add("P_BRUCETMC_INFO", "“If wishes were horses, beggars would ride” is an English proverb used to suggest that it’s useless to wish and that better results will be achieved through action. In this work, “beggars” is replaced for “refugees”, possibly because of the current refugee problems. The rhyme also refers to the horse stables that were once situated here. Bruce Tsai-Meu-Chong (TMC) is a Rotterdam based illustrator and sign painter. His work varies from menu’s and storefronts to big murals. Sometimes with a message, always handmade.");
            _English.Add("P_THOMAS&JURGEN_NAME", "Thomas & Jurgen");
            _English.Add("P_THOMAS&JURGEN_INFO", "In an attic of a moving company in the Stallingstraat once a chest packed Van Gogh works was stored. After Van Gogh’s mother moved, the owner sold to the drawings for a dime apiece on the market. Only later he found out how valuable they were. The text “Trash to Treasure” illustrates this event. Thomas&Jurgen is a design studio from Breda. The studio designs books, copyzines and is also responsible for the visual identity of the 3sec.gallery (Chassé Parking).");
            _English.Add("P_ILSEWEISFELT_NAME", "Ilse Weisfelt");
            _English.Add("P_ILSEWEISFELT_INFO", "There used to be a horse stable on the site of the bike shed on which Weisfelt made her mural. Hence a playful mix of past and present with an illustration of a rider on a bike and a cyclist on a horse. Illustrator Ilse Weisfelt (Den Bosch) makes colourful and cartoonesque works in which funny scenes with animals and people play a central role.");
            _English.Add("P_FRM_NAME", "FRM");
            _English.Add("P_FRM_INFO", "This mural refers to the legend of St. George, a Saint who is closely connected with the history of Breda. The work spells “Overcome the Wind” and calls for bravery. FRM (Wroclaw, Poland) is a graphic designer and often creator of wall paintings in public spaces. Together with Joanna Jopkiewicz he runs design collective Grupa Projektor, they offer simple solutions for all kinds of graphic challenges.");
            _English.Add("P_ARONVELLEKOOPLÉON_NAME", "Aron Vellekoop Léon");
            _English.Add("P_ARONVELLEKOOPLÉON_INFO", "Illustrator and graphic artist Aron Vellekoop Leon was born in Fuerteventura, grew up in the Veluwe, studied at AKV | St. Joost in Breda and works from Amsterdam. His sleek geometric drawing must be firmly influenced by the Netherlands, while his Spanish roots return in his color palette. Aron creates prints and editorial illustrations, often using traditional techniques such as screen printing. He is a true craftsman in the digital age, but had rely on a computer for this piece. An 8GB file depicts the theme of mobility on the facade of the oldest car park of the city (1968). ");
            _English.Add("P_AKACORLEONE_NAME", "AKAcorleone");
            _English.Add("P_AKACORLEONE_INFO", "This mural is a visual interpretation of the busy location and to the chaos that surrounds us daily. Inspired by the adjacent lively shopping street, AKACorleone made a work that shows his own vision on chaos. AKACorleone (Pedro Campiche) is a Portuguese artist who started out as a notorious graffiti writer. In his work colours, typography, characters and forms blend together to eye-cat- ching compositions.");
            _English.Add("P_ZENKONE_NAME", "Zenk ONE");
            _English.Add("P_ZENKONE_INFO", "This painting on a temporary construction wall shows a flight of ducks for which fotorealism and illustration are combined. The design refers to the green character of the new building. Here the casco is largely reused, there is room for sustainable entrepreneurs and the green roofs enhance the fauna in the city. Zenk One (Robin Nas) from Breda makes illustrations and (wall) paintings. In his work he combines ‘realistic’ drawings with graphic elements.");
            _English.Add("P_CRANIO_NAME", "Cranio");
            _English.Add("P_CRANIO_INFO", "With his mural Cranio refers to the present and theneed for more color in the streets of Breda: his indians create the commissioned mural. As a passers­by you see how this colorful group writes the word ‘Amazonia’ on the temporary wall in a typical graffiti style. Cranio (Fabio Oliveira) decided in 1998 that the grey walls in ‘his’ Sao Paolo needed a boost. Since then he does the same for other cities. His trademark and key player is a blue indian.");
            _English.Add("P_MCITY_NAME", "M-City");
            _English.Add("P_MCITY_INFO", "With a futuristic looking ‘Robot Dino’ M-City refers to the industrial past of the city. In this district the renowned Etna factory was founded. The iron foundry and steam engines have been replaced by a robot with scissors. A reference to the barber shop which is located in the building. M-City (Mariusz Waras) born in Gdynia, Poland. As graphic artist, outdoor painter, traveller, amateur architect his work focuses on urban space. His over 700 murals can be seen in the streets of Warsaw, Gdańsk, Berlin, Paris, Budapest, Sao Paulo, Rio de Janeiro, Bolzano, London and Prague. His work involves piecing together hundreds of carefully cut stencils to create a coherent imagined cityscape of mechanical and industrial objects. He is intrigued by industrial spaces and their surroundings, taking his inspiration from the factories, hydroelectric plants, chimneys, and cranes that dominated his native town and childhood.");
            _English.Add("P_ANTIHELD_NAME", "anti-held");
            _English.Add("P_ANTIHELD_INFO", "Illustrator Sjoerd Jansen aka Anti-held enjoys creating semi realistic expressive illustrations reflecting on the world we live in, using his own metaphors and symbolism. Fascinated by analog techniques his work often results in drawing, painting, screenprinting, woodcutting and etching. With this mural he reflects on the nightlife in this narrow alley.");
            _English.Add("P_JORENJOSHUA_NAME", "Joren Joshua");
            _English.Add("P_JORENJOSHUA_INFO", "This work was specially made to visually improve the Potkanstraat (such as 4, 5 & 7). The colours refer to the water of the Harbour. The feasting duo, with a drink and Dutch ‘bitter­bal’ in hand, brings an ode to the Breda nightlife. The playfull illustrations of Joren Joshua (Rotterdam) are influenced by graffiti and print making. With his lanky characters he reflects on daily life, always in a humorous way.");
            _English.Add("P_RUTGERTERMOHLEN2_NAME", "Rutger Termohlen");
            _English.Add("P_RUTGERTERMOHLEN2_INFO", "Like Antiheld, Joren Joshua and Daniel van de Haterd , Termohlen worked on a wall in the Potkanstraat. His painting is an ode to the Harbour and the nightlife around the corner, seen in his lovely lady who is surrounded by aquatic plants and an octopus. Breda illustrator, painter and tattoo artist Rutger Termohlen depicts people, animals and more often a combination of both. His dynamic work is rich in contrasts, colour and theme: from love to death, from light to dark.");
            _English.Add("P_IWANSMIT_NAME", "Iwan Smit");
            _English.Add("P_IWANSMIT_INFO", "Het op de muur achtergebleven logo van studenten dispuut Phileas Fogg, tevens gevestigd in de School­ straat, was het startpunt voor deze schildering. Smit reageert met zijn vraag “Who’s got the power?” op de traditie van de verschillende logo’s op deze muur. Hij stelt de vraag aan passanten en nodigt andere disputen uit tot reactie. Iwan Smit (Rotterdam) illustreert, ontwerpt, schildert en maakt. Zijn werken zijn energiek, soms donker en vaak speelt mythologie een belangrijke rol.");
            _English.Add("P_HEDOF2_NAME", "Hedof");
            _English.Add("P_HEDOF2_INFO", "On the walls of the sanitary cabin in the new city marina Hedof shows the ‘key figures’ of this neighborhood: sailors, recreationists and passing families. The decor refers to the buildings of the city. Hedof is Rick Berkelmans, an illustrator from Breda. A mix of strong shapes, weird characters and bold colors typifies his work");
            _English.Add("P_STAYNICE_NAME", "Staynice");
            _English.Add("P_STAYNICE_INFO", "The construction wall next to Breda Station is perfect for a visual story. A loop of ten images visualizes a dynamic and colorful day in the life of the commuter. Staynice is a graphic design agency from Breda. With a passion for typography and illustration they produce striking concepts, visual identities, murals and more.");
            _English.Add("P_TECKELKMA_NAME", "Teckel KMA");
            _English.Add("P_STAYNICESCOUTING_NAME", "Staynice scouting");
        }

        #endregion


    }
}
