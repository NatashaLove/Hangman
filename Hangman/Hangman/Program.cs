using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        // Start the programming exercise by defining each of the user-created
        // methods for this program. 
        //
        /*
         * @name - DisplayWord
         * @param - params char[] letters
         * @return - string
         * 
         * @description - accepts a paramatarized array of characters and
         *      generates a string made up of the characters in order.
         */
        static string DisplayWord(params char[] letters)
        {
            // create a string with an empty set
            string word = "";

            // loops through the letters param and concatenate each letter to
            // the end of the string

            int i = 0;
            // this method - because you CAN'T display char array [] with Console.Write
            while (i< letters.Length)
            {
                word += letters[i];
                i++;
            }
            // but overall better not to use this methods, there are string builders - better to use them.
            // if rewrite a new word every time - takes a new memory for every string (doesn't update them)
            
            // return the string
            return word;
        }

        /*
         * @name - FillArray
         * @param - char[] a
         * @param - char c
         * @return - void
         * 
         * @description - loops through the array of characters (a) and fills
         *      it with an assigned character (c)
         */
         // This array below will be filled with selected chars : "-" or "*"
        static void FillArray(char[] a, char c)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = c;
            }
        }

        /*
         * @name - GetWord
         * @param - string[] WordList
         * @return - char[]
         * 
         * @description - accepts an array of strings and chooses one to play
         *      the game with.
         */
        static char[] GetWord(string[] wordList)
        {
            //picks a random word from the ready list of words and turns the word into char array:
            Random rand = new Random();
            // the method randomly picks a word (number of word position) from the list of words and then turns it to chars
            return wordList[rand.Next(0, wordList.Length)].ToCharArray();// this method - ToCharArray()- takes a string and returns array of chars
        }

        /*
         * @name - GetValidCharacter
         * @param - out char validChar
         * @return - void
         * 
         * @description - Asks the user to pick a letter and verifies that the
         *      entry is a valid character.
         */
        static void GetValidCharacter(out char validChar)
        {
            // create a loop that you will break out of when the letter is valid
            // This do-while loop is checking if the input can be parsed into char - if yes - break and continue; else- do again: 
            do
            {
                // ask the user for a letter
                Console.Write("Pick a letter: ");

                // try to parse the input into a char. Display a message is it
                // is not a valid character

                if (Char.TryParse(Console.ReadLine(), out validChar)) // validChar - is the char from the user input
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid character.");
                }

            } while (true);
        }

        /*
         * @name - CheckForLetter
         * @param - char letter
         * @param - char[] word
         * @param - char[]display
         * 
         * @description - Loop through the word array, checking to see if the
         *      guessed letter is found in the array. If it is, update the
         *      display array with the guessed letter. Then, set the boolean 
         *      variable to true to denote this as a valid letter and increment
         *      the correct answer counter variable.
         */

        static bool CheckForLetter(char letter, char[] word, char[] display)
        {
            // Create a boolean to see if it is in the word. If it is not,
            // this will remain false.
            bool goodLetter = false;

            // loop through the answer word array
            for (int i = 0; i < word.Length; i++)
            {
                // check to see if the letter guessed matches the letter of
                // the answer word array at the index of the loop position.
                // If it is, set the display (the correct guesses) array at
                // that index to the guessed letter and update the boolean to
                // true.
                if (word[i]==letter)
                {
                    display[i] = letter;
                    goodLetter = true;
                }

            }

            // return the boolean. If the letter was able to be found in the
            // answer word array, it'll be true; otherwise, false.
            return goodLetter;
        }

        static void Main(string[] args)
        {
            // set a constant integer to hold the limit of wrong guesses
            const int LIMIT_OF_GUESSES = 6;

            // create an array of strings to hold the possible words used in
            // the game. try to make sure some of the words are the same
            // length. There should be any number of words in this array.
            // Example array could be harder, baseball, showhow, morning, the, great

            string[] wordList = new string[] { "harder", "baseball", "showhow", "morning", "the", "great"};


            // Create three character arrays. One to hold the word as an array
            // This will hold the correct answer. This array will be initial-
            // ized with the GetWord method. The second array will hold the
            // the letters that have been correctly guessed. The size of this
            // array will be the Length property of the first array. The third
            // array will hold the wrong guesses and will have the size of the
            // constant set above.

            char[] answer = GetWord(wordList); // answer - is array of chars - of the random word
            char[] correct = new char[answer.Length]; // new array of null chars
            char[] wrong = new char[LIMIT_OF_GUESSES]; //new array of null chars - can do: -2 or +4 - for difficulty level - amount of tries

            // Call the FillArray method on the second and third arrays
            // described above. Choose a different character for each array
            // to act as a placeholder. For instance, '-' for the current
            // display and '*' for the wrong guesses.

            FillArray(correct, '-');
            FillArray(wrong, '*');

            // Create an integer variable to hold the number  incorrect
            // answers and initialize it to zero (0).

            int wrongAnswers = 0;


            // THE ACTUAL GAME PLAY
            // Create a loop that will ask the user for a character. This
            // character will be compared to the array generated from the
            // answer array. If the character is found in the word array, it
            // will show in the second array. If the character is not found,
            // it will be added to the wrong guesses array. The loop will exit
            // When the letters guessed match up with the letters of the an-
            // swer, or if the user guesses wrong the limit of wrong answers.
            do
            {
                // Setup a char to hold the user's guess but do not initialize
                // the guess.

                char guess;// guess is reference (out - validCharacter) - but becomes null after the end of the loop

                // Clear the console each time through the loop. This will keep
                // the display clean.
                Console.Clear();

                // Show the current word. This will showcase the letters that
                // the user current has right. It should give the user some
                // indication that it is the current word and call the
                // DisplayWord method, passing in the second array from above.

                Console.WriteLine("The current correct answers are : {0}", DisplayWord(correct));

                // Show the incorrect guesses. This will showcase the letters
                // that the user has guessed and are not in the word. It should
                // give the user some indication that these are the incorrect
                // guesses and call the DisplayWord method, passing in the
                // third array from above.

                Console.WriteLine("The incorrect answers are : {0}", DisplayWord(wrong));

                // Use the GetValidCharacter method, passing in the guess out
                // parameter.

                GetValidCharacter(out guess); // out - in order to use the value from the reference - out is in the description of the method

                // Call the CheckForLetter method, passing in the guess, the
                // word array, and the array to be displayed. Set this in an
                // if statement, since it returns a boolean. If the letter is
                // found in the answer word, display a message saying so. If
                // it is not, display a message saying that it is not a valid
                // letter in the word and add the wrongly guessed letter to
                // the list of incorrect answers.

                if (CheckForLetter(guess, answer, correct)) //  static bool CheckForLetter(char letter, char[] word, char[] display)
                // Created a boolean inside the method to see if it is in the word. If it is not, this will remain false:  bool goodLetter = false;

                {
                    Console.WriteLine("The letter {0} was in the word ", guess);
                
                }
                else
                {
                    Console.WriteLine("The letter {0} was NOT in the word ", guess);

                    // To add the letter to the list of incorrect answers, use
                    // the wrong guess counter as the index for the wrong
                    // guesses array and assign that the value of the guess.
                    // For example: wrongGuesses[wrongCounter] = guess;
                    // Then increment wrongCounter;

                    wrong[wrongAnswers] = guess; // wrong - array of chars - here wrongAswers - is int - the position of the char; guess- is a wrong char - goes to the position
                    wrongAnswers++; // adds to move to the next position

                    // Display how many wrong guesses the user has left.

                    Console.WriteLine("You have {0} more {1} left.",
                        LIMIT_OF_GUESSES - wrongAnswers,
                        (LIMIT_OF_GUESSES - wrongAnswers==1) ? "guess" : "guesses");

                }

                // Have the user press any key to continue and wait for a
                // response.
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                
            } while (wrongAnswers < LIMIT_OF_GUESSES && !(DisplayWord(answer).Equals(DisplayWord(correct)))); // 6<6 - false => message:

            // After one of the two exit conditions it met - either too many
            // incorrect guesses or the word is guessed - display a message
            // saying whether or not the user won or not. Either way, display
            // the correct word.

            if (DisplayWord(answer).Equals(DisplayWord(correct)))
            {
                Console.WriteLine("Congratulations! You have won! The word was {0}.", DisplayWord(answer));
            }
            else
            {
                Console.WriteLine("Too bad. You didn't win. The word was {0}.", DisplayWord(answer));
            }

            // Have the user press any key to exit and wait for a response.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
