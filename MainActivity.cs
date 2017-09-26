using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Calculator
{
    [Activity(Label = "Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            
            TextView MainText = FindViewById<TextView>(Resource.Id.display_text);
            TextView SubText = FindViewById<TextView>(Resource.Id.display_text_input);

            Button Button0 = FindViewById<Button>(Resource.Id.Button_0);
            Button Button1 = FindViewById<Button>(Resource.Id.Button_1);
            Button Button2 = FindViewById<Button>(Resource.Id.Button_2);
            Button Button3 = FindViewById<Button>(Resource.Id.Button_3);
            Button Button4 = FindViewById<Button>(Resource.Id.Button_4);
            Button Button5 = FindViewById<Button>(Resource.Id.Button_5);
            Button Button6 = FindViewById<Button>(Resource.Id.Button_6);
            Button Button7 = FindViewById<Button>(Resource.Id.Button_7);
            Button Button8 = FindViewById<Button>(Resource.Id.Button_8);
            Button Button9 = FindViewById<Button>(Resource.Id.Button_9);

            Button ButtonDec = FindViewById<Button>(Resource.Id.Button_decimal);

            Button ButtonAdd = FindViewById<Button>(Resource.Id.Button_add);
            Button ButtonSubtract = FindViewById<Button>(Resource.Id.Button_subtract);
            Button ButtonDivide = FindViewById<Button>(Resource.Id.Button_div);
            Button ButtonMultiply = FindViewById<Button>(Resource.Id.Button_multiply);
            Button ButtonDel = FindViewById<Button>(Resource.Id.Button_del);
            Button ButtonClear = FindViewById<Button>(Resource.Id.Button_clear);
            Button ButtonNegative = FindViewById<Button>(Resource.Id.Button_neg);
            Button ButtonSqrt = FindViewById<Button>(Resource.Id.Button_sqrt);

            Button ButtonSolve = FindViewById<Button>(Resource.Id.Button_solve);

            Button0.Click += delegate
            {
                addtonumber(MainText, "0");
            };
            Button1.Click += delegate
            {
                addtonumber(MainText, "1");
            };
            Button2.Click += delegate
            {
                addtonumber(MainText, "2");
            };
            Button3.Click += delegate
            {
                addtonumber(MainText, "3");
            };
            Button4.Click += delegate
            {
                addtonumber(MainText, "4");
            };
            Button5.Click += delegate
            {
                addtonumber(MainText, "5");
            };
            Button6.Click += delegate
            {
                addtonumber(MainText, "6");
            };
            Button7.Click += delegate
            {
                addtonumber(MainText, "7");
            };
            Button8.Click += delegate
            {
                addtonumber(MainText, "8");
            };
            Button9.Click += delegate
            {
                addtonumber(MainText, "9");
            };

            ButtonSqrt.Click += delegate
            {
                double result = Math.Sqrt(Convert.ToDouble(MainText.Text));
                if (result.ToString().Length > 12)
                {
                    result = Convert.ToDouble(result.ToString().Substring(0,12));
                }
                else
                {
                    result = Convert.ToDouble(result.ToString());
                }
                MainText.Text = result.ToString();
            };
            ButtonDec.Click += delegate
            {
                if (!(MainText.Text.Contains(".")))
                {
                    MainText.Text += ".";
                }
            };
            ButtonClear.Click += delegate
            {
                MainText.Text = "0";
                SubText.Text = "";
                
            };
            ButtonDel.Click += delegate
            {
                if (MainText.Text != "0")
                {
                    if (MainText.Length() > 1)
                        MainText.Text = MainText.Text.Substring(0, (MainText.Text.Length - 1));
                    else
                        MainText.Text = "0";
                }
            };
            ButtonNegative.Click += delegate
            {
                if (MainText.Text.Length < 12 && MainText.Text != "0")
                {
                    string temp = "";
                    if (MainText.Text[0] != '-')
                    {
                        temp = MainText.Text.Insert(0, "-"); ;
                    }
                    else if(MainText.Text[0] == '-')
                    {
                        temp = MainText.Text.Substring(1, MainText.Text.Length-1);
                    }
                    MainText.Text = temp;
                }
            };

            ButtonAdd.Click += delegate
            {
                operations(MainText, SubText, "+");
            };
            ButtonSubtract.Click += delegate
            {
                operations(MainText, SubText, "-");
            };
            ButtonMultiply.Click += delegate
            {
                operations(MainText, SubText, "x");
            };
            ButtonDivide.Click += delegate
            {
                operations(MainText, SubText, "/");
            };
            ButtonSolve.Click += delegate
            {
                operations(MainText, SubText, "=");
            };

        }

        private void operations(TextView MainText, TextView SubText, string op)
        {
            if(MainText.Text[MainText.Text.Length-1] == '.')
            {
                MainText.Text = MainText.Text.Substring(0, (MainText.Text.Length - 1));
            }
            if(op != "=")
            {
                SubText.Text = suboperations(MainText, SubText, op) + op;
                MainText.Text = "0";
            }
            else
            {
                MainText.Text = suboperations(MainText, SubText, op);
                SubText.Text = "";
            }
        }

        private string suboperations(TextView MainText, TextView SubText, string op)
        {
            double result;
            double mainneg = 1;
            double subneg = 1;
            if (SubText.Text != "") {
                if (MainText.Text[0] == '-')
                {
                    mainneg *= -1;
                    MainText.Text = MainText.Text.Substring(1);
                }
                if (SubText.Text[0] == '-')
                {
                    subneg *= -1;
                    SubText.Text = SubText.Text.Substring(1);
                }
                
                if (SubText.Text.Contains("+"))
                {
                    SubText.Text = SubText.Text.Substring(0, (SubText.Text.Length - 1));
                    result = (subneg * Convert.ToDouble(SubText.Text)) + (mainneg * Convert.ToDouble(MainText.Text));
                    return result.ToString();
                }

                if (SubText.Text.Contains("-"))
                {
                    SubText.Text = SubText.Text.Substring(0, (SubText.Text.Length - 1));
                    result = (subneg * Convert.ToDouble(SubText.Text)) - (mainneg * Convert.ToDouble(MainText.Text));
                    return result.ToString();
                }

                if (SubText.Text.Contains("*"))
                {
                    SubText.Text = SubText.Text.Substring(0, (SubText.Text.Length - 1));
                    result = (subneg * Convert.ToDouble(SubText.Text)) * (mainneg * Convert.ToDouble(MainText.Text));
                    return result.ToString();
                }

                if (SubText.Text.Contains("/"))
                {
                    SubText.Text = SubText.Text.Substring(0, (SubText.Text.Length - 1));
                    result = (subneg * Convert.ToDouble(SubText.Text)) / (mainneg * Convert.ToDouble(MainText.Text));
                    if (result.ToString() == "Infinity")
                        return "0";
                    else
                        return result.ToString();
                }
            }
            return MainText.Text;
        }

        private void addtonumber(TextView MainText,string number)
        {
            if (MainText.Length() < 12)
                if (MainText.Text == "0" && MainText.Length() == 1)
                    MainText.Text = number;
                else
                    MainText.Text += number;
        }
    }
}

