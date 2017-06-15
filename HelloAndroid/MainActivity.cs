using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace HelloAndroid
{
    [Activity(Label = "HelloAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private AlertDialog alertDialog = null;  
        private AlertDialog.Builder builder = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get the UI controls from the loaded layout:
            Button questionLabButton = FindViewById<Button>(Resource.Id.QuestionLabButton);
            Button testButton = FindViewById<Button>(Resource.Id.TestButton);

            //Load DataBase
            
            string dbPath = FileAccessHelper.GetLocalFilePath("Question.db3");
            

            questionLabButton.Click += (object sender, EventArgs e) =>
            {
                alertDialog = null;
                builder = new AlertDialog.Builder(this);
                alertDialog = builder
                  .SetTitle("提示")
                   .SetMessage("功能暂时没有开放！")
                   .SetPositiveButton("sure", (s, ev) =>
                  {
                      Toast.MakeText(this, "you click sure", ToastLength.Short).Show();
                  })
                   .Create();       //创建alertDialog对象  

                alertDialog.Show();
                var dialog = new AlertDialog.Builder(this);

            };

            testButton.Click += (object sender, EventArgs e) =>
              {
                  //jump the test page
                  Intent intent = new Intent(this,typeof(QuestionsActivity));
                  StartActivity(intent);
              };
        }
    }
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbPath = System.IO.Path.Combine(path, filename);
            System.IO.File.Delete(dbPath);
            CopyDataBaseIfNotExists(dbPath);
            return dbPath;
        }

        private static void CopyDataBaseIfNotExists(string dbPaht)
        {
            if(!System.IO.File.Exists(dbPaht))
            {
                using (var br = new System.IO.BinaryReader(Application.Context.Assets.Open("Question.db3")))
                {
                    using (var bw = new System.IO.BinaryWriter(new System.IO.FileStream(dbPaht, System.IO.FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int lenght = 0;
                        while ((lenght = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, lenght);
                        }
                    }
                }
            }
        }
    }
}

