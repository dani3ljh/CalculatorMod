using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.UI;
using rail;
using Terraria.GameContent.UI.Elements;

namespace CalculatorMod
{
    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }

    public static class OperatorExtensions
    {
        public static string ToSymbol(this Operator op)
        {
            return op switch {
                Operator.Addition => "+",
                Operator.Subtraction => "-",
                Operator.Multiplication => "×",
                Operator.Division => "÷",
                _ => null,
            };
        }
    }

    class CalculatorState : ModSystem
    {
        private string num1;
        private Operator operation;
        private string num2;
        private bool isNum1;
        internal UIText outputText;

        public override void OnWorldLoad()
        {
            ClearEntry();
        }

        internal void ClearEntry()
        {
            num1 = "";
            num2 = "";
            isNum1 = true;
            UpdateOutput();
        }

        private void UpdateOutput()
        {
            if (outputText == null) return;
            if (isNum1) {
                outputText.SetText(num1);
            } else {
                outputText.SetText($"{num1} {operation.ToSymbol()} {num2}");
            }
        }

        internal void ZeroButton()
        {
            if (isNum1) {
                num1 += '0';
            } else {
                num2 += '0';
            }
            UpdateOutput();
        }

        internal void OneButton()
        {
            if (isNum1) {
                num1 += '1';
            } else {
                num2 += '1';
            }
            UpdateOutput();
        }

        internal void TwoButton()
        {
            if (isNum1) {
                num1 += '2';
            } else {
                num2 += '2';
            }
            UpdateOutput();
        }

        internal void ThreeButton()
        {
            if (isNum1) {
                num1 += '3';
            } else {
                num2 += '3';
            }
            UpdateOutput();
        }

        internal void FourButton()
        {
            if (isNum1) {
                num1 += '4';
            } else {
                num2 += '4';
            }
            UpdateOutput();
        }

        internal void FiveButton()
        {
            if (isNum1) {
                num1 += '5';
            } else {
                num2 += '5';
            }
            UpdateOutput();
        }

        internal void SixButton()
        {
            if (isNum1) {
                num1 += '6';
            } else {
                num2 += '6';
            }
            UpdateOutput();
        }

        internal void SevenButton()
        {
            if (isNum1) {
                num1 += '7';
            } else {
                num2 += '7';
            }
            UpdateOutput();
        }

        internal void EightButton()
        {
            if (isNum1) {
                num1 += '8';
            } else {
                num2 += '8';
            }
            UpdateOutput();
        }

        internal void NineButton()
        {
            if (isNum1) {
                num1 += '9';
            } else {
                num2 += '9';
            }
            UpdateOutput();
        }

        internal void DecimalButton()
        {
            if (isNum1) {
                if (num1 == "")
                    num1 = "0.";
                else if (!num1.Contains('.'))
                    num1 += '.';
            } else {
                if (num2 == "")
                    num2 = "0.";
                else if (!num2.Contains('.'))
                    num2 += '.';
            }
            UpdateOutput();
        }

        internal void NegateButton()
        {
            string currNum = isNum1 ? num1 : num2;
            if (currNum == "") return;
            if (currNum[0] == '-')
                currNum = currNum[1..];
            else
                currNum = '-' + currNum;
            if (isNum1)
                num1 = currNum;
            else
                num2 = currNum;
            UpdateOutput();
        }

        internal void AdditionButton()
        {
            operation = Operator.Addition;
            isNum1 = false;
            UpdateOutput();
        }

        internal void SubtractionButton()
        {
            operation = Operator.Subtraction;
            isNum1 = false;
            UpdateOutput();
        }

        internal void MultiplicationButton()
        {
            operation = Operator.Multiplication;
            isNum1 = false;
            UpdateOutput();
        }

        internal void DivisionButton()
        {
            operation = Operator.Division;
            isNum1 = false;
            UpdateOutput();
        }

        private double CalculateOperation(double num1, double num2)
        {
            return operation switch {
                Operator.Addition => num1 + num2,
                Operator.Subtraction => num1 - num2,
                Operator.Multiplication => num1 * num2,
                Operator.Division => num1 / num2,
                _ => 0,
            };
        }

        internal void EqualsButton()
        {
            if (isNum1) return;

            try {
                double doubleNum1 = Convert.ToDouble(num1);
                double doubleNum2 = Convert.ToDouble(num2);

                double output = CalculateOperation(doubleNum1, doubleNum2);
                num1 = output.ToString();
                num2 = "";
                isNum1 = true;
                UpdateOutput();
            } catch (Exception e) {
                outputText.SetText(e.ToString());
            }
        }

        internal void BackspaceButton()
        {
            if (isNum1) {
                if (num1 == "") return;
                num1 = num1[..(num1.Length - 1)];
            } else {
                if (num2 == "")
                    isNum1 = true;
                else
                    num2 = num2[..(num2.Length - 1)];
            }
            UpdateOutput();
        }

        internal void SqrtButton()
        {
            try {
                if (isNum1) {
                    double doubleNum1 = Convert.ToDouble(num1);
                    num1 = Math.Sqrt(doubleNum1).ToString();
                } else {
                    double doubleNum2 = Convert.ToDouble(num2);
                    num2 = Math.Sqrt(doubleNum2).ToString();
                }
                UpdateOutput();
            } catch (Exception e) {
                outputText.SetText(e.ToString());
            }
        }
    }
}