using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G3Motor
{
    public sealed class Entity
    {
        private string description;
        private DateTime fromDate;
        private DateTime toDate;
        private byte[] usagePattern;
        private int usageCategory;
        private double powerUsage;
        private int resolution;
        private int entities;

        public Entity(string description, DateTime fromDate, DateTime toDate, byte[] usagePattern, int usageCategory, double powerUsage, int resolution, int entities)
        {
            this.description    = description;
            this.fromDate       = fromDate;
            this.toDate         = toDate;
            this.usagePattern   = usagePattern;
            this.usageCategory  = usageCategory;
            this.powerUsage     = powerUsage;
            this.resolution     = resolution;
            this.entities       = entities;
        }

        private bool turnedOn(int minutesSinceDayStart)
        {
            int bitNumber = minutesSinceDayStart % 8;
            byte b = usagePattern[(minutesSinceDayStart - bitNumber) / 8];
            return (b & (1 << bitNumber - 1)) != 0;
        }

        public double[] getDailyUsage()
        {
            double[] usage = new double[resolution];
            for (int i = 0; i < resolution; i++)
            {
                if (turnedOn(i))
                {
                    usage[i] = powerUsage * entities;
                }
            }
            return usage;
        }

    }
}
