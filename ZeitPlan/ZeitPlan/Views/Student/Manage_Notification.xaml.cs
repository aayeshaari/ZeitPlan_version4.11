﻿using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeitPlan.View_Model;

namespace ZeitPlan.Views.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Manage_Notification : ContentPage
    {
        public Manage_Notification()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                LoadingInd.IsRunning = true;
                LoadData();
                LoadingInd.IsRunning = false;
            }
            catch (Exception ex)
            {
                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong, please  try again later" + ex.Message, "ok");
                return;
            }


        }

        async void LoadData()
        {
            LoadingInd.IsRunning = true;
            DataList.ItemsSource = (await App.firebaseDatabase.Child("TBL_NOTICEBOARD").OnceAsync<TBL_NOTICEBOARD>()).Select(x => new TBL_NOTICEBOARD
            {
                NITI_IMAGE = x.Object.NITI_IMAGE,
                NOTI_DATE = x.Object.NOTI_DATE,
                NOTI_ID = x.Object.NOTI_ID,
                NOTI_PRIORITY = x.Object.NOTI_PRIORITY,
                NOTI_STATUS = x.Object.NOTI_STATUS,
                NOTI_TEXT = x.Object.NOTI_TEXT,
                NOTI_TIME = x.Object.NOTI_TIME,
                NOTI_TO = x.Object.NOTI_TO,


            }).Where(x => x.NOTI_TO == "Students" || x.NOTI_TO=="All").OrderBy(x => x.NOTI_DATE).ThenBy(x => x.NOTI_TIME).ToList();
            LoadingInd.IsRunning = false;
        }


        private async void DataList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = e.Item as TBL_NOTICEBOARD;

            var item = (await App.firebaseDatabase.Child("TBL_NOTICEBOARD").OnceAsync<TBL_NOTICEBOARD>()).FirstOrDefault(a => a.Object.NOTI_ID == selected.NOTI_ID);

            var choice = await DisplayActionSheet("Options", "Close", "View");
            if (choice == "View")
            {

                await Navigation.PushAsync(new Notification_Details(selected));

            }
          
        }


    }
}
