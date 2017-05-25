using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Word = Microsoft.Office.Interop.Word;
using System.Threading;
using System.Globalization;
using System.Data.OleDb;
using Microsoft.Office.Interop.Word;

namespace Recept
{
    public partial class Form1 : Form
    {

        #region перевод чисел в пропись
        /// <summary>
        /// Класс для преобразования чисел в пропись на русском языке.
        /// </summary>
        /// <example>
        /// Число.Пропись (1, РодЧисло.Мужской); // "один"
        /// Число.Пропись (2, РодЧисло.Женский); // "две"
        /// Число.Пропись (21, РодЧисло.Средний); // "двадцать одно"
        /// </example>
        /// <example>
        /// Число.Пропись (5, new ЕдиницаИзмерения (
        ///  РодЧисло.Мужской, "метр", "метра", "метров"), sb); // "пять метров"
        /// </example>
        public static class Число
        {
            /// <summary>
            /// Получить пропись числа с согласованной единицей измерения.
            /// </summary>
            /// <param name="число"> Число должно быть целым, неотрицательным. </param>
            /// <param name="еи"></param>
            /// <param name="result"> Сюда записывается результат. </param>
            /// <returns> <paramref name="result"/> </returns>
            /// <exception cref="ArgumentException">
            /// Если число меньше нуля или не целое. 
            /// </exception>
            public static StringBuilder Пропись(decimal число, IЕдиницаИзмерения еи, StringBuilder result)
            {
                string error = ПроверитьЧисло(число);
                if (error != null) throw new ArgumentException(error, "число");

                // Целочисленные версии работают в разы быстрее, чем decimal.
                if (число <= uint.MaxValue)
                {
                    Пропись((uint)число, еи, result);
                }
                else if (число <= ulong.MaxValue)
                {
                    Пропись((ulong)число, еи, result);
                }
                else
                {
                    MyStringBuilder mySb = new MyStringBuilder(result);

                    decimal div1000 = Math.Floor(число / 1000);
                    ПрописьСтаршихКлассов(div1000, 0, mySb);
                    ПрописьКласса((uint)(число - div1000 * 1000), еи, mySb);
                }

                return result;
            }

            /// <summary>
            /// Получить пропись числа с согласованной единицей измерения.
            /// </summary>
            /// <param name="число"> 
            /// Число должно быть целым, неотрицательным, не большим <see cref="MaxDouble"/>. 
            /// </param>
            /// <param name="еи"></param>
            /// <param name="result"> Сюда записывается результат. </param>
            /// <exception cref="ArgumentException">
            /// Если число меньше нуля, не целое или больше <see cref="MaxDouble"/>. 
            /// </exception>
            /// <returns> <paramref name="result"/> </returns>
            /// <remarks>
            /// float по умолчанию преобразуется к double, поэтому нет перегрузки для float.
            /// В результате ошибок округления возможно расхождение цифр прописи и
            /// строки, выдаваемой double.ToString ("R"), начиная с 17 значащей цифры.
            /// </remarks>
            public static StringBuilder Пропись(double число, IЕдиницаИзмерения еи, StringBuilder result)
            {
                string error = ПроверитьЧисло(число);
                if (error != null) throw new ArgumentException(error, "число");

                if (число <= uint.MaxValue)
                {
                    Пропись((uint)число, еи, result);
                }
                else if (число <= ulong.MaxValue)
                {
                    // Пропись с ulong выполняется в среднем в 2 раза быстрее.
                    Пропись((ulong)число, еи, result);
                }
                else
                {
                    MyStringBuilder mySb = new MyStringBuilder(result);

                    double div1000 = Math.Floor(число / 1000);
                    ПрописьСтаршихКлассов(div1000, 0, mySb);
                    ПрописьКласса((uint)(число - div1000 * 1000), еи, mySb);
                }

                return result;
            }

            /// <summary>
            /// Получить пропись числа с согласованной единицей измерения.
            /// </summary>
            /// <returns> <paramref name="result"/> </returns>
            public static StringBuilder Пропись(ulong число, IЕдиницаИзмерения еи, StringBuilder result)
            {
                if (число <= uint.MaxValue)
                {
                    Пропись((uint)число, еи, result);
                }
                else
                {
                    MyStringBuilder mySb = new MyStringBuilder(result);

                    ulong div1000 = число / 1000;
                    ПрописьСтаршихКлассов(div1000, 0, mySb);
                    ПрописьКласса((uint)(число - div1000 * 1000), еи, mySb);
                }

                return result;
            }

            /// <summary>
            /// Получить пропись числа с согласованной единицей измерения.
            /// </summary>
            /// <returns> <paramref name="result"/> </returns>
            public static StringBuilder Пропись(uint число, IЕдиницаИзмерения еи, StringBuilder result)
            {
                MyStringBuilder mySb = new MyStringBuilder(result);

                if (число == 0)
                {
                    mySb.Append("ноль");
                    mySb.Append(еи.РодМнож);
                }
                else
                {
                    uint div1000 = число / 1000;
                    ПрописьСтаршихКлассов(div1000, 0, mySb);
                    ПрописьКласса(число - div1000 * 1000, еи, mySb);
                }

                return result;
            }

            /// <summary>
            /// Записывает в <paramref name="sb"/> пропись числа, начиная с самого 
            /// старшего класса до класса с номером <paramref name="номерКласса"/>.
            /// </summary>
            /// <param name="sb"></param>
            /// <param name="число"></param>
            /// <param name="номерКласса">0 = класс тысяч, 1 = миллионов и т.д.</param>
            /// <remarks>
            /// В методе применена рекурсия, чтобы обеспечить запись в StringBuilder 
            /// в нужном порядке - от старших классов к младшим.
            /// </remarks>
            static void ПрописьСтаршихКлассов(decimal число, int номерКласса, MyStringBuilder sb)
            {
                if (число == 0) return; // конец рекурсии

                // Записать в StringBuilder пропись старших классов.
                decimal div1000 = Math.Floor(число / 1000);
                ПрописьСтаршихКлассов(div1000, номерКласса + 1, sb);

                uint числоДо999 = (uint)(число - div1000 * 1000);
                if (числоДо999 == 0) return;

                ПрописьКласса(числоДо999, Классы[номерКласса], sb);
            }

            static void ПрописьСтаршихКлассов(double число, int номерКласса, MyStringBuilder sb)
            {
                if (число == 0) return; // конец рекурсии

                // Записать в StringBuilder пропись старших классов.
                double div1000 = Math.Floor(число / 1000);
                ПрописьСтаршихКлассов(div1000, номерКласса + 1, sb);

                uint числоДо999 = (uint)(число - div1000 * 1000);
                if (числоДо999 == 0) return;

                ПрописьКласса(числоДо999, Классы[номерКласса], sb);
            }

            static void ПрописьСтаршихКлассов(ulong число, int номерКласса, MyStringBuilder sb)
            {
                if (число == 0) return; // конец рекурсии

                // Записать в StringBuilder пропись старших классов.
                ulong div1000 = число / 1000;
                ПрописьСтаршихКлассов(div1000, номерКласса + 1, sb);

                uint числоДо999 = (uint)(число - div1000 * 1000);
                if (числоДо999 == 0) return;

                ПрописьКласса(числоДо999, Классы[номерКласса], sb);
            }

            static void ПрописьСтаршихКлассов(uint число, int номерКласса, MyStringBuilder sb)
            {
                if (число == 0) return; // конец рекурсии

                // Записать в StringBuilder пропись старших классов.
                uint div1000 = число / 1000;
                ПрописьСтаршихКлассов(div1000, номерКласса + 1, sb);

                uint числоДо999 = число - div1000 * 1000;
                if (числоДо999 == 0) return;

                ПрописьКласса(числоДо999, Классы[номерКласса], sb);
            }

            #region ПрописьКласса

            /// <summary>
            /// Формирует запись класса с названием, например,
            /// "125 тысяч", "15 рублей".
            /// Для 0 записывает только единицу измерения в род.мн.
            /// </summary>
            private static void ПрописьКласса(uint числоДо999, IЕдиницаИзмерения класс, MyStringBuilder sb)
            {
                uint числоЕдиниц = числоДо999 % 10;
                uint числоДесятков = (числоДо999 / 10) % 10;
                uint числоСотен = (числоДо999 / 100) % 10;

                sb.Append(Сотни[числоСотен]);

                if ((числоДо999 % 100) != 0)
                {
                    Десятки[числоДесятков].Пропись(sb, числоЕдиниц, класс.РодЧисло);
                }

                // Добавить название класса в нужной форме.
                sb.Append(Согласовать(класс, числоДо999));
            }

            #endregion

            #region ПроверитьЧисло

