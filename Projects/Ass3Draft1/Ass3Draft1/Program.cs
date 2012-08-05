using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ass3Draft1
{
    class Program
    {
        static void Main(string[] args)
        {
/*
Constant Flow Valve
Attributes:
Serial Number (unique 6 digit/alphanumeric and cannot be modified)
Status: (on/off)
Subtype (low flow‐rate, medium flow‐rate, high flow‐rate)
Flow is constant (determined by subtype: 10m/s, 21m/s, 29m/s)
Methods:
Turn off (change status to off if on, otherwise do nothing)
Turn on (change status to on if off, otherwise do nothing)
Variable Flow Valve
Attributes * 3) m/s
Methods:
Turn off (chan:
Serial Number (6 digit unique number and cannot be modified)
Status: (on/off)
Valve setting (1 through 10 inclusive in increments of 1)
Flow = (Valve settingge status to off if on, otherwise do nothing)
Turn on (change status to on if off, otherwise do nothing)
Increment Valve setting by number up to max (default 1)
Decrement Valve setting by number down to min (default 1)
*/

            List<Valve> ListOfValves = new List<Valve>();


            ConstantFlowValve test = new ConstantFlowValve("123456", true, 1);
            

            Console.WriteLine("================================================================");
            Console.WriteLine("\tAss3_110352329");
            Console.WriteLine("\tVALVE PROGRAM");
            Console.WriteLine();
            Console.WriteLine("Main: What do you want to do?");
            Console.WriteLine();
            Console.Write("1. Create a new valve  2. View Valve   3. EditValve    4. Exit  :=");
            
            
            
            int ListCounter = 0;
            
            int Mainselector = int.Parse(Console.ReadLine());
            while (Mainselector != 4)//exit no.
            {
                if (Mainselector == 1) //MAIN SELECTOR OPTION 1
                {
                    //constant valve
                    Console.WriteLine();
                    Console.WriteLine("Do you want a constant valve or variable valve");
                    Console.Write("1. Constant Valve    2. Variable Valve:=");
                    int ValveSelector = int.Parse(Console.ReadLine());
                    if (ValveSelector == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have selected create a new constant valve");
                        Console.Write("Insert 6 digit Serial No:=");
                        string LSerialNumber = Console.ReadLine();
                        int LSerialNumberIncrementer = 0;

                        while (LSerialNumber.Count() != 6) //looped length check, runs this check simple check for the first.
                        {
                            Console.WriteLine("Incorrect length, please try again");
                            Console.Write("Insert 6 digit Serial No:=");
                            LSerialNumber = Console.ReadLine();
                            LSerialNumberIncrementer = 0;
                        }

                        if (ListCounter > 0)
                        {
                            while (LSerialNumberIncrementer + 1 <= ListOfValves.Count) // followed by unique number checker
                            {


                                if (LSerialNumber == ListOfValves[LSerialNumberIncrementer].SerialNumber.ToString()) //loops this 
                                {
                                    Console.WriteLine("Serial Number has been used, please try again");
                                    Console.Write("Insert 6 digit Serial No:=");
                                    LSerialNumber = Console.ReadLine();
                                    while (LSerialNumber.Count() != 6) //looped length check,
                                    {
                                        Console.WriteLine("Incorrect length, please try again");
                                        Console.Write("Insert 6 digit Serial No:=");
                                        LSerialNumber = Console.ReadLine();

                                    }
                                    LSerialNumberIncrementer = 0;
                                    //you want the process to start from zero again

                                }


                                else
                                {
                                    LSerialNumberIncrementer++;
                                }


                            }

                        }



                        Console.WriteLine();
                        Console.Write("Status? 1. On    2. Off :=");
                        int LStatusint = int.Parse(Console.ReadLine());
                        bool LStatusbool = true;
                        if (LStatusint == 1)
                        {
                            LStatusbool = true;
                        }
                        else if (LStatusint == 2)
                        {
                            LStatusbool = false;
                        }
                        Console.WriteLine();
                        Console.Write("Subtype? 1. Low  2. Medium  3. High :=");
                        int LSubtype = int.Parse(Console.ReadLine());
                        ListOfValves.Add(new ConstantFlowValve(LSerialNumber, LStatusbool, LSubtype));
                        //check if serial number is original...
                        Console.WriteLine(ListOfValves[ListCounter]);
                        ListCounter++;
                    }

                    else if (ValveSelector == 2)//variable valve selector
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have selected create a new variable valve");
                        Console.Write("Insert 6 digit Serial No :");
                        string LSerialNumber = Console.ReadLine();




                        int LSerialNumberIncrementer = 0;

                        while (LSerialNumber.Count() != 6) //looped length check, runs this check simple check for the first.
                        {
                            Console.WriteLine("Incorrect length, please try again");
                            Console.Write("Insert 6 digit Serial No:=");
                            LSerialNumber = Console.ReadLine();
                            LSerialNumberIncrementer = 0;
                        }

                        if (ListCounter > 0)
                        {
                            while (LSerialNumberIncrementer + 1 <= ListOfValves.Count) // followed by unique number checker
                            {


                                if (LSerialNumber == ListOfValves[LSerialNumberIncrementer].SerialNumber.ToString()) //loops this 
                                {
                                    Console.WriteLine("Serial Number has been used, please try again");
                                    Console.Write("Insert 6 digit Serial No:=");
                                    LSerialNumber = Console.ReadLine();
                                    while (LSerialNumber.Count() != 6) //looped length check,
                                    {
                                        Console.WriteLine("Incorrect length, please try again");
                                        Console.Write("Insert 6 digit Serial No:=");
                                        LSerialNumber = Console.ReadLine();

                                    }
                                    LSerialNumberIncrementer = 0;
                                    //you want the process to start from zero again

                                }


                                else
                                {
                                    LSerialNumberIncrementer++;
                                }


                            }

                        }

                        Console.WriteLine();
                        Console.Write("Status? 1. On 2. Off :");
                        int LStatusint = int.Parse(Console.ReadLine());
                        bool LStatusbool = true;
                        if (LStatusint == 1)
                        {
                            LStatusbool = true;
                        }
                        else if (LStatusint == 2)
                        {
                            LStatusbool = false;
                        }
                        Console.WriteLine();
                        Console.Write("Valve Setting (1 - 10) :");
                        int LValveSetting = int.Parse(Console.ReadLine());
                        ListOfValves.Add(new VariableFlowValve(LSerialNumber, LStatusbool, LValveSetting));

                        Console.WriteLine(ListOfValves[ListCounter]);
                        ListCounter++;
                    }


                }

                else if ((Mainselector == 2 || Mainselector == 3) && ListOfValves.Count == 0)
                {
                    Console.WriteLine("No Valves have yet been created");
                }
                else if (Mainselector == 2 && ListOfValves.Count != 0)//MAIN SELECTOR Option 2
                {
                    if (ListOfValves.Count != 0)//if you haven't actually created any objects
                    {
                        int ListIncrementer = 0;
                        Console.WriteLine();
                        Console.WriteLine("Select Valve to view");
                        while (ListIncrementer <= ListOfValves.Count - 1)
                        {
                            Console.WriteLine("{0}:= {1}", ListIncrementer, ListOfValves[ListIncrementer].SerialNumber);
                            ListIncrementer++;
                        }
                        Console.Write("Valve Index No:= ");
                        int ValveIndexViewer = int.Parse(Console.ReadLine());
                        Console.WriteLine(ListOfValves[ValveIndexViewer]);
                    }


                }

                else if (Mainselector == 3 && ListOfValves.Count != 0)//MAIN SELECTOR Option 3
                {
                    int ListIncrementer = 0;
                    Console.WriteLine();
                    Console.WriteLine("Select Valve to view");
                    while (ListIncrementer <= ListOfValves.Count - 1)
                    {
                        Console.WriteLine("{0}:= {1}", ListIncrementer, ListOfValves[ListIncrementer].SerialNumber);
                        ListIncrementer++;
                    }
                    Console.WriteLine();
                    Console.Write("Valve Index No:= ");
                    int ValveIndexViewer = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("You have selected := {0}", ListOfValves[ValveIndexViewer].SerialNumber);

                    //if certain type... allow certain to do certain stuff...
                    if (ListOfValves[ValveIndexViewer] is ConstantFlowValve)//edit constant flow valve
                    {
                        Console.WriteLine();
                        Console.WriteLine("Do you want turn on or off?  1.Turn On    2. Turn Off    3.Leave it Alone");
                        int TurnOnOff = int.Parse(Console.ReadLine());
                        if (TurnOnOff == 1)
                        { ListOfValves[ValveIndexViewer].TurnOn(); Console.WriteLine("You have turned {0} ON", ListOfValves[ValveIndexViewer].SerialNumber); }
                        else if (TurnOnOff == 2)
                        { ListOfValves[ValveIndexViewer].TurnOff(); Console.WriteLine("You have turned {0} OFF", ListOfValves[ValveIndexViewer].SerialNumber); }
                        else if (TurnOnOff == 3)
                        {
                        }


                    }

                    else if (ListOfValves[ValveIndexViewer] is VariableFlowValve)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Do you want turn on or off?  1.Turn On    2. Turn Off    3. Leave it Alone");
                        int TurnOnOff = int.Parse(Console.ReadLine());
                        if (TurnOnOff == 1)
                        { ListOfValves[ValveIndexViewer].TurnOn(); Console.WriteLine("You have turned {0} ON", ListOfValves[ValveIndexViewer].SerialNumber); }
                        else if (TurnOnOff == 2)
                        { ListOfValves[ValveIndexViewer].TurnOff(); Console.WriteLine("You have turned {0} OFF", ListOfValves[ValveIndexViewer].SerialNumber); }
                        else if (TurnOnOff == 3)
                        { }

                        Console.WriteLine();
                        Console.Write("Do you want to adjust flow setting? 1. Yes   2. No?");
                        int AdjustVarFlowSettingYesNo = int.Parse(Console.ReadLine());
                        if (AdjustVarFlowSettingYesNo != 1 && AdjustVarFlowSettingYesNo != 2)
                        { Console.WriteLine("Invalid Input"); }

                        else if (AdjustVarFlowSettingYesNo == 1)
                        {
                            Console.Write("Valve Setting (1 - 10) :");
                            //copy info and replace old object with new object.
                            int LValveSetting = int.Parse(Console.ReadLine());
                            VariableFlowValve LVariableFlowValveCopy = new VariableFlowValve(ListOfValves[ValveIndexViewer].SerialNumber, ListOfValves[ValveIndexViewer].Status, LValveSetting);

                            ListOfValves[ValveIndexViewer] = LVariableFlowValveCopy;




                        }
                        else if (AdjustVarFlowSettingYesNo == 2)
                        {
                        }


                    }


                }

                    //Main Question
                Console.WriteLine("Main: What do you want to do?");
                Console.WriteLine();
                Console.Write("1. Create a new valve  2. View Valve   3. EditValve    4. Exit   :=");
            
                Mainselector = int.Parse(Console.ReadLine());
                
            
            }
            Console.WriteLine("Bye bye :)");

            Console.ReadLine();


        }

        
    }
}
