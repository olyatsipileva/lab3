using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public enum MeasureType { F, C, K, Ra };

    public class Temperature
    {
        private float value;
        private MeasureType type;

        public Temperature(float value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }

        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.F:
                    typeVerbose = "F";
                    break;
                case MeasureType.C:
                    typeVerbose = "C";
                    break;
                case MeasureType.K:
                    typeVerbose = "K";
                    break;
                case MeasureType.Ra:
                    typeVerbose = "Ra";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }

        public static Temperature operator +(Temperature instance, float number)
        {
            // расчитываем новую значение
            var newValue = instance.value + number;
            // создаем новый экземпляр класса, с новый значением и типом как у меры, к которой число добавляем
            var length = new Temperature(newValue, instance.type);
            // возвращаем результат
            return length;
        }

        public static bool operator %(Temperature instance, float number)
        {
            // сравнение чисел
            if (instance.value == number)
            {
                return true;
            }

            return false;
        }

        public static bool operator %(float number, Temperature instance)
        {
            // сравнение чисел
            if (instance.value == number)
            {
                return true;
            }

            return false;
        }

        // чтобы можно было добавлять число также слева
        public static Temperature operator +(float number, Temperature instance)
        {
            // вызываем с правильным порядком аргументов, то есть сначала длина потом число
            // для такого порядка мы определили оператор выше
            return instance + number;
        }

        // умножение
        public static Temperature operator *(Temperature instance, float number)
        {
            // мне лень по три строчки писать, поэтому я сокращаю код до одной строки
            return new Temperature(instance.value * number, instance.type); ;
        }

        public static Temperature operator *(float number, Temperature instance)
        {
            return instance * number;
        }

        // вычитание
        public static Temperature operator -(Temperature instance, float number)
        {
            return new Temperature(instance.value - number, instance.type); ;
        }

        public static Temperature operator -(float number, Temperature instance)
        {
            return instance - number;
        }

        // деление
        public static Temperature operator /(Temperature instance, float number)
        {
            return new Temperature(instance.value / number, instance.type); ;
        }

        public static Temperature operator /(float number, Temperature instance)
        {
            return instance / number;
        }

        public static string Output(Temperature instance)
        {
            // перевод температуры
            return instance.value.ToString() + ' ' + instance.type.ToString();
        }

        public Temperature To(MeasureType newType)
        {
            // по умолчанию новое значение совпадает со старым
            var newValue = this.value;
            // переводим в Цельсий
            switch (this.type)
            {
                case MeasureType.C:
                    newValue = this.value;
                    break;
                case MeasureType.F:
                    newValue = (this.value - 32) / (9 / 5);
                    break;
                case MeasureType.K:
                    newValue = this.value - 273;
                    break;
                case MeasureType.Ra:
                    newValue = (this.value - 491.67f) / (9 / 5);
                    break;
            }
            // если текущий тип -- это метр
            if (this.type == MeasureType.C)
            {
                // а теперь рассматриваем все другие ситуации
                switch (newType)
                {
                    // если конвертим в метр, то значение не меняем
                    case MeasureType.C:
                        break;
                    // если в км.
                    case MeasureType.F:
                        newValue = newValue * 9 / 5 + 32;
                        break;
                    // если в  а.е.
                    case MeasureType.K:
                        newValue = newValue + 273;
                        break;
                    // если в парсек
                    case MeasureType.Ra:
                        newValue = newValue * 9 / 5 + 491.67f;
                        break;
                }
            }
            this.type = newType;
            return new Temperature(newValue, newType);
        }

        public static Temperature operator +(Temperature instance1, Temperature instance2)
        {
            var newValue = instance1.To(MeasureType.C).value + instance2.To(MeasureType.C).value;
            return new Temperature(newValue, MeasureType.C);
        }

        public static Temperature operator -(Temperature instance1, Temperature instance2)
        {
            var newValue = instance1.To(MeasureType.C).value - instance2.To(MeasureType.C).value;
            return new Temperature(newValue, MeasureType.C);
        }

        public static string operator %(Temperature instance1, Temperature instance2)
        {
            if (instance1.To(MeasureType.C).value == instance2.To(MeasureType.C).value)
            {
                return "Равны";
            }
            if (instance1.To(MeasureType.C).value > instance2.To(MeasureType.C).value)
            {
                return "Первое больше";
            }

            return "Первое меньше";
        }

        public static Temperature operator *(Temperature instance1, Temperature instance2)
        {
            var newValue = instance1.To(MeasureType.C).value * instance2.To(MeasureType.C).value;
            return new Temperature(newValue, MeasureType.C);
        }
    }
}