            /// <summary>
            /// Проверяет, подходит ли число для передачи методу 
            /// <see cref="Пропись(decimal,IЕдиницаИзмерения,StringBuilder)"/>.
            /// </summary>
            /// <returns>
            /// Описание нарушенного ограничения или null.
            /// </returns>
            public static string ПроверитьЧисло(decimal число)
            {
                if (число < 0)
                    return "Число должно быть больше или равно нулю.";

                if (число != decimal.Floor(число))
                    return "Число не должно содержать дробной части.";

                return null;
            }

            /// <summary>
            /// Проверяет, подходит ли число для передачи методу 
            /// <see cref="Пропись(double,IЕдиницаИзмерения,StringBuilder)"/>.
            /// </summary>
            /// <returns>
            /// Описание нарушенного ограничения или null.
            /// </returns>
            public static string ПроверитьЧисло(double число)
            {
                if (число < 0)
                    return "Число должно быть больше или равно нулю.";

                if (число != Math.Floor(число))
                    return "Число не должно содержать дробной части.";

                if (число > MaxDouble)
                {
                    return "Число должно быть не больше " + MaxDouble + ".";
                }

                return null;
            }

            #endregion

            #region Согласовать

            /// <summary>
            /// Согласовать название единицы измерения с числом.
            /// Например, согласование единицы (рубль, рубля, рублей) 
            /// с числом 23 даёт "рубля", а с числом 25 - "рублей".
            /// </summary>
            public static string Согласовать(IЕдиницаИзмерения единицаИзмерения, uint число)
            {
                uint числоЕдиниц = число % 10;
                uint числоДесятков = (число / 10) % 10;

                if (числоДесятков == 1) return единицаИзмерения.РодМнож;
                switch (числоЕдиниц)
                {
                    case 1: return единицаИзмерения.ИменЕдин;
                    case 2:
                    case 3:
                    case 4: return единицаИзмерения.РодЕдин;
                    default: return единицаИзмерения.РодМнож;
                }
            }

            /// <summary>
            /// Согласовать название единицы измерения с числом.
            /// Например, согласование единицы (рубль, рубля, рублей) 
            /// с числом 23 даёт "рубля", а с числом 25 - "рублей".
            /// </summary>
            public static string Согласовать(IЕдиницаИзмерения единицаИзмерения, decimal число)
            {
                return Согласовать(единицаИзмерения, (uint)(число % 100));
            }

            #endregion

            #region Единицы

            static string ПрописьЦифры(uint цифра, РодЧисло род)
            {
                return Цифры[цифра].Пропись(род);
            }

            abstract class Цифра
            {
                public abstract string Пропись(РодЧисло род);
            }

            class ЦифраИзменяющаясяПоРодам : Цифра, IИзменяетсяПоРодам
            {
                public ЦифраИзменяющаясяПоРодам(
                    string мужской,
                    string женский,
                    string средний,
                    string множественное)
                {
                    this.мужской = мужской;
                    this.женский = женский;
                    this.средний = средний;
                    this.множественное = множественное;
                }

                public ЦифраИзменяющаясяПоРодам(
                    string единственное,
                    string множественное)

                    : this(единственное, единственное, единственное, множественное)
                {
                }

                private readonly string мужской;
                private readonly string женский;
                private readonly string средний;
                private readonly string множественное;

                #region IИзменяетсяПоРодам Members

                public string Мужской { get { return this.мужской; } }
                public string Женский { get { return this.женский; } }
                public string Средний { get { return this.средний; } }
                public string Множественное { get { return this.множественное; } }

                #endregion

                public override string Пропись(РодЧисло род)
                {
                    return род.ПолучитьФорму(this);
                }
            }

            class ЦифраНеизменяющаясяПоРодам : Цифра
            {
                public ЦифраНеизменяющаясяПоРодам(string пропись)
                {
                    this.пропись = пропись;
                }

                private readonly string пропись;

                public override string Пропись(РодЧисло род)
                {
                    return this.пропись;
                }
            }

            private static readonly Цифра[] Цифры = new Цифра[]
        {
            null,
            new ЦифраИзменяющаясяПоРодам ("один", "одна", "одно", "одни"),
            new ЦифраИзменяющаясяПоРодам ("два", "две", "два", "двое"),
            new ЦифраИзменяющаясяПоРодам ("три", "трое"),
            new ЦифраИзменяющаясяПоРодам ("четыре", "четверо"),
            new ЦифраНеизменяющаясяПоРодам ("пять"),
            new ЦифраНеизменяющаясяПоРодам ("шесть"),
            new ЦифраНеизменяющаясяПоРодам ("семь"),
            new ЦифраНеизменяющаясяПоРодам ("восемь"),
            new ЦифраНеизменяющаясяПоРодам ("девять"),
        };

            #endregion
            #region Десятки

            static readonly Десяток[] Десятки = new Десяток[]
        {
            new ПервыйДесяток (),
            new ВторойДесяток (),
            new ОбычныйДесяток ("двадцать"),
            new ОбычныйДесяток ("тридцать"),
            new ОбычныйДесяток ("сорок"),
            new ОбычныйДесяток ("пятьдесят"),
            new ОбычныйДесяток ("шестьдесят"),
            new ОбычныйДесяток ("семьдесят"),
            new ОбычныйДесяток ("восемьдесят"),
            new ОбычныйДесяток ("девяносто")
        };

            abstract class Десяток
            {
                public abstract void Пропись(MyStringBuilder sb, uint числоЕдиниц, РодЧисло род);
            }

            class ПервыйДесяток : Десяток
            {
                public override void Пропись(MyStringBuilder sb, uint числоЕдиниц, РодЧисло род)
                {
                    sb.Append(ПрописьЦифры(числоЕдиниц, род));
                }
            }

            class ВторойДесяток : Десяток
            {
                static readonly string[] ПрописьНаДцать = new string[]
            {
                "десять",
                "одиннадцать",
                "двенадцать",
                "тринадцать",
                "четырнадцать",
                "пятнадцать",
                "шестнадцать",
                "семнадцать",
                "восемнадцать",
                "девятнадцать"
            };

                public override void Пропись(MyStringBuilder sb, uint числоЕдиниц, РодЧисло род)
                {
                    sb.Append(ПрописьНаДцать[числоЕдиниц]);
                }
            }

            class ОбычныйДесяток : Десяток
            {
                public ОбычныйДесяток(string названиеДесятка)
                {
                    this.названиеДесятка = названиеДесятка;
                }

                private readonly string названиеДесятка;

                public override void Пропись(MyStringBuilder sb, uint числоЕдиниц, РодЧисло род)
                {
                    sb.Append(this.названиеДесятка);

                    if (числоЕдиниц == 0)
                    {
                        // После "двадцать", "тридцать" и т.д. не пишут "ноль" (единиц)
                    }
                    else
                    {
                        sb.Append(ПрописьЦифры(числоЕдиниц, род));
                    }
                }
            }

            #endregion
            #region Сотни

            static readonly string[] Сотни = new string[]
        {
            null,
            "сто",
            "двести",
            "триста",
            "четыреста",
            "пятьсот",
            "шестьсот",
            "семьсот",
            "восемьсот",
            "девятьсот"
        };

            #endregion
            #region Классы

            #region КлассТысяч

            class КлассТысяч : IЕдиницаИзмерения
            {
                public string ИменЕдин { get { return "тысяча"; } }
                public string РодЕдин { get { return "тысячи"; } }
                public string РодМнож { get { return "тысяч"; } }
                public РодЧисло РодЧисло { get { return РодЧисло.Женский; } }
            }

            #endregion
            #region Класс

            class Класс : IЕдиницаИзмерения
            {
                readonly string начальнаяФорма;

                public Класс(string начальнаяФорма)
                {
                    this.начальнаяФорма = начальнаяФорма;
                }

                public string ИменЕдин { get { return this.начальнаяФорма; } }
                public string РодЕдин { get { return this.начальнаяФорма + "а"; } }
                public string РодМнож { get { return this.начальнаяФорма + "ов"; } }
                public РодЧисло РодЧисло { get { return РодЧисло.Мужской; } }
            }

            #endregion

            /// <summary>
            /// Класс - группа из 3 цифр.  Есть классы единиц, тысяч, миллионов и т.д.
            /// </summary>
            static readonly IЕдиницаИзмерения[] Классы = new IЕдиницаИзмерения[]
        {
            new КлассТысяч (),
            new Класс ("миллион"),
            new Класс ("миллиард"),
            new Класс ("триллион"),
            new Класс ("квадриллион"),
            new Класс ("квинтиллион"),
            new Класс ("секстиллион"),
            new Класс ("септиллион"),
            new Класс ("октиллион"),
 
            // Это количество классов покрывает весь диапазон типа decimal.
        };

