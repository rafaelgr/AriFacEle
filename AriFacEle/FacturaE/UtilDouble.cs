using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaE
{
    public abstract class DoubleFixedDecimalType
    {
        protected double value;

        public DoubleFixedDecimalType()
        {
            value = 0;
        }

        public DoubleFixedDecimalType(double value)
        {
            this.value = value;
        }

        [System.Xml.Serialization.XmlText()]
        public abstract string Value { get; set; }
    }

    public class DoubleTwoDecimalType : DoubleFixedDecimalType
    {
        public DoubleTwoDecimalType() : base()
        {
        }

        public DoubleTwoDecimalType(double value) : base(value)
        {
        }

        public static implicit operator double(DoubleTwoDecimalType o)
        {
            return o.value;
        }

        public static implicit operator DoubleTwoDecimalType(double value)
        {
            return new DoubleTwoDecimalType(value);
        }

        [System.Xml.Serialization.XmlText()]
        public override string Value
        {
            get
            {
                //return value.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
                //return String.Format("{0:0.00}", value);
                return value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            }
            set
            {
                this.value = System.Convert.ToDouble(value);
            }
        }
    }

    public class DoubleFourDecimalType : DoubleFixedDecimalType
    {
        public DoubleFourDecimalType() : base()
        {
        }

        public DoubleFourDecimalType(double value) : base(value)
        {
        }

        public static implicit operator double(DoubleFourDecimalType o)
        {
            return o.value;
        }

        public static implicit operator DoubleFourDecimalType(double value)
        {
            return new DoubleFourDecimalType(value);
        }

        [System.Xml.Serialization.XmlText()]
        public override string Value
        {
            get
            {
                //return value.ToString("F4", System.Globalization.CultureInfo.InvariantCulture);
                return value.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
            }
            set
            {
                this.value = System.Convert.ToDouble(value);
            }
        }
    }

    public class DoubleSixDecimalType : DoubleFixedDecimalType
    {
        public DoubleSixDecimalType() : base()
        {
        }

        public DoubleSixDecimalType(double value) : base(value)
        {
        }

        public static implicit operator double(DoubleSixDecimalType o)
        {
            return o.value;
        }

        public static implicit operator DoubleSixDecimalType(double value)
        {
            return new DoubleSixDecimalType(value);
        }

        [System.Xml.Serialization.XmlText()]
        public override string Value
        {
            get
            {
                //return value.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
                return value.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture);
            }
            set
            {
                this.value = System.Convert.ToDouble(value);
            }
        }
    }
}
