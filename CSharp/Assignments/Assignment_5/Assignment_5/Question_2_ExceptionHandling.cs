using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class InvalidMarksException:Exception
    {
        public InvalidMarksException(string message) : base(message) { }
    }
    class Scholarship
    {
        double Marks;
        double Fees;

        public Scholarship(double marks,double fees)
        {
            Marks = marks;
            Fees = fees;
        }

        public void Merit()
        {
            if(Marks>=70 && Marks<=80)
            {
                double discount = Fees * 0.2;
                Fees -= discount;
                Console.WriteLine($"Marks: {Marks} You get 20% Discount so Fees: {Fees}");
            }
            else if(Marks>=80 && Marks<=90)
            {
                double discount = Fees * 0.3;
                Fees -= discount;
                Console.WriteLine($"Marks: {Marks} You get 30% Discount so Fees: {Fees}");
            }
            else if(Marks>90)
            {
                double discount = Fees * 0.5;
                Fees -= discount;
                Console.WriteLine($"Marks: {Marks} You get 50% Discount so Fees: {Fees}");
            }
            else
            {
                throw new InvalidMarksException("Marks are not eligible for a scholarship.");
            }
        }
    }
    class Question_2_ExceptionHandling
    {
        public static void Main()
        {
            Console.Write("Enter Marks: ");
            double marks = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Fees: ");
            double fees = Convert.ToDouble(Console.ReadLine());
            Scholarship scholarship = new Scholarship(marks, fees);
            try
            {
                scholarship.Merit();
            }
            catch(InvalidMarksException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.Read();
        }
    }
}
