using System;

namespace BTI_3
{
    class Program
    {
        static int x;
        static int y;
        static String encryptMessage(char[] msg)
        {
            String cipher = "";

            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] != ' ')
                {
                    cipher = cipher
                    + (char)((((x * (msg[i] - 'A')) + y) % 26) + 'A');
                }
                else
                {
                    cipher += msg[i];
                }
            }
            return cipher;
        }
        static String decryptCipher(String cipher)
        {
            String msg = "";
            int x_inv = 0;
            int flag = 0;

            for (int i = 0; i < 26; i++)
            {
                flag = (x * i) % 26;
                if (flag == 1)
                {
                    x_inv = i;
                }
            }

            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] != ' ')
                {
                    msg = msg + (char)(((x_inv *
                    ((cipher[i] + 'A' - y)) % 26)) + 'A');
                }
                else
                {
                    msg += cipher[i];
                }
            }
            return msg;
        }
        public static void Main(String[] args)
        {
            while (true)
            {
                Console.Write("Test/słowo do zaszyfrowania: ");
                String msg = Console.ReadLine();
                msg = msg.ToUpper();
                Console.Write("x = ");
                x = int.Parse(Console.ReadLine());
                Console.Write("y = ");
                y = int.Parse(Console.ReadLine());
                String cipherText = encryptMessage(msg.ToCharArray());
                Console.WriteLine("\n ---------------------- \n");
                Console.WriteLine("Zaszyfrowane słowo/tekst: " + cipherText);
                Console.WriteLine("Odszyfrowane słowo/tekst: " + decryptCipher(cipherText));
                Console.WriteLine("\n ---------------------- \n");
            }
        }
    }
}
