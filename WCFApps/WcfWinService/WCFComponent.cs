//Add the references of the WCF libraries: System.ServiceModel and System.Runtime.Serialization...
using System;
using System.ServiceModel;

namespace WcfWinService
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        double SquareOfNumber(double no);

        [OperationContract]
        double SquareRootOfNumber(double no);        
    }

    public class MathComponent : IMathService
    {
        public double SquareOfNumber(double no)
        {
            return no * no;
        }

        public double SquareRootOfNumber(double no)
        {
            return Math.Sqrt(no);
        }
    }
}