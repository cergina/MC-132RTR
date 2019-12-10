using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Support
{
    class Endorsment
    {
        // ENABLING OF SENDING
        public static bool SENDING_POSSIBLE = true;

        public static string COMMENT { get; private set; } = "" +
            "This project was developed at FIIT STU\n" +
            "for summer semester 2020, subject WAN\n" +
            "Student: Maroš Čergeť\n" +
            "private repo on GitHub: /cergina/MC-132RTR\n" +
            "   Ask for access to see more";
    }
}
