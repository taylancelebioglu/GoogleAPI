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
        public static List<int> GeoIdList = new List<int>(){           1012764,1012766,1012781,1012804,9056711,9056810,9056815,9056825,9056826,9056840,9056869,9056882,9073388,9056898,9056888,9056870,9056846,9056828,9056803,9056780,9056753,9056754,1009840,1009864,1009876,1009883,1009888,1030688,1009850,1001447,1001449,1001450,1001451,1001452,1001453,1001454,1001517,1001518,1001520,1001521,1001522,1001523,1001524,1001525,1001528,1001529,1001856,1001857,1001865,1001866,1001867,1001996,1001997,1002061,1002153,1002154,1002156,1002486,1002487,1002488,1002489,1003362,1003363,1003365,1003366,1003380,1003381,1003416,1003420,1003495,1003496,1003637,1003638,1003868,1003870,1003903,1003904,1003969,1003970,1004097,1004098,1004294,1004295,1004358,1004438,1004440,1004535,1004999,1006470,1006471,1006495,1006496,1006658,1006659,1006981,1006983,1007292,1007293,1007464,1007465,1007466,1007469,1007623,1007624,1007683,1007684,1007693,1007694,1007743,1007744,1007805,1007806,1007828,1007829,1007949,1008022,1008023,1008024,1008045,1008046,1008045,1008046,1008189,1008190,1008386,1008387,1008388,1008588,1008589,1008590,1009244,1009246,1009247,1009249,1009244,1009246,1009247,1009249,1009447,1009449,1009548,1009550,1009551,1009715,1009717,1010297,1010298,1010299,1010782,1010788,1010791,1010794,1010807,1010814,1011034,1011077,1011078,1011079,1011080,1011183,1011184,1011185,1011186,1011187,1011188,1011195,1011196,1011197,1011866,1011867,1011868,1012006,1012007,1012085,1012182,1012200,1012204,1012205,1012209,1012210,1012211,1012716,1012717,1012719,1012721,1012874,1012875,1012876,1012877,1012942,1012943,1012944,1012945,1016343,1016344,1028111,1028112,1028298,1028299,1029053,1029054,1029055,1029447,1029448,1029449,1029489,1029558,1029559,1029560,1029561,1029562,1029563,1029703,1029704,9040144,9040165,9040166,9040167,9040168,9040339,9040341,9040343,9040346,9072512,9072513
        };
    }
}