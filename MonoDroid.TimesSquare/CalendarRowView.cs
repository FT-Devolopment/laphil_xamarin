using System;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MonoDroid.TimesSquare
{
    public class CalendarRowView : ViewGroup, View.IOnClickListener
    {
        public bool IsHeaderRow { get; set; }
        public ClickHandler ClickHandler;
        private int _cellSize;

        public CalendarRowView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public override void AddView(View child, int index, LayoutParams @params)
        {
            child.SetOnClickListener(this);
            base.AddView(child, index, @params);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int totalWidth = MeasureSpec.GetSize(widthMeasureSpec);
            _cellSize = totalWidth / 7;
            int cellWidthSpec = MeasureSpec.MakeMeasureSpec(_cellSize, MeasureSpecMode.Exactly);
            int cellHeightSpec = IsHeaderRow
                ? MeasureSpec.MakeMeasureSpec(_cellSize, MeasureSpecMode.AtMost)
                : cellWidthSpec;
            int rowHeight = 0;
            for (int c = 0; c < ChildCount; c++) {
                var child = GetChildAt(c);
                child.Measure(cellWidthSpec, cellHeightSpec);
                //The row height is the height of the tallest cell.
                if (child.MeasuredHeight > rowHeight) {
                    rowHeight = child.MeasuredHeight;
                }
            }
            int widthWithPadding = totalWidth + PaddingLeft + PaddingRight;
            int heightWithPadding = rowHeight + PaddingTop + PaddingBottom;
            SetMeasuredDimension(widthWithPadding, heightWithPadding);

            stopwatch.Stop();
            //Logr.D("Row.OnMeasure {0} ms", stopwatch.ElapsedMilliseconds);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int cellHeight = b - t;
            for (int c = 0; c < ChildCount; c++) {
                var child = GetChildAt(c);
                child.Layout(c * _cellSize, 0, (c + 1) * _cellSize, cellHeight);
            }

            stopwatch.Stop();
            //Logr.D("Row.OnLayout {0} ms", stopwatch.ElapsedMilliseconds);
        }

        public void OnClick(View v)
        {
            if (ClickHandler != null) {
                ClickHandler((MonthCellDescriptor) v.Tag);
            }
        }

        public void SetCellBackground(int resID)
        {
            for (int i = 0; i < ChildCount; i++) {
                GetChildAt(i).SetBackgroundResource(resID);
            }
        }

        public void SetCellTextColor(ColorStateList colors)
        {
            for (int i = 0; i < ChildCount; i++) {
                ((TextView)GetChildAt(i)).SetTextColor(colors);
            }
        }

        public void SetCellTextColor(int resID)
        {
            for (int i = 0; i < ChildCount; i++) {
                ((TextView) GetChildAt(i)).SetTextColor(base.Resources.GetColor(resID));
            }
        }
    }
}