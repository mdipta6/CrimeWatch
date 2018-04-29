using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App4
{

    namespace ConsoleApp1
    {
        using QuickType;
        class ListStats
        {
            private double avgFelony = 0;
            private double avgMis = 0;
            private List<Crime> crimesList = new List<Crime>();
            private string jsonString;
            int[] complaintsPerPrecinct = new int[123];
            int[] felonyComplaintsPerPrecinct = new int[123];
            int[] otherComplaintsPerPrecinct = new int[123];
            List<int> dangerousFelony = new List<int>();
            List<int> dangerousMis = new List<int>();
            List<int> existingPrecinct = new List<int>();
            //
           
        //
            public void dangerdangerHighVoltage()
            {
                foreach (var item in existingPrecinct)
                {
                    if (felonyComplaintsPerPrecinct[item] > avgFelony)
                    {
                        dangerousFelony.Add(item);

                    }
                    if (otherComplaintsPerPrecinct[item] > avgMis)
                    {
                        dangerousMis.Add(item);
                    }
                }
            }
            public void getFgetM()
            {
                double fCount = 0;
                double mCount = 0;
                foreach (var item in existingPrecinct)
                {
                    fCount += felonyComplaintsPerPrecinct[item];
                    mCount += otherComplaintsPerPrecinct[item];
                }
                avgFelony = fCount / existingPrecinct.Count();
                avgMis = mCount / existingPrecinct.Count();
            }

            public void getJsonString(string s)
            {
                string line = System.IO.File.ReadAllText(s);
                jsonString = line;
            }
            public void fillList()
            {
                crimesList = Crime.FromJson(jsonString);
            }


            public void countComplaints()
            {
                foreach (var item in crimesList.ToList())
                {
                    int precinctNum = Convert.ToInt32(item.AddrPctCd);

                    complaintsPerPrecinct[precinctNum - 1]++;
                    if (!existingPrecinct.Contains(precinctNum))
                    {
                        existingPrecinct.Add(precinctNum);
                    }
                    if (Convert.ToString(item.LawCatCd) == "Felony")
                    {
                        felonyComplaintsPerPrecinct[precinctNum - 1]++;
                    }
                    else
                    {
                        otherComplaintsPerPrecinct[precinctNum - 1]++;
                    }


                }

            }

        }
    }

}