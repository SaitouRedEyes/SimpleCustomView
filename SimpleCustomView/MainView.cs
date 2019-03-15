using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Java.Lang;

namespace SimpleCustomView
{
    public class MainView : View, IRunnable
    {
        Context c;
        private Handler handler;
        private bool isUpdating;
        private int greenX;

        private Paint green;

        public MainView(Context context) : base(context)
        {
            Initialize(context);
        }

        public MainView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public MainView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize(context);
        }

        private void Initialize(Context context)
        {
            c = context;
            isUpdating = true;

            green = new Paint();
            green.SetARGB(255, 0, 255, 0);
            greenX = 100;

            handler = new Handler();
            handler.Post(this);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            //Aqui desenho meus objetos
            canvas.DrawRect(greenX, 100, 50 + greenX, 50, green);
        }

        private void OnUpdate()
        {
            //Aqui atualizado meus objetos
            greenX += 2;
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