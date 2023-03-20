using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT10
    {
        byte[] data;
         string TYP;
        string SYM;
        string DCR;
        string CHN;
        string CRT;
        string FX;
        string GBS;
        string SIM;
        string TST;
        string RAB;
        string SPI;
        string TOT;
        string LOP;


        double h;
        double Timeoftheday;

        double RHO;
        double THETA;

        int SAC;
        int SIC;
        int TrackNumb;
        int PAM;


        public CAT10(byte[] message)
        {
            
            this.data = message;
            

            // Aqui dentro vamos a ir decodificando el mensaje usando las funciones que vamos
            // a crear en esta misma clase. De esta manera, cuando llamemos a esta funcion ya
            // va a quedar todo decodificado
            
            


            //if (FSPEC[1]=='1')

            // DataSourdeIdentifier();



            //DataSourceIdentifier
            public void DataSourceIdentifier(string octet1, string octet2)
            {
                SAC = Functions.BinToNum(octet1);
                SIC = Functions.BinToNum(octet2);

            }
            // Data Item I010/020, Target Report Descriptor
            public void TargetReportDescriptor (string octet)
            {
                string TYPs =  octet[0] + octet[1] + octet[2];
                int Length = octet.Length;
                if (Length>=8)
                {
                    if (TYPs=="000")
                    {
                        TYP = "SSR multilateration";
                    }
                    if (TYPs=="001")
                    {
                        TYP = "Mode S multilateration";
                    }
                    if (TYPs== "010")
                    {
                        TYP = "ADS - B";
                    }
                    if (TYPs == "011")
                    {
                        TYP = "PSR";
                    }
                    if (TYPs == "100")
                    {
                        TYP = "Magnetic Loop System";
                    }
                    if (TYPs == "101")
                    {
                        TYP = "HF multilateration";
                    }
                    if (TYP == "110")
                    {
                        TYP = "Not defined";
                    }
                    if (TYPs == "111")
                    {
                        TYP = "Other types";
                    }
                    if (Convert.ToString(octet[3])== "0")
                    {
                        DCR = "No differential correction (ADS-B)";
                    }
                    if (Convert.ToString(octet[3]) == "1")
                     {
                        DCR = "Differential correction (ADS-B)";
                    }
                    if (Convert.ToString(octet[4]) == "0")
                    {
                        CHN = "Chain 1";

                    }
                    if (Convert.ToString(octet[4]) == "1")
                    {
                        CHN = "Chain 1";
                    }
                    if (Convert.ToString(octet[5]) == "0")
                    {
                        GBS = "Transponder Ground bit not set";

                    }
                    if (Convert.ToString(octet[5]) == "1")
                    {
                        GBS = "Transponder Ground bit set";
                    }
                    if (Convert.ToString(octet[6])== "0")
                    {
                        CRT = "No Corrupted reply in multilateration";
                    }
                    if (Convert.ToString(octet[6]) == "1")
                    {
                        CRT = "Corrupted replies in multilateration ";
                    }
                    if (Convert.ToString(octet[7])== "0")
                    {
                        FX = "End of Data Item";
                    }
                    if (Convert.ToString(octet[7])== "1")
                    {
                        FX = "Extension into first extent ";

                            if (Convert.ToString(octet[8]) == "0")
                            {
                                SIM = "Actual target report ";
                            }
                            if (Convert.ToString(octet[8]) == "1")
                            {
                                SIM = " Simulated target report";

                            }
                            if (Convert.ToString(octet[9]) == "0")
                            {
                                TST = "Default";
                            }
                            if (Convert.ToString(octet[9]) == "1")
                            {
                                TST = "Test Target";
                            }
                            if (Convert.ToString(octet[10]) == "0")
                            {
                                RAB = "Report from target transponder";
                            }
                            if (Convert.ToString(octet[10]) == "1")
                            {
                                RAB = "Report from field monitor(fixed transponder)";
                            }
                            if (Convert.ToString(octet[11]+ Convert.ToString(octet[12]) == "00")
                            {
                                LOP = "Undetermined";
                            }
                            if (Convert.ToString(octet[11]+ Convert.ToString(octet[12]) == "01")
                            {
                                LOP = "Loop start";
                            }
                            if (Convert.ToString(octet[11]) + Convert.ToString(octet[12])== "10")
                            {
                                LOP = "Loop finish";
                            }
                            if (Convert.ToString(octet[13]+ Convert.ToString(octet[14])) == "00")
                            {
                                TOT = "Undetermined";
                            }
                            if (Convert.ToString(octet[13]) + Convert.ToString(octet[14]) == "01")
                            {
                                TOT = "Aircraft";
                            }
                            if (Convert.ToString(octet[13]+ Convert.ToString(octet[14])) == "10")
                            {
                                TOT = "Ground vehicle";
                            }

                            if (Convert.ToString(octet[13]Convert.ToString(octet[14])) == "11")
                            {
                                TOT = "Helicopter";
                            }
                    }
                    if (Length == 24)
                    {
                        if (Convert.ToString(octet[15])+Convert.ToString(octet[16]) == "01")
                        {
                            SPI= "Absence of SPI ";
                        }
                        if (Convert.ToString(octet[15])+ Convert.ToString(octet[16]) == "10")
                        {
                             SPI = "Special Position Identification";
                        }

                    }
                } 

            }
            //Data Item I010/040, Measured Position in Polar Co-ordinates
            public void MeasuredPositioninPolarCoordinates (string octet1, string octet2, string octet3, string octet4)
            {
                    double LSB_RHO =1;
                    double LSB_theta = 360/(2^16);
                    RHO = Convert.ToDouble(Functions.BinToNum(octet1) + Functions.BinToNum(octet2)) * LSB_RHO;
                   THETA = Convert.ToDouble(Functions.BinToNum(octet3)+ Functions.BinToNum(octet4)) * LSB_theta;

            }
            // Data Item I010/091, Measured Height
            public void MeasuredHeight(string octeto1, string octeto2)
            {
                    double LSB = 6.25;
                    int hbin = Functions.BinToNum(octeto1 + octeto2);
                    h = Convert.ToDouble(hbin) * LSB;

            }
            //Data Item I010/131, Amplitude of Primary Plot
            public void AmplitudPrimayPlot(string octeto)
            {
                PAM = Functions.BinToNum(octeto);
            } 
            // Data Item I010/140: Time of Day
            public void TimeofDay(string octet1,string octet2,string octet3)
            {
                    double LSB = 1 / 128;
                    string TimeofDaystring = octet1 + octet2 + octet3;
                    Timeoftheday =Convert.ToDouble(Functions.BinToNum(TimeofDaystring))*LSB ;
            }
            // Data Item I010/161: Track Number
            public void TrackNumber (string octet1, string octet2)
            {
                    TrackNumb = Functions.BinToNum(Convert.ToString(octet1[5]) + Convert.ToString(octet1[6]) + Convert.ToString(octet1[7]) + octet2);
            }
            //TargetAddress
            public void TargetAdress(string octet1, string octet2, string octet3)
            {



            }
            //Presence
            public void Presence ()
            { 

            }
            //VehicleFleetIdentification
            public void VehicleFleetIdentification()
            {

            }
            //PreprogrammedMessage
            public void PreprogrammeMessage() 
            { 

            }
            //StandardDeviationPosition
            public void StandardDeviationPosition 
            { 
            }
            //SystemStatusMessageType
            public void SystemStatusMessageType
            {




            }




        }
    }
}
