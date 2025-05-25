using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
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
        public override void OnInitialize()
        {
            UIPanel panel = new() {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            panel.Width.Set(150, 0);
            panel.Height.Set(200, 0);
            Append(panel);

            UIPanel textBox = new() {
                HAlign = 0.5f
            };
            textBox.Width.Set(0, 1f);
            textBox.Height.Set(30, 0);
            panel.Append(textBox);

            UIText outputText = new("");
            outputText.Width.Set(0, 1f);
            outputText.Height.Set(0, 1f);
            textBox.Append(outputText);

            CalculatorState state = ModContent.GetInstance<CalculatorState>();
            state.outputText = outputText;

            MouseEvent[,] buttonActions = new MouseEvent[4, 5] {
                {state.SevenButton, state.EightButton, state.NineButton, OnButtonClick, OnButtonClick},
                {state.FourButton, state.FiveButton, state.SixButton, OnButtonClick, OnButtonClick},
                {state.OneButton, state.TwoButton, state.ThreeButton, OnButtonClick, OnButtonClick},
                {state.ZeroButton, OnButtonClick, OnButtonClick, OnButtonClick, OnButtonClick},
            };

            string[,] buttonLabels = new string[4, 5] {
                {"7", "8", "9", "!", "!"},
                {"4", "5", "6", "!", "!"},
                {"1", "2", "3", "!", "!"},
                {"0", "!", "!", "!", "!"},
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

        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            if (listeningElement is UIButton button) {
                UIText label = button.GetLabel();
                label.TextColor = label.TextColor == Color.White ? Color.Green : Color.White;
            }
        }
    }
}
