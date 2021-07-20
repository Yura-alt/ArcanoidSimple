using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ArcanoidSimple
{
    class GameEndgine
    {
        public Canvas mapSpace;
        List<ObjShape> shapes = new List<ObjShape>();
        DispatcherTimer timerBall = new DispatcherTimer();

        GameBackground gameBackground = new GameBackground();
        Ball ball = new Ball();
        Platform platform = new Platform();

        public bool statusGame=false;
        public GameEndgine()
        {

        }


        public void Draw()
        {
            foreach (var item in shapes)
                item.Draw(ref mapSpace);
        }
        public void Left()
        {
            if (platform.basePoint.X > 3)
            {
                mapSpace.Children.RemoveAt(2);
                platform.basePoint.X -= 5;
                platform.Draw(ref mapSpace);
            }
        }
        public void Right()
        {
            if ((platform.basePoint.X + 100) < 432)
            {
                mapSpace.Children.RemoveAt(2);
                platform.basePoint.X += 5;
                platform.Draw(ref mapSpace);
            }
        }
        public void MirrorBall()
        {
            if (ball.speedX>0 & ball.speedY>0)
                ball.speedY = -ball.speedY;
            else if (ball.speedX>0 & ball.speedY<0)
                ball.speedX = -ball.speedX;
            else if (ball.speedX < 0 & ball.speedY < 0)
                ball.speedY = -ball.speedY;
            else if (ball.speedX < 0 & ball.speedY > 0)
                ball.speedX = -ball.speedX;
        }
        public void CheckCollision()
        {
            var extball = ball.GetExtents();
            if (!extball.IsIntersect(shapes[0].GetExtents()))
            {
                MirrorBall();
            }

            for (int i = 2; i < shapes.Count(); i++)
            {
                
                if (extball.IsIntersect(shapes[i].GetExtents()))
                {
                    if (i==2)
                    {
                       MirrorBall();
                    }
                    else
                    {
                        RemoveBlock(i);
                        MirrorBall();
                    }    
                }
                
            }
        }

        public void RemoveBlock(int index)
        {
            shapes.RemoveAt(index);
            mapSpace.Children.RemoveAt(index);

        }

        public void KeyDown(System.Windows.Input.Key e)
        {
            if (e == Key.Left)
            {
                Left();
            }
            if (e == Key.Right)
            {
                Right();
            }
            if (e == Key.Space)
            {
                statusGame = true;
                timerBall.Start();
            }
        }

          private void TimerBall_Tick(object sender, EventArgs e)
        {
            ball.basePoint.X += ball.speedX;
            ball.basePoint.Y += ball.speedY;

            CheckCollision();
           

            ball.Move(ref mapSpace);

            
        }
            public void Init(ref Canvas mapSpace)
        {

          this.mapSpace = mapSpace;
            timerBall.Tick += new EventHandler(TimerBall_Tick);
            timerBall.Interval = new TimeSpan(0, 0, 0, 0, 5);
            

            shapes.Add(gameBackground);
            //shapes.Add(ball);
            shapes.Add(platform);


            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Block block = new Block(2 * j + Barrier.Widht * (j - 1), Barrier.Height * (i - 1) + 10 * i);
                    shapes.Add(block);
                }

            }

        }
    }
}