            #endregion

            #region MaxDouble

            /// <summary>
            /// Максимальное число типа double, представимое в виде прописи.
            /// </summary>
            /// <remarks>
            /// Рассчитывается исходя из количества определённых классов.
            /// Если добавить ещё классы, оно будет автоматически увеличено.
            /// </remarks>
            public static double MaxDouble
            {
                get
                {
                    if (maxDouble == 0)
                    {
                        maxDouble = CalcMaxDouble();
                    }

                    return maxDouble;
                }
            }

            private static double maxDouble = 0;

            static double CalcMaxDouble()
            {
                double max = Math.Pow(1000, Классы.Length + 1);

                double d = 1;

                while (max - d == max)
                {
                    d *= 2;
                }

                return max - d;
            }

            #endregion

            #region Вспомогательные классы

            #region Форма

            #endregion
            #region MyStringBuilder

            /// <summary>
            /// Вспомогательный класс, аналогичный <see cref="StringBuilder"/>.
            /// Между вызовами <see cref="MyStringBuilder.Append"/> вставляет пробелы.
            /// </summary>
            class MyStringBuilder
            {
                public MyStringBuilder(StringBuilder sb)
                {
                    this.sb = sb;
                }

                readonly StringBuilder sb;
                bool insertSpace = false;

                /// <summary>
                /// Добавляет слово <paramref name="s"/>,
                /// вставляя перед ним пробел, если нужно.
                /// </summary>
                public void Append(string s)
                {
                    if (string.IsNullOrEmpty(s)) return;

                    if (this.insertSpace)
                    {
                        this.sb.Append(' ');
                    }
                    else
                    {
                        this.insertSpace = true;
                    }

                    this.sb.Append(s);
                }

                public override string ToString()
                {
                    return sb.ToString();
                }
            }

            #endregion

            #endregion

            #region Перегрузки метода Пропись, возвращающие string

            /// <summary>
            /// Возвращает пропись числа строчными буквами.
            /// </summary>
            public static string Пропись(decimal число, IЕдиницаИзмерения еи)
            {
                return Пропись(число, еи, Заглавные.Нет);
            }

            /// <summary>
            /// Возвращает пропись числа.
            /// </summary>
            public static string Пропись(decimal число, IЕдиницаИзмерения еи, Заглавные заглавные)
            {
                return ApplyCaps(Пропись(число, еи, new StringBuilder()), заглавные);
            }

            /// <summary>
            /// Возвращает пропись числа строчными буквами.
            /// </summary>
            public static string Пропись(double число, IЕдиницаИзмерения еи)
            {
                return Пропись(число, еи, Заглавные.Нет);
            }

            /// <summary>
            /// Возвращает пропись числа.
            /// </summary>
            public static string Пропись(double число, IЕдиницаИзмерения еи, Заглавные заглавные)
            {
                return ApplyCaps(Пропись(число, еи, new StringBuilder()), заглавные);
            }

            /// <summary>
            /// Возвращает пропись числа строчными буквами.
            /// </summary>
            public static string Пропись(ulong число, IЕдиницаИзмерения еи)
            {
                return Пропись(число, еи, Заглавные.Нет);
            }

            /// <summary>
            /// Возвращает пропись числа.
            /// </summary>
            public static string Пропись(ulong число, IЕдиницаИзмерения еи, Заглавные заглавные)
            {
                return ApplyCaps(Пропись(число, еи, new StringBuilder()), заглавные);
            }

            /// <summary>
            /// Возвращает пропись числа строчными буквами.
            /// </summary>
            public static string Пропись(uint число, IЕдиницаИзмерения еи)
            {
                return Пропись(число, еи, Заглавные.Нет);
            }

            /// <summary>
            /// Возвращает пропись числа.
            /// </summary>
            public static string Пропись(uint число, IЕдиницаИзмерения еи, Заглавные заглавные)
            {
                return ApplyCaps(Пропись(число, еи, new StringBuilder()), заглавные);
            }

            internal static string ApplyCaps(StringBuilder sb, Заглавные заглавные)
            {
                заглавные.Применить(sb);
                return sb.ToString();
            }

            #endregion
        }

        /// <summary>
        /// Стратегия расстановки заглавных букв.
        /// </summary>
        public abstract class Заглавные
        {
            /// <summary>
            /// Применить стратегию к <paramref name="sb"/>.
            /// </summary>
            public abstract void Применить(StringBuilder sb);

            class _ВСЕ : Заглавные
            {
                public override void Применить(StringBuilder sb)
                {
                    for (int i = 0; i < sb.Length; ++i)
                    {
                        sb[i] = char.ToUpperInvariant(sb[i]);
                    }
                }
            }

            class _Нет : Заглавные
            {
                public override void Применить(StringBuilder sb)
                {
                }
            }

            class _Первая : Заглавные
            {
                public override void Применить(StringBuilder sb)
                {
                    sb[0] = char.ToUpperInvariant(sb[0]);
                }
            }

            public static readonly Заглавные ВСЕ = new _ВСЕ();
            public static readonly Заглавные Нет = new _Нет();
            public static readonly Заглавные Первая = new _Первая();
        }


        /// <summary>
        /// Класс, хранящий падежные формы единицы измерения в явном виде.
        /// </summary>
        public class ЕдиницаИзмерения : IЕдиницаИзмерения
        {
            /// <summary> </summary>
            public ЕдиницаИзмерения(
                РодЧисло родЧисло,
                string именЕдин,
                string родЕдин,
                string родМнож)
            {
                this.родЧисло = родЧисло;
                this.именЕдин = именЕдин;
                this.родЕдин = родЕдин;
                this.родМнож = родМнож;
            }

            readonly РодЧисло родЧисло;
            readonly string именЕдин;
            readonly string родЕдин;
            readonly string родМнож;

            #region IЕдиницаИзмерения Members

            string IЕдиницаИзмерения.ИменЕдин
            {
                get { return this.именЕдин; }
            }

            string IЕдиницаИзмерения.РодЕдин
            {
                get { return this.родЕдин; }
            }

            string IЕдиницаИзмерения.РодМнож
            {
                get { return this.родМнож; }
            }

            РодЧисло IЕдиницаИзмерения.РодЧисло
            {
                get { return this.родЧисло; }
            }

            #endregion
        }

        #region РодЧисло

        /// <summary>
        /// Указывает род и число.
        /// Может передаваться в качестве параметра "единица измерения" метода 
        /// <see cref="Число.Пропись(decimal,IЕдиницаИзмерения,StringBuilder)"/>.
        /// Управляет родом и числом числительных один и два.
        /// </summary>
        /// <example>
        /// Число.Пропись (2, РодЧисло.Мужской); // "два"
        /// Число.Пропись (2, РодЧисло.Женский); // "две"
        /// Число.Пропись (21, РодЧисло.Средний); // "двадцать одно"
        /// </example>
        public abstract class РодЧисло : IЕдиницаИзмерения
        {
            internal abstract string ПолучитьФорму(IИзменяетсяПоРодам слово);

            #region Рода

            class _Мужской : РодЧисло
            {
                internal override string ПолучитьФорму(IИзменяетсяПоРодам слово)
                {
                    return слово.Мужской;
                }
            }

            class _Женский : РодЧисло
            {
                internal override string ПолучитьФорму(IИзменяетсяПоРодам слово)
                {
                    return слово.Женский;
                }
            }

            class _Средний : РодЧисло
            {
                internal override string ПолучитьФорму(IИзменяетсяПоРодам слово)
                {
                    return слово.Средний;
                }
            }

            class _Множественное : РодЧисло
            {
                internal override string ПолучитьФорму(IИзменяетсяПоРодам слово)
                {
                    return слово.Множественное;
                }
            }

            public static readonly РодЧисло Мужской = new _Мужской();
            public static readonly РодЧисло Женский = new _Женский();
            public static readonly РодЧисло Средний = new _Средний();
            public static readonly РодЧисло Множественное = new _Множественное();

            #endregion

            #region IЕдиницаИзмерения Members

            РодЧисло IЕдиницаИзмерения.РодЧисло
            {
                get { return this; }
            }

            string IЕдиницаИзмерения.ИменЕдин
            {
                get { return null; }
            }

            string IЕдиницаИзмерения.РодЕдин
            {
                get { return null; }
            }

            string IЕдиницаИзмерения.РодМнож
            {
                get { return null; }
            }

            #endregion
        }

        #region IИзменяетсяПоРодам

        internal interface IИзменяетсяПоРодам
        {
            string Мужской { get; }
            string Женский { get; }
            string Средний { get; }
            string Множественное { get; }
        }

        #endregion

        #endregion

        #region ЕдиницаИзмерения

