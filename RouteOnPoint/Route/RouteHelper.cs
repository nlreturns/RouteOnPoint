using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RouteOnPoint.Route
{
    /// <summary>
    /// Class that's capeble of creating routes.
    /// </summary>
    class RouteHelper
    {
        /// Create Historic Route
        /// <summary>
        /// Creates an instance of the historic route
        /// Adds the points to the route
        /// </summary>
        /// <returns>Instance of the blind wall object</returns>
        public Route createHistoriscRoute()
        {
            //Creates the route
            Route r = new Route("R_HISTORISCHEKILOMETER_NAME");
            //Adds points
            r.addPoint("P_VVV_NAME", "P_VVV_INFO", "ms-appx:///Assets/2.jpg", new BasicGeoposition() { Latitude = 51.356467, Longitude = 4.467650 });
            r.addPoint("P_LIEFDESZUSTER_NAME", "P_LIEFDESZUSTER_INFO", "ms-appx:///Assets/3.jpg", new BasicGeoposition() { Latitude = 51.356967, Longitude = 4.467333 });
            r.addPoint("P_NASSAUBARONIEMONUMENT_NAME", "P_NASSAUBARONIEMONUMENT_INFO", "ms-appx:///Assets/4.jpg", new BasicGeoposition() { Latitude = 51.355500, Longitude = 4.467817 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.355500, Longitude = 4.467633 });
            r.addPoint("P_THELIGHTHOUSE_NAME", "P_THELIGHTHOUSE_INFO", "ms-appx:///Assets/5.jpg", new BasicGeoposition() { Latitude = 51.355700, Longitude = 4.467083 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.355600, Longitude = 4.466750 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.354367, Longitude = 4.466200 });
            r.addPoint("P_KASTEELVANBREDA_NAME", "P_KASTEELVANBREDA_INFO", "ms-appx:///Assets/9.jpg", new BasicGeoposition() { Latitude = 51.354367, Longitude = 4.465700 });
            r.addPoint("P_STADHOUDERSPOORT_NAME", "P_STADHOUDERSPOORT_INFO", "ms-appx:///Assets/11.jpg", new BasicGeoposition() { Latitude = 51.353817, Longitude = 4.465683 });
            r.addPoint(null, null, "ms - appx:///Assets/12.jpg", new BasicGeoposition() { Latitude = 51.354200, Longitude = 4.465600 });
            r.addPoint(null, null, "ms - appx:///Assets/8.jpg", new BasicGeoposition() { Latitude = 51.354233, Longitude = 4.465000 });
            r.addPoint("P_HUISVANBRECHT_NAME", "P_HUISVANBRECHT_INFO", "ms-appx:///Assets/7.jpg", new BasicGeoposition() { Latitude = 51.354017, Longitude = 4.464617 });
            r.addPoint("P_SPANJAARDSGAT_NAME", "P_SPANJAARDSGAT_INFO", "ms-appx:///Assets/22.jpg", new BasicGeoposition() { Latitude = 51.354117, Longitude = 4.464067 });
            r.addPoint("P_BEGINVISMARKT_NAME", "P_BEGINVISMARKT_INFO", "ms-appx:///Assets/20.jpg", new BasicGeoposition() { Latitude = 51.353900, Longitude = 4.464000 });
            r.addPoint("P_BEGINHAVERMARKT_NAME", "P_BEGINHAVERMARKT_INFO", "ms - appx:///Assets/19.jpg", new BasicGeoposition() { Latitude = 51.353617, Longitude = 4.464667 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353267, Longitude = 4.464993 });
            r.addPoint("P_GROTEKERK_NAME", "P_GROTEKERK_INFO", "ms-appx:///Assets/10.jpg", new BasicGeoposition() { Latitude = 51.353300, Longitude = 4.465167 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353267, Longitude = 4.4645167 });
            r.addPoint("P_HETPOORTJE_NAME", "P_HETPOORTJE_INFO", "" , new BasicGeoposition() { Latitude = 51.352917, Longitude = 4.465083 });
            r.addPoint("P_RIDDERSTRAAT_NAME", "P_RIDDERSTRAAT_INFO", "", new BasicGeoposition() { Latitude = 51.3532250, Longitude = 4.465450 });
            r.addPoint("P_GROTEMARKT_NAME", "P_GROTEMARKT_INFO", null, new BasicGeoposition() { Latitude = 51.352450, Longitude = 4.465933 });
            r.addPoint("P_BEVRIJDINGSMONUMENT_NAME", "P_BEVREIJDINGSMONUMENT_INFO", "", new BasicGeoposition() { Latitude = 51.352817, Longitude = 4.465800 });
            r.addPoint("P_STADHUIS_NAME", "P_STADHUIS_INFO", "", new BasicGeoposition() { Latitude = 51.353250, Longitude = 4.465667 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352783, Longitude = 4.465817 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352500, Longitude = 4.465933 });
            r.addPoint("P_ANTONIUSVANPADAUKERK_NAME", "P_ANTONIUSVANPADUAKER_INFO" , null, new BasicGeoposition() { Latitude = 51.352583, Longitude = 4.466350 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352967, Longitude = 4.467100 });
            r.addPoint("P_BIBLIOTHEEK_NAME", "P_BIBLIOTHEEK_INFO", null, new BasicGeoposition() { Latitude = 51.352800, Longitude = 4.467367 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352417, Longitude = 4.468133 });
            r.addPoint("P_KLOOSTERKAZERNE_NAME", "P_KLOOSTERKAZERNE_INFO",null , new BasicGeoposition() { Latitude = 51.352417, Longitude = 4.468167 });
            r.addPoint("P_CHASSETHEATER_NAME", "P_CHASSETHEATER_INFO", null, new BasicGeoposition() { Latitude = 51.352650, Longitude = 4.46819200 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352650, Longitude = 4.468750 });
            r.addPoint("P_BINDINGVANISAAC_NAME", "P_BINDINGVANISAAC_INFO", null, new BasicGeoposition() { Latitude = 51.353167, Longitude = 4.46818533 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353700, Longitude = 4.468267 });
            r.addPoint("P_BEYERD_NAME", "P_BEYERD_INFO", null, new BasicGeoposition() { Latitude = 51.353800, Longitude = 4.46818600 });
            r.addPoint(null,null, null, new BasicGeoposition() { Latitude = 51.353700, Longitude = 4.46818267});
            r.addPoint("P_GASTHUISPOORT_NAME", "P_GASTHUISPOOR_INFO" , null, new BasicGeoposition() { Latitude = 51.353733, Longitude = 4.468000 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353650, Longitude = 4.467917 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353417, Longitude = 4.467817 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353133, Longitude = 4.467000 });
            r.addPoint("P_WILLEMMERKXTUIN_NAME", "P_WILLEMMERKXTUIN_INFO", null, new BasicGeoposition() { Latitude = 51.353467, Longitude = 4.466767 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353467, Longitude = 4.466767 });
            r.addPoint("P_BEGIJNENHOF_NAME", "P_BEGIJNENHOF_INFO", null, new BasicGeoposition() { Latitude = 51.353817, Longitude = 4.467017 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353800, Longitude = 4.466683 });
            //r.addPoint("P_VVV_NAME", "P_VVV_INFO", "ms-appx:///Assets/2.jpg", new BasicGeoposition() { Latitude = 51.356467, Longitude = 4.467650 });
            

//            foreach (var POI in r)
//            {
//                poi
//            }
            return r;
        }
        ///Create a Blind Wall route
        /// <summary>
        /// Creates an instance blind wall route
        /// Then adds the points.
        /// </summary>
        /// <remarks>Still needs to be completed</remarks>
        /// <returns></returns>
        public Route createBlindWalls()
        {
            //TODO Add remaining points
            //Create route
            Route r = new Route("R_BLINDWALLS_NAME");

            //Add Points
            r.addPoint("P_ZENKONEGODEVAERT_NAME", "P_ZENKONEGODEVAERT_INFO", "ms-appx:///Assets/B1.jpg", new BasicGeoposition() { Latitude = 51.5819112, Longitude = 4.7757498 });
            r.addPoint("P_STAYNICELUNETTUNNEL_NAME", "P_STAYNICELUNETTUNNEL_INFO", "ms-appx:///Assets/B2.jpg", new BasicGeoposition() { Latitude = 51.592311, Longitude = 4.757159 });
            r.addPoint("P_JUKKAHAKANEN_NAME", "P_JUKKAHAKANEN_INFO", "ms-appx:///Assets/B3.jpg", new BasicGeoposition() { Latitude = 51.588161, Longitude = 4.778344 });
            r.addPoint("P_MAIKKIRANTALA_NAME", "P_MAIKKIRANTALA_INFO", "ms-appx:///Assets/B4.jpg", new BasicGeoposition() { Latitude = 51.585579, Longitude = 4.777428 });
            r.addPoint("P_DZIA_NAME", "P_DZIA_INFO", "ms-appx:///Assets/B5.jpg", new BasicGeoposition() { Latitude = 51.596971, Longitude = 4.788051 });
            r.addPoint("P_DAMIENPOULAINVANCOOTHPLEIN_NAME", "P_DAMIENPOULAINVANCOOTHPLEIN_INFO", "ms-appx:///Assets/B6.jpg", new BasicGeoposition() { Latitude = 51.582854, Longitude = 4.777061 });
            r.addPoint("P_DAMIENPOULAINBOSCHSTRAAT_NAME", "P_DAMIENPOULAINBOSCHSTRAAT_INFO", "ms-appx:///Assets/B7.jpg", new BasicGeoposition() { Latitude = 51.591129, Longitude = 4.783754 });
            r.addPoint("P_HELL'O_NAME", "P_HELL'O_INFO", "ms-appx:///Assets/B7.jpg", new BasicGeoposition() { Latitude = 51.58523, Longitude = 4.776137 });
            r.addPoint("P_KRATJEBEELD_NAME", "P_KRATJEBEELD_INFO", "ms-appx:///Assets/B8.jpg", new BasicGeoposition() { Latitude = 51.584043, Longitude = 4.77689 });
            r.addPoint("P_NOL_NAME", "P_NOL_INFO", "ms-appx:///Assets/B9.jpg", new BasicGeoposition() { Latitude = 51.587121, Longitude = 4.768484 });
            r.addPoint("P_THUNDER&BOLD_NAME", "P_THUNDER&BOLD_INFO", "ms-appx:///Assets/B10.jpg", new BasicGeoposition() { Latitude = 51.579412, Longitude = 4.764087 });

            /** Points that still need a definition.
             * 
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
            _Dutch.Add("P_STAYNICESCOUTING_NAME", "Staynice scouting");*/
            return r;
        }

    }
}
