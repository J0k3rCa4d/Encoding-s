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
            //TODO 
            // UTF8 - 1-4 bytes encoding 
            // C# int16 (default is 32 ) 1-4 byte
            // Print table of all existing characters usign int16

            var parameter = args.ToList().FirstOrDefault() ?? "0";
            var unicodeLastCharacter_Decimal = Int16.Parse(parameter);
            var unicodeLastCharacter_ByteArray = BitConverter.GetBytes(unicodeLastCharacter_Decimal);
            var unicodeLastCharacter_Hex = $"0x{unicodeLastCharacter_Decimal:X}";
            var unicodeLastCharacter_Char = UnicodeEncoding.Unicode.GetChars(bytes,0,1);

            var characters = "hello";
            var numberRepresentationOfString = System.Text.UnicodeEncoding.UTF8.GetBytes(characters);


            Console.WriteLine($"{characters} -> {String.Join(' ',numberRepresentationOfString)}");
            Console.WriteLine($"INT:{unicodeLastCharacter_Decimal}"+ Environment.NewLine +
            $@" -> BYTES:   [ {String.Join(' ',unicodeLastCharacter_ByteArray)} ]"+ Environment.NewLine +
            $@" -> HEX  :   [ {String.Join(' ',unicodeLastCharacter_Hex)} ]"+ Environment.NewLine +
            $@" -> Unicode: [ {String.Join(' ',unicodeLastCharacter_Char)} ]");
        }
    }
}
