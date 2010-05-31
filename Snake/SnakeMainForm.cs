using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake
{
    public partial class SnakeMainForm : Form
    {
        Arena arena;
        bool updating;

        Random random = new Random();

        public SnakeMainForm()
        {
            InitializeComponent();
            CreateArena();
        }

        private void PanelArena_Paint(object sender, PaintEventArgs e)
        {
            ArenaView.Render(e.Graphics, arena);
        }

        private void TimerUpdateWorld_Tick(object sender, EventArgs e)
        {
            if (!updating)
            {
                updating = true;
                arena.Update();
                PanelArena.Refresh();
                updating = false;
            }
            else
            {
                Console.WriteLine("!");
            }
        }

        private void PanelArena_Resize(object sender, EventArgs e)
        {
            CreateArena();
        }

        private void CreateArena()
        {
            arena = new Arena(PanelArena.Width / 10, PanelArena.Height / 10);
        }

        private void SnakeMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    arena.Snake.ChangeDirection(Direction.Down);
                    break;

                case Keys.Left:
                    arena.Snake.ChangeDirection(Direction.Left);
                    break;

                case Keys.Right:
                    arena.Snake.ChangeDirection(Direction.Right);
                    break;

                case Keys.Up:
                    arena.Snake.ChangeDirection(Direction.Up);
                    break;
            }
        }
    }
}
