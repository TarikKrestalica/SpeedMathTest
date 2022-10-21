using System;
using System.Diagnostics;

namespace SpeedMathTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ExplainGame();
            Console.Clear();    // Remove the explanation

            // Create a random object, and my stopwatch
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            // Create two numbers and my operation
            int num1, num2, numOp;

            //Create a result
            double questionsRight = 0;
            double totalQuestions = 5;

            // Start the timer
            sw.Start();
            
            // Play the Game!
            for (int numOfProblemsAnswered = 0; numOfProblemsAnswered < 5; ++numOfProblemsAnswered)
            {
                // Choose two random numbers and an operation
                num1 = rnd.Next(1, 11);
                num2 = rnd.Next(1, 11);
                numOp = rnd.Next(0, 4);

                // Notify them how many questions they have left!
                double questionsLeft = totalQuestions - numOfProblemsAnswered;
                string response = questionsLeft > 1? $"{questionsLeft} questions left!": "Last question!";
                Console.WriteLine(response);

                // Create, Display the problem
                Console.Write(CreateProblem(num1, num2, numOp));
                string textAnswer = Console.ReadLine();     

                // Is the answer in number form?
                bool successfulConversion = double.TryParse(textAnswer, out double answer);

                if (successfulConversion)
                {
                    // Compute the answer, compare with the user's answer!
                    double actualAnswer = GetAnswer((double)num1, (double)num2, (double)numOp);
                    if (RightAnswer(Math.Round(answer, 2), Math.Round(actualAnswer, 2)))
                        questionsRight++;
                }

                // Remove the text on the console, keep it clean!
                Console.Clear();
            }
            // End the Game!
            EndStopwatch(sw);

            // Display their result, print out a message!
            Console.WriteLine($"{questionsRight} / {totalQuestions}.");
            Console.WriteLine(PrintOutResponse(questionsRight));
              
        }

        // Describe the game!
        public static void ExplainGame()
        {
            // Explanation
            Console.WriteLine("Hello user! Welcome to my speed Math Test!");
            Console.WriteLine("This game is designed to test your mathematical abilities");
            Console.WriteLine("through 5 random arithmetic questions. For each question, ");
            Console.WriteLine("you will have one opportunity to answer and will");
            Console.WriteLine("be evaluated based on how many you get correct out of the 5 total questions.");
            Console.WriteLine("Please make sure your answers are numbers!!");
            Console.WriteLine("To play, please enter the return key....");

            // Display that text
            Console.ReadLine();

        }
        // Create a Math Problem
        public static string CreateProblem(int number1, int number2, int op)
        {
            // Create a default operation
            char operation = '?';

            // Compare my number operation to 4 potential cases
            switch (op)
            {
                case 0:
                    operation = '+';
                    break;

                case 1:
                    operation = '-';
                    break;

                case 2:
                    operation = '*';
                    break;

                case 3:
                    operation = '/';
                    break;
            }

            // Create and obtain a math problem
            string problem = $"What is {number1} {operation} {number2}?: ";
            return problem;
        }

        // Compare the user's response to the answer
        public static double GetAnswer(double num1, double num2, double op)
        {
            // Initial result
            double result = 0;

            // Compare the operation, perform the appropriate operation between these numbers
            switch (op)
            {
                case 0:
                    result = num1 + num2;
                    break;
                case 1:
                    result = num1 - num2;
                    break;
                case 2:
                    result = num1 * num2;
                    break;
                case 3:
                    result = num1 / num2;
                    break;
            }

            // Obtain the result
            return result;
        }

        // Check if the answer is correct!
        public static bool RightAnswer(double myAnswer, double result)
        {
            if (myAnswer == result)
                return true;
            else
                return false;
        }

        // Stop the time, print out how much time they took
        public static void EndStopwatch(Stopwatch watch)
        {
            watch.Stop();
            Console.WriteLine("Elasped Time: " + watch.Elapsed);
        }

        // Calculate my result, print out a response
        public static string PrintOutResponse(double rightAnswers)
        {
            //Create a default response!
            string response = "?";

            // Compare how I did?
            switch (rightAnswers)
            {
                case 0:
                    response = "Terrible! I don't get out of bed at 0! 0%";
                    break;

                case 1:
                    response = "Well, at least you're not like 0% over there! 20%";
                    break;

                case 2:
                    response = "Slow and Steady wins the Race! 40%";
                    break;

                case 3:
                    response = "Don't discourage yourself! 60%";
                    break;

                case 4:
                    response = "Great effort, can you do better? 80%";
                    break;

                case 5:
                    response = "You're a wise grasshopper! Or maybe I made it too easy! 100%";
                    break;

            }
            // Obtain the proper response
            return response;
        }

        


        
    }
}
