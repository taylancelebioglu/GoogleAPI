using System.Collections.Generic;

namespace GoogleAnalyticsConsumer.Business
{
    public abstract class SimulatorParameters
    {
        public static List<KeyValuePair<string, string>> BrowserList = new List<KeyValuePair<string, string>>() {
           new KeyValuePair<string, string>("Windows-Edge","Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.246" ),
           new KeyValuePair<string, string>("Windows7-Chrome","Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36" ),
           new KeyValuePair<string, string>("MacOS-Safari","Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_2) AppleWebKit/601.3.9 (KHTML, like Gecko) Version/9.0.2 new KeyValuePair<string, string>(Safari/601.3.9" ),
           new KeyValuePair<string, string>("Linux-Firefox","Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:15.0) Gecko/20100101 Firefox/15.0.1"),
           new KeyValuePair<string, string>("Windows-Edge","Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 new KeyValuePair<string, string>(Edge/12.246" ),
           new KeyValuePair<string, string>("Playstation4","Mozilla/5.0 (PlayStation 4 3.11) AppleWebKit/537.73 (KHTML, like Gecko)" ),
           new KeyValuePair<string, string>("XBox-One","Mozilla/5.0 (Windows Phone 10.0; Android 4.2.1; Xbox; Xbox One) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0new KeyValuePair<string, string>( Mobile Safari/537.36 Edge/13.10586" ),
           new KeyValuePair<string, string>("Sony Xperia Z5","Mozilla/5.0 (Linux; Android 6.0.1; E6653 Build/32.2.A.0.253) AppleWebKit/537.36 (KHTML, like Gecko) new KeyValuePair<string, string>(Chrome/52.0.2743.98 Mobile Safari/537.36" ),
           new KeyValuePair<string, string>("HTC One M9","Mozilla/5.0 (Linux; Android 6.0; HTC One M9 Build/MRA58K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.98 new KeyValuePair<string, string>(Mobile Safari/537.36" ),
           new KeyValuePair<string, string>("Microsoft Lumia 950","Mozilla/5.0 (Windows Phone 10.0; Android 4.2.1; Microsoft; Lumia 950) AppleWebKit/537.36 (KHTML, like Gecko) new KeyValuePair<string, string>(Chrome/46.0.2486.0 Mobile Safari/537.36 Edge/13.10586" ),
           new KeyValuePair<string, string>( "Samsung Galaxy S6","Mozilla/5.0 (Linux; Android 6.0.1; SM-G920V Build/MMB29K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.98 Mobile Safari/537.36" )
        };
        public static List<KeyValuePair<string, string>> PageUrlList = new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("Home Page","/Home"),
            new KeyValuePair<string, string>("Contact","/Contact"),
            new KeyValuePair<string, string>("About","/About"),
            new KeyValuePair<string, string>("Index","/Google" ),
            new KeyValuePair<string, string>("ReportTestPage","/Google/ReportTestPage"),
            new KeyValuePair<string, string>("FirstTestPage","/Google/FirstTestPage"),
            new KeyValuePair<string, string>("SecondTestPage","/Google/SecondTestPage"),
            new KeyValuePair<string, string>("ThirdTestPage", "/Google/ThirdTestPage")
        };
        public static List<int> GeoIdList = new List<int>() { 2004, 2044, 2214, 21059, 21060, 21061, 21062, 21063, 21064, 21065, 21066, 21067, 21068, 21069, 21070, 21071, 21072, 21073, 21074, 21075, 21076, 21077, 21078, 21079, 9046870, 9046871, 9046872, 9070436, 9070437, 9070438, 9070439, 9070440, 1010543 };
    }
}