        /// <summary>
        /// Представляет единицу измерения (например, метр, рубль)
        /// и содержит всю необходимую информацию для согласования
        /// этой единицы с числом, а именно - три падежно-числовых формы
        /// и грамматический род / число.
        /// </summary>
        public interface IЕдиницаИзмерения
        {
            /// <summary>
            /// Форма именительного падежа единственного числа.
            /// Согласуется с числительным "один":
            /// одна тысяча, один миллион, один рубль, одни сутки и т.д.
            /// </summary>
            string ИменЕдин { get; }

            /// <summary>
            /// Форма родительного падежа единственного числа.
            /// Согласуется с числительными "один, два, три, четыре":
            /// две тысячи, два миллиона, два рубля, двое суток и т.д.
            /// </summary>
            string РодЕдин { get; }

            /// <summary>
            /// Форма родительного падежа множественного числа.
            /// Согласуется с числительным "ноль, пять, шесть, семь" и др:
            /// пять тысяч, пять миллионов, пять рублей, пять суток и т.д.
            /// </summary>
            string РодМнож { get; }

            /// <summary>
            /// Род и число единицы измерения.
            /// </summary>
            РодЧисло РодЧисло { get; }
        }

        #endregion
        #endregion

        public Form1()
        {
            InitializeComponent();
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            //Формируем и выполняем запрос на выборку 
            string strSQL = "SELECT * FROM [Врачи];";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();

            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    doctor.Add(myDataReader["ФИО"].ToString());
                    listBox2.Items.Add(myDataReader["ФИО"].ToString());
                    //comboBox1.Items.Add(myDataReader["ФИО"].ToString());
                }
            }
            //Формируем и выполняем запрос на выборку 
            strSQL = "SELECT * FROM [Пациенты];";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();

            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    pacienty.Add(myDataReader["ФИО"].ToString());
                    listBox1.Items.Add(myDataReader["ФИО"].ToString());
                    listBox9.Items.Add(myDataReader["ФИО"].ToString());
                    //comboBox1.Items.Add(myDataReader["ФИО"].ToString());
                }
            }
            //Формируем и выполняем запрос на выборку 
            strSQL = "SELECT * FROM [Лекарства];";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();

            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    lecarstva.Add(myDataReader["НазваниеЛат"].ToString());
                    listBox6.Items.Add(myDataReader["НазваниеЛат"].ToString());
                    listBox7.Items.Add(myDataReader["НазваниеЛат"].ToString());
                    listBox8.Items.Add(myDataReader["НазваниеЛат"].ToString());
                    //comboBox1.Items.Add(myDataReader["ФИО"].ToString());
                }
            }
            //Формируем и выполняем запрос на выборку 
            strSQL = "SELECT * FROM [ЕдИзм];";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();

            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    rp.Add(myDataReader["НазваниеЛат"].ToString());
                    listBox3.Items.Add(myDataReader["НазваниеЛат"].ToString());
                    //comboBox1.Items.Add(myDataReader["ФИО"].ToString());
                }
            }
            //Формируем и выполняем запрос на выборку 
            strSQL = "SELECT * FROM [Дозы];";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();

            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    dtd.Add(myDataReader["НазваниеЛат"].ToString());
                    listBox4.Items.Add(myDataReader["НазваниеЛат"].ToString());
                    //comboBox1.Items.Add(myDataReader["ФИО"].ToString());
                }
            }
            //Формируем и выполняем запрос на выборку 
            strSQL = "SELECT * FROM [Способ];";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();

            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    s.Add(myDataReader["Применение"].ToString());
                    listBox5.Items.Add(myDataReader["Применение"].ToString());
                    //comboBox1.Items.Add(myDataReader["ФИО"].ToString());
                }
            }
            cn.Close();
        }

        #region список глобальных переменных
        //список для врачей
        public List<string> doctor = new List<string>();
        //список для пациентов
        public List<string> pacienty = new List<string>();
        //список для лекарств
        public List<string> lecarstva = new List<string>();
        //список для rp
        public List<string> rp = new List<string>();
        //список для dtd
        public List<string> dtd = new List<string>();
        //список для s
        public List<string> s = new List<string>();

        //Подключение к БД
        public OleDbConnection cn;
        //Конструктор строки подключения
        public OleDbConnectionStringBuilder cnstr;
        //SQL-запрос
        public OleDbCommand cm;
        //Поток строк с данными из запроса
        public OleDbDataReader myDataReader;

        Word._Application oWord = new Word.Application();
        object oMissing = System.Reflection.Missing.Value;

        public string godRowd;
        public int nomRec;

        #endregion


        #region первая форма
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nomRec = Convert.ToInt32(textBox9.Text);
            godRowd = textBox10.Text;
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            
            //Формируем и выполняем запрос на выборку 
            string strSQL = "INSERT INTO Отчеты ( Дата, ФИОБольного, ФИОВрача, ГодРождения, Адрес, НомРецепта, Препарат, Доза, Количество, Льгота) VALUES ('"+DateTime.Now.Day+"."+DateTime.Now.Month+"."+DateTime.Now.Year+"','"+textBox3.Text+"','"+textBox1.Text+"','"+godRowd+"','"+textBox4.Text+"',"+nomRec+",'"+textBox8.Text+"','"+textBox7.Text+"',"+nomRec+",'"+textBox12.Text+"');";
            cm = new OleDbCommand(strSQL, cn);

            int i=cm.ExecuteNonQuery();

            cn.Close();

            Word._Document oDoc = LoadTemplate(Environment.CurrentDirectory + "\\Корешок новый заполненный.docx");
            SetTemplate(oDoc);
            SaveToDisk(oDoc, Environment.CurrentDirectory + "\\"+textBox3.Text+".docx");
            //oDoc.Close(ref oMissing, ref oMissing, ref oMissing);
            //oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
        }

        private Word._Document LoadTemplate(string filePath)
        {
            object oTemplate = filePath;
            Word._Document oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);
            return oDoc;
        }

        private void SetTemplate(Word._Document oDoc)
        {          
            //устанавливаем русскую локализацию
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru");
            //получаем название месяца 
            string monthName = DateTime.Today.ToString("MMMM");
            //объявление переменных для заполнения ссылок
            string per1 = " ", per2 = " ", per3 = " ", per4 = " ", per5 = " ", per6 = " ", per7 = " ", per8 = " ", per9 = " ", per10 = " ", per11 = " ", per12 = " ", per13 = " ", per14 = " ", per15 = " ", per16 = " ", per17 = " ", per18 = " ", per19 = " ", per20 = " ", per21 = " ", per22 = " ", per23 = " ", per24 = " ", per25 = " ", per26 = " ";
            per1 = textBox3.Text;
            per2 = textBox4.Text;
            per3 = textBox1.Text;
            per4 = textBox6.Text;
            per5 = textBox8.Text+" "+textBox2.Text;
            //radiobutton
            if (checkBox1.Checked)
            {
                per6 = "X";
                object oBookMark6 = "з6";
                oDoc.Bookmarks.get_Item(ref oBookMark6).Range.Text = per6;
                per12 = "X";
                object oBookMark12 = "з12";
                oDoc.Bookmarks.get_Item(ref oBookMark12).Range.Text = per12;
            }
            else
            {
                if (checkBox2.Checked)
                {
                    per7 = "X";
                    object oBookMark7 = "з7";
                    oDoc.Bookmarks.get_Item(ref oBookMark7).Range.Text = per7;
                    per13 = "X";
                    object oBookMark13 = "з13";
                    oDoc.Bookmarks.get_Item(ref oBookMark13).Range.Text = per13;
                }
                else
                {
                    per8 = "X";
                    object oBookMark8 = "з8";
                    oDoc.Bookmarks.get_Item(ref oBookMark8).Range.Text = per8;
                    per14 = "X";
                    object oBookMark14 = "з14";
                    oDoc.Bookmarks.get_Item(ref oBookMark14).Range.Text = per14;
                }
            }
            //
            per9 = textBox6.Text;
            per10 = DateTime.Now.Day.ToString()+" " +monthName+" ";
            per11 = DateTime.Now.Year.ToString();
            godRowd = textBox10.Text;
            //
            per15 = textBox3.Text +" "+ godRowd + "г.р.";
            per16 = textBox12.Text;
            //
            per17 = textBox4.Text;

            per18 = textBox1.Text;
            string dozaINom = textBox21.Text;
            if (radioButton1.Checked)
            {
                dozaINom += "мг №" + textBox22.Text + " (" + Число.Пропись(Convert.ToDecimal(textBox22.Text), РодЧисло.Мужской) + ")";
            }
            else
            {
                dozaINom += "мл №" + textBox22.Text + " (" + Число.Пропись(Convert.ToDecimal(textBox22.Text), РодЧисло.Мужской)+")";
            }
            per19 = textBox8.Text + " " + textBox2.Text + " "+dozaINom;
            per23 = textBox2.Text;
            per20 = textBox5.Text;
            per21 = textBox7.Text;
            object oBookMark1 = "з1";
            oDoc.Bookmarks.get_Item(ref oBookMark1).Range.Text = per1;
            object oBookMark2 = "з2";
            oDoc.Bookmarks.get_Item(ref oBookMark2).Range.Text = per2;
            object oBookMark3 = "з3";
            oDoc.Bookmarks.get_Item(ref oBookMark3).Range.Text = per3;
            object oBookMark4 = "з4";
            oDoc.Bookmarks.get_Item(ref oBookMark4).Range.Text = per4;
            object oBookMark5 = "з5";
            oDoc.Bookmarks.get_Item(ref oBookMark5).Range.Text = per5;
            object oBookMark9 = "з9";
            oDoc.Bookmarks.get_Item(ref oBookMark9).Range.Text = per9;
            object oBookMark10 = "з10";
            oDoc.Bookmarks.get_Item(ref oBookMark10).Range.Text = per10;
            object oBookMark11 = "з11";
            oDoc.Bookmarks.get_Item(ref oBookMark11).Range.Text = per11;
            
            object oBookMark15 = "з15";
            oDoc.Bookmarks.get_Item(ref oBookMark15).Range.Text = per15;
            
            object oBookMark16 = "з16";
            oDoc.Bookmarks.get_Item(ref oBookMark16).Range.Text = per16;
            object oBookMark17 = "з17";
            oDoc.Bookmarks.get_Item(ref oBookMark17).Range.Text = per17;
            object oBookMark18 = "з18";
            oDoc.Bookmarks.get_Item(ref oBookMark18).Range.Text = per18;
            object oBookMark19 = "з19";
            oDoc.Bookmarks.get_Item(ref oBookMark19).Range.Text = per19;

            object oBookMark20 = "з20";
            oDoc.Bookmarks.get_Item(ref oBookMark20).Range.Text = per20;

            object oBookMark21 = "з21";
            oDoc.Bookmarks.get_Item(ref oBookMark21).Range.Text = per21;

        }

        private void SaveToDisk(Word._Document oDoc, string filePath)
        {
            object fileName = filePath;
            oDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref 

oMissing, ref oMissing, ref oMissing, ref oMissing);
        }

        //для пациентов
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox3.Text.Length > 0)
            {
                for (int i = 0; i < this.listBox1.Items.Count; i++)
                    if (!this.listBox1.Items[i].ToString().Contains(this.textBox3.Text))
                    {

                        this.listBox1.Items.RemoveAt(i);
                        i--;
                    }
            }
            else
            {
                this.listBox1.Items.Clear();
                for (int i = 0; i < pacienty.Count; i++)
                    this.listBox1.Items.Add(pacienty[i]);
            }
            textBox11.Text = textBox3.Text;
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            //Формируем и выполняем запрос на выборку 
            string strSQL = "SELECT * FROM [Пациенты] WHERE [ФИО]='" + textBox3.Text + "';";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();

            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    textBox4.Text = myDataReader["Адрес"].ToString();
                    textBox13.Text = myDataReader["Адрес"].ToString();
                }
            }
            cn.Close();
        }


        #region изменение чекбоксов
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox1.Checked = false;
        }
        #endregion

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox13.Text = textBox4.Text;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = listBox1.SelectedItem.ToString();
                cn = new OleDbConnection();
                cnstr = new OleDbConnectionStringBuilder();
                cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
                cnstr.DataSource = @"dataBase.accdb";
                cn.ConnectionString = cnstr.ToString();

                //Подключаемся к БД и считываем данные

                //Открываем подключение
                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                //Формируем и выполняем запрос на выборку 
                string strSQL = "SELECT * FROM [Пациенты] WHERE [ФИО]='" + textBox3.Text + "';";
                cm = new OleDbCommand(strSQL, cn);
                myDataReader = cm.ExecuteReader();
                string[] dataRowd;
                if (myDataReader.HasRows)
                {

                    while (myDataReader.Read())
                    {
                        godRowd = myDataReader["ДатаРождения"].ToString();//.Split('.');
                        textBox12.Text = myDataReader["Документ"].ToString();
                        textBox10.Text = godRowd;
                        //godRowd = dataRowd[2];
                    }
                }

                cn.Close();
            }
            catch { }

            listBox1.Visible = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textBox3.Text = listBox1.SelectedItem.ToString();
                    cn = new OleDbConnection();
                    cnstr = new OleDbConnectionStringBuilder();
                    cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
                    cnstr.DataSource = @"dataBase.accdb";
                    cn.ConnectionString = cnstr.ToString();

                    //Подключаемся к БД и считываем данные

                    //Открываем подключение
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    //Формируем и выполняем запрос на выборку 
                    string strSQL = "SELECT * FROM [Пациенты] WHERE [ФИО]='" + textBox3.Text + "';";
                    cm = new OleDbCommand(strSQL, cn);
                    myDataReader = cm.ExecuteReader();
                    string[] dataRowd;
                    if (myDataReader.HasRows)
                    {

                        while (myDataReader.Read())
                        {
                            dataRowd = myDataReader["ДатаРождения"].ToString().Split('.');
                            textBox12.Text = myDataReader["Документ"].ToString();
                            godRowd = dataRowd[2];
                        }
                    }

                    cn.Close();
                }
                catch { }

                listBox1.Visible = false;
            }

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }

        #region для врачей
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length > 0)
            {
                for (int i = 0; i < this.listBox2.Items.Count; i++)
                    if (!this.listBox2.Items[i].ToString().Contains(this.textBox1.Text))
                    {

                        this.listBox2.Items.RemoveAt(i);
                        i--;
                    }
            }
            else
            {
                this.listBox2.Items.Clear();
                for (int i = 0; i < doctor.Count; i++)
                    this.listBox2.Items.Add(doctor[i]);
            }
            
            textBox14.Text = textBox1.Text;
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            //Формируем и выполняем запрос на выборку 
            string strSQL = "SELECT * FROM [Врачи] WHERE [ФИО]='" + textBox1.Text + "';";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();

            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    textBox6.Text = myDataReader["Код"].ToString();
                }
            }
            cn.Close();
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listBox2.SelectedItem.ToString();
            }
            catch { }
            listBox2.Visible = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            listBox2.Visible = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textBox1.Text = listBox2.SelectedItem.ToString();
                }
                catch { }
                listBox2.Visible = false;
            }
        }

