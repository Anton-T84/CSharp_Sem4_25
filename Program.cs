/* Напишите цикл, который принимает на вход два числа (А и В) и возводит число А в натуральную степень В. */

int numberInput(char whatSymbolIsEntered)
{  //Метод ввода и проверки на число
    bool readlineFromStrToInt = true;
    int number =0;
    while (readlineFromStrToInt)
    {
        switch (whatSymbolIsEntered)
        {  
            case 'A':
                Console.Write("Введите число, А : ");
                break;
            case 'B':
                Console.Write("Введите степень, B : ");
                break;   }
        string numberSTR = Console.ReadLine();
        
        if (int.TryParse(numberSTR, out int numberInt) )
        {  //проверка на число
            number = numberInt;
            //дополнительная проверка
            if (number < 0)
            {
                Console.WriteLine("Взял число по модулю");
                number *= -1;
                readlineFromStrToInt = false;
                }
            else readlineFromStrToInt = false;
            } 
            } 
return number;
}

string degree(int number)
{  //Метод перевода числа от 0 до 9 в запись с верхним регистром 
    string result = "\0";
    switch (number)
    {
        case 0:
            result = "\x2070";
            break;
        case 1:
            result = "\u00B9";
            break;
        case 2:
            result = "\u00B2";
            break;
        case 3:
            result = "\u00B3";
            break;
        case 4:
            result = "\x2074";
            break;
        case 5:
            result = "\x2075";
            break;
        case 6:
            result = "\x2076";
            break;
        case 7:
            result = "\x2077";
            break;
        case 8:
            result = "\x2078";
            break;
        case 9:
            result = "\x2079";
            break;
        default:
            result = degreeBuild(number);
            break;
    }

return result;  
}

string degreeBuild(int number)
{   //Метод перевода числа больше 9 в запись с верхним регистром
    string numberSTR = Convert.ToString(number);
    string result = String.Empty;
    foreach(char num in numberSTR) result = result + degree(Convert.ToInt32(Convert.ToString(num)));
return result;
}


double exponentiation(int A,int B){  //Метод возведения в степень используя Math.Pow - не используется
    double result = Math.Pow(A, B);
return result;
}

double exponentiationCicle(int A,int B)
{   //Метод возведения в степень через цикл
    double result = 1;
    if (B != 0)for (int i = 0; i < B; i++) result = result *A;   
return result;
}

string printBigNumber(double number)
{
    string numberSTR = Convert.ToString(number);
    string result = String.Empty;
    while (numberSTR.Length%3 != 0) numberSTR = " "+numberSTR;
    for (int i = 1;i <= numberSTR.Length; i++){
        result = (i%3 == 0)? $"{result}{Convert.ToString(numberSTR[i-1])} ":$"{result}{Convert.ToString(numberSTR[i-1])}"; }

    if ((Convert.ToString(result[0]) == " ") && (Convert.ToString(result[1]) == " ")) result = result.Remove(0,2);
    else if ((Convert.ToString(result[0]) == " ")) result = result.Remove(0,1);
return result;
}

//Тело программы
System.Console.OutputEncoding = System.Text.Encoding.Unicode;

Console.Clear();
Console.WriteLine("Задача 25:\n"+
"\tНапишите цикл, который принимает на вход два числа (A и B) \n"+
"\tи возводит число A в натуральную степень B.\n"+
"\tПример : 3, 5 -> 243 (3⁵) -- *нажмите Enter для продолжения");
Console.ReadLine();

do
{
Console.Clear();

int A = numberInput('A');
int B = numberInput('B');


Console.WriteLine($"{A}, {B} - > {printBigNumber(exponentiationCicle(A,B))} ({A}{degree(B)}) *{exponentiationCicle(A,B)}");
Console.WriteLine("Для выхода, нажмите ESCAPE, люба другая кнопка запустить программу повторно.");
} while (Console.ReadKey().Key != ConsoleKey.Escape);