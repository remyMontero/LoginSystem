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

namespace LoginSystem
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mFirstName;
        private string mEmail;
        private string mPassword;

        public OnSignUpEventArgs(string firstName, string email, string password) 
            : base()
        {
            this.FirstName = firstName;
            this.Email = email;
            this.Password = password;
        }
        public string FirstName
        {
            get {return mFirstName;}
            set { mFirstName = value; }
        }

        public string Email
        {
            get {return mEmail;}
            set {mEmail = value;}
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

    }
    public class dialog_SignUp : DialogFragment
    {
        private EditText mTxtFirstName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private Button mbtnSignUp;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            //Create the view
            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);
            mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mbtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            mbtnSignUp.Click += (object sender, EventArgs e) =>
                {
                    //Broadcast the event
                    //Invoke is an event
                    mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTxtFirstName.Text, mTxtEmail.Text, mTxtPassword.Text));
                    this.Dismiss();
                };
            return view;
        }

        //When is created do this first
        public override void OnActivityCreated(Bundle savedInstanceState)
        {            
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);//WIll remove title
            base.OnActivityCreated(savedInstanceState);//Call base clase
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}