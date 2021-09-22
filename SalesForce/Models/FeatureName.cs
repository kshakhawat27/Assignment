using System;
using System.ComponentModel.DataAnnotations;

namespace SalesForce.Models
{
    public class FeatureName
    {
        public class AdmUserEntity
        {
            public int SL
            {
                get;
                set;
            }
            public string Id
            {
                get;
                set;
            }

            public string UserName
            {
                get;
                set;
            }

            public string Dob
            {
                get;
                set;
            }

            public string Gender
            {
                get;
                set;
            }

            public string JoiningDate
            {
                get;
                set;
            }

            public string ContactNo
            {
                get;
                set;
            }
            public string Email
            {
                get;
                set;
            }

            public string UserId
            {
                get;
                set;
            }
            public string UserPassword
            {
                get;
                set;
            }


            public string CreatedBy
            {
                get;
                set;
            }
            public string CreatedDate
            {
                get;
                set;
            }
            public string UpdatedBy
            {
                get;
                set;
            }
            public string UpdatedDate
            {
                get;
                set;
            }

            public string DataLists { get; set; }
            public string UserDept { get; set; }
            public string UserDesig { get; set; }
            public string UserTLeader { get; set; }
            public string isManager { get; set; }
            public string isHod { get; set; }
            public string isPMG { get; set; }
            public string isSelected { get; set; }
            public string BranchId { get; set; }
            public string ProductPermission { get; set; }


            //public string RegUserId
            //{
            //	get;
            //	set;
            //}

            //      public string EmployeeType
            //      {
            //          get;
            //          set;
            //      }


            //      public string UserPassword
            //{
            //	get;
            //	set;
            //}
            //public string Confirmpass
            //{
            //	get;
            //	set;
            //}
            //public string Usertype
            //{
            //	get;
            //	set;
            //}

            //      public string EmpID
            //      {
            //          get;
            //          set;
            //      }



            //      public string FatherName
            //      {
            //          get;
            //          set;
            //      }


            //      public string MotherName
            //      {
            //          get;
            //          set;
            //      }

            //      public string CostCenter
            //      {
            //          get;
            //          set;
            //      }

            //      public string Company
            //      {
            //          get;
            //          set;
            //      }

            //      public string Department
            //      {
            //          get;
            //          set;
            //      }


            //      public string Designation
            //      {
            //          get;
            //          set;
            //      }

            //public string Departmentid
            //{
            //    get;
            //    set;
            //}
            //public string DeptName
            //{
            //    get;
            //    set;
            //}
            //public string CompanyID
            //{
            //    get;
            //    set;
            //}
            //public string EmployeeTypeId
            //{
            //    get;
            //    set;
            //}

            //public string ActiveUser { get; set; }
        }
        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
        public string FeatureURL
        {
            get;
            set;
        }
        public string CurrentPageStatus
        {
            get;
            set;
        }

        public string ControlerName { get; set; }
    }

    public class AutoComplete
    {
        public string id { get; set; }
        public string label { get; set; }
        public string UnitName { get; set; }
    }
    public class LoginModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }



        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }

    public class SystemContact
    {
        public virtual string Id { get; set; }

        public virtual string Role { get; set; }
        public virtual string EmpId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string CompanyAddress { get; set; }
        public virtual string UserType { get; set; }
        public virtual SystemUser User { get; set; }
    }

    public class SystemUser
    {
        public virtual string Id { get; set; }
        public virtual string Role { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual int PrivilegeLevel { get; set; }
        public virtual bool IsSuspended { get; set; }
        public virtual Guid CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual Guid UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}