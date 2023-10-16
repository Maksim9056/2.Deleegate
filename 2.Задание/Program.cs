namespace _2.Задание
{

    class Program
    {
        /// <summary>
        /// Необходимо написать программу, которая проверяет пользователя на знание таблицы умножения.
        /// Пользователь сам вводит два целых однозначных числа. Программа задаёт вопрос: результат умножения первого числа на второе. 
        /// Пользователь должен ввести ответ и увидеть на экране правильно он ответил или нет. Если нет  – показать еще и правильный результат
        /// </summary>
        static void Main()
        {
            // Вызываем метод для проверки знания таблицы умножения
            TestMultiplicationTable();
            Console.ReadLine();
        }

        static void TestMultiplicationTable()
        {
            Random random = new Random();

            int firstNumber = random.Next(1, 10); // Генерируем первое случайное число
            int secondNumber = random.Next(1, 10); // Генерируем второе случайное число

            // Создаем делегаты Action<T> и Func<T>
            Action<string> askQuestion = AskQuestion;
            Func<int, int, int> calculateAnswer = MultiplyNumbers;

            // Задаем вопрос пользователю
            askQuestion($"Сколько будет {firstNumber} умножить на {secondNumber}?");

            // Получаем ответ пользователя
            string userAnswer = Console.ReadLine();

            int answer;
            if (int.TryParse(userAnswer, out answer))
            {
                // Вычисляем правильный ответ
                int correctAnswer = calculateAnswer(firstNumber, secondNumber);

                // Проверяем ответ пользователя
                if (answer == correctAnswer)
                {
                    Console.WriteLine("Верно! Молодец!");
                }
                else
                {
                    Console.WriteLine($"Неверно! Правильный ответ: {correctAnswer}");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ответа. Введите целое число.");
            }
        }

        static void AskQuestion(string question)
        {
            Console.WriteLine(question);
        }

        static int MultiplyNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}

