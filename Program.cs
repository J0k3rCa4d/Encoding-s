using System;
using System.Linq;
using System.Text;

namespace EncodingsFun
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[] {0b0000_0001};
            Encoding utf8 = Encoding.Unicode;

            var parameter = args.ToList().FirstOrDefault() ?? "0";
            Console.WriteLine($"--------------\nValue {parameter} in:\n--------------");
            
            var u_int16 = Int16.Parse(parameter);                // Two bytes ex. 255 255 = FF FF Unicode is char = 2 bytes
            var u_ByteArray = BitConverter.GetBytes(u_int16);    // Int16 to Array of bytes
            var u_Chars = utf8.GetChars(u_ByteArray);

            Console.WriteLine(
                $"-> Int:   {u_int16}\n\r"+
                $"-> Hex:   {u_int16:X2}\n\r"+
                $"-> Bytes: {String.Join(' ', u_ByteArray)}\n\r"+
                $"-> Chars: {new String(u_Chars)}"
            );
                             
            //DifferentTypesOfEncodings.Run();
            //UnicodeEncodingDecoding.Run();
        }
    }
}
