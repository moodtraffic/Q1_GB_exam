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

// 1 - начало и инициализация начальных переменных
int dataSize = 5;
string[] initialData = new string[dataSize];

// 2 - загрузка данных из файла
initialData[0] = "Hi!";
initialData[1] = "Hello,";
initialData[2] = "World!";
initialData[3] = " ";
initialData[4] = "Bye";

// в результате должен быть массив string[3] {"Hi!", " ", "Bye"}

// 3 - основной алгоритм:

// 3.1 -- обход исходного массива строк, с целью запомнить индексы элементов,
// для которых выполняется условие - длина строки меньше либо равно 3 и запоминание кол-ва таких элементов
// результатом должно быть int[5] {0, 3, 4, -1, -1}
(int[] positions, int positionsCounter) = findStringsNotLongerThan(initialData, 3);

// 3.2 -- копирование из исходного массива элементов в результирующий массив
string[] resultData = new string[positionsCounter]; // создадим результирующий массив нужной длины

for (int index = 0; index < positionsCounter; index++)
{
    // в элемент c индексом index копируем значение строки с индексом positions[index] из initialData
    resultData[index] = initialData[positions[index]];
}

// 4 - вывод начального и результирующего массивов и заверешение
printStrings(initialData, "Input data:");
Console.WriteLine();
Console.WriteLine();
printStrings(resultData, "Filtered data:");
Console.WriteLine();

// end

/**
 * @param in string[] -- массив (исходный) строк
 * @param int MaxLength -- строки какой длины будем искать
 * @return (int[], int) -- вернем массив со значениями идексов в исходном массиве и кол-во найденных элементов
 */
(int[], int) findStringsNotLongerThan(in string[] Strings, int MaxLength)
{
    int indexCounter = 0; // тут будет хранится кол-во найденных элементов
    int StringsCounter = Strings.Length; // длина исходного массива

    int[] indexes = new int[StringsCounter]; // массив найденных индексов
    int index = 0; // для итерации

    for (index = 0 ; index < StringsCounter; index++)
    {
        indexes[index] = -1; // устанавливаем начальное значение, не совпадающее ни с одним индексом, т.е. < 0
    }

    /** begin Основной алгоритм - отбор */
    index = 0; // начальное значение в исходном массиве
    indexCounter = 0; // начальное значение в результирующем массиве

    while (index < StringsCounter) {
        if (Strings[index].Length <= MaxLength) {
            indexes[indexCounter] = index; // сначала сохраним, чтобы двигаться от 0
            indexCounter++;
        }

        index++; // двигаемся к следующему элементу исходного массива
    }
    /** end of Основной алгоримт */

    return (indexes, indexCounter);
}

void printStrings(string[] Strings, string Caption)
{
    Console.WriteLine(Caption);
    for (int index = 0; index < Strings.Length; index++)
    {
        Console.WriteLine($"'{Strings[index]}'");
    }
}
