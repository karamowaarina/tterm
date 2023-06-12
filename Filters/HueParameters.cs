using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class HueParameters : IParameters
    {
        public double Coefficient { get; set; }
        public ParameterInfo[] GetDecription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Коэффициент",
                    MinValue = 0,
                    MaxValue = 360,
                    DefaultValue = 0,
                    Increment = 1
                }
            };
        }

        public void SetValues(double[] values)
        {
            Coefficient = values[0];
        }
    }
}