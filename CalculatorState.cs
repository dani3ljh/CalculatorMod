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
        internal UIText outputText;

        private string num1;
        private Operator operation;
        private string num2;
        private bool isNum1;

        public override void OnWorldLoad()
        {
            num1 = "";
            num2 = "";
            isNum1 = true;
        }

        internal void ClearEntry()
        {
            if (isNum1) {
                num1 = "";
            } else if (num2 != "") {
                num2 = "";
            } else {
                isNum1 = true;
            }
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

        internal void NumberButton(char num)
        {
            if (isNum1) {
                num1 += num;
            } else {
                num2 += num;
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

        internal void OperatorButton(Operator op)
        {
            operation = op;
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
            } catch {
                outputText.SetText("Error");
            }
        }

        internal void BackspaceButton()
        {
            if (isNum1) {
                if (num1 == "") return;
                num1 = num1[..(num1.Length - 1)];
            } else if (num2 == "") {
                isNum1 = true;
            } else {
                num2 = num2[..(num2.Length - 1)];
            }
            UpdateOutput();
        }

        internal void SqrtButton()
        {
            try {
                if (isNum1) {
                    if (num1 == "") return;
                    double doubleNum1 = Convert.ToDouble(num1);
                    num1 = Math.Sqrt(doubleNum1).ToString();
                } else {
                    if (num2 == "") return;
                    double doubleNum2 = Convert.ToDouble(num2);
                    num2 = Math.Sqrt(doubleNum2).ToString();
                }
                UpdateOutput();
            } catch {
                outputText.SetText("Error");
            }
        }
    }
}