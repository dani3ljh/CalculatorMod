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
    class UISystem : ModSystem
    {
        internal UserInterface MyInterface;
        internal CalculatorUI CalculatorUIState;
        private GameTime _lastUpdateUIGameTime;
        
        public override void Load()
        {
            if (!Main.dedServ)
            {
                MyInterface = new();
                
                CalculatorUIState = new();
                CalculatorUIState.Activate();
            }
        }
        
        public override void Unload()
        {
            // MyUI?.Unload();
            CalculatorUIState = null;
        }
        
        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUIGameTime = gameTime;
            if (MyInterface?.CurrentState != null)
            {
                MyInterface.Update(gameTime);
            }
        }
        
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name == "Vanilla: Mouse Text");
            if (mouseTextIndex == -1) return;
            
            layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                "TutorialMod: MyInterface",
                delegate
                {
                    if (_lastUpdateUIGameTime != null && MyInterface?.CurrentState != null)
                    {
                        MyInterface.Draw(Main.spriteBatch, _lastUpdateUIGameTime);
                    }
                    return true;
                },
                InterfaceScaleType.UI
            ));
        }
        
        internal void ShowCalculatorUI()
        {
            MyInterface?.SetState(CalculatorUIState);
        }
        
        internal void HideCalculatorUI()
        {
            MyInterface?.SetState(null);
        }
        
        internal void ToggleCalculatorUI()
        {
            if (MyInterface == null) return;
            if (MyInterface.CurrentState == null)
                ShowCalculatorUI();
            else
                HideCalculatorUI();
        }
    }
    
    class UIButton : UIPanel
    {
        private readonly UIText label;
        
        public UIButton(MouseEvent onClick, string labelText) : base()
        {
            OnLeftClick += onClick;
            
            label = new(labelText)
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            Append(label);
        }
        
        public UIButton(MouseEvent onClick) : base()
        {
            OnLeftClick += onClick;
        }
        
        public UIText GetLabel()
        {
            return label;
        }
    }
}
