﻿using Firebase.Database;
using Firebase.Storage;
using Plugin.FirebasePushNotification;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using ZeitPlan.LoginSystem;
using ZeitPlan.Models;
using ZeitPlan.Views.Admin;
using ZeitPlan.Views.Student;
using ZeitPlan.Views.Teacher;

namespace ZeitPlan
{
    public partial class App : Application
    {
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbZeitPlan.db3");
        public static SQLiteConnection db = new SQLiteConnection(dbPath);

        //Firebase Connections  ======================================
        public static FirebaseStorage FirebaseStorage = new FirebaseStorage("zeitplan-1fc20.appspot.com");

        public static FirebaseClient firebaseDatabase = new FirebaseClient("https://zeitplan-1fc20-default-rtdb.firebaseio.com/");

        public static TBL_TEACHER LoggedInUser = null;
        public static TBL_STUDENT LoggedInStudent = null;
        public static users LoggedInAdmin = null;

       

        public static string Data { get; set; }
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "MediaElement_Experimental", "Brush_Experimental" });
          
            MainPage = new SplashScreen();

         
        }




        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