#endregion

        #region название лекарства
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox8.Text.Length > 0)
            {
                for (int i = 0; i < this.listBox6.Items.Count; i++)
                    if (!this.listBox6.Items[i].ToString().Contains(this.textBox8.Text))
                    {

                        this.listBox6.Items.RemoveAt(i);
                        i--;
                    }
            }
            else
            {
                this.listBox6.Items.Clear();
                for (int i = 0; i < lecarstva.Count; i++)
                    this.listBox6.Items.Add(lecarstva[i]);
            }
        }

        private void listBox6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text = listBox6.SelectedItem.ToString();
            }
            catch { }
            listBox6.Visible = false;
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            listBox6.Visible = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textBox8.Text = listBox6.SelectedItem.ToString();
                }
                catch { }
                listBox6.Visible = false;
            }
        }

        #endregion

        #region изменение rp
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox8.Text.Length > 0)
            {
                for (int i = 0; i < this.listBox3.Items.Count; i++)
                    if (!this.listBox3.Items[i].ToString().Contains(this.textBox2.Text))
                    {

                        this.listBox3.Items.RemoveAt(i);
                        i--;
                    }
            }
            else
            {
                this.listBox3.Items.Clear();
                for (int i = 0; i < rp.Count; i++)
                    this.listBox3.Items.Add(rp[i]);
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            listBox3.Visible = true;
        }

        private void listBox3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = listBox3.SelectedItem.ToString();
            }
            catch { }
            listBox3.Visible = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textBox2.Text = listBox3.SelectedItem.ToString();
                }
                catch { }
                listBox3.Visible = false;
            }
        }

        #endregion

        #region изменение dtd
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox5.Text.Length > 0)
            {
                for (int i = 0; i < this.listBox4.Items.Count; i++)
                    if (!this.listBox4.Items[i].ToString().Contains(this.textBox5.Text))
                    {

                        this.listBox4.Items.RemoveAt(i);
                        i--;
                    }
            }
            else
            {
                this.listBox4.Items.Clear();
                for (int i = 0; i < dtd.Count; i++)
                    this.listBox4.Items.Add(dtd[i]);
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            listBox4.Visible = true;
        }

        private void listBox4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = listBox4.SelectedItem.ToString();
            }
            catch { }
            listBox4.Visible = false;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textBox5.Text = listBox4.SelectedItem.ToString();
                }
                catch { }
                listBox4.Visible = false;
            }
        }

        #endregion

        #region изменение s
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox7.Text.Length > 0)
            {
                for (int i = 0; i < this.listBox5.Items.Count; i++)
                    if (!this.listBox5.Items[i].ToString().Contains(this.textBox7.Text))
                    {

                        this.listBox5.Items.RemoveAt(i);
                        i--;
                    }
            }
            else
            {
                this.listBox5.Items.Clear();
                for (int i = 0; i < s.Count; i++)
                    this.listBox5.Items.Add(s[i]);
            }
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            listBox5.Visible = true;
        }

        private void listBox5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = listBox5.SelectedItem.ToString();
            }
            catch { }

            listBox5.Visible = false;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textBox7.Text = listBox5.SelectedItem.ToString();
                }
                catch { }

                listBox5.Visible = false;
            }
        }

