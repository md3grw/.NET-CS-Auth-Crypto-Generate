using SilevenText.Graphics;
using SilevenText.Menu;
using SilevenText.WorkWithFiles;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Cipher
{
    public enum CipherActionCode
    {
        Encryption,
        Decryption,
        Null,
    }

    public enum TypeOfSavings
    {
        ResultAsFile,
        ResultAsText,
        Null,
    }

    public enum TypeOfCipher
    {
        Caesar,
        ME,
        Vigenere,
        Null,
    }

    internal class CipherHandler
    {
        public void HandleChoice(TypeOfCipher encryptionType, CipherActionCode encryptOrDecrypt, TypeOfSavings typeOfSavings)
        {
            if (encryptionType == TypeOfCipher.Caesar) { HandleCipher(new CaesarCipher(), encryptOrDecrypt, typeOfSavings); }
            else if (encryptionType == TypeOfCipher.ME) { HandleCipher(new MECipher(), encryptOrDecrypt, typeOfSavings); }
            else if (encryptionType == TypeOfCipher.Vigenere) { HandleCipher(new VigenereCipher(), encryptOrDecrypt, typeOfSavings); }
        }

        private void HandleCipher(ICipher cipher, CipherActionCode encryptOrDecrypt, TypeOfSavings typeOfSavings)
        {
            Console.Clear();

            string text = TextInput.AskForText("Please input text: ");
            if (TextInput.HandleInput(text) == false) return;

            Console.Clear();

            string key = TextInput.AskForText("Please input key: ");
            if (TextInput.HandleInput(key) == false) return;

            if (encryptOrDecrypt == CipherActionCode.Encryption) 
            {
                if (typeOfSavings == TypeOfSavings.ResultAsText)
                {
                    Console.Clear();

                    new GameGraphics().PrintText(25, 9, "Your encrypted text:", ConsoleColor.Green);
                    new GameGraphics().PrintText(25, 10, cipher.Encrypt(text, key), ConsoleColor.Green);

                    Console.SetCursorPosition(25, 11);
                    Console.Write("Press any button...");
                    Console.ReadKey(true);
                }
                else if (typeOfSavings == TypeOfSavings.ResultAsFile)
                {
                    string path = TextInput.AskForText("Please input path: ");
                    if (TextInput.HandleInput(path) == false) return;

                    new FileManager().WriteToFile(path, cipher.Encrypt(text, key));

                    Console.Clear();
                    new GameGraphics().PrintText(25, 9, "Text was successfully encrypted:", ConsoleColor.Green);
                    
                    Console.SetCursorPosition(25, 11);
                    Console.Write("Press any button...");
                    Console.ReadKey(true);
                }
            }

            else if (encryptOrDecrypt == CipherActionCode.Decryption)
            {
                if (typeOfSavings == TypeOfSavings.ResultAsText)
                {
                    Console.Clear();
                    new GameGraphics().PrintText(25, 9, "Your decrypted text:", ConsoleColor.Green);
                    new GameGraphics().PrintText(25, 10, cipher.Decrypt(text, key), ConsoleColor.Green);

                    Console.SetCursorPosition(25, 11);
                    Console.Write("Press any button...");
                    Console.ReadKey(true);
                }
                else if (typeOfSavings == TypeOfSavings.ResultAsFile)
                {
                    string path = TextInput.AskForText("Please input path: ");

                    new FileManager().WriteToFile(path, cipher.Decrypt(text, key));

                    Console.Clear();
                    new GameGraphics().PrintText(25, 9, "Text was successfully decrypted:", ConsoleColor.Green);

                    Console.SetCursorPosition(25, 11);
                    Console.Write("Press any button...");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
