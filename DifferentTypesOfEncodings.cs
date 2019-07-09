using System;
using System.Text;

namespace EncodingsFun
{
    internal class DifferentTypesOfEncodings
    {
        // The characters to encode:
        //    Latin Small Letter Z (U+007A)
        //    Latin Small Letter A (U+0061)
        //    Combining Breve (U+0306)
        //    Latin Small Letter AE With Acute (U+01FD)
        //    Greek Small Letter Beta (U+03B2)
        //    a high-surrogate value (U+D8FF)
        //    a low-surrogate value (U+DCFF)
        static char[] myChars = new char[] { 'z'}; //, 'a', '\u0306', '\u01FD', '\u03B2', '\uD8FF', '\uDCFF' };
        static Encoding u7, u8, u16LE, u16BE, u32;

        internal static void Run()
        {
            Console.WriteLine($"{nameof(DifferentTypesOfEncodings)} ctor");
            // Get different encodings.
            u7 = Encoding.UTF7;
            u8 = Encoding.UTF8;
            u16LE = Encoding.Unicode;
            u16BE = Encoding.BigEndianUnicode;
            u32 = Encoding.UTF32;

            // Encode the entire array, and print out the counts and the resulting bytes.
            PrintCountsAndBytes(myChars, u7);
            PrintCountsAndBytes(myChars, u8);
            PrintCountsAndBytes(myChars, u16LE);
            PrintCountsAndBytes(myChars, u16BE);
            PrintCountsAndBytes(myChars, u32);
        }



        internal static void PrintCountsAndBytes(char[] chars, Encoding enc)
        {
            var encTypeNameLength = enc.ToString().Length > 25 ? 25 : enc.ToString().Length;
            var encoding = enc.ToString().Substring(0,encTypeNameLength);
            int iBC = enc.GetByteCount(chars);//exact byte count.
            int iMBC = enc.GetMaxByteCount(chars.Length); // maximum byte count.

            Console.Write($"{encoding,-28}: [ {iBC} / {iMBC} ] => ");
            
            // Encode the array of chars.
            byte[] bytes = enc.GetBytes(chars);

            // Display all the encoded bytes.
            PrintHexBytes(bytes);
        }


        internal static void PrintHexBytes(byte[] bytes)
        {

            if ((bytes == null) || (bytes.Length == 0))
                Console.WriteLine("<none>");
            else
            {   
                for (int i = 0; i < bytes.Length; i++)
                    Console.Write("{0,-3:X2} ", bytes[i]);
                Console.WriteLine();
                //Console.Write($"{"",41} => ");
                
                // for (int i = 0; i < bytes.Length; i++)
                //     Console.Write("{0,-3} ", bytes[i]);

                // Console.WriteLine();
            }
        }
    }
}