#endregion

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text="";
            textBox4.Text="";
            textBox1.Text="";
            textBox6.Text="";
            textBox8.Text=""; 
            textBox2.Text="";
            
            checkBox1.Checked=false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            

            textBox6.Text = "";
            textBox3.Text = "";
            textBox12.Text = "";
            //
            textBox4.Text = "";
            textBox4.Text = "";
            textBox1.Text = "";
            textBox8.Text = ""; 
            textBox2.Text = ""; 
            textBox5.Text = ""; 
            textBox7.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";

        }

        #endregion

        #region вторая форма

        #region выборка по лекарству
        private void button3_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            string str1, str2;
            str1 = maskedTextBox1.Text.Replace('.','/');
            str2 = maskedTextBox2.Text.Replace('.', '/');
            //Формируем и выполняем запрос на выборку 
            string strSQL = "SELECT Отчеты.Дата, Отчеты.ФИОБольного, Отчеты.ГодРождения, Отчеты.Адрес, Отчеты.НомРецепта, Отчеты.Препарат, Отчеты.Доза, Отчеты.Количество, Отчеты.Льгота, Отчеты.ФИОВрача FROM Отчеты WHERE (Дата Between #" + str1 + "# And #" + str2 + "#) AND (Препарат='"+textBox15.Text+"');";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int countRow = 0;
            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    countRow++;
                }
            }




            // "Создаем" word
            Word.Application oWord = new Word.Application();
            // Делаем его видимым
            oWord.Visible = true;
            // Создаем новый документ
            Object template = Type.Missing;
            Object newTemplate = false;
            Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            Object visible = true;

            oWord.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
            // Выбираем его
            Word.Document oDoc = (Word.Document)oWord.Documents.get_Item(1);
            // Свойства документа:
            // Поля
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            oDoc.PageSetup.LeftMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.TopMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.RightMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.BottomMargin = oWord.CentimetersToPoints((float)1.0);

            //oDoc.Paragraphs.Add(ref oMissing);
            Word.Paragraph oParagraph = oDoc.Paragraphs.Add(ref oMissing);
            Word.Range oRange2 = oParagraph.Range;
            Object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;// Автоматически менять ячейки по тексту
            Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;// Автоподбор ширины столбцов
            //Добавляем таблицу и получаем объект wordtable
            Word.Table wordtable = oDoc.Tables.Add(oRange2,countRow+1,// Число строк //2,// Число строк
            11,// Число столбцов
            ref defaultTableBehavior, ref autoFitBehavior);
            Word.Table oTable = oDoc.Tables[1];
            // Заполняем шапку таблицы
            
            Word.Range wordcellrange = oTable.Cell(1, 1).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№";
            wordcellrange = oTable.Cell(1, 2).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "дата";
            wordcellrange = oTable.Cell(1, 3).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Фио больного";
            wordcellrange = oTable.Cell(1, 4).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Год рождения";
            wordcellrange = oTable.Cell(1, 5).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "адрес";
            wordcellrange = oTable.Cell(1, 6).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№ рецепта";
            wordcellrange = oTable.Cell(1, 7).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "препарат";
            wordcellrange = oTable.Cell(1, 8).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "доза";
            wordcellrange = oTable.Cell(1, 9).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "кол-во";
            wordcellrange = oTable.Cell(1, 10).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "льгота";
            wordcellrange = oTable.Cell(1, 11).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "врач";



            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int i = 2;
            if (myDataReader.HasRows)
            {
                while (myDataReader.Read())
                {
                    wordcellrange = oTable.Cell(i , 1).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = (i-1).ToString();
                    wordcellrange = oTable.Cell(i, 2).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Дата"].ToString();
                    wordcellrange = oTable.Cell(i, 3).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОБольного"].ToString();
                    wordcellrange = oTable.Cell(i, 4).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ГодРождения"].ToString();
                    wordcellrange = oTable.Cell(i, 5).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Адрес"].ToString();
                    wordcellrange = oTable.Cell(i, 6).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["НомРецепта"].ToString();
                    wordcellrange = oTable.Cell(i, 7).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Препарат"].ToString();
                    wordcellrange = oTable.Cell(i, 8).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Доза"].ToString();
                    wordcellrange = oTable.Cell(i, 9).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Количество"].ToString();
                    wordcellrange = oTable.Cell(i, 10).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Льгота"].ToString();
                    wordcellrange = oTable.Cell(i, 11).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОВрача"].ToString();
                    i++;
                }
                
            }
            
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox15.Text.Length > 0)
            {
                for (int i = 0; i < this.listBox7.Items.Count; i++)
                    if (!this.listBox7.Items[i].ToString().Contains(this.textBox15.Text))
                    {

                        this.listBox7.Items.RemoveAt(i);
                        i--;
                    }
            }
            else
            {
                this.listBox7.Items.Clear();
                for (int i = 0; i < lecarstva.Count; i++)
                    this.listBox7.Items.Add(lecarstva[i]);
            }
        }

        private void textBox15_Click(object sender, EventArgs e)
        {
            listBox7.Visible = true;
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textBox15.Text = listBox6.SelectedItem.ToString();
                }
                catch { }
                listBox7.Visible = false;
            }
        }

        private void listBox7_Click(object sender, EventArgs e)
        {
            try
            {
                textBox15.Text = listBox7.SelectedItem.ToString();
            }
            catch { }
            listBox7.Visible = false;
        }

        #endregion


        //по рецепту
        private void button4_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            //Формируем и выполняем запрос на выборку 
            string strSQL = "SELECT Отчеты.Дата, Отчеты.ФИОБольного, Отчеты.ГодРождения, Отчеты.Адрес, Отчеты.НомРецепта, Отчеты.Препарат, Отчеты.Доза, Отчеты.Количество, Отчеты.Льгота, Отчеты.ФИОВрача FROM Отчеты WHERE НомРецепта="+textBox16.Text+" ;";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int countRow = 0;
            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    countRow++;
                }
            }




            // "Создаем" word
            Word.Application oWord = new Word.Application();
            // Делаем его видимым
            oWord.Visible = true;
            // Создаем новый документ
            Object template = Type.Missing;
            Object newTemplate = false;
            Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            Object visible = true;

            oWord.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
            // Выбираем его
            Word.Document oDoc = (Word.Document)oWord.Documents.get_Item(1);
            // Свойства документа:
            // Поля
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            oDoc.PageSetup.LeftMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.TopMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.RightMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.BottomMargin = oWord.CentimetersToPoints((float)1.0);

            //oDoc.Paragraphs.Add(ref oMissing);
            Word.Paragraph oParagraph = oDoc.Paragraphs.Add(ref oMissing);
            Word.Range oRange2 = oParagraph.Range;
            Object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;// Автоматически менять ячейки по тексту
            Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;// Автоподбор ширины столбцов
            //Добавляем таблицу и получаем объект wordtable
            Word.Table wordtable = oDoc.Tables.Add(oRange2, countRow + 1,// Число строк //2,// Число строк
            11,// Число столбцов
            ref defaultTableBehavior, ref autoFitBehavior);
            Word.Table oTable = oDoc.Tables[1];
            // Заполняем шапку таблицы

            Word.Range wordcellrange = oTable.Cell(1, 1).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№";
            wordcellrange = oTable.Cell(1, 2).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "дата";
            wordcellrange = oTable.Cell(1, 3).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Фио больного";
            wordcellrange = oTable.Cell(1, 4).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Год рождения";
            wordcellrange = oTable.Cell(1, 5).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "адрес";
            wordcellrange = oTable.Cell(1, 6).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№ рецепта";
            wordcellrange = oTable.Cell(1, 7).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "препарат";
            wordcellrange = oTable.Cell(1, 8).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "доза";
            wordcellrange = oTable.Cell(1, 9).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "кол-во";
            wordcellrange = oTable.Cell(1, 10).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "льгота";
            wordcellrange = oTable.Cell(1, 11).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "врач";



            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int i = 2;
            if (myDataReader.HasRows)
            {
                while (myDataReader.Read())
                {
                    wordcellrange = oTable.Cell(i, 1).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = (i - 1).ToString();
                    wordcellrange = oTable.Cell(i, 2).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Дата"].ToString();
                    wordcellrange = oTable.Cell(i, 3).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОБольного"].ToString();
                    wordcellrange = oTable.Cell(i, 4).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ГодРождения"].ToString();
                    wordcellrange = oTable.Cell(i, 5).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Адрес"].ToString();
                    wordcellrange = oTable.Cell(i, 6).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["НомРецепта"].ToString();
                    wordcellrange = oTable.Cell(i, 7).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Препарат"].ToString();
                    wordcellrange = oTable.Cell(i, 8).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Доза"].ToString();
                    wordcellrange = oTable.Cell(i, 9).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Количество"].ToString();
                    wordcellrange = oTable.Cell(i, 10).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Льгота"].ToString();
                    wordcellrange = oTable.Cell(i, 11).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОВрача"].ToString();
                    i++;
                }

            }
        }

        //по статье
        private void button5_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            string str1, str2;
            str1 = maskedTextBox1.Text.Replace('.', '/');
            str2 = maskedTextBox2.Text.Replace('.', '/');
            //Формируем и выполняем запрос на выборку 
            string strSQL = "SELECT Отчеты.Дата, Отчеты.ФИОБольного, Отчеты.ГодРождения, Отчеты.Адрес, Отчеты.НомРецепта, Отчеты.Препарат, Отчеты.Доза, Отчеты.Количество, Отчеты.Льгота, Отчеты.ФИОВрача FROM Отчеты WHERE Дата Between #" + str1 + "# And #" + str2 + "#;";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int countRow = 0;
            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    countRow++;
                }
            }




            // "Создаем" word
            Word.Application oWord = new Word.Application();
            // Делаем его видимым
            oWord.Visible = true;
            // Создаем новый документ
            Object template = Type.Missing;
            Object newTemplate = false;
            Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            Object visible = true;

            oWord.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
            // Выбираем его
            Word.Document oDoc = (Word.Document)oWord.Documents.get_Item(1);
            // Свойства документа:
            // Поля
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            oDoc.PageSetup.LeftMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.TopMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.RightMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.BottomMargin = oWord.CentimetersToPoints((float)1.0);

            //oDoc.Paragraphs.Add(ref oMissing);
            Word.Paragraph oParagraph = oDoc.Paragraphs.Add(ref oMissing);
            Word.Range oRange2 = oParagraph.Range;
            Object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;// Автоматически менять ячейки по тексту
            Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;// Автоподбор ширины столбцов
            //Добавляем таблицу и получаем объект wordtable
            Word.Table wordtable = oDoc.Tables.Add(oRange2, countRow + 1,// Число строк //2,// Число строк
            11,// Число столбцов
            ref defaultTableBehavior, ref autoFitBehavior);
            Word.Table oTable = oDoc.Tables[1];
            // Заполняем шапку таблицы

            Word.Range wordcellrange = oTable.Cell(1, 1).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№";
            wordcellrange = oTable.Cell(1, 2).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "дата";
            wordcellrange = oTable.Cell(1, 3).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Фио больного";
            wordcellrange = oTable.Cell(1, 4).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Год рождения";
            wordcellrange = oTable.Cell(1, 5).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "адрес";
            wordcellrange = oTable.Cell(1, 6).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№ рецепта";
            wordcellrange = oTable.Cell(1, 7).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "препарат";
            wordcellrange = oTable.Cell(1, 8).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "доза";
            wordcellrange = oTable.Cell(1, 9).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "кол-во";
            wordcellrange = oTable.Cell(1, 10).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "льгота";
            wordcellrange = oTable.Cell(1, 11).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "врач";



            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int i = 2;
            if (myDataReader.HasRows)
            {
                while (myDataReader.Read())
                {
                    wordcellrange = oTable.Cell(i, 1).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = (i - 1).ToString();
                    wordcellrange = oTable.Cell(i, 2).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Дата"].ToString();
                    wordcellrange = oTable.Cell(i, 3).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОБольного"].ToString();
                    wordcellrange = oTable.Cell(i, 4).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ГодРождения"].ToString();
                    wordcellrange = oTable.Cell(i, 5).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Адрес"].ToString();
                    wordcellrange = oTable.Cell(i, 6).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["НомРецепта"].ToString();
                    wordcellrange = oTable.Cell(i, 7).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Препарат"].ToString();
                    wordcellrange = oTable.Cell(i, 8).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Доза"].ToString();
                    wordcellrange = oTable.Cell(i, 9).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Количество"].ToString();
                    wordcellrange = oTable.Cell(i, 10).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Льгота"].ToString();
                    wordcellrange = oTable.Cell(i, 11).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОВрача"].ToString();
                    i++;
                }

            }
        }

        //по заболеванию
        private void button6_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            string str1, str2;
            str1 = maskedTextBox1.Text.Replace('.', '/');
            str2 = maskedTextBox2.Text.Replace('.', '/');
            //Формируем и выполняем запрос на выборку 
            string strSQL = "SELECT Отчеты.Дата, Отчеты.ФИОБольного, Отчеты.ГодРождения, Отчеты.Адрес, Отчеты.НомРецепта, Отчеты.Препарат, Отчеты.Доза, Отчеты.Количество, Отчеты.Льгота, Отчеты.ФИОВрача FROM Отчеты WHERE Дата Between #" + str1 + "# And #" + str2 + "#;";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int countRow = 0;
            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    countRow++;
                }
            }




            // "Создаем" word
            Word.Application oWord = new Word.Application();
            // Делаем его видимым
            oWord.Visible = true;
            // Создаем новый документ
            Object template = Type.Missing;
            Object newTemplate = false;
            Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            Object visible = true;

            oWord.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
            // Выбираем его
            Word.Document oDoc = (Word.Document)oWord.Documents.get_Item(1);
            // Свойства документа:
            // Поля
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            oDoc.PageSetup.LeftMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.TopMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.RightMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.BottomMargin = oWord.CentimetersToPoints((float)1.0);

            //oDoc.Paragraphs.Add(ref oMissing);
            Word.Paragraph oParagraph = oDoc.Paragraphs.Add(ref oMissing);
            Word.Range oRange2 = oParagraph.Range;
            Object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;// Автоматически менять ячейки по тексту
            Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;// Автоподбор ширины столбцов
            //Добавляем таблицу и получаем объект wordtable
            Word.Table wordtable = oDoc.Tables.Add(oRange2, countRow + 1,// Число строк //2,// Число строк
            11,// Число столбцов
            ref defaultTableBehavior, ref autoFitBehavior);
            Word.Table oTable = oDoc.Tables[1];
            // Заполняем шапку таблицы

            Word.Range wordcellrange = oTable.Cell(1, 1).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№";
            wordcellrange = oTable.Cell(1, 2).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "дата";
            wordcellrange = oTable.Cell(1, 3).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Фио больного";
            wordcellrange = oTable.Cell(1, 4).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Год рождения";
            wordcellrange = oTable.Cell(1, 5).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "адрес";
            wordcellrange = oTable.Cell(1, 6).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№ рецепта";
            wordcellrange = oTable.Cell(1, 7).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "препарат";
            wordcellrange = oTable.Cell(1, 8).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "доза";
            wordcellrange = oTable.Cell(1, 9).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "кол-во";
            wordcellrange = oTable.Cell(1, 10).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "льгота";
            wordcellrange = oTable.Cell(1, 11).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "врач";



            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int i = 2;
            if (myDataReader.HasRows)
            {
                while (myDataReader.Read())
                {
                    wordcellrange = oTable.Cell(i, 1).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = (i - 1).ToString();
                    wordcellrange = oTable.Cell(i, 2).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Дата"].ToString();
                    wordcellrange = oTable.Cell(i, 3).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОБольного"].ToString();
                    wordcellrange = oTable.Cell(i, 4).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ГодРождения"].ToString();
                    wordcellrange = oTable.Cell(i, 5).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Адрес"].ToString();
                    wordcellrange = oTable.Cell(i, 6).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["НомРецепта"].ToString();
                    wordcellrange = oTable.Cell(i, 7).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Препарат"].ToString();
                    wordcellrange = oTable.Cell(i, 8).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Доза"].ToString();
                    wordcellrange = oTable.Cell(i, 9).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Количество"].ToString();
                    wordcellrange = oTable.Cell(i, 10).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Льгота"].ToString();
                    wordcellrange = oTable.Cell(i, 11).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОВрача"].ToString();
                    i++;
                }

            }
        }


        #region выборка по пациенту и по лекарству
        private void button7_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            string str1, str2;
            str1 = maskedTextBox3.Text.Replace('.', '/');
            str2 = maskedTextBox4.Text.Replace('.', '/');
            //Формируем и выполняем запрос на выборку 
            string strSQL = "SELECT Отчеты.Дата, Отчеты.ФИОБольного, Отчеты.ГодРождения, Отчеты.Адрес, Отчеты.НомРецепта, Отчеты.Препарат, Отчеты.Доза, Отчеты.Количество, Отчеты.Льгота, Отчеты.ФИОВрача FROM Отчеты WHERE (Дата Between #" + str1 + "# And #" + str2 + "#) AND (Препарат='"+textBox19.Text+"') AND ('"+textBox20.Text+"');";
            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int countRow = 0;
            if (myDataReader.HasRows)
            {

                while (myDataReader.Read())
                {
                    countRow++;
                }
            }




            // "Создаем" word
            Word.Application oWord = new Word.Application();
            // Делаем его видимым
            oWord.Visible = true;
            // Создаем новый документ
            Object template = Type.Missing;
            Object newTemplate = false;
            Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            Object visible = true;

            oWord.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
            // Выбираем его
            Word.Document oDoc = (Word.Document)oWord.Documents.get_Item(1);
            // Свойства документа:
            // Поля
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            oDoc.PageSetup.LeftMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.TopMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.RightMargin = oWord.CentimetersToPoints((float)1.0);
            oDoc.PageSetup.BottomMargin = oWord.CentimetersToPoints((float)1.0);

            //oDoc.Paragraphs.Add(ref oMissing);
            Word.Paragraph oParagraph = oDoc.Paragraphs.Add(ref oMissing);
            Word.Range oRange2 = oParagraph.Range;
            Object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;// Автоматически менять ячейки по тексту
            Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;// Автоподбор ширины столбцов
            //Добавляем таблицу и получаем объект wordtable
            Word.Table wordtable = oDoc.Tables.Add(oRange2, countRow + 1,// Число строк //2,// Число строк
            11,// Число столбцов
            ref defaultTableBehavior, ref autoFitBehavior);
            Word.Table oTable = oDoc.Tables[1];
            // Заполняем шапку таблицы

            Word.Range wordcellrange = oTable.Cell(1, 1).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№";
            wordcellrange = oTable.Cell(1, 2).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "дата";
            wordcellrange = oTable.Cell(1, 3).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Фио больного";
            wordcellrange = oTable.Cell(1, 4).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "Год рождения";
            wordcellrange = oTable.Cell(1, 5).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "адрес";
            wordcellrange = oTable.Cell(1, 6).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "№ рецепта";
            wordcellrange = oTable.Cell(1, 7).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "препарат";
            wordcellrange = oTable.Cell(1, 8).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "доза";
            wordcellrange = oTable.Cell(1, 9).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "кол-во";
            wordcellrange = oTable.Cell(1, 10).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "льгота";
            wordcellrange = oTable.Cell(1, 11).Range;
            wordcellrange.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
            wordcellrange.Text = "врач";



            cm = new OleDbCommand(strSQL, cn);
            myDataReader = cm.ExecuteReader();
            int i = 2;
            if (myDataReader.HasRows)
            {
                while (myDataReader.Read())
                {
                    wordcellrange = oTable.Cell(i, 1).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = (i - 1).ToString();
                    wordcellrange = oTable.Cell(i, 2).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Дата"].ToString();
                    wordcellrange = oTable.Cell(i, 3).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОБольного"].ToString();
                    wordcellrange = oTable.Cell(i, 4).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ГодРождения"].ToString();
                    wordcellrange = oTable.Cell(i, 5).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Адрес"].ToString();
                    wordcellrange = oTable.Cell(i, 6).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["НомРецепта"].ToString();
                    wordcellrange = oTable.Cell(i, 7).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Препарат"].ToString();
                    wordcellrange = oTable.Cell(i, 8).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Доза"].ToString();
                    wordcellrange = oTable.Cell(i, 9).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Количество"].ToString();
                    wordcellrange = oTable.Cell(i, 10).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["Льгота"].ToString();
                    wordcellrange = oTable.Cell(i, 11).Range;
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;// Выравнивание в ячейке
                    wordcellrange.Text = myDataReader["ФИОВрача"].ToString();
                    i++;
                }

            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox19.Text.Length > 0)
            {
                for (int i = 0; i < this.listBox8.Items.Count; i++)
                    if (!this.listBox8.Items[i].ToString().Contains(this.textBox19.Text))
                    {

                        this.listBox8.Items.RemoveAt(i);
                        i--;
                    }
            }
            else
            {
                this.listBox8.Items.Clear();
                for (int i = 0; i < lecarstva.Count; i++)
                    this.listBox8.Items.Add(lecarstva[i]);
            }
        }

        private void textBox19_Click(object sender, EventArgs e)
        {
            listBox8.Visible = true;
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textBox19.Text = listBox8.SelectedItem.ToString();
                }
                catch { }
                listBox8.Visible = false;
            }
        }

        private void listBox8_Click(object sender, EventArgs e)
        {
            try
            {
                textBox19.Text = listBox8.SelectedItem.ToString();
            }
            catch { }
            listBox8.Visible = false;
        }

        private void textBox20_Click(object sender, EventArgs e)
        {
            listBox9.Visible = true;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox20.Text.Length > 0)
            {
                for (int i = 0; i < this.listBox9.Items.Count; i++)
                    if (!this.listBox9.Items[i].ToString().Contains(this.textBox20.Text))
                    {

                        this.listBox9.Items.RemoveAt(i);
                        i--;
                    }
            }
            else
            {
                this.listBox9.Items.Clear();
                for (int i = 0; i < lecarstva.Count; i++)
                    this.listBox9.Items.Add(lecarstva[i]);
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textBox20.Text = listBox8.SelectedItem.ToString();
                }
                catch { }
                listBox9.Visible = false;
            }
        }

        private void listBox9_Click(object sender, EventArgs e)
        {
            try
            {
                textBox20.Text = listBox9.SelectedItem.ToString();
            }
            catch { }
            listBox9.Visible = false;
        }
        
        #endregion

        
        #endregion

        private void button8_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();


            if (comboBox1.SelectedItem.ToString() == "Врачи")
            {
                //Формируем и выполняем запрос на выборку 
                string strSQL = "SELECT * FROM [Врачи];";
                cm = new OleDbCommand(strSQL, cn);
                myDataReader = cm.ExecuteReader();
                dataGridView1.ColumnCount = 2;
                dataGridView1.RowCount = 60;
                int i = 0;
                if (myDataReader.HasRows)
                {

                    while (myDataReader.Read())
                    {
                        dataGridView1[0,i].Value=myDataReader["ФИО"].ToString();
                        dataGridView1[1, i].Value = myDataReader["Код"].ToString();
                        //dataGridView1.RowCount++;
                        i++;
                    }
                }
            }
            else
            {
                //Формируем и выполняем запрос на выборку 
                string strSQL = "SELECT * FROM [Пациенты];";
                cm = new OleDbCommand(strSQL, cn);
                myDataReader = cm.ExecuteReader();

                dataGridView1.ColumnCount = 5;
                dataGridView1.RowCount = 5;
                int i = 0;
                if (myDataReader.HasRows)
                {

                    while (myDataReader.Read())
                    {
                        dataGridView1[0, i].Value = myDataReader["ФИО"].ToString();
                        dataGridView1[1, i].Value = myDataReader["Адрес"].ToString();
                        dataGridView1[2, i].Value = myDataReader["ДатаРождения"].ToString();
                        dataGridView1[3, i].Value = myDataReader["Документ"].ToString();
                        dataGridView1[4, i].Value = myDataReader["Заболевание"].ToString();
                        //dataGridView1.RowCount++;
                        i++;
                    }
                }
            }
            cn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cnstr = new OleDbConnectionStringBuilder();
            cnstr.Provider = "Microsoft.ACE.OLEDB.12.0";
            cnstr.DataSource = @"dataBase.accdb";
            cn.ConnectionString = cnstr.ToString();

            //Подключаемся к БД и считываем данные

            //Открываем подключение
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            string strSQL = "INSERT INTO Врачи ( ФИО, Код) VALUES ('" + textBox23.Text + "','" + textBox24.Text + "');";
            cm = new OleDbCommand(strSQL, cn);

            int i = cm.ExecuteNonQuery();
            if (i == 1)
                MessageBox.Show("Запись успешно добавлена");
            cn.Close();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
