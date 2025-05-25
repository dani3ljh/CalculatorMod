using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.UI;
using TutorialMod.UI;
using rail;
using Terraria.GameContent.UI.Elements;

namespace TutorialMod
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
        public static string ToSymbol(this Operator op) {
            switch (op)
            {
                case Operator.Addition:
                    return "+";
                case Operator.Subtraction:
                    return "-";
                case Operator.Multiplication:
                    return "×";
                case Operator.Division:
                    return "÷";
                default:
                    return null;
            }
        }
    }

    class CalculatorState : ModSystem
    {
        private string num1;
        private Operator operation;
        private string num2;
        private bool isNum1 = true;
        internal UIText outputText;

        private void UpdateOutput()
        {
            if (isNum1)
            {
                outputText.SetText(num1);
            }
            else
            {
                outputText.SetText($"{num1} {operation.ToSymbol()} {num2}");
            }
        }

        internal void ZeroButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "0";
            }
            else
            {
                num2 += "0";
            }
            UpdateOutput();
        }

        internal void OneButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "1";
            }
            else
            {
                num2 += "1";
            }
            UpdateOutput();
        }

        internal void TwoButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "2";
            }
            else
            {
                num2 += "2";
            }
            UpdateOutput();
        }

        internal void ThreeButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "3";
            }
            else
            {
                num2 += "3";
            }
            UpdateOutput();
        }

        internal void FourButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "4";
            }
            else
            {
                num2 += "4";
            }
            UpdateOutput();
        }

        internal void FiveButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "5";
            }
            else
            {
                num2 += "5";
            }
            UpdateOutput();
        }

        internal void SixButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "6";
            }
            else
            {
                num2 += "6";
            }
            UpdateOutput();
        }

        internal void SevenButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "7";
            }
            else
            {
                num2 += "7";
            }
            UpdateOutput();
        }

        internal void EightButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "8";
            }
            else
            {
                num2 += "8";
            }
            UpdateOutput();
        }

        internal void NineButton(UIMouseEvent evt, UIElement listeningElement)
        {
            if (isNum1)
            {
                num1 += "9";
            }
            else
            {
                num2 += "9";
            }
            UpdateOutput();
        }
        
        // internal void Decimal
    }
}