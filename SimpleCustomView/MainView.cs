using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Java.Lang;
using XamarinSimpleCustomView;

namespace SimpleCustomView
{
    public class MainView : View, IRunnable
    {
        Context c;
        private Handler handler;
        private bool isUpdating;
        private int greenX;

        private Paint green;
        private bool isMoving;
        private bool isMovingLeft;

        private int screenW, screenH;

        private Bitmap ball;

        public MainView(Context context) : base(context)
        {
            Initialize(context);
        }

        private void Initialize(Context context)
        {
            c = context;
            isUpdating = true;
            isMoving = true;

            screenW = context.Resources.DisplayMetrics.WidthPixels;
            screenH = context.Resources.DisplayMetrics.HeightPixels;

            green = new Paint();
            green.SetARGB(255, 0, 255, 0);
            greenX = 100;

            ball = BitmapFactory.DecodeResource(Resources, Resource.Drawable.ball);            

            handler = new Handler();
            handler.Post(this);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            //Aqui desenho meus objetos
            canvas.DrawRect(greenX, 100, 50 + greenX, 50, green);
            canvas.DrawRect(300, 600, 350, 650, green);            
            canvas.DrawBitmap(ball, 100, 100, green);
        }

        private void OnUpdate()
        {
            //Aqui atualizado meus objetos
            if(isMoving)
            {
                if(isMovingLeft == true)
                {
                    greenX -= 10;
                }
                else
                {
                    greenX += 10;
                }

                if (greenX + 50 > screenW) isMovingLeft = true;
                else if(greenX < 0) isMovingLeft = false;
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            /*if (e.Action == MotionEventActions.Down ||
               e.Action == MotionEventActions.Move)
            {
                isMoving = true;
                isMovingLeft = greenX > e.RawX; // x = true || false
            }
            else if (e.Action == MotionEventActions.Up)
                isMoving = false;*/

            return true;
        }

        public void Run()
        {
            if(isUpdating == true)
            {
                handler.PostDelayed(this, 30);

                OnUpdate();
                this.Invalidate();
            }            
        }
    }
}