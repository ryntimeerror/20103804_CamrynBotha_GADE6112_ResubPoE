/*Camryn Botha 2010384
 * GADE6112 PoE Resubmission
 * 20/01/2021*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20103804_Botha_GADE6112_Resub
{
    public partial class frmGame : Form
    {
        //Task 1 - Q4.1
        GameEngine gameEngine;

        public frmGame()
        {
            gameEngine = new GameEngine();
           
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            lblMap.Text = gameEngine.View;
            lblBattleInfo.Text = gameEngine.HeroStats;
        }

        private void frmGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                MoveUp();
            }
            else if (e.KeyChar == 's')
            {
                MoveDown();
            }
            else if (e.KeyChar == 'a')
            {
                MoveLeft();
            }
            else if (e.KeyChar == 'd')
            {
                MoveRight();
            }
            else if (e.KeyChar == 'i')
            {
                AttackUp();
            }
            else if (e.KeyChar == 'k')
            {
                AttackDown();
            }
            else if (e.KeyChar == 'j')
            {
                AttackRight();
            }
            else if (e.KeyChar == 'l')
            {
                AttackLeft();
            }
            else if (e.KeyChar == '1')
            {
                SaveGame();
            }
            else if (e.KeyChar == '2')
            {
                LoadGame();
            }
        }

        private void MoveUp()
        {
            gameEngine.MovePlayer(Movement.UP);
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;
            
        }

        private void MoveLeft()
        {
            gameEngine.MovePlayer(Movement.LEFT);
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;
            
        }

        private void MoveDown()
        {
            gameEngine.MovePlayer(Movement.DOWN);
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;
            
        }

        private void MoveRight()
        {
            gameEngine.MovePlayer(Movement.RIGHT);
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;            
        }

        private void AttackUp()
        {
            lblBattleInfo.Text = gameEngine.PlayerAttack(AttackDirection.UP);
            lblMap.Text = gameEngine.View;
        }

        private void AttackDown()
        {
            lblBattleInfo.Text = gameEngine.PlayerAttack(AttackDirection.DOWN);
            lblMap.Text = gameEngine.View;
        }

        private void AttackLeft()
        {
            lblBattleInfo.Text = gameEngine.PlayerAttack(AttackDirection.LEFT);
            lblMap.Text = gameEngine.View;
        }


        private void AttackRight()
        {
            lblBattleInfo.Text = gameEngine.PlayerAttack(AttackDirection.RIGHT);
            lblMap.Text = gameEngine.View;
        }

        private void SaveGame()
        {
            gameEngine.Save();
        }

        private void LoadGame()
        {
            gameEngine.Load();
            lblBattleInfo.Text = gameEngine.HeroStats;
            lblMap.Text = gameEngine.View;
        }
    }
}
