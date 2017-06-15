using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HelloAndroid
{
    [Activity(Label = "QuestionsActivity")]
    public class QuestionsActivity : Activity
    {
        private RadioButton choiceA, choiceB, choiceC, choiceD;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            
            // Create your application here
            SetContentView(Resource.Layout.Questions);

            //getData
            QuestionSQLiteOpenHelper dbHelper = new QuestionSQLiteOpenHelper(this.ApplicationContext);
            Android.Database.Sqlite.SQLiteDatabase db = dbHelper.WritableDatabase;
            Android.Database.ICursor cursor = db.Query("TBQuestion", null, null, null, null, null, null);

            if(cursor.MoveToFirst())
            {
                do
                {
                    string title = cursor.GetString(cursor.GetColumnIndex("QTitle"));
                } while (cursor.MoveToNext());

            }
            
            string[] question = {    "【单选】教育贯穿整个人生，从出生到坟墓都要学习。此观点表达的思想是（）。",  "A、终身学习", "B、学生地位" , "C、我是选项C", "D、学生是责权的主体" };
            
            ListView questionListView = FindViewById<ListView>(Resource.Id.QuestionListView);
            ArrayAdapter<string> adp = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, question);
            questionListView.Adapter = adp;

            Button submitBtn = FindViewById<Button>(Resource.Id.SubmitButton);
            submitBtn.Click += SubmitBtn_Click;

            Button endTestBtn = FindViewById<Button>(Resource.Id.EndButton);
            endTestBtn.Click += EndTestBtn_Click;

            Button nextBtn = FindViewById<Button>(Resource.Id.NextButton);
            nextBtn.Click += NextBtn_Click;

            choiceA = FindViewById<RadioButton>(Resource.Id.choiceA);
            choiceB = FindViewById<RadioButton>(Resource.Id.choiceB);
            choiceC = FindViewById<RadioButton>(Resource.Id.choiceC);
            choiceD = FindViewById<RadioButton>(Resource.Id.choiceD);
            setChoiceEvent();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            LinearLayout single_linearLayout = FindViewById<LinearLayout>(Resource.Id.AnswerLinearLayout_Single);
            LinearLayout muti_linearLayout = FindViewById<LinearLayout>(Resource.Id.AnswerLinearLayout_Muti);
            if (single_linearLayout.Visibility == ViewStates.Invisible)
                single_linearLayout.Visibility = ViewStates.Visible;
            else
                single_linearLayout.Visibility = ViewStates.Invisible;
            if (muti_linearLayout.Visibility == ViewStates.Invisible)
                muti_linearLayout.Visibility = ViewStates.Visible;
            else
                muti_linearLayout.Visibility = ViewStates.Invisible;
        }

        private void EndTestBtn_Click(object sender, EventArgs e)
        {
            choiceC.Visibility = ViewStates.Invisible;
            choiceD.Visibility = ViewStates.Invisible;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            string[] answer = { "我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案我是正答案" };
            ListView answerListView = FindViewById <ListView>(Resource.Id.AnswerListView);
            ArrayAdapter<string> adp = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, answer);
            answerListView.Adapter = adp;
        }

        private void setSingleCheck()
        {
            
        }

        private void setChoiceEvent()
        {
            choiceA.Click += SingleCheck;
            choiceB.Click += SingleCheck;
            choiceC.Click += SingleCheck;
            choiceD.Click += SingleCheck;
        }

        private void SingleCheck(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            choiceA.Checked = choiceA.Text.Equals(radioButton.Text);
            choiceB.Checked = choiceB.Text.Equals(radioButton.Text);
            choiceC.Checked = choiceC.Text.Equals(radioButton.Text);
            choiceD.Checked = choiceD.Text.Equals(radioButton.Text);
        }
    }
}