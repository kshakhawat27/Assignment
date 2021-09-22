using System;

namespace SalesForce.Domain.Admin
{
    public class AdmUserpermissionEntity
	{
		public string Id
		{
			get;
			set;
		}
        public int Role
        {
            get;
            set;
        }
        public int SL
        {
            get;
            set;
        }
        
        public string GuidUserId
        {
            get;
            set;
        }

        public string status
        {
            get;
            set;
        }

		public string Subfeatureid
		{
			get;
			set;
		}
		public string Accesslevel
		{
			get;
			set;
		}

        public String EmpID
        {
            get;
            set;
        }

        public string UserName
        {
            get;set;
        }

        public string FatherName
        {
            get;
            set;
        }

        public string MotherName
        {
            get;
            set;
        }

        public string CostCenter
        {
            get;
            set;
        }

        public string Company
        {
            get;
            set;
        }

        public string Department
        {
            get;
            set;
        }

        public string Designation
        {
            get;
            set;
        }

        public string ModuleName
        {
            get;
            set;
        }

        public string TabName
        {
            get;
            set;
        }

        public string SubFeature
        {
            get;
            set;
        }

		public string Createdby
		{
			get;
			set;
		}
		public string Createddate
		{
			get;
			set;
		}
		public string Updateby
		{
			get;
			set;
		}

        public bool GetAllAdmUserpermissionRecord
        {
            get;
            set;
        }

        public bool GetAllAdmUserpermissionDetail
        {
            get;
            set;
        }

        public bool GetAllAdmUserpermissionDetail_UserWise
        {
            get;
            set;

        }

        public bool UserLogon
        {
            get;
            set;

        }

        public string password
        {
            get;
            set;
        }
		public string Updatedate
		{
			get;
			set;
		}

        public bool PermittedModule
        {
            get;
            set;

        }

        public bool isAdmin
        {
            get;
            set;

        }

        public string TabId
        {
            get;
            set;
        }

        public string newPassword
        {
            get;
            set;
        }

        public bool passwordChange
        {
            get;
            set;
        }

        public bool GetUserNotification { get; set; }
	    public string Userid { get; set; }
	}
}

