﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1_tester_
{
    abstract class AutoMobile : Vehicle
    {

        public int GasTank { get; private set; }
        public string Color { get;  set; }
        public int MilesPerGallon { get; private set; }
        private int _gasInTank;
        public int YearOfManufacturer { get; private set; }
        public virtual int Milage { get; protected set; } = 0;

        public string Model { get; private set; }

     

        public virtual int MilesToOilChange { get; protected set; } = 10000;

        //Constructor
        public AutoMobile(int gasTank, String color, int milesPerGallon, int yearOfManufacturer, string model)
        {
            Model = model;
            GasTank = gasTank;
            GasInTank = GasTank;
            Color = color;
            MilesPerGallon = milesPerGallon;
            YearOfManufacturer = yearOfManufacturer;
            IsLocked = true;
            if (yearOfManufacturer < 1905)
            {
                throw new Exception("Cars didn't exist in this time period.");
            }

        }

        //---------------------------------------------------------------------------------------------------------------

        //GasInTank property. It can only be set if the value is between gasTank and 0. If it is over or unnder it will throw an error.

        public int GasInTank
        {
            get { return _gasInTank; }
          protected  set {
               


                        if (value >= 0 && value <= GasTank)
                        {
                            _gasInTank = value;
                        }
                        if (value > GasTank) { throw new InvalidOperationException("You are over filling the gas tank!"); }

                        if (value <= 0) { throw new InvalidOperationException("There is no gas left in the tank."); }


                

               
            }


        }

      
      //----------------------------------------------------------------------------------------------------------------------------->


      // Is locked propertiues and all of it's methods.
      

        public virtual bool IsLocked { get; private set; }

        public void Unlock()
        {

            IsLocked = false;
        }

        public void Lock()
        {

            IsLocked = true;
        }


       //------------------------------------------------------------------------------------------------------------------------------------>


       // Fill() method. Fills up the GasIntank property


        public virtual void Fill()
        {
            GasInTank = GasTank;
        }
        //Fill method takes an integer and is wrapped around a try catch block. If they over fill the gas tank it will thorw an error. 
        public virtual void Fill(int gallonsOfGas)
        {
            
                GasInTank += gallonsOfGas;

        }


        //---------------------------------------------------------------------------------------------------------------------------------------->



        // If the the car is locked the code will throw an error. 
        // takes miles as an integer. Finds the amount of gallons used and then places it in a "while" loop. Every time the loop runs milage is added, GasInTank goes down by one
        // and the counter goes down by one.
        public virtual void Drive(int miles)
        {

           

            if (IsLocked == false && MilesToOilChange >= 0)
            {

                int gallonsUsed = miles / MilesPerGallon;
                int gallonsToGo = gallonsUsed;


                while (gallonsToGo > 0)
                {
                    Milage += MilesPerGallon;
                    GasInTank--;
                    Console.WriteLine("VROOM!");
                    gallonsToGo--;
                }

                if (GasInTank > 0)
                {
                    Console.WriteLine($"You have completed your {miles} mile journey. You have {GasInTank} gallon(s) left in the tank and this car has driven {Milage} miles.");
                }


            }




            
            else { throw new InvalidOperationException("Your car is locked. Unlock to drive."); }

            
            //miles to oil changes decreases every time you use the Drive() method. If MilesToOilChange() gets to zero it will throw an exception.
            MilesToOilChange -= miles;
            if (MilesToOilChange <= 0) { throw new InvalidOperationException("You need to get an oil change with the GetOilChange() method."); }




        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------------->



        // tow Interface set as a variable so we can pass down CanTow() method. Every child object can now specify wich CanTow() method is called creating ultimate flexability. 
        public ITowable SetTow;


        // PerformTowable is the CanTow method that the child class speicfies
        public void PerformTowable()
        {
                    SetTow.CanTow();
        }




        //-------------------------------------------------------------------------------------------------------------------------

        public void GetOilChange(int milesToNextOilChange)
        {
            MilesToOilChange += milesToNextOilChange;
            Console.WriteLine($"You have {milesToNextOilChange} miles until your next oil change.");
        }


     

}

}







