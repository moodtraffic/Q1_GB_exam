/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Задание контрольной работы
 * --------------------------
 * Написать программу, которая из имеющегося массива строк формирует массив из строк,
 * длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры,
 * либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями,
 * лучше обойтись исключительно массивами.
 *
 * Техническое решение описано в README.md
 */

string[] initialData = new string[] {"Hi!", "Hello,", "World!", " ", "Bye"};

// в результате должен быть массив string[3] {"Hi!", " ", "Bye"}
(int[] positions, int positionsCounter) = findStringsNotLongerThan(initialData, 3);

string[] resultData = new string[positionsCounter]; // создадим результирующий массив нужной длины

for (int index = 0; index < positionsCounter; index++)
{
    // в элемент resultData c индексом index копируем значение строки с индексом positions[index] из initialData
    resultData[index] = initialData[positions[index]];
}

printStrings(initialData, "Input data:");
Console.WriteLine();
Console.WriteLine();
printStrings(resultData, "Filtered data:");
Console.WriteLine();

/**
 * @param in string[] -- массив (исходный) строк
 * @param int MaxLength -- строки какой длины будем искать
 * @return (int[], int) -- вернем массив со значениями идексов в исходном массиве и кол-во найденных элементов
 */
(int[], int) findStringsNotLongerThan(in string[] Strings, int MaxLength)
{
    int stringsCounter = Strings.Length; // длина исходного массива

    int[] indexes = new int[stringsCounter]; // массив найденных индексов

    /** begin Основной алгоритм - отбор */
    int index = 0; // начальное значение в исходном массиве
    int indexCounter = 0; // начальное значение в результирующем массиве

    while (index < stringsCounter) {
        if (Strings[index].Length <= MaxLength) {
            indexes[indexCounter] = index; // сначала сохраним, чтобы двигаться от 0
            indexCounter++;
        }

        index++; // двигаемся к следующему элементу исходного массива
    }
    /** end of Основной алгоритм */

    return (indexes, indexCounter);
}

/**
 * @param string[] Массив строк
 * @param strirng Заголовок
 */
void printStrings(string[] Strings, string Caption)
{
    Console.WriteLine(Caption);

    for (int index = 0; index < Strings.Length; index++)
    {
        Console.WriteLine($"'{Strings[index]}'");
    }

    if (Strings.Length == 0) {
        Console.WriteLine("<empty>");
    }
}
