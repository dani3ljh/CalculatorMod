using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace CalculatorMod.UI
{
    class CalculatorUI : UIState
    {
        UIPanel panel;

        public override void OnInitialize()
        {
            panel = new() {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            panel.Width.Set(150, 0);
            panel.Height.Set(250, 0);
            Append(panel);

            UIPanel textBox = new() {
                HAlign = 0.5f
            };
            textBox.Width.Set(0, 1f);
            textBox.Height.Set(40, 0);
            panel.Append(textBox);

            UIText outputText = new("");
            outputText.Width.Set(0, 1f);
            outputText.Height.Set(0, 1f);
            textBox.Append(outputText);

            CalculatorState state = ModContent.GetInstance<CalculatorState>();
            state.outputText = outputText;

            MouseEvent[,] buttonActions = new MouseEvent[4, 5] {
                {(_,_) => state.NumberButton('7'), (_,_) => state.NumberButton('8'), (_,_) => state.NumberButton('9'), (_,_) => state.OperatorButton(Operator.Division), (_,_) => state.ClearEntry()},
                {(_,_) => state.NumberButton('4'), (_,_) => state.NumberButton('5'), (_,_) => state.NumberButton('6'), (_,_) => state.OperatorButton(Operator.Multiplication), (_,_) => state.BackspaceButton()},
                {(_,_) => state.NumberButton('1'), (_,_) => state.NumberButton('2'), (_,_) => state.NumberButton('3'), (_,_) => state.OperatorButton(Operator.Subtraction), (_,_) => state.SqrtButton()},
                {(_,_) => state.NumberButton('0'), (_,_) => state.DecimalButton(), (_,_) => state.NegateButton(), (_,_) => state.OperatorButton(Operator.Addition), (_,_) => state.EqualsButton()},
            };

            string[,] buttonLabels = new string[4, 5] {
                {"7", "8", "9", "÷", "CE"},
                {"4", "5", "6", "×", "←"},
                {"1", "2", "3", "-", "√"},
                {"0", ".", "(-)", "+", "="},
            };

            // array of buttons
            CalculatedStyle panelInnerDimensions = panel.GetInnerDimensions();
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 4; y++) {
                    UIButton button = new(buttonActions[3 - y, x], buttonLabels[3 - y, x]);
                    button.Left.Set(0.2f * panelInnerDimensions.Width * x, 0);
                    button.Top.Set(panelInnerDimensions.Height - 0.2f * panelInnerDimensions.Height * (y + 1), 0);
                    button.Width.Set(0, 0.2f);
                    button.Height.Set(0, 0.2f);
                    panel.Append(button);
                }
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            
            if (panel.ContainsPoint(Main.MouseScreen)) {
                Main.LocalPlayer.mouseInterface = true;
            }
        }
    }
}
