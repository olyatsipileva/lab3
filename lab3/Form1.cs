using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // список значений
            var measureItems = new string[]
            {
            "C",
            "F",
            "K",
            "Ra",
            };

            // привязываем списки значений к каждому комбобоксу
            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);
        }

        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "C":
                    measureType = MeasureType.C;
                    break;
                case "F":
                    measureType = MeasureType.F;
                    break;
                case "K":
                    measureType = MeasureType.K;
                    break;
                case "Ra":
                    measureType = MeasureType.Ra;
                    break;
                default:
                    measureType = MeasureType.C;
                    break;
            }
            return measureType;
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // считали значения с полей для ввода и сконвертили в числа
                var firstValue = float.Parse(txtFirst.Text);
                var secondValue = float.Parse(txtSecond.Text);

                // вместо трех страшных свитчей, три вызова нашей новой функции
                MeasureType firstType = GetMeasureType(cmbFirstType);
                MeasureType secondType = GetMeasureType(cmbSecondType);
                MeasureType resultType = GetMeasureType(cmbResultType);

                // на основании значений создали экземпляры нашего класса Length 
                var firstTemperature = new Temperature(firstValue, firstType);
                var secondTempearature = new Temperature(secondValue, secondType);

                Temperature sumTemp;

                switch (cmbOperation.Text)
                {
                    case "+":
                        // если плюсик выбрали, то складываем
                        sumTemp = firstTemperature + secondTempearature;
                        break;
                    case "-":
                        // если минус, то вычитаем
                        sumTemp = firstTemperature - secondTempearature;
                        break;
                    default:
                        // а если что-то другое, то просто 0 выводим,
                        // такое маловероятно, но надо указать иначе не скомпилится
                        sumTemp = new Temperature(0, MeasureType.C);
                        break;
                }
                // записали в поле txtResult длину в строковом виде
                txtResult.Text = sumTemp.To(resultType).Verbose();
            }
            catch (FormatException)
            {
                // если тип преобразовать не смогли
                txtResult.Text = "-";
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFirst_TextChanged(sender, e);
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            txtFirst_TextChanged(sender, e);
        }
    }
}
