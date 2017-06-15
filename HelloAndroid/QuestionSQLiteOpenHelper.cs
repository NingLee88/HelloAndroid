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
using Android.Database.Sqlite;
using Android.Database;

namespace HelloAndroid
{
    public class QuestionSQLiteOpenHelper : SQLiteOpenHelper
    {
        public QuestionSQLiteOpenHelper(Context context):base(context,"Question.db3",null,1)
        {

        }
        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL("CREATE TABLE 'TBQuestion'('QTitle'  TEXT(1000) NOT NULL,'QOptions'  TEXT(2000) NOT NULL,'QType'  INTEGER NOT NULL DEFAULT 1,'QAnswer'  TEXT(1) NOT NULL,'QDescription'  TEXT(4000) NOT NULL,'QChapter'  TEXT(40) NOT NULL)");

        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS TBQuestion");
            OnCreate(db);
        }
    }
}