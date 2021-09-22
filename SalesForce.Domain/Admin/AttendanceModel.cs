using System;


namespace SalesForce.Domain.Admin
{
	public class AttendanceModel
	{
		public string Id
		{
			get;
			set;
		}
		public string Employeeid
		{
			get;
			set;
		}
		public string Startdatetime
		{
			get;
			set;
		}
		public string Enddatetime
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

       
            public string flag
        {
            get;
            set;
        }
    }
}

