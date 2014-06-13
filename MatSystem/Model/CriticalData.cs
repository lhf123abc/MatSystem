using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Model
{
    public struct CriticalData
    {
        private int generatorId;//电机号
        private string lcNum;//下位机序列号
        private float oilPress;
        private float waterTemp;
        private float frequency;
        private float motorSpeed;
        private float voltage;
        private float current;
        private float motorPower;
        private float powerFactor;
        private float oilMass;
        private int alarmValue;
        private DateTime dateTime;

        public string LcNum
        {
            get
            {
                return lcNum;
            }
            set
            {
                lcNum = value;
            }
        }

        public int GeneratorId
        {
            get
            {
                return generatorId;
            }
            set
            {
                generatorId = value;
            }
        }

        public float OilPress
        {
            get
            {
                return this.oilPress;
            }
            set
            {
                oilPress = value;
            }
        }

        public float WaterTemp
        {
            get
            {
                return waterTemp;
            }
            set
            {
                waterTemp = value;
            }
        }

        public float Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
            }
        }

        public float MotorSpeed
        {
            get
            {
                return motorSpeed;
            }
            set
            {
                motorSpeed = value;
            }
        }

        public float Voltage
        {
            get
            {
                return voltage;
            }
            set
            {
                voltage = value;
            }
        }

        public float _Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }

        public float MotorPower
        {
            get
            {
                return motorPower;
            }
            set
            {
                motorPower = value;
            }
        }

        public float PowerFactor
        {
            get
            {
                return powerFactor;
            }
            set
            {
                powerFactor = value;
            }
        }

        public float OilMass
        {
            get
            {
                return oilMass;
            }
            set
            {
                oilMass = value;
            }
        }

        public int AlarmValue
        {
            get
            {
                return alarmValue;
            }
            set
            {
                alarmValue = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
            }
        }
        public CriticalData(string lcNum, int number, float oilPress, float waterTemp, float frequency, float motorSpeed, float voltage, float current, float motorPower, float powerFactor, float oilMass, int alarmValue, DateTime date)
        {
            this.lcNum = lcNum;
            this.generatorId = number;
            this.oilPress = oilPress;
            this.waterTemp = waterTemp;
            this.frequency = frequency;
            this.motorSpeed = motorSpeed;
            this.voltage = voltage;
            this.current = current;
            this.motorPower = motorPower;
            this.powerFactor = powerFactor;
            this.oilMass = oilMass;
            this.alarmValue = alarmValue;
            this.dateTime = date;
        }

    }
